using System;
using System.Collections.Generic;
using System.Text;
using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.Messaging;
using ABB.Robotics.Controllers.Discovery;
using System.Windows.Forms;
using System.Drawing;
using System.Timers;

namespace Robot_Drawing_Interface
{
    class RobotConnection
    {
        private ControllerInfoCollection connectedControllers;
        private Controller currentController;
        private IpcQueue robotsMessageQueue;
        private IpcQueue myMessageQueue;
        private bool connected = false;
        private bool runningRAPID = false;

        private Form SelectionForm = new Form();
        private ListView controllerListView = new ListView();
        private Button connectButton = new Button();
        private Button refreshButton = new Button();
        private Button cancelButton = new Button();

        Form OutgoingMessageForm;
        TextBox OutgoingMessageFormTextbox;
        private List<string> outgoingMessageList = new List<string>();

        System.Timers.Timer timer = new System.Timers.Timer(100);
        public event EventHandler ConnectedToTheController;
        public event EventHandler DisconnectedFromTheController;
        public event EventHandler StartedRunningRAPID;
        public event EventHandler StoppedRunningRAPID;

        public bool Connected
        {
            get
            {
                return connected;
            }
        }

        public bool RunningRAPID
        {
            get
            {
                return runningRAPID;
            }
        }

        public RobotConnection()
        {
            SelectionForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            SelectionForm.Text = "Connect to a controller";
            SelectionForm.Size = new Size(1007, 408);
            SelectionForm.MinimizeBox = false;
            SelectionForm.MaximizeBox = false;
            SelectionForm.StartPosition = FormStartPosition.CenterParent;

            controllerListView.Location = new Point(10, 10);
            controllerListView.Size = new Size(970, 310);
            controllerListView.GridLines = true;
            controllerListView.FullRowSelect = true;
            controllerListView.MultiSelect = false;
            controllerListView.View = View.Details;

            controllerListView.Columns.Add("ipAdress", "IP Adress", 120);
            controllerListView.Columns.Add("robotware", "Robotware version", 185);
            controllerListView.Columns.Add("controllerName", "Name", 120);
            controllerListView.Columns.Add("id", "Controller ID", 120);
            controllerListView.Columns.Add("availability", "Available", 120);
            controllerListView.Columns.Add("isVirtual", "Virtual", 120);
            controllerListView.Columns.Add("systemName", "System Name", 181);

            connectButton.Location = new Point(660, 330);
            connectButton.Size = new Size(100, 30);
            connectButton.Text = "Connect";
            connectButton.Enabled = false;
            connectButton.Click += new EventHandler(ConnectButton_Click);

            refreshButton.Location = new Point(770, 330);
            refreshButton.Size = new Size(100, 30);
            refreshButton.Text = "Refresh";
            refreshButton.Click += new EventHandler(RefreshButton_Click);

            cancelButton.Location = new Point(880, 330);
            cancelButton.Size = new Size(100, 30);
            cancelButton.Text = "Cancel";
            cancelButton.Click += new EventHandler(CancelButton_Click);

            SelectionForm.Controls.Add(controllerListView);
            SelectionForm.Controls.Add(connectButton);
            SelectionForm.Controls.Add(refreshButton);
            SelectionForm.Controls.Add(cancelButton);
        }

