using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ABB.Robotics.Controllers.RapidDomain;

namespace Robot_Drawing_Interface
{
    public partial class Form1 : Form
    {
        private RobotConnection robot = new RobotConnection();

        private Form SurfaceSetupForm = new Form();
        private Label label_surface_setup_1 = new Label();
        private Label label_surface_setup_2 = new Label();
        private Label label_surface_setup_3 = new Label();
        private Label label_surface_setup_4 = new Label();
        private Label label_surface_setup_5 = new Label();
        private Label label_surface_setup_6 = new Label();
        private Label label_surface_setup_7 = new Label();
        private TextBox textbox_f_w = new TextBox();
        private TextBox textbox_f_h = new TextBox();
        private TextBox textbox_c_b_h = new TextBox();
        private TextBox textbox_c_t_h = new TextBox();
        private TextBox textbox_c_r = new TextBox();
        private TextBox textbox_c_x = new TextBox();
        private TextBox textbox_c_y = new TextBox();
        private Button button_accept = new Button();
        private Button button_cancel = new Button();

        private LinkLabel linkLabel1 = new LinkLabel();
        private LinkLabel linkLabel2 = new LinkLabel();

        private bool writeOnFlat = true;
        private bool writeOnCylinder = false;

        private int flatSurfaceWidth = 600;
        private int flatSurfaceHeight = 150;
        private int currentSurfaceWidth = 600;
        private int currentSurfaceHeight = 150;
        private float pictureBoxX;
        private float pictureBoxY;
        private bool drawing = false;
        private Point cylinderPosition = new Point(150, 75);
        private int cylinderBottomHeight = 40;
        private int cylinderTopHeight = 140;
        private int cylinderRadius = 47;

        private Trajectory currentTrajectory;
        private Trajectory fullTrajectory;

        private int graphicsMultiplyer = 5;
        private float imageScale;
        private PointF firstPoint = new PointF(0, 0);
        private PointF secondPoint = new PointF(0, 0);
        private PointF centerPoint = new PointF(0, 0);
        private PointF originPoint = new PointF(0, 0);
        private float radius = 0;
        private int textRotation = 0;

        delegate void ConnectedToTheControllerUpdateGUICallback();
        delegate void DisconnectedFromTheControllerUpdateGUICallback();
        delegate void StartedRunningRAPIDUpdateGUICallback();
        delegate void StoppedRunningRAPIDUpdateGUICallback();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox.BackgroundImageLayout = ImageLayout.Zoom;

            textBox_text.Size = new Size(300, 20);
            label_fp.Visible = false;
            label_fp_x.Visible = false;
            label_fp_y.Visible = false;
            textBox_fp_x.Visible = false;
            textBox_fp_y.Visible = false;
            label_sp.Visible = false;
            label_sp_x.Visible = false;
            label_sp_y.Visible = false;
            textBox_sp_x.Visible = false;
            textBox_sp_y.Visible = false;
            label_cp.Visible = false;
            label_cp_x.Visible = false;
            label_cp_y.Visible = false;
            textBox_cp_x.Visible = false;
            textBox_cp_y.Visible = false;
            label_radius.Visible = false;
            textBox_radius.Visible = false;
            toolStripStatusLabel1.Visible = false;
            toolStripStatusLabel2.Visible = false;
            toolStripStatusLabel3.Visible = false;
            toolStripStatusLabel_x.Visible = false;
            toolStripStatusLabel_y.Visible = false;
            toolStripProgressBarSend.Visible = false;
            toolStripProgressBarSend.Visible = false;

            fullTrajectory = new Trajectory(new Size(currentSurfaceWidth, currentSurfaceHeight));
            currentTrajectory = new Trajectory(new Size(currentSurfaceWidth, currentSurfaceHeight));

            redrawGraphics(true);

            robot.ConnectedToTheController += OnConnectedToTheController;
            robot.DisconnectedFromTheController += OnDisconnectedFromTheController;
            robot.StartedRunningRAPID += OnStartedRunnigRAPID;
            robot.StoppedRunningRAPID += OnStoppedRunnigRAPID;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {

        }

        private Bitmap ToBitmap(Trajectory traj, Pen pen)
        {
            Bitmap btm = new Bitmap(traj.Width * graphicsMultiplyer + 1, traj.Height * graphicsMultiplyer + 1);
            Graphics grph = Graphics.FromImage(btm);

            for (int i = 0; i < traj.Count - 1; i++)
            {
                if (traj.PointTypes[i] != 2)
                {
                    grph.DrawLine(pen, new PointF(traj.Points[i].X * graphicsMultiplyer, traj.Points[i].Y * graphicsMultiplyer), 
                        new PointF(traj.Points[i + 1].X * graphicsMultiplyer, traj.Points[i + 1].Y * graphicsMultiplyer));
                }
            }
            return btm;
        }

        private Bitmap ToBitmap(Trajectory traj, Pen pen, Brush brush)
        {
            Bitmap btm = new Bitmap(traj.Width * graphicsMultiplyer + 1, traj.Height * graphicsMultiplyer + 1);
            Graphics grph = Graphics.FromImage(btm);

            grph.FillRectangle(brush, new Rectangle(0, 0, traj.Width * graphicsMultiplyer - 1, traj.Height * graphicsMultiplyer - 1));

            for (int i = 0; i < traj.Count - 1; i++)
            {
                if (traj.PointTypes[i] != 2)
                {
                    grph.DrawLine(pen, new PointF(traj.Points[i].X * graphicsMultiplyer, traj.Points[i].Y * graphicsMultiplyer),
                        new PointF(traj.Points[i + 1].X * graphicsMultiplyer, traj.Points[i + 1].Y * graphicsMultiplyer));
                }
            }
            return btm;
        }

