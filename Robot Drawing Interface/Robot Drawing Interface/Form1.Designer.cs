namespace Robot_Drawing_Interface
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.robotControllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewOutgoingMessagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.surfaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flatSurfaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cylinderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sepToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.flatSurfaceSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.surfaceSetupHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelRAPID = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelController = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBarSend = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_y = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_x = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButton_text = new System.Windows.Forms.RadioButton();
            this.radioButton_line = new System.Windows.Forms.RadioButton();
            this.radioButton_rectangle = new System.Windows.Forms.RadioButton();
            this.radioButton_circle = new System.Windows.Forms.RadioButton();
            this.radioButton_freehand = new System.Windows.Forms.RadioButton();
            this.button_add_current = new System.Windows.Forms.Button();
            this.button_reset_full = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_op_y = new System.Windows.Forms.TextBox();
            this.textBox_op_x = new System.Windows.Forms.TextBox();
            this.label_fp = new System.Windows.Forms.Label();
            this.label_fp_x = new System.Windows.Forms.Label();
            this.label_fp_y = new System.Windows.Forms.Label();
            this.label_sp = new System.Windows.Forms.Label();
            this.label_sp_x = new System.Windows.Forms.Label();
            this.label_sp_y = new System.Windows.Forms.Label();
            this.label_cp = new System.Windows.Forms.Label();
            this.label_cp_x = new System.Windows.Forms.Label();
            this.label_cp_y = new System.Windows.Forms.Label();
            this.label_radius = new System.Windows.Forms.Label();
            this.textBox_fp_x = new System.Windows.Forms.TextBox();
            this.textBox_fp_y = new System.Windows.Forms.TextBox();
            this.textBox_sp_x = new System.Windows.Forms.TextBox();
            this.textBox_sp_y = new System.Windows.Forms.TextBox();
            this.textBox_cp_x = new System.Windows.Forms.TextBox();
            this.textBox_cp_y = new System.Windows.Forms.TextBox();
            this.textBox_radius = new System.Windows.Forms.TextBox();
            this.button_font = new System.Windows.Forms.Button();
            this.textBox_text = new System.Windows.Forms.TextBox();
            this.label_op = new System.Windows.Forms.Label();
            this.label_op_x = new System.Windows.Forms.Label();
            this.label_op_y = new System.Windows.Forms.Label();
            this.label_text = new System.Windows.Forms.Label();
            this.label_text_rotation = new System.Windows.Forms.Label();
            this.numericUpDown_text_rotation = new System.Windows.Forms.NumericUpDown();
            this.panelPictureBox = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanelRobotControls = new System.Windows.Forms.TableLayoutPanel();
            this.button_send = new System.Windows.Forms.Button();
            this.button_clean = new System.Windows.Forms.Button();
            this.button_target = new System.Windows.Forms.Button();
            this.button_center = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.buttonBoundaries = new System.Windows.Forms.Button();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.backgroundWorkerSend = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_text_rotation)).BeginInit();
            this.panelPictureBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.tableLayoutPanelRobotControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.robotControllerToolStripMenuItem,
            this.surfaceToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1255, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // robotControllerToolStripMenuItem
            // 
            this.robotControllerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem,
            this.viewOutgoingMessagesToolStripMenuItem});
            this.robotControllerToolStripMenuItem.Name = "robotControllerToolStripMenuItem";
            this.robotControllerToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.robotControllerToolStripMenuItem.Text = "Controller";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.connectToolStripMenuItem.Text = "Connect...";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Enabled = false;
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // viewOutgoingMessagesToolStripMenuItem
            // 
            this.viewOutgoingMessagesToolStripMenuItem.Enabled = false;
            this.viewOutgoingMessagesToolStripMenuItem.Name = "viewOutgoingMessagesToolStripMenuItem";
            this.viewOutgoingMessagesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.viewOutgoingMessagesToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.viewOutgoingMessagesToolStripMenuItem.Text = "View outgoing messages";
            this.viewOutgoingMessagesToolStripMenuItem.Click += new System.EventHandler(this.viewOutgoingMessagesToolStripMenuItem_Click);
            // 
            // surfaceToolStripMenuItem
            // 
            this.surfaceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.flatSurfaceToolStripMenuItem,
            this.cylinderToolStripMenuItem,
            this.sepToolStripMenuItem,
            this.flatSurfaceSetupToolStripMenuItem});
            this.surfaceToolStripMenuItem.Name = "surfaceToolStripMenuItem";
            this.surfaceToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.surfaceToolStripMenuItem.Text = "Surfaces";
            this.surfaceToolStripMenuItem.Click += new System.EventHandler(this.surfaceToolStripMenuItem_Click);
            // 
            // flatSurfaceToolStripMenuItem
            // 
            this.flatSurfaceToolStripMenuItem.Checked = true;
            this.flatSurfaceToolStripMenuItem.CheckOnClick = true;
            this.flatSurfaceToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.flatSurfaceToolStripMenuItem.Name = "flatSurfaceToolStripMenuItem";
            this.flatSurfaceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.flatSurfaceToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.flatSurfaceToolStripMenuItem.Text = "Flat surface";
            this.flatSurfaceToolStripMenuItem.Click += new System.EventHandler(this.flatSurfaceToolStripMenuItem_Click);
            // 
            // cylinderToolStripMenuItem
            // 
            this.cylinderToolStripMenuItem.CheckOnClick = true;
            this.cylinderToolStripMenuItem.Name = "cylinderToolStripMenuItem";
            this.cylinderToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.cylinderToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.cylinderToolStripMenuItem.Text = "Cylinder";
            this.cylinderToolStripMenuItem.Click += new System.EventHandler(this.cylinderToolStripMenuItem_Click);
            // 
            // sepToolStripMenuItem
            // 
            this.sepToolStripMenuItem.Name = "sepToolStripMenuItem";
            this.sepToolStripMenuItem.Size = new System.Drawing.Size(191, 6);
            // 
            // flatSurfaceSetupToolStripMenuItem
            // 
            this.flatSurfaceSetupToolStripMenuItem.Name = "flatSurfaceSetupToolStripMenuItem";
            this.flatSurfaceSetupToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.flatSurfaceSetupToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.flatSurfaceSetupToolStripMenuItem.Text = "Surface setup...";
            this.flatSurfaceSetupToolStripMenuItem.Click += new System.EventHandler(this.flatSurfaceSetupToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.surfaceSetupHelpToolStripMenuItem,
            this.aToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // surfaceSetupHelpToolStripMenuItem
            // 
            this.surfaceSetupHelpToolStripMenuItem.Name = "surfaceSetupHelpToolStripMenuItem";
            this.surfaceSetupHelpToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.surfaceSetupHelpToolStripMenuItem.Text = "Surface setup help";
            this.surfaceSetupHelpToolStripMenuItem.Click += new System.EventHandler(this.surfaceSetupHelpToolStripMenuItem_Click);
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(168, 6);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelRAPID,
            this.toolStripStatusLabelController,
            this.toolStripProgressBarSend,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel_y,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel_x,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 515);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(1255, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelRAPID
            // 
            this.toolStripStatusLabelRAPID.AutoSize = false;
            this.toolStripStatusLabelRAPID.BackColor = System.Drawing.Color.OrangeRed;
            this.toolStripStatusLabelRAPID.Name = "toolStripStatusLabelRAPID";
            this.toolStripStatusLabelRAPID.Size = new System.Drawing.Size(88, 17);
            this.toolStripStatusLabelRAPID.Text = "RAPID: running";
            // 
            // toolStripStatusLabelController
            // 
            this.toolStripStatusLabelController.AutoSize = false;
            this.toolStripStatusLabelController.BackColor = System.Drawing.Color.OrangeRed;
            this.toolStripStatusLabelController.Name = "toolStripStatusLabelController";
            this.toolStripStatusLabelController.Size = new System.Drawing.Size(137, 17);
            this.toolStripStatusLabelController.Text = "Controller: disconnected";
            // 
            // toolStripProgressBarSend
            // 
            this.toolStripProgressBarSend.Name = "toolStripProgressBarSend";
            this.toolStripProgressBarSend.Size = new System.Drawing.Size(150, 16);
            this.toolStripProgressBarSend.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // toolStripStatusLabel_y
            // 
            this.toolStripStatusLabel_y.AutoSize = false;
            this.toolStripStatusLabel_y.Name = "toolStripStatusLabel_y";
            this.toolStripStatusLabel_y.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel_y.Text = "y_crd";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // toolStripStatusLabel_x
            // 
            this.toolStripStatusLabel_x.AutoSize = false;
            this.toolStripStatusLabel_x.Name = "toolStripStatusLabel_x";
            this.toolStripStatusLabel_x.Size = new System.Drawing.Size(34, 17);
            this.toolStripStatusLabel_x.Text = "x_crd";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel3.Text = "|";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.radioButton_text, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioButton_line, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioButton_rectangle, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioButton_circle, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioButton_freehand, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_add_current, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_reset_full, 9, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1249, 34);
            this.tableLayoutPanel1.TabIndex = 3;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // radioButton_text
            // 
            this.radioButton_text.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButton_text.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton_text.Checked = true;
            this.radioButton_text.Location = new System.Drawing.Point(3, 3);
            this.radioButton_text.Name = "radioButton_text";
            this.radioButton_text.Size = new System.Drawing.Size(77, 23);
            this.radioButton_text.TabIndex = 0;
            this.radioButton_text.TabStop = true;
            this.radioButton_text.Text = "Text";
            this.radioButton_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton_text.UseVisualStyleBackColor = true;
            this.radioButton_text.CheckedChanged += new System.EventHandler(this.radioButton_text_CheckedChanged);
            // 
            // radioButton_line
            // 
            this.radioButton_line.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButton_line.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton_line.Location = new System.Drawing.Point(86, 3);
            this.radioButton_line.Name = "radioButton_line";
            this.radioButton_line.Size = new System.Drawing.Size(77, 23);
            this.radioButton_line.TabIndex = 1;
            this.radioButton_line.Text = "Line";
            this.radioButton_line.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton_line.UseVisualStyleBackColor = true;
            this.radioButton_line.CheckedChanged += new System.EventHandler(this.radioButton_line_CheckedChanged);
            // 
            // radioButton_rectangle
            // 
            this.radioButton_rectangle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButton_rectangle.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton_rectangle.Location = new System.Drawing.Point(169, 3);
            this.radioButton_rectangle.Name = "radioButton_rectangle";
            this.radioButton_rectangle.Size = new System.Drawing.Size(77, 23);
            this.radioButton_rectangle.TabIndex = 2;
            this.radioButton_rectangle.Text = "Rectangle";
            this.radioButton_rectangle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton_rectangle.UseVisualStyleBackColor = true;
            this.radioButton_rectangle.CheckedChanged += new System.EventHandler(this.radioButton_rectangle_CheckedChanged);
            // 
            // radioButton_circle
            // 
            this.radioButton_circle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButton_circle.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton_circle.Location = new System.Drawing.Point(252, 3);
            this.radioButton_circle.Name = "radioButton_circle";
            this.radioButton_circle.Size = new System.Drawing.Size(77, 23);
            this.radioButton_circle.TabIndex = 3;
            this.radioButton_circle.Text = "Circle";
            this.radioButton_circle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton_circle.UseVisualStyleBackColor = true;
            this.radioButton_circle.CheckedChanged += new System.EventHandler(this.radioButton_circle_CheckedChanged);
            // 
            // radioButton_freehand
            // 
            this.radioButton_freehand.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButton_freehand.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton_freehand.Location = new System.Drawing.Point(335, 3);
            this.radioButton_freehand.Name = "radioButton_freehand";
            this.radioButton_freehand.Size = new System.Drawing.Size(77, 23);
            this.radioButton_freehand.TabIndex = 4;
            this.radioButton_freehand.Text = "Free-hand";
            this.radioButton_freehand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton_freehand.UseVisualStyleBackColor = true;
            this.radioButton_freehand.CheckedChanged += new System.EventHandler(this.radioButton_freehand_CheckedChanged);
            // 
            // button_add_current
            // 
            this.button_add_current.AutoSize = true;
            this.button_add_current.Location = new System.Drawing.Point(1025, 3);
            this.button_add_current.Name = "button_add_current";
            this.button_add_current.Size = new System.Drawing.Size(115, 23);
            this.button_add_current.TabIndex = 5;
            this.button_add_current.Text = "Add current graphics";
            this.button_add_current.UseVisualStyleBackColor = true;
            this.button_add_current.Click += new System.EventHandler(this.button_add_current_Click);
            // 
            // button_reset_full
            // 
            this.button_reset_full.AutoSize = true;
            this.button_reset_full.Location = new System.Drawing.Point(1146, 3);
            this.button_reset_full.Name = "button_reset_full";
            this.button_reset_full.Size = new System.Drawing.Size(100, 23);
            this.button_reset_full.TabIndex = 6;
            this.button_reset_full.Text = "Clear full graphics";
            this.button_reset_full.UseVisualStyleBackColor = true;
            this.button_reset_full.Click += new System.EventHandler(this.button_reset_full_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panelPictureBox, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanelRobotControls, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1255, 491);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 28;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.textBox_op_y, 24, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBox_op_x, 22, 0);
            this.tableLayoutPanel3.Controls.Add(this.label_fp, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label_fp_x, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label_fp_y, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.label_sp, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.label_sp_x, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.label_sp_y, 8, 0);
            this.tableLayoutPanel3.Controls.Add(this.label_cp, 10, 0);
            this.tableLayoutPanel3.Controls.Add(this.label_cp_x, 11, 0);
            this.tableLayoutPanel3.Controls.Add(this.label_cp_y, 13, 0);
            this.tableLayoutPanel3.Controls.Add(this.label_radius, 15, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBox_fp_x, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBox_fp_y, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBox_sp_x, 7, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBox_sp_y, 9, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBox_cp_x, 12, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBox_cp_y, 14, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBox_radius, 16, 0);
            this.tableLayoutPanel3.Controls.Add(this.button_font, 19, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBox_text, 18, 0);
            this.tableLayoutPanel3.Controls.Add(this.label_op, 20, 0);
            this.tableLayoutPanel3.Controls.Add(this.label_op_x, 21, 0);
            this.tableLayoutPanel3.Controls.Add(this.label_op_y, 23, 0);
            this.tableLayoutPanel3.Controls.Add(this.label_text, 17, 0);
            this.tableLayoutPanel3.Controls.Add(this.label_text_rotation, 25, 0);
            this.tableLayoutPanel3.Controls.Add(this.numericUpDown_text_rotation, 26, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 43);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1249, 34);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // textBox_op_y
            // 
            this.textBox_op_y.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_op_y.Location = new System.Drawing.Point(970, 7);
            this.textBox_op_y.Name = "textBox_op_y";
            this.textBox_op_y.Size = new System.Drawing.Size(30, 20);
            this.textBox_op_y.TabIndex = 29;
            this.textBox_op_y.Text = "0";
            this.textBox_op_y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_op_y.TextChanged += new System.EventHandler(this.textBox_op_y_TextChanged);
            // 
            // textBox_op_x
            // 
            this.textBox_op_x.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_op_x.Location = new System.Drawing.Point(911, 7);
            this.textBox_op_x.Name = "textBox_op_x";
            this.textBox_op_x.Size = new System.Drawing.Size(30, 20);
            this.textBox_op_x.TabIndex = 28;
            this.textBox_op_x.Text = "0";
            this.textBox_op_x.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_op_x.TextChanged += new System.EventHandler(this.textBox_op_x_TextChanged);
            // 
            // label_fp
            // 
            this.label_fp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_fp.AutoSize = true;
            this.label_fp.Location = new System.Drawing.Point(3, 10);
            this.label_fp.Name = "label_fp";
            this.label_fp.Size = new System.Drawing.Size(52, 13);
            this.label_fp.TabIndex = 0;
            this.label_fp.Text = "First point";
            // 
            // label_fp_x
            // 
            this.label_fp_x.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_fp_x.AutoSize = true;
            this.label_fp_x.Location = new System.Drawing.Point(61, 10);
            this.label_fp_x.Name = "label_fp_x";
            this.label_fp_x.Size = new System.Drawing.Size(17, 13);
            this.label_fp_x.TabIndex = 1;
            this.label_fp_x.Text = "X:";
            // 
            // label_fp_y
            // 
            this.label_fp_y.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_fp_y.AutoSize = true;
            this.label_fp_y.Location = new System.Drawing.Point(120, 10);
            this.label_fp_y.Name = "label_fp_y";
            this.label_fp_y.Size = new System.Drawing.Size(17, 13);
            this.label_fp_y.TabIndex = 2;
            this.label_fp_y.Text = "Y:";
            // 
            // label_sp
            // 
            this.label_sp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_sp.AutoSize = true;
            this.label_sp.Location = new System.Drawing.Point(179, 10);
            this.label_sp.Name = "label_sp";
            this.label_sp.Size = new System.Drawing.Size(70, 13);
            this.label_sp.TabIndex = 3;
            this.label_sp.Text = "Second point";
            // 
            // label_sp_x
            // 
            this.label_sp_x.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_sp_x.AutoSize = true;
            this.label_sp_x.Location = new System.Drawing.Point(255, 10);
            this.label_sp_x.Name = "label_sp_x";
            this.label_sp_x.Size = new System.Drawing.Size(17, 13);
            this.label_sp_x.TabIndex = 4;
            this.label_sp_x.Text = "X:";
            // 
            // label_sp_y
            // 
            this.label_sp_y.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_sp_y.AutoSize = true;
            this.label_sp_y.Location = new System.Drawing.Point(314, 10);
            this.label_sp_y.Name = "label_sp_y";
            this.label_sp_y.Size = new System.Drawing.Size(17, 13);
            this.label_sp_y.TabIndex = 5;
            this.label_sp_y.Text = "Y:";
            // 
            // label_cp
            // 
            this.label_cp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_cp.AutoSize = true;
            this.label_cp.Location = new System.Drawing.Point(373, 10);
            this.label_cp.Name = "label_cp";
            this.label_cp.Size = new System.Drawing.Size(64, 13);
            this.label_cp.TabIndex = 10;
            this.label_cp.Text = "Center point";
            // 
            // label_cp_x
            // 
            this.label_cp_x.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_cp_x.AutoSize = true;
            this.label_cp_x.Location = new System.Drawing.Point(443, 10);
            this.label_cp_x.Name = "label_cp_x";
            this.label_cp_x.Size = new System.Drawing.Size(17, 13);
            this.label_cp_x.TabIndex = 11;
            this.label_cp_x.Text = "X:";
            // 
            // label_cp_y
            // 
            this.label_cp_y.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_cp_y.AutoSize = true;
            this.label_cp_y.Location = new System.Drawing.Point(502, 10);
            this.label_cp_y.Name = "label_cp_y";
            this.label_cp_y.Size = new System.Drawing.Size(17, 13);
            this.label_cp_y.TabIndex = 13;
            this.label_cp_y.Text = "Y:";
            // 
            // label_radius
            // 
            this.label_radius.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_radius.AutoSize = true;
            this.label_radius.Location = new System.Drawing.Point(561, 10);
            this.label_radius.Name = "label_radius";
            this.label_radius.Size = new System.Drawing.Size(43, 13);
            this.label_radius.TabIndex = 15;
            this.label_radius.Text = "Radius:";
            // 
            // textBox_fp_x
            // 
            this.textBox_fp_x.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_fp_x.Location = new System.Drawing.Point(84, 7);
            this.textBox_fp_x.Name = "textBox_fp_x";
            this.textBox_fp_x.Size = new System.Drawing.Size(30, 20);
            this.textBox_fp_x.TabIndex = 16;
            this.textBox_fp_x.Text = "0";
            this.textBox_fp_x.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_fp_x.TextChanged += new System.EventHandler(this.textBox_fp_x_TextChanged);
            // 
            // textBox_fp_y
            // 
            this.textBox_fp_y.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_fp_y.Location = new System.Drawing.Point(143, 7);
            this.textBox_fp_y.Name = "textBox_fp_y";
            this.textBox_fp_y.Size = new System.Drawing.Size(30, 20);
            this.textBox_fp_y.TabIndex = 17;
            this.textBox_fp_y.Text = "0";
            this.textBox_fp_y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_fp_y.TextChanged += new System.EventHandler(this.textBox_fp_y_TextChanged);
            // 
            // textBox_sp_x
            // 
            this.textBox_sp_x.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_sp_x.Location = new System.Drawing.Point(278, 7);
            this.textBox_sp_x.Name = "textBox_sp_x";
            this.textBox_sp_x.Size = new System.Drawing.Size(30, 20);
            this.textBox_sp_x.TabIndex = 18;
            this.textBox_sp_x.Text = "0";
            this.textBox_sp_x.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_sp_x.TextChanged += new System.EventHandler(this.textBox_sp_x_TextChanged);
            // 
            // textBox_sp_y
            // 
            this.textBox_sp_y.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_sp_y.Location = new System.Drawing.Point(337, 7);
            this.textBox_sp_y.Name = "textBox_sp_y";
            this.textBox_sp_y.Size = new System.Drawing.Size(30, 20);
            this.textBox_sp_y.TabIndex = 19;
            this.textBox_sp_y.Text = "0";
            this.textBox_sp_y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_sp_y.TextChanged += new System.EventHandler(this.textBox_sp_y_TextChanged);
            // 
            // textBox_cp_x
            // 
            this.textBox_cp_x.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_cp_x.Location = new System.Drawing.Point(466, 7);
            this.textBox_cp_x.Name = "textBox_cp_x";
            this.textBox_cp_x.Size = new System.Drawing.Size(30, 20);
            this.textBox_cp_x.TabIndex = 20;
            this.textBox_cp_x.Text = "0";
            this.textBox_cp_x.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_cp_x.TextChanged += new System.EventHandler(this.textBox_cp_x_TextChanged);
            // 
            // textBox_cp_y
            // 
            this.textBox_cp_y.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_cp_y.Location = new System.Drawing.Point(525, 7);
            this.textBox_cp_y.Name = "textBox_cp_y";
            this.textBox_cp_y.Size = new System.Drawing.Size(30, 20);
            this.textBox_cp_y.TabIndex = 21;
            this.textBox_cp_y.Text = "0";
            this.textBox_cp_y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_cp_y.TextChanged += new System.EventHandler(this.textBox_cp_y_TextChanged);
            // 
            // textBox_radius
            // 
            this.textBox_radius.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_radius.Location = new System.Drawing.Point(610, 7);
            this.textBox_radius.Name = "textBox_radius";
            this.textBox_radius.Size = new System.Drawing.Size(30, 20);
            this.textBox_radius.TabIndex = 22;
            this.textBox_radius.Text = "0";
            this.textBox_radius.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_radius.TextChanged += new System.EventHandler(this.textBox_radius_TextChanged);
            // 
            // button_font
            // 
            this.button_font.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_font.Location = new System.Drawing.Point(739, 5);
            this.button_font.Name = "button_font";
            this.button_font.Size = new System.Drawing.Size(77, 23);
            this.button_font.TabIndex = 23;
            this.button_font.Text = "Font";
            this.button_font.UseVisualStyleBackColor = true;
            this.button_font.Click += new System.EventHandler(this.button_font_Click);
            // 
            // textBox_text
            // 
            this.textBox_text.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_text.Location = new System.Drawing.Point(683, 7);
            this.textBox_text.Name = "textBox_text";
            this.textBox_text.Size = new System.Drawing.Size(50, 20);
            this.textBox_text.TabIndex = 24;
            this.textBox_text.TextChanged += new System.EventHandler(this.textBox_text_TextChanged);
            // 
            // label_op
            // 
            this.label_op.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_op.AutoSize = true;
            this.label_op.Location = new System.Drawing.Point(822, 10);
            this.label_op.Name = "label_op";
            this.label_op.Size = new System.Drawing.Size(60, 13);
            this.label_op.TabIndex = 25;
            this.label_op.Text = "Origin point";
            // 
            // label_op_x
            // 
            this.label_op_x.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_op_x.AutoSize = true;
            this.label_op_x.Location = new System.Drawing.Point(888, 10);
            this.label_op_x.Name = "label_op_x";
            this.label_op_x.Size = new System.Drawing.Size(17, 13);
            this.label_op_x.TabIndex = 26;
            this.label_op_x.Text = "X:";
            // 
            // label_op_y
            // 
            this.label_op_y.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_op_y.AutoSize = true;
            this.label_op_y.Location = new System.Drawing.Point(947, 10);
            this.label_op_y.Name = "label_op_y";
            this.label_op_y.Size = new System.Drawing.Size(17, 13);
            this.label_op_y.TabIndex = 27;
            this.label_op_y.Text = "Y:";
            // 
            // label_text
            // 
            this.label_text.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_text.AutoSize = true;
            this.label_text.Location = new System.Drawing.Point(646, 10);
            this.label_text.Name = "label_text";
            this.label_text.Size = new System.Drawing.Size(31, 13);
            this.label_text.TabIndex = 30;
            this.label_text.Text = "Text:";
            // 
            // label_text_rotation
            // 
            this.label_text_rotation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_text_rotation.AutoSize = true;
            this.label_text_rotation.Location = new System.Drawing.Point(1006, 10);
            this.label_text_rotation.Name = "label_text_rotation";
            this.label_text_rotation.Size = new System.Drawing.Size(39, 13);
            this.label_text_rotation.TabIndex = 31;
            this.label_text_rotation.Text = "Rotate";
            // 
            // numericUpDown_text_rotation
            // 
            this.numericUpDown_text_rotation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDown_text_rotation.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_text_rotation.Location = new System.Drawing.Point(1051, 7);
            this.numericUpDown_text_rotation.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDown_text_rotation.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numericUpDown_text_rotation.Name = "numericUpDown_text_rotation";
            this.numericUpDown_text_rotation.Size = new System.Drawing.Size(45, 20);
            this.numericUpDown_text_rotation.TabIndex = 32;
            this.numericUpDown_text_rotation.ValueChanged += new System.EventHandler(this.numericUpDown_text_rotation_ValueChanged);
            // 
            // panelPictureBox
            // 
            this.panelPictureBox.Controls.Add(this.pictureBox);
            this.panelPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPictureBox.Location = new System.Drawing.Point(3, 83);
            this.panelPictureBox.Name = "panelPictureBox";
            this.panelPictureBox.Size = new System.Drawing.Size(1249, 365);
            this.panelPictureBox.TabIndex = 6;
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.ImageLocation = "";
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1249, 365);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseEnter += new System.EventHandler(this.pictureBox_MouseEnter);
            this.pictureBox.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // tableLayoutPanelRobotControls
            // 
            this.tableLayoutPanelRobotControls.ColumnCount = 11;
            this.tableLayoutPanelRobotControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelRobotControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelRobotControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelRobotControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelRobotControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelRobotControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelRobotControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelRobotControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelRobotControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelRobotControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelRobotControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRobotControls.Controls.Add(this.button_send, 0, 0);
            this.tableLayoutPanelRobotControls.Controls.Add(this.button_clean, 3, 0);
            this.tableLayoutPanelRobotControls.Controls.Add(this.button_target, 4, 0);
            this.tableLayoutPanelRobotControls.Controls.Add(this.button_center, 5, 0);
            this.tableLayoutPanelRobotControls.Controls.Add(this.button_stop, 1, 0);
            this.tableLayoutPanelRobotControls.Controls.Add(this.buttonBoundaries, 2, 0);
            this.tableLayoutPanelRobotControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelRobotControls.Enabled = false;
            this.tableLayoutPanelRobotControls.Location = new System.Drawing.Point(3, 454);
            this.tableLayoutPanelRobotControls.Name = "tableLayoutPanelRobotControls";
            this.tableLayoutPanelRobotControls.RowCount = 1;
            this.tableLayoutPanelRobotControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRobotControls.Size = new System.Drawing.Size(1249, 34);
            this.tableLayoutPanelRobotControls.TabIndex = 7;
            // 
            // button_send
            // 
            this.button_send.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_send.AutoSize = true;
            this.button_send.Location = new System.Drawing.Point(3, 5);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(85, 23);
            this.button_send.TabIndex = 0;
            this.button_send.Text = "Send graphics";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // button_clean
            // 
            this.button_clean.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_clean.AutoSize = true;
            this.button_clean.Location = new System.Drawing.Point(321, 5);
            this.button_clean.Name = "button_clean";
            this.button_clean.Size = new System.Drawing.Size(129, 23);
            this.button_clean.TabIndex = 1;
            this.button_clean.Text = " Clean the drawing area";
            this.button_clean.UseVisualStyleBackColor = true;
            this.button_clean.Click += new System.EventHandler(this.button_clean_Click);
            // 
            // button_target
            // 
            this.button_target.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_target.AutoSize = true;
            this.button_target.Location = new System.Drawing.Point(456, 5);
            this.button_target.Name = "button_target";
            this.button_target.Size = new System.Drawing.Size(126, 23);
            this.button_target.TabIndex = 2;
            this.button_target.Text = "Mark cylinders position";
            this.button_target.UseVisualStyleBackColor = true;
            this.button_target.Click += new System.EventHandler(this.button_target_Click);
            // 
            // button_center
            // 
            this.button_center.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_center.AutoSize = true;
            this.button_center.Location = new System.Drawing.Point(588, 5);
            this.button_center.Name = "button_center";
            this.button_center.Size = new System.Drawing.Size(105, 23);
            this.button_center.TabIndex = 3;
            this.button_center.Text = "Center the cylinder";
            this.button_center.UseVisualStyleBackColor = true;
            this.button_center.Click += new System.EventHandler(this.button_center_Click);
            // 
            // button_stop
            // 
            this.button_stop.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_stop.AutoSize = true;
            this.button_stop.Location = new System.Drawing.Point(94, 5);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(79, 23);
            this.button_stop.TabIndex = 4;
            this.button_stop.Text = "Stop drawing";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // buttonBoundaries
            // 
            this.buttonBoundaries.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonBoundaries.AutoSize = true;
            this.buttonBoundaries.Location = new System.Drawing.Point(179, 5);
            this.buttonBoundaries.Name = "buttonBoundaries";
            this.buttonBoundaries.Size = new System.Drawing.Size(136, 23);
            this.buttonBoundaries.TabIndex = 5;
            this.buttonBoundaries.Text = "Mark drawing boundaries";
            this.buttonBoundaries.UseVisualStyleBackColor = true;
            this.buttonBoundaries.Click += new System.EventHandler(this.buttonBoundaries_Click);
            // 
            // fontDialog
            // 
            this.fontDialog.Font = new System.Drawing.Font("DS ISO 1", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontDialog.MaxSize = 150;
            this.fontDialog.MinSize = 10;
            this.fontDialog.Apply += new System.EventHandler(this.fontDialog_Apply);
            // 
            // backgroundWorkerSend
            // 
            this.backgroundWorkerSend.WorkerReportsProgress = true;
            this.backgroundWorkerSend.WorkerSupportsCancellation = true;
            this.backgroundWorkerSend.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSend_DoWork);
            this.backgroundWorkerSend.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerSend_ProgressChanged);
            this.backgroundWorkerSend.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSend_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 537);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(750, 500);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IRB Drawing Interface";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_text_rotation)).EndInit();
            this.panelPictureBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.tableLayoutPanelRobotControls.ResumeLayout(false);
            this.tableLayoutPanelRobotControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem robotControllerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem surfaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flatSurfaceSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_x;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_y;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton radioButton_text;
        private System.Windows.Forms.RadioButton radioButton_line;
        private System.Windows.Forms.RadioButton radioButton_rectangle;
        private System.Windows.Forms.RadioButton radioButton_circle;
        private System.Windows.Forms.RadioButton radioButton_freehand;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button_add_current;
        private System.Windows.Forms.Button button_reset_full;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label_fp;
        private System.Windows.Forms.Label label_fp_x;
        private System.Windows.Forms.Label label_fp_y;
        private System.Windows.Forms.Label label_sp;
        private System.Windows.Forms.Label label_sp_x;
        private System.Windows.Forms.Label label_sp_y;
        private System.Windows.Forms.Label label_cp;
        private System.Windows.Forms.Label label_cp_x;
        private System.Windows.Forms.Label label_cp_y;
        private System.Windows.Forms.Label label_radius;
        private System.Windows.Forms.TextBox textBox_fp_x;
        private System.Windows.Forms.TextBox textBox_fp_y;
        private System.Windows.Forms.TextBox textBox_sp_x;
        private System.Windows.Forms.TextBox textBox_sp_y;
        private System.Windows.Forms.TextBox textBox_cp_x;
        private System.Windows.Forms.TextBox textBox_cp_y;
        private System.Windows.Forms.TextBox textBox_radius;
        private System.Windows.Forms.Panel panelPictureBox;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button button_font;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.TextBox textBox_text;
        private System.Windows.Forms.ToolStripMenuItem flatSurfaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cylinderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator sepToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox_op_y;
        private System.Windows.Forms.TextBox textBox_op_x;
        private System.Windows.Forms.Label label_op;
        private System.Windows.Forms.Label label_op_x;
        private System.Windows.Forms.Label label_op_y;
        private System.Windows.Forms.Label label_text;
        private System.Windows.Forms.Label label_text_rotation;
        private System.Windows.Forms.NumericUpDown numericUpDown_text_rotation;
        private System.Windows.Forms.ToolStripMenuItem surfaceSetupHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRobotControls;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.Button button_clean;
        private System.Windows.Forms.Button button_target;
        private System.Windows.Forms.Button button_center;
        private System.Windows.Forms.Button button_stop;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSend;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBarSend;
        private System.Windows.Forms.Button buttonBoundaries;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelController;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripMenuItem viewOutgoingMessagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRAPID;
    }
}