        public void SetupController()
        {
            if (currentController == null)
            {
                RefreshConnectedList();
                SelectionForm.ShowDialog();
            }
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (connectedControllers.Count != 0)
            {
                if (controllerListView.SelectedItems.Count == 0)
                {
                    ConnectSelected(connectedControllers[0].SystemId);
                }
                else
                {
                    ConnectSelected(connectedControllers[controllerListView.SelectedIndices[0]].SystemId);
                }
                timer.Start();
                timer.Elapsed += OnTimedEvent;
                timer.AutoReset = true;
                SelectionForm.Close();
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshConnectedList();
        }

        private void RefreshConnectedList()
        {
            NetworkScanner networkScanner = new NetworkScanner();
            networkScanner.Scan();
            connectedControllers = networkScanner.Controllers;

            if (connectedControllers.Count != 0)
            {
                connectButton.Enabled = true;
            }
            else
            {
                connectButton.Enabled = false;
            }

            ListViewItem item = null;
            controllerListView.Items.Clear();
            foreach (ControllerInfo controllerInfo in connectedControllers)
            {
                item = new ListViewItem(controllerInfo.IPAddress.ToString());
                item.SubItems.Add(controllerInfo.Version.ToString());
                item.SubItems.Add(controllerInfo.ControllerName);
                item.SubItems.Add(controllerInfo.Id);
                item.SubItems.Add(controllerInfo.Availability.ToString());
                item.SubItems.Add(controllerInfo.IsVirtual.ToString());
                item.SubItems.Add(controllerInfo.SystemName);
                controllerListView.Items.Add(item);
                item.Tag = controllerInfo;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            SelectionForm.Close();
        }

        private void ConnectSelected(Guid selectedControllerId)
        {
            currentController = new Controller(selectedControllerId);
            robotsMessageQueue = currentController.Ipc.GetQueue("RMQ_T_ROB1");
            if (!currentController.Ipc.Exists("PC_SDK_Q"))
            {
                myMessageQueue = currentController.Ipc.CreateQueue("PC_SDK_Q", 50, Ipc.IPC_MAXMSGSIZE);
            }
            else
            {
                myMessageQueue = currentController.Ipc.GetQueue("PC_SDK_Q");
            }
        }

        public void Disconnect()
        {
            if (currentController != null)
            {
                if (myMessageQueue != null)
                {
                    currentController.Ipc.DeleteQueue(myMessageQueue.QueueId);
                    myMessageQueue = null;
                }
                currentController.Logoff();
                currentController.Dispose();
                currentController = null;
            }
            timer.AutoReset = false;
        }

        public void SendMessage(bool boolMsg)
        {
            if (IsRunningRAPID())
            {
                IpcMessage outgoingMessage = new IpcMessage();
                Byte[] dataToSend = null;

                if (boolMsg)
                {
                    dataToSend = new UTF8Encoding().GetBytes("bool;TRUE");
                }
                else
                {
                    dataToSend = new UTF8Encoding().GetBytes("bool;FALSE");
                }

                outgoingMessage.SetData(dataToSend);
                outgoingMessage.Sender = myMessageQueue.QueueId;
                robotsMessageQueue.Send(outgoingMessage);
            }
            else
            {
                throw new Exception("RAPID program is stopped");
            }
}

        public void SendMessage(string stringMsg)
        {
            if (IsRunningRAPID())
            {
                IpcMessage outgoingMessage = new IpcMessage();
                Byte[] dataToSend = null;

                dataToSend = new UTF8Encoding().GetBytes("string;\"" + stringMsg + "\"");

                outgoingMessage.SetData(dataToSend);
                outgoingMessage.Sender = myMessageQueue.QueueId;
                robotsMessageQueue.Send(outgoingMessage);

                SaveOutgoingMessage("string;\"" + stringMsg + "\"" + Environment.NewLine);
            }
            else
            {
                throw new Exception("RAPID program is stopped");
            }
        }

        public void SendMessage(ABB.Robotics.Controllers.RapidDomain.Pos targetPos)
        {
            if (IsRunningRAPID())
            {
                IpcMessage outgoingMessage = new IpcMessage();
                Byte[] dataToSend = null;

                dataToSend = new UTF8Encoding().GetBytes("pos;" + targetPos);

                outgoingMessage.SetData(dataToSend);
                outgoingMessage.Sender = myMessageQueue.QueueId;
                robotsMessageQueue.Send(outgoingMessage);

                SaveOutgoingMessage("pos; " + targetPos.X + " " + targetPos.Y + " " + targetPos.Z + Environment.NewLine);
            }
            else
            {
                throw new Exception("RAPID program is stopped");
            }
        }

        private bool IsControllerConnected()
        {
            if (currentController != null && currentController.Connected == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsRunningRAPID()
        {
            if (currentController.Rapid.ExecutionStatus == ABB.Robotics.Controllers.RapidDomain.ExecutionStatus.Running)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ShowMessageLog()
        {
            OutgoingMessageForm = new Form();
            OutgoingMessageFormTextbox = new TextBox();

            OutgoingMessageForm.Text = "Outgoing message log";
            OutgoingMessageForm.Size = new Size(400, 800);
            OutgoingMessageForm.MinimumSize = new Size(300, 300);

            OutgoingMessageFormTextbox.Multiline = true;
            OutgoingMessageFormTextbox.ScrollBars = ScrollBars.Vertical;
            OutgoingMessageFormTextbox.Dock = DockStyle.Fill;
            OutgoingMessageFormTextbox.ReadOnly = true;
            for(int i = 0; i < outgoingMessageList.Count; i++)
            {
                OutgoingMessageFormTextbox.Text += outgoingMessageList[i];
            }

            OutgoingMessageForm.Controls.Add(OutgoingMessageFormTextbox);

            OutgoingMessageForm.Show();
            OutgoingMessageFormTextbox.Select(0, 0);
        }

        private void SaveOutgoingMessage(string message)
        {
            outgoingMessageList.Add(message);
            if(outgoingMessageList.Count >= 1000)
            {
                outgoingMessageList.RemoveAt(0);
            }
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if(connected != IsControllerConnected())
            {
                if(IsControllerConnected())
                {
                    connected = true;
                    OnConnectedToTheController(new EventArgs());
                }
                else
                {
                    connected = false;
                    runningRAPID = false;
                    OnDisconnectedFromTheController(new EventArgs());
                    OnStoppedRunningRAPID(new EventArgs());
                }
            }

            if (connected)
            {
                if (runningRAPID != IsRunningRAPID())
                {
                    if (IsRunningRAPID())
                    {
                        runningRAPID = true;
                        OnStartedRunningRAPID(new EventArgs());
                    }
                    else
                    {
                        runningRAPID = false;
                        OnStoppedRunningRAPID(new EventArgs());
                    }
                }
            }
            else
            {
                runningRAPID = false;
            }
        }

        protected virtual void OnConnectedToTheController(EventArgs e)
        {
            ConnectedToTheController(this, e);
        }

        protected virtual void OnDisconnectedFromTheController(EventArgs e)
        {
            DisconnectedFromTheController(this, e);
        }

        protected virtual void OnStartedRunningRAPID(EventArgs e)
        {
            StartedRunningRAPID(this, e);
        }

        protected virtual void OnStoppedRunningRAPID(EventArgs e)
        {
            StoppedRunningRAPID(this, e);
        }
    }
}