        private void updateCurrentTrajectory()
        {
            currentTrajectory.Reset();
            if (radioButton_line.Checked)
            {
                currentTrajectory.AddLine(firstPoint, secondPoint);
            }
            else if (radioButton_rectangle.Checked)
            {
                currentTrajectory.AddRectangle(firstPoint, secondPoint);
            }
            else if (radioButton_circle.Checked)
            {
                currentTrajectory.AddCircle(centerPoint, radius);
            }
            else if (radioButton_text.Checked)
            {
                currentTrajectory.AddString(textBox_text.Text, fontDialog.Font, originPoint, textRotation);
            }

            pictureBox.Image = ToBitmap(currentTrajectory, Pens.Red);
        }

        private void redrawGraphics(bool fullChanged)
        {
            pictureBox.Image = ToBitmap(currentTrajectory, Pens.Red);
            if (fullChanged)
            {
                pictureBox.BackgroundImage = ToBitmap(fullTrajectory, Pens.Black, Brushes.White);
            }
        }

        private void setupGraphics()
        {
            if (writeOnFlat)
            {
                currentSurfaceWidth = flatSurfaceWidth;
                currentSurfaceHeight = flatSurfaceHeight;
            }
            else if (writeOnCylinder)
            {
                currentSurfaceWidth = (int)(2 * Math.PI * cylinderRadius);
                currentSurfaceHeight = cylinderTopHeight - cylinderBottomHeight;
            }

            currentTrajectory.Reset();
            fullTrajectory.Reset();

            currentTrajectory.Width = currentSurfaceWidth;
            currentTrajectory.Height = currentSurfaceHeight;
            fullTrajectory.Width = currentSurfaceWidth;
            fullTrajectory.Height = currentSurfaceHeight;
        }

        private void radioButton_text_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_text.Checked)
            {
                label_fp.Visible = false;
                label_fp_x.Visible = false;
                label_fp_y.Visible = false;
                textBox_fp_x.Visible = false;
                textBox_fp_y.Visible = false;

                label_sp.Visible = false;
                label_sp_x.Visible = false;
                label_sp_y.Visible = false;
                textBox_sp_x.Visible = false;
                textBox_sp_y.Visible = false;

                label_cp.Visible = false;
                label_cp_x.Visible = false;
                label_cp_y.Visible = false;
                textBox_cp_x.Visible = false;
                textBox_cp_y.Visible = false;

                label_radius.Visible = false;
                textBox_radius.Visible = false;

                label_text.Visible = true;
                textBox_text.Visible = true;
                button_font.Visible = true;
                label_op.Visible = true;
                label_op_x.Visible = true;
                label_op_y.Visible = true;
                textBox_op_x.Visible = true;
                textBox_op_y.Visible = true;
                label_text_rotation.Visible = true;
                numericUpDown_text_rotation.Visible = true;
            }
            else if(!radioButton_text.Checked)
            {
                textBox_text.Text = "";
                currentTrajectory.Reset();
                redrawGraphics(false);
            }
        }

        private void radioButton_line_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_line.Checked)
            {
                label_fp.Visible = true;
                label_fp_x.Visible = true;
                label_fp_y.Visible = true;
                textBox_fp_x.Visible = true;
                textBox_fp_y.Visible = true;

                label_sp.Visible = true;
                label_sp_x.Visible = true;
                label_sp_y.Visible = true;
                textBox_sp_x.Visible = true;
                textBox_sp_y.Visible = true;

                label_cp.Visible = false;
                label_cp_x.Visible = false;
                label_cp_y.Visible = false;
                textBox_cp_x.Visible = false;
                textBox_cp_y.Visible = false;

                label_radius.Visible = false;
                textBox_radius.Visible = false;

                label_text.Visible = false;
                textBox_text.Visible = false;
                button_font.Visible = false;
                label_op.Visible = false;
                label_op_x.Visible = false;
                label_op_y.Visible = false;
                textBox_op_x.Visible = false;
                textBox_op_y.Visible = false;
                label_text_rotation.Visible = false;
                numericUpDown_text_rotation.Visible = false;
            }
            else if (!radioButton_line.Checked)
            {
                textBox_fp_x.Text = "0";
                textBox_fp_y.Text = "0";
                textBox_sp_x.Text = "0";
                textBox_sp_y.Text = "0";
                currentTrajectory.Reset();
                redrawGraphics(false);
            }
        }

        private void radioButton_rectangle_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_rectangle.Checked)
            {
                label_fp.Visible = true;
                label_fp_x.Visible = true;
                label_fp_y.Visible = true;
                textBox_fp_x.Visible = true;
                textBox_fp_y.Visible = true;

                label_sp.Visible = true;
                label_sp_x.Visible = true;
                label_sp_y.Visible = true;
                textBox_sp_x.Visible = true;
                textBox_sp_y.Visible = true;

                label_cp.Visible = false;
                label_cp_x.Visible = false;
                label_cp_y.Visible = false;
                textBox_cp_x.Visible = false;
                textBox_cp_y.Visible = false;

                label_radius.Visible = false;
                textBox_radius.Visible = false;

                label_text.Visible = false;
                textBox_text.Visible = false;
                button_font.Visible = false;
                label_op.Visible = false;
                label_op_x.Visible = false;
                label_op_y.Visible = false;
                textBox_op_x.Visible = false;
                textBox_op_y.Visible = false;
                label_text_rotation.Visible = false;
                numericUpDown_text_rotation.Visible = false;
            }
            else if (!radioButton_rectangle.Checked)
            {
                textBox_fp_x.Text = "0";
                textBox_fp_y.Text = "0";
                textBox_sp_x.Text = "0";
                textBox_sp_y.Text = "0";
                currentTrajectory.Reset();
                redrawGraphics(false);
            }
        }

        private void radioButton_circle_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_circle.Checked)
            {
                label_fp.Visible = false;
                label_fp_x.Visible = false;
                label_fp_y.Visible = false;
                textBox_fp_x.Visible = false;
                textBox_fp_y.Visible = false;

                label_sp.Visible = false;
                label_sp_x.Visible = false;
                label_sp_y.Visible = false;
                textBox_sp_x.Visible = false;
                textBox_sp_y.Visible = false;

                label_cp.Visible = true;
                label_cp_x.Visible = true;
                label_cp_y.Visible = true;
                textBox_cp_x.Visible = true;
                textBox_cp_y.Visible = true;

                label_radius.Visible = true;
                textBox_radius.Visible = true;

                label_text.Visible = false;
                textBox_text.Visible = false;
                button_font.Visible = false;
                label_op.Visible = false;
                label_op_x.Visible = false;
                label_op_y.Visible = false;
                textBox_op_x.Visible = false;
                textBox_op_y.Visible = false;
                label_text_rotation.Visible = false;
                numericUpDown_text_rotation.Visible = false;
            }
            else if (!radioButton_circle.Checked)
            {
                textBox_cp_x.Text = "0";
                textBox_cp_y.Text = "0";
                textBox_radius.Text = "0";
                currentTrajectory.Reset();
                redrawGraphics(false);
            }
        }

        private void radioButton_freehand_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_freehand.Checked)
            {
                label_fp.Visible = false;
                label_fp_x.Visible = false;
                label_fp_y.Visible = false;
                textBox_fp_x.Visible = false;
                textBox_fp_y.Visible = false;

                label_sp.Visible = false;
                label_sp_x.Visible = false;
                label_sp_y.Visible = false;
                textBox_sp_x.Visible = false;
                textBox_sp_y.Visible = false;

                label_cp.Visible = false;
                label_cp_x.Visible = false;
                label_cp_y.Visible = false;
                textBox_cp_x.Visible = false;
                textBox_cp_y.Visible = false;

                label_radius.Visible = false;
                textBox_radius.Visible = false;

                label_text.Visible = false;
                textBox_text.Visible = false;
                button_font.Visible = false;
                label_op.Visible = false;
                label_op_x.Visible = false;
                label_op_y.Visible = false;
                textBox_op_x.Visible = false;
                textBox_op_y.Visible = false;
                label_text_rotation.Visible = false;
                numericUpDown_text_rotation.Visible = false;
            }
            else if (!radioButton_line.Checked)
            {
                currentTrajectory.Reset();
                redrawGraphics(false);
            }
        }

        private void button_add_current_Click(object sender, EventArgs e)
        {
            if (radioButton_line.Checked)
            {
                fullTrajectory.AddLine(firstPoint, secondPoint);
                textBox_fp_x.Text = "0";
                textBox_fp_y.Text = "0";
                textBox_sp_x.Text = "0";
                textBox_sp_y.Text = "0";
            }
            else if (radioButton_rectangle.Checked)
            {
                fullTrajectory.AddRectangle(firstPoint, secondPoint);
                textBox_fp_x.Text = "0";
                textBox_fp_y.Text = "0";
                textBox_sp_x.Text = "0";
                textBox_sp_y.Text = "0";
            }
            else if (radioButton_circle.Checked)
            {
                fullTrajectory.AddCircle(centerPoint, radius);
                textBox_cp_x.Text = "0";
                textBox_cp_y.Text = "0";
                textBox_radius.Text = "0";
            }
            else if (radioButton_text.Checked)
            {
                fullTrajectory.AddString(textBox_text.Text, fontDialog.Font, originPoint, textRotation);
                textBox_text.Text = "";
                textBox_op_x.Text = "0";
                textBox_op_y.Text = "0";
                numericUpDown_text_rotation.Text = "0";
            }
            else if (radioButton_freehand.Checked)
            {
                for(int i = 0; i < currentTrajectory.Count; i++)
                {
                    fullTrajectory.AddPoint(currentTrajectory.Points[i], currentTrajectory.PointTypes[i]);
                }
            }

            currentTrajectory.Reset();
            redrawGraphics(true);
        }

        private void textBox_fp_x_TextChanged(object sender, EventArgs e)
        {
            if (textBox_fp_x.Text != "")
            {
                float value = float.Parse(textBox_fp_x.Text);
                if(value < 0)
                {
                    value = 0;
                    textBox_fp_x.Text = "0";
                }
                else if(value > currentSurfaceWidth)
                {
                    value = currentSurfaceWidth;
                    textBox_fp_x.Text = currentSurfaceWidth.ToString();
                }
                firstPoint.X = value;
            }

            updateCurrentTrajectory();
        }

        private void textBox_fp_y_TextChanged(object sender, EventArgs e)
        {
            if (textBox_fp_y.Text != "")
            {
                float value = float.Parse(textBox_fp_y.Text);
                if (value < 0)
                {
                    value = 0;
                    textBox_fp_y.Text = "0";
                }
                else if (value > currentSurfaceHeight)
                {
                    value = currentSurfaceHeight;
                    textBox_fp_y.Text = currentSurfaceHeight.ToString();
                }
                firstPoint.Y = value;
            }

            updateCurrentTrajectory();
        }

        private void textBox_sp_x_TextChanged(object sender, EventArgs e)
        {
            if (textBox_sp_x.Text != "")
            {
                float value = float.Parse(textBox_sp_x.Text);
                if(value < 0)
                {
                    value = 0;
                    textBox_sp_x.Text = "0";
                }
                else if(value > currentSurfaceWidth)
                {
                    value = currentSurfaceWidth;
                    textBox_sp_x.Text = currentSurfaceWidth.ToString();
                }
                secondPoint.X = value;
            }

            updateCurrentTrajectory();
        }

        private void textBox_sp_y_TextChanged(object sender, EventArgs e)
        {
            if (textBox_sp_y.Text != "")
            {
                float value = float.Parse(textBox_sp_y.Text);
                if (value < 0)
                {
                    value = 0;
                    textBox_sp_y.Text = "0";
                }
                else if (value > currentSurfaceHeight)
                {
                    value = currentSurfaceHeight;
                    textBox_sp_y.Text = currentSurfaceHeight.ToString();
                }
                secondPoint.Y = value;
            }

            updateCurrentTrajectory();
        }

        private void textBox_cp_x_TextChanged(object sender, EventArgs e)
        {
            if (textBox_cp_x.Text != "")
            {
                float value = float.Parse(textBox_cp_x.Text);
                if (value < 0)
                {
                    value = 0;
                    textBox_cp_x.Text = "0";
                }
                else if (value > currentSurfaceWidth)
                {
                    value = currentSurfaceWidth;
                    textBox_cp_x.Text = currentSurfaceWidth.ToString();
                }
                centerPoint.X = value;
            }

            updateCurrentTrajectory();
        }

        private void textBox_cp_y_TextChanged(object sender, EventArgs e)
        {
            if (textBox_cp_y.Text != "")
            {
                float value = float.Parse(textBox_cp_y.Text);
                if (value < 0)
                {
                    value = 0;
                    textBox_cp_y.Text = "0";
                }
                else if (value > currentSurfaceHeight)
                {
                    value = currentSurfaceHeight;
                    textBox_cp_y.Text = currentSurfaceHeight.ToString();
                }
                centerPoint.Y = value;
            }

            updateCurrentTrajectory();
        }

        private void textBox_radius_TextChanged(object sender, EventArgs e)
        {
            if (textBox_radius.Text != "")
            {
                float value = float.Parse(textBox_radius.Text);
                if (value < 0)
                {
                    value = 0;
                    textBox_radius.Text = "0";
                }
                radius = value;
            }

            updateCurrentTrajectory();
        }

        private void textBox_op_x_TextChanged(object sender, EventArgs e)
        {
            if (textBox_op_x.Text != "")
            {
                float value = float.Parse(textBox_op_x.Text);
                if (value < 0)
                {
                    value = 0;
                    textBox_op_x.Text = "0";
                }
                else if (value > currentSurfaceWidth)
                {
                    value = currentSurfaceWidth;
                    textBox_op_x.Text = currentSurfaceWidth.ToString();
                }
                originPoint.X = value;
            }

            updateCurrentTrajectory();
        }

        private void textBox_op_y_TextChanged(object sender, EventArgs e)
        {
            if (textBox_op_y.Text != "")
            {
                float value = float.Parse(textBox_op_y.Text);
                if (value < 0)
                {
                    value = 0;
                    textBox_op_y.Text = "0";
                }
                else if (value > currentSurfaceHeight)
                {
                    value = currentSurfaceHeight;
                    textBox_op_y.Text = currentSurfaceHeight.ToString();
                }
                originPoint.Y = value;
            }

            updateCurrentTrajectory();
        }

        private void numericUpDown_text_rotation_ValueChanged(object sender, EventArgs e)
        {
            if(numericUpDown_text_rotation.Text != "")
            {
                int value = (int)numericUpDown_text_rotation.Value;
                if(value < 0)
                {
                    value += 360;
                }
                textRotation = value;
            }

            updateCurrentTrajectory();
        }

        private void button_reset_full_Click(object sender, EventArgs e)
        {
            fullTrajectory.Reset();
            redrawGraphics(true);
        }

        private void button_font_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                updateCurrentTrajectory();
            }
        }

        private void flatSurfaceSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SurfaceSetupForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            SurfaceSetupForm.Text = "Surfaces";
            SurfaceSetupForm.Size = new Size(240, 290);
            SurfaceSetupForm.MinimizeBox = false;
            SurfaceSetupForm.MaximizeBox = false;
            SurfaceSetupForm.StartPosition = FormStartPosition.CenterParent;

            label_surface_setup_1.Size = new Size(150, 13);
            label_surface_setup_1.Location = new Point(10, 10);
            label_surface_setup_1.Text = "Flat surface width";

            label_surface_setup_2.Size = new Size(150, 13);
            label_surface_setup_2.Location = new Point(10, 40);
            label_surface_setup_2.Text = "Flat surface height";

            label_surface_setup_6.Size = new Size(150, 13);
            label_surface_setup_6.Location = new Point(10, 70);
            label_surface_setup_6.Text = "Cylinder position X";

            label_surface_setup_7.Size = new Size(150, 13);
            label_surface_setup_7.Location = new Point(10, 100);
            label_surface_setup_7.Text = "Cylinder position Y";

            label_surface_setup_3.Size = new Size(150, 13);
            label_surface_setup_3.Location = new Point(10, 130);
            label_surface_setup_3.Text = "Cylinder bottom heiht";

            label_surface_setup_4.Size = new Size(150, 13);
            label_surface_setup_4.Location = new Point(10, 160);
            label_surface_setup_4.Text = "Cylinder top height";

            label_surface_setup_5.Size = new Size(150, 13);
            label_surface_setup_5.Location = new Point(10, 190);
            label_surface_setup_5.Text = "Cylinder radius";

            textbox_f_w.Size = new Size(50, 20);
            textbox_f_w.Location = new Point(160, 10);
            textbox_f_w.Text = flatSurfaceWidth.ToString();
            textbox_f_w.TextChanged += new EventHandler(FlatSuraceSetupTextBox_f_w_Changed);

            textbox_f_h.Size = new Size(50, 20);
            textbox_f_h.Location = new Point(160, 40);
            textbox_f_h.Text = flatSurfaceHeight.ToString();
            textbox_f_h.TextChanged += new EventHandler(FlatSuraceSetupTextBox_f_h_Changed);

            textbox_c_x.Size = new Size(50, 20);
            textbox_c_x.Location = new Point(160, 70);
            textbox_c_x.Text = cylinderPosition.X.ToString();
            textbox_c_x.TextChanged += new EventHandler(FlatSuraceSetupTextBox_c_x_Changed);

            textbox_c_y.Size = new Size(50, 20);
            textbox_c_y.Location = new Point(160, 100);
            textbox_c_y.Text = cylinderPosition.Y.ToString();
            textbox_c_y.TextChanged += new EventHandler(FlatSuraceSetupTextBox_c_y_Changed);

            textbox_c_b_h.Size = new Size(50, 20);
            textbox_c_b_h.Location = new Point(160, 130);
            textbox_c_b_h.Text = cylinderBottomHeight.ToString();
            textbox_c_b_h.TextChanged += new EventHandler(FlatSuraceSetupTextBox_c_b_h_Changed);

            textbox_c_t_h.Size = new Size(50, 20);
            textbox_c_t_h.Location = new Point(160, 160);
            textbox_c_t_h.Text = cylinderTopHeight.ToString();
            textbox_c_t_h.TextChanged += new EventHandler(FlatSuraceSetupTextBox_c_t_h_Changed);

            textbox_c_r.Size = new Size(50, 20);
            textbox_c_r.Location = new Point(160, 190);
            textbox_c_r.Text = cylinderRadius.ToString();
            textbox_c_r.TextChanged += new EventHandler(FlatSuraceSetupTextBox_c_r_Changed);

            button_accept.Size = new Size(100, 23);
            button_accept.Location = new Point(10, 220);
            button_accept.Text = "Accept";
            button_accept.Click += new EventHandler(FlatSurfaceSetupAcceptButtonClick);

            button_cancel.Size = new Size(100, 23);
            button_cancel.Location = new Point(115, 220);
            button_cancel.Text = "Cancel";
            button_cancel.Click += new EventHandler(FlatSurfaceSetupCancelButtonClick);

            SurfaceSetupForm.Controls.Add(label_surface_setup_1);
            SurfaceSetupForm.Controls.Add(label_surface_setup_2);
            SurfaceSetupForm.Controls.Add(label_surface_setup_3);
            SurfaceSetupForm.Controls.Add(label_surface_setup_4);
            SurfaceSetupForm.Controls.Add(label_surface_setup_5);
            SurfaceSetupForm.Controls.Add(label_surface_setup_6);
            SurfaceSetupForm.Controls.Add(label_surface_setup_7);
            SurfaceSetupForm.Controls.Add(textbox_f_w);
            SurfaceSetupForm.Controls.Add(textbox_f_h);
            SurfaceSetupForm.Controls.Add(textbox_c_b_h);
            SurfaceSetupForm.Controls.Add(textbox_c_t_h);
            SurfaceSetupForm.Controls.Add(textbox_c_r);
            SurfaceSetupForm.Controls.Add(textbox_c_x);
            SurfaceSetupForm.Controls.Add(textbox_c_y);
            SurfaceSetupForm.Controls.Add(button_accept);
            SurfaceSetupForm.Controls.Add(button_cancel);

            SurfaceSetupForm.ShowDialog();
        }

        private void FlatSurfaceSetupAcceptButtonClick(object sender, EventArgs e)
        {
            flatSurfaceWidth = int.Parse(textbox_f_w.Text);
            flatSurfaceHeight = int.Parse(textbox_f_h.Text);
            cylinderBottomHeight = int.Parse(textbox_c_b_h.Text);
            cylinderTopHeight = int.Parse(textbox_c_t_h.Text);
            cylinderRadius = int.Parse(textbox_c_r.Text);
            cylinderPosition.X = int.Parse(textbox_c_x.Text);
            cylinderPosition.Y = int.Parse(textbox_c_y.Text);

            if(robot.RunningRAPID)
            {
                UploadSettingsToTheController();
            }

            setupGraphics();
            redrawGraphics(true);
            SurfaceSetupForm.Close();
        }

        private void FlatSurfaceSetupCancelButtonClick(object sender, EventArgs e)
        {
            SurfaceSetupForm.Close();
        }

        private void FlatSuraceSetupTextBox_f_w_Changed(object sender, EventArgs e)
        {
            if (textBox_fp_x.Text != "")
            {
                int value = int.Parse(textbox_f_w.Text);
                if (value < 0)
                {
                    value = 0;
                    textBox_fp_x.Text = "0";
                }

                flatSurfaceWidth = value;
            }
        }

        private void FlatSuraceSetupTextBox_f_h_Changed(object sender, EventArgs e)
        {

        }

        private void FlatSuraceSetupTextBox_c_b_h_Changed(object sender, EventArgs e)
        {

        }

        private void FlatSuraceSetupTextBox_c_t_h_Changed(object sender, EventArgs e)
        {

        }

        private void FlatSuraceSetupTextBox_c_r_Changed(object sender, EventArgs e)
        {

        }

        private void FlatSuraceSetupTextBox_c_x_Changed(object sender, EventArgs e)
        {

        }

        private void FlatSuraceSetupTextBox_c_y_Changed(object sender, EventArgs e)
        {

        }

        private void flatSurfaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flatSurfaceToolStripMenuItem.Checked = true;
            cylinderToolStripMenuItem.Checked = false;
            writeOnFlat = true;
            writeOnCylinder = false;

            button_clean.Visible = true;
            button_target.Visible = true;
            button_center.Visible = true;
            buttonBoundaries.Visible = true;

            setupGraphics();
            redrawGraphics(true);

            if(robot.RunningRAPID)
            {
                UploadSettingsToTheController();
            }
        }

        private void cylinderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flatSurfaceToolStripMenuItem.Checked = false;
            cylinderToolStripMenuItem.Checked = true;
            writeOnFlat = false;
            writeOnCylinder = true;

            button_clean.Visible = false;
            button_target.Visible = false;
            button_center.Visible = false;
            buttonBoundaries.Visible = false;

            setupGraphics();
            redrawGraphics(true);

            if (robot.RunningRAPID)
            {
                UploadSettingsToTheController();
            }
        }

        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Visible = true;
            toolStripStatusLabel2.Visible = true;
            toolStripStatusLabel3.Visible = true;
            toolStripStatusLabel_x.Visible = true;
            toolStripStatusLabel_y.Visible = true;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if(radioButton_line.Checked)
            {
                if(textBox_fp_x.Focused || textBox_fp_y.Focused)
                {
                    textBox_fp_x.Text = pictureBoxX.ToString();
                    textBox_fp_y.Text = pictureBoxY.ToString();
                    textBox_sp_x.Focus();
                }
                else if (textBox_sp_x.Focused || textBox_sp_y.Focused)
                {
                    textBox_sp_x.Text = pictureBoxX.ToString();
                    textBox_sp_y.Text = pictureBoxY.ToString();
                }
            }
            else if (radioButton_rectangle.Checked)
            {
                if (textBox_fp_x.Focused || textBox_fp_y.Focused)
                {
                    textBox_fp_x.Text = pictureBoxX.ToString();
                    textBox_fp_y.Text = pictureBoxY.ToString();
                    textBox_sp_x.Focus();
                }
                else if (textBox_sp_x.Focused || textBox_sp_y.Focused)
                {
                    textBox_sp_x.Text = pictureBoxX.ToString();
                    textBox_sp_y.Text = pictureBoxY.ToString();
                }
            }
            else if (radioButton_circle.Checked)
            {
                if (textBox_cp_x.Focused || textBox_cp_y.Focused)
                {
                    textBox_cp_x.Text = pictureBoxX.ToString();
                    textBox_cp_y.Text = pictureBoxY.ToString();
                }
            }
            else if (radioButton_text.Checked)
            {
                if (textBox_op_x.Focused || textBox_op_y.Focused)
                {
                    textBox_op_x.Text = pictureBoxX.ToString();
                    textBox_op_y.Text = pictureBoxY.ToString();
                }
            }
            else if(radioButton_freehand.Checked)
            {
                drawing = true;
                currentTrajectory.AddPoint(new PointF(pictureBoxX, pictureBoxY), 0);
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            float x, y, imageRealW, imageRealH, scaleFactorW, scaleFactorH, clientW, clientH, bitmapW, bitmapH;

            clientW = pictureBox.ClientSize.Width;
            clientH = pictureBox.ClientSize.Height;
            bitmapW = currentSurfaceWidth;
            bitmapH = currentSurfaceHeight;

            scaleFactorW = clientW / bitmapW;
            scaleFactorH = clientH / bitmapH;

            x = e.Location.X;
            y = e.Location.Y;

            if (scaleFactorW < scaleFactorH)
            {
                imageScale = scaleFactorW;
                imageRealW = clientW;
                imageRealH = bitmapH * imageScale;

                pictureBoxX = x / imageScale;
                pictureBoxY = (y - (clientH - imageRealH) / 2) / imageScale;

                toolStripStatusLabel_x.Text = ((int)pictureBoxX).ToString();
                toolStripStatusLabel_y.Text = ((int)pictureBoxY).ToString();

                if(pictureBoxY < 0 || pictureBoxY > bitmapH)
                {
                    toolStripStatusLabel1.Visible = false;
                    toolStripStatusLabel2.Visible = false;
                    toolStripStatusLabel3.Visible = false;
                    toolStripStatusLabel_x.Visible = false;
                    toolStripStatusLabel_y.Visible = false;
                }
                else
                {
                    toolStripStatusLabel1.Visible = true;
                    toolStripStatusLabel2.Visible = true;
                    toolStripStatusLabel3.Visible = true;
                    toolStripStatusLabel_x.Visible = true;
                    toolStripStatusLabel_y.Visible = true;
                }
            }
            else
            {
                imageScale = scaleFactorH;
                imageRealW = bitmapW * imageScale;
                imageRealH = clientH;

                pictureBoxX = (x - (clientW - imageRealW) / 2) / imageScale;
                pictureBoxY = y / imageScale;

                toolStripStatusLabel_x.Text = ((int)pictureBoxX).ToString();
                toolStripStatusLabel_y.Text = ((int)pictureBoxY).ToString();

                if (pictureBoxX < 0 || pictureBoxX > bitmapW)
                {
                    toolStripStatusLabel1.Visible = false;
                    toolStripStatusLabel2.Visible = false;
                    toolStripStatusLabel3.Visible = false;
                    toolStripStatusLabel_x.Visible = false;
                    toolStripStatusLabel_y.Visible = false;
                }
                else
                {
                    toolStripStatusLabel1.Visible = true;
                    toolStripStatusLabel2.Visible = true;
                    toolStripStatusLabel3.Visible = true;
                    toolStripStatusLabel_x.Visible = true;
                    toolStripStatusLabel_y.Visible = true;
                }
            }

            if (radioButton_freehand.Checked && drawing)
            {
                currentTrajectory.AddPoint(new PointF(pictureBoxX, pictureBoxY), 1);
                redrawGraphics(false);
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (radioButton_freehand.Checked && drawing)
            {
                drawing = false;
                currentTrajectory.AddPoint(new PointF(pictureBoxX, pictureBoxY), 2);
                redrawGraphics(false);
            }
        }

        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Visible = false;
            toolStripStatusLabel2.Visible = false;
            toolStripStatusLabel3.Visible = false;
            toolStripStatusLabel_x.Visible = false;
            toolStripStatusLabel_y.Visible = false;

            if (radioButton_freehand.Checked && drawing)
            {
                drawing = false;
                currentTrajectory.AddPoint(new PointF(pictureBoxX, pictureBoxY), 2);
                redrawGraphics(false);
            }
        }

        private void textBox_text_TextChanged(object sender, EventArgs e)
        {
            updateCurrentTrajectory();
        }

        private void fontDialog_Apply(object sender, EventArgs e)
        {
            updateCurrentTrajectory();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void surfaceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_send_Click(object sender, EventArgs e)
        {
            if (!backgroundWorkerSend.IsBusy)
            {
                toolStripProgressBarSend.Visible = true;
                backgroundWorkerSend.RunWorkerAsync();
            }
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            string message = "func ";

            message += "1";

            try
            {
                robot.SendMessage(message);

            }
            catch (Exception ex)
            {
                if (ex.Message == "RAPID program is stopped")
                {
                    MessageBox.Show("Start RAPID program in robots controller.", "RAPID program has stopped", MessageBoxButtons.OK);
                }
            }
        }

        private void button_clean_Click(object sender, EventArgs e)
        {
            string message = "func ";

            message += "2";

            try
            {
                robot.SendMessage(message);

            }
            catch (Exception ex)
            {
                if (ex.Message == "RAPID program is stopped")
                {
                    MessageBox.Show("Start RAPID program in robots controller.", "RAPID program has stopped", MessageBoxButtons.OK);
                }
            }
        }

        private void button_target_Click(object sender, EventArgs e)
        {
            string message = "func ";

            message += "6";

            try
            {
                robot.SendMessage(message);

            }
            catch (Exception ex)
            {
                if (ex.Message == "RAPID program is stopped")
                {
                    MessageBox.Show("Start RAPID program in robots controller.", "RAPID program has stopped", MessageBoxButtons.OK);
                }
            }
        }

        private void button_center_Click(object sender, EventArgs e)
        {
            string message = "func ";

            message += "5";

            robot.SendMessage(message);
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Robots are dangerous!\nUse this at your own risk.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            robot.SetupController();
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            robot.Disconnect();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form aboutWindow = new Form();
            Label label1 = new Label();
            Label label2 = new Label();

            aboutWindow.FormBorderStyle = FormBorderStyle.FixedDialog;
            aboutWindow.Text = "About";
            aboutWindow.Size = new Size(350, 150);
            aboutWindow.MinimizeBox = false;
            aboutWindow.MaximizeBox = false;
            aboutWindow.StartPosition = FormStartPosition.CenterParent;

            label1.Text = "     Robot Drawing Interface";
            label1.Location = new Point(3, 3);
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 18);
            label1.Anchor = AnchorStyles.Top;

            label2.Text = "Created by Elijus Gustys";
            label2.Location = new Point(3, 43);
            label2.AutoSize = true;
            label2.Anchor = AnchorStyles.None;

            linkLabel1.Text = "Youtube: https://goo.gl/nrDEp1";
            linkLabel1.Location = new Point(3, 63);
            linkLabel1.AutoSize = true;
            linkLabel1.LinkArea = new LinkArea(9, 21);
            linkLabel1.Anchor = AnchorStyles.None;

            linkLabel2.Text = "Email: elijus.gustys@gmail.com";
            linkLabel2.Location = new Point(3, 83);
            linkLabel2.AutoSize = true;
            linkLabel2.LinkArea = new LinkArea(7, 23);
            linkLabel2.Anchor = AnchorStyles.None;
            
            aboutWindow.Controls.Add(label1);
            aboutWindow.Controls.Add(label2);
            aboutWindow.Controls.Add(linkLabel1);
            aboutWindow.Controls.Add(linkLabel2);

            linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
            linkLabel2.LinkClicked += new LinkLabelLinkClickedEventHandler(linkLabel2_LinkClicked);

            aboutWindow.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://goo.gl/nrDEp1");
        }

        private void linkLabel2_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            linkLabel2.LinkVisited = true;
            System.Diagnostics.Process.Start("mailto:elijus.gustys@gmail.com");
        }

        private void backgroundWorkerSend_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = 0; i < fullTrajectory.Count; i++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    Pos position = new Pos();
                    position.X = fullTrajectory.Points[i].X;
                    position.Y = fullTrajectory.Points[i].Y;
                    position.Z = fullTrajectory.PointTypes[i];

                    try
                    {
                        robot.SendMessage(position);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == "RAPID program is stopped")
                        {
                            MessageBox.Show("Check robots controller for an error message.\nGraphics transfer has been canceled.", "RAPID program has stopped", MessageBoxButtons.OK);
                        }
                        break;
                    }

                    worker.ReportProgress((int)(i * 100 / fullTrajectory.Count) + 1);
                    System.Threading.Thread.Sleep(10);
                }
            }
        }

        private void backgroundWorkerSend_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBarSend.Value = e.ProgressPercentage;
        }

        private void backgroundWorkerSend_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                toolStripProgressBarSend.Visible = false;
            }
            else if (e.Error != null)
            {
                toolStripProgressBarSend.Visible = false;
            }
            else
            {
                toolStripProgressBarSend.Value = 0;
                toolStripProgressBarSend.Visible = false;
            }
        }

        private void buttonBoundaries_Click(object sender, EventArgs e)
        {
            string message = "func ";

            message += "7";

            robot.SendMessage(message);
        }

        private void buttonDebug_Click(object sender, EventArgs e)
        {
            
        }

        private void surfaceSetupHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form surfaceHelpWindow = new Form();
            //Label label1 = new Label();
            PictureBox pictureBoxHelp1 = new PictureBox();
            PictureBox pictureBoxHelp2 = new PictureBox();

            surfaceHelpWindow.FormBorderStyle = FormBorderStyle.FixedDialog;
            surfaceHelpWindow.Text = "Surface setup help";
            surfaceHelpWindow.Size = new Size(1345, 605);
            surfaceHelpWindow.MinimizeBox = false;
            surfaceHelpWindow.MaximizeBox = false;
            surfaceHelpWindow.StartPosition = FormStartPosition.CenterParent;
            /*
            label1.Text = "Surface setup parameters";
            label1.Location = new Point(3, 3);
            label1.AutoSize = true;
            label1.Anchor = AnchorStyles.Top;
            */
            pictureBoxHelp1.Location = new Point(3, 3);
            pictureBoxHelp1.Size = new Size(660, 560);
            pictureBoxHelp1.ImageLocation = "C:/Users/elijo/OneDrive/Documents/Visual Studio 2017/Projects/Robot Drawing Interface/Media/help1.png";
            pictureBoxHelp1.Load();


            pictureBoxHelp2.Location = new Point(666, 3);
            pictureBoxHelp2.Size = new Size(660, 700);
            pictureBoxHelp2.ImageLocation = "C:/Users/elijo/OneDrive/Documents/Visual Studio 2017/Projects/Robot Drawing Interface/Media/help2.png";
            pictureBoxHelp2.Load();

            //surfaceHelpWindow.Controls.Add(label1);
            surfaceHelpWindow.Controls.Add(pictureBoxHelp1);
            surfaceHelpWindow.Controls.Add(pictureBoxHelp2);

            surfaceHelpWindow.ShowDialog();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void viewOutgoingMessagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            robot.ShowMessageLog();
        }

        private void OnConnectedToTheController(object sender, EventArgs e)
        {
            ConnectedToTheControllerUpdateGUI();
        }
        
        private void OnDisconnectedFromTheController(object sender, EventArgs e)
        {
            DisconnectedFromTheControllerUpdateGUI();
        }

        private void OnStartedRunnigRAPID(object sender, EventArgs e)
        {
            StartedRunningRAPIDUpdateGUI();
        }

        private void OnStoppedRunnigRAPID(object sender, EventArgs e)
        {
            StoppedRunningRAPIDUpdateGUI();
        }

        private void ConnectedToTheControllerUpdateGUI()
        {
            if (menuStrip1.InvokeRequired)
            {
                ConnectedToTheControllerUpdateGUICallback d = new ConnectedToTheControllerUpdateGUICallback(ConnectedToTheControllerUpdateGUI);
                Invoke(d, new object[] { });
            }
            else
            {
                toolStripStatusLabelController.BackColor = Color.LightGreen;
                toolStripStatusLabelController.Text = "Controller: connected";
                connectToolStripMenuItem.Enabled = false;
                disconnectToolStripMenuItem.Enabled = true;
                viewOutgoingMessagesToolStripMenuItem.Enabled = true;
            }
        }

        private void DisconnectedFromTheControllerUpdateGUI()
        {
            if (menuStrip1.InvokeRequired)
            {
                DisconnectedFromTheControllerUpdateGUICallback d = new DisconnectedFromTheControllerUpdateGUICallback(DisconnectedFromTheControllerUpdateGUI);
                Invoke(d, new object[] { });
            }
            else
            {
                toolStripStatusLabelController.BackColor = Color.OrangeRed;
                toolStripStatusLabelController.Text = "Controller: disconnected";
                connectToolStripMenuItem.Enabled = true;
                disconnectToolStripMenuItem.Enabled = false;
                viewOutgoingMessagesToolStripMenuItem.Enabled = false;
            }
        }

        private void StartedRunningRAPIDUpdateGUI()
        {
            if (menuStrip1.InvokeRequired)
            {
                StartedRunningRAPIDUpdateGUICallback d = new StartedRunningRAPIDUpdateGUICallback(StartedRunningRAPIDUpdateGUI);
                Invoke(d, new object[] { });
            }
            else
            {
                toolStripStatusLabelRAPID.BackColor = Color.LightGreen;
                toolStripStatusLabelRAPID.Text = "RAPID: running";
                tableLayoutPanelRobotControls.Enabled = true;
                UploadSettingsToTheController();
            }
        }

        private void StoppedRunningRAPIDUpdateGUI()
        {
            if (menuStrip1.InvokeRequired)
            {
                StoppedRunningRAPIDUpdateGUICallback d = new StoppedRunningRAPIDUpdateGUICallback(StoppedRunningRAPIDUpdateGUI);
                Invoke(d, new object[] { });
            }
            else
            {
                toolStripStatusLabelRAPID.BackColor = Color.OrangeRed;
                toolStripStatusLabelRAPID.Text = "RAPID: stopped";
                tableLayoutPanelRobotControls.Enabled = false;
            }
        }

        private void UploadSettingsToTheController()
        {
            string message = "para ";

            message += "fsw" + flatSurfaceWidth.ToString() + " ";
            message += "fsh" + flatSurfaceHeight.ToString() + " ";
            message += "cpx" + cylinderPosition.X.ToString() + " ";
            message += "cpy" + cylinderPosition.Y.ToString() + " ";
            message += "cbh" + cylinderBottomHeight.ToString() + " ";
            message += "cth" + cylinderTopHeight.ToString() + " ";
            message += "cra" + cylinderRadius.ToString() + " ";
            message += "cld" + writeOnCylinder.ToString() + " ";

            try
            {
                robot.SendMessage(message);
            }
            catch (Exception ex)
            {
                if (ex.Message == "RAPID program is stopped")
                {
                    MessageBox.Show("Start RAPID program in robots controller.", "RAPID program has stopped", MessageBoxButtons.OK);
                }
            }
        }
    }
}
