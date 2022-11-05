using Eve.TapToClick.Controls;

namespace Eve.TapToClick.Forms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.notifyIconConfigureMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIconExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configGroupBox = new System.Windows.Forms.GroupBox();
            this.applyConfigButton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.maxTapDistanceTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.maxTapMillisecondsTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.triggerThresholdTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.detectionThresholdTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.settingsGroupBox = new System.Windows.Forms.GroupBox();
            this.startupCheckbox = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.previousTapGroupBox = new System.Windows.Forms.GroupBox();
            this.previousMaxDistanceLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.previousContactCountLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.previousDurationLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.previousMaxPressureLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.activeContactDisplay4 = new Eve.TapToClick.Controls.ActiveContactDisplay();
            this.activeContactDisplay3 = new Eve.TapToClick.Controls.ActiveContactDisplay();
            this.activeContactDisplay2 = new Eve.TapToClick.Controls.ActiveContactDisplay();
            this.activeContactDisplay1 = new Eve.TapToClick.Controls.ActiveContactDisplay();
            this.activeContactDisplay5 = new Eve.TapToClick.Controls.ActiveContactDisplay();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dragGroupBox = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dragGapTimeTextbox = new System.Windows.Forms.TextBox();
            this.notifyIconContextMenuStrip.SuspendLayout();
            this.configGroupBox.SuspendLayout();
            this.settingsGroupBox.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.previousTapGroupBox.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.dragGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyIconContextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Eve.TapToClick";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // notifyIconContextMenuStrip
            // 
            this.notifyIconContextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.notifyIconContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notifyIconConfigureMenuItem,
            this.notifyIconExitMenuItem});
            this.notifyIconContextMenuStrip.Name = "notifyIconContextMenuStrip";
            this.notifyIconContextMenuStrip.Size = new System.Drawing.Size(175, 68);
            // 
            // notifyIconConfigureMenuItem
            // 
            this.notifyIconConfigureMenuItem.Name = "notifyIconConfigureMenuItem";
            this.notifyIconConfigureMenuItem.Size = new System.Drawing.Size(174, 32);
            this.notifyIconConfigureMenuItem.Text = "Configure...";
            this.notifyIconConfigureMenuItem.Click += new System.EventHandler(this.notifyIconConfigureMenuItem_Click);
            // 
            // notifyIconExitMenuItem
            // 
            this.notifyIconExitMenuItem.Name = "notifyIconExitMenuItem";
            this.notifyIconExitMenuItem.Size = new System.Drawing.Size(174, 32);
            this.notifyIconExitMenuItem.Text = "Exit";
            this.notifyIconExitMenuItem.Click += new System.EventHandler(this.notifyIconExitMenuItem_Click);
            // 
            // configGroupBox
            // 
            this.configGroupBox.Controls.Add(this.applyConfigButton);
            this.configGroupBox.Controls.Add(this.label11);
            this.configGroupBox.Controls.Add(this.maxTapDistanceTextBox);
            this.configGroupBox.Controls.Add(this.label10);
            this.configGroupBox.Controls.Add(this.maxTapMillisecondsTextBox);
            this.configGroupBox.Controls.Add(this.label9);
            this.configGroupBox.Controls.Add(this.triggerThresholdTextBox);
            this.configGroupBox.Controls.Add(this.label7);
            this.configGroupBox.Controls.Add(this.detectionThresholdTextBox);
            this.configGroupBox.Controls.Add(this.label5);
            this.configGroupBox.Location = new System.Drawing.Point(9, 9);
            this.configGroupBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.configGroupBox.Name = "configGroupBox";
            this.configGroupBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.configGroupBox.Size = new System.Drawing.Size(278, 312);
            this.configGroupBox.TabIndex = 2;
            this.configGroupBox.TabStop = false;
            this.configGroupBox.Text = "Detection/Tap Configuration";
            // 
            // applyConfigButton
            // 
            this.applyConfigButton.Location = new System.Drawing.Point(14, 268);
            this.applyConfigButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.applyConfigButton.Name = "applyConfigButton";
            this.applyConfigButton.Size = new System.Drawing.Size(256, 34);
            this.applyConfigButton.TabIndex = 9;
            this.applyConfigButton.Text = "Apply";
            this.applyConfigButton.UseVisualStyleBackColor = true;
            this.applyConfigButton.Click += new System.EventHandler(this.applyConfigButton_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 205);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(136, 20);
            this.label11.TabIndex = 8;
            this.label11.Text = "Max Tap Distance";
            // 
            // maxTapDistanceTextBox
            // 
            this.maxTapDistanceTextBox.Location = new System.Drawing.Point(14, 229);
            this.maxTapDistanceTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.maxTapDistanceTextBox.Name = "maxTapDistanceTextBox";
            this.maxTapDistanceTextBox.Size = new System.Drawing.Size(224, 26);
            this.maxTapDistanceTextBox.TabIndex = 7;
            this.maxTapDistanceTextBox.TextChanged += new System.EventHandler(this.configTextBox_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 205);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 20);
            this.label10.TabIndex = 6;
            // 
            // maxTapMillisecondsTextBox
            // 
            this.maxTapMillisecondsTextBox.Location = new System.Drawing.Point(14, 169);
            this.maxTapMillisecondsTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.maxTapMillisecondsTextBox.Name = "maxTapMillisecondsTextBox";
            this.maxTapMillisecondsTextBox.Size = new System.Drawing.Size(224, 26);
            this.maxTapMillisecondsTextBox.TabIndex = 5;
            this.maxTapMillisecondsTextBox.TextChanged += new System.EventHandler(this.configTextBox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 145);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(158, 20);
            this.label9.TabIndex = 4;
            this.label9.Text = "Max Tap Milliseconds";
            // 
            // triggerThresholdTextBox
            // 
            this.triggerThresholdTextBox.Location = new System.Drawing.Point(14, 109);
            this.triggerThresholdTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.triggerThresholdTextBox.Name = "triggerThresholdTextBox";
            this.triggerThresholdTextBox.Size = new System.Drawing.Size(224, 26);
            this.triggerThresholdTextBox.TabIndex = 3;
            this.triggerThresholdTextBox.TextChanged += new System.EventHandler(this.configTextBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 85);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(177, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Tap Pressure Threshold";
            // 
            // detectionThresholdTextBox
            // 
            this.detectionThresholdTextBox.Location = new System.Drawing.Point(14, 49);
            this.detectionThresholdTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.detectionThresholdTextBox.Name = "detectionThresholdTextBox";
            this.detectionThresholdTextBox.Size = new System.Drawing.Size(224, 26);
            this.detectionThresholdTextBox.TabIndex = 1;
            this.detectionThresholdTextBox.TextChanged += new System.EventHandler(this.configTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 25);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(248, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Min Pressure Detection Threshold";
            // 
            // settingsGroupBox
            // 
            this.settingsGroupBox.Controls.Add(this.startupCheckbox);
            this.settingsGroupBox.Location = new System.Drawing.Point(295, 9);
            this.settingsGroupBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.settingsGroupBox.Size = new System.Drawing.Size(176, 312);
            this.settingsGroupBox.TabIndex = 3;
            this.settingsGroupBox.TabStop = false;
            this.settingsGroupBox.Text = "Application Settings";
            // 
            // startupCheckbox
            // 
            this.startupCheckbox.AutoSize = true;
            this.startupCheckbox.Location = new System.Drawing.Point(12, 29);
            this.startupCheckbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.startupCheckbox.Name = "startupCheckbox";
            this.startupCheckbox.Size = new System.Drawing.Size(137, 24);
            this.startupCheckbox.TabIndex = 0;
            this.startupCheckbox.Text = "Run at startup";
            this.startupCheckbox.UseVisualStyleBackColor = true;
            this.startupCheckbox.CheckedChanged += new System.EventHandler(this.startupCheckbox_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(18, 18);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(740, 409);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.previousTapGroupBox);
            this.tabPage1.Controls.Add(this.activeContactDisplay4);
            this.tabPage1.Controls.Add(this.activeContactDisplay3);
            this.tabPage1.Controls.Add(this.activeContactDisplay2);
            this.tabPage1.Controls.Add(this.activeContactDisplay1);
            this.tabPage1.Controls.Add(this.activeContactDisplay5);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(732, 376);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Current Values";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // previousTapGroupBox
            // 
            this.previousTapGroupBox.Controls.Add(this.previousMaxDistanceLabel);
            this.previousTapGroupBox.Controls.Add(this.label4);
            this.previousTapGroupBox.Controls.Add(this.previousContactCountLabel);
            this.previousTapGroupBox.Controls.Add(this.label3);
            this.previousTapGroupBox.Controls.Add(this.previousDurationLabel);
            this.previousTapGroupBox.Controls.Add(this.label2);
            this.previousTapGroupBox.Controls.Add(this.previousMaxPressureLabel);
            this.previousTapGroupBox.Controls.Add(this.label1);
            this.previousTapGroupBox.Location = new System.Drawing.Point(20, 235);
            this.previousTapGroupBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.previousTapGroupBox.Name = "previousTapGroupBox";
            this.previousTapGroupBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.previousTapGroupBox.Size = new System.Drawing.Size(688, 83);
            this.previousTapGroupBox.TabIndex = 10;
            this.previousTapGroupBox.TabStop = false;
            this.previousTapGroupBox.Text = "Previous Tap";
            // 
            // previousMaxDistanceLabel
            // 
            this.previousMaxDistanceLabel.AutoSize = true;
            this.previousMaxDistanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previousMaxDistanceLabel.Location = new System.Drawing.Point(340, 51);
            this.previousMaxDistanceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.previousMaxDistanceLabel.Name = "previousMaxDistanceLabel";
            this.previousMaxDistanceLabel.Size = new System.Drawing.Size(19, 20);
            this.previousMaxDistanceLabel.TabIndex = 7;
            this.previousMaxDistanceLabel.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(340, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Max Contact Distance";
            // 
            // previousContactCountLabel
            // 
            this.previousContactCountLabel.AutoSize = true;
            this.previousContactCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previousContactCountLabel.Location = new System.Drawing.Point(552, 51);
            this.previousContactCountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.previousContactCountLabel.Name = "previousContactCountLabel";
            this.previousContactCountLabel.Size = new System.Drawing.Size(19, 20);
            this.previousContactCountLabel.TabIndex = 5;
            this.previousContactCountLabel.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(552, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Contact Count";
            // 
            // previousDurationLabel
            // 
            this.previousDurationLabel.AutoSize = true;
            this.previousDurationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previousDurationLabel.Location = new System.Drawing.Point(195, 51);
            this.previousDurationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.previousDurationLabel.Name = "previousDurationLabel";
            this.previousDurationLabel.Size = new System.Drawing.Size(19, 20);
            this.previousDurationLabel.TabIndex = 3;
            this.previousDurationLabel.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Duration (ms)";
            // 
            // previousMaxPressureLabel
            // 
            this.previousMaxPressureLabel.AutoSize = true;
            this.previousMaxPressureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previousMaxPressureLabel.Location = new System.Drawing.Point(9, 51);
            this.previousMaxPressureLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.previousMaxPressureLabel.Name = "previousMaxPressureLabel";
            this.previousMaxPressureLabel.Size = new System.Drawing.Size(19, 20);
            this.previousMaxPressureLabel.TabIndex = 1;
            this.previousMaxPressureLabel.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Maximum Pressure";
            // 
            // activeContactDisplay4
            // 
            this.activeContactDisplay4.Active = false;
            this.activeContactDisplay4.ContactIndex = 3;
            this.activeContactDisplay4.Location = new System.Drawing.Point(435, 9);
            this.activeContactDisplay4.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.activeContactDisplay4.Name = "activeContactDisplay4";
            this.activeContactDisplay4.Pressure = ((uint)(0u));
            this.activeContactDisplay4.Size = new System.Drawing.Size(132, 217);
            this.activeContactDisplay4.TabIndex = 9;
            this.activeContactDisplay4.X = ((uint)(0u));
            this.activeContactDisplay4.Y = ((uint)(0u));
            // 
            // activeContactDisplay3
            // 
            this.activeContactDisplay3.Active = false;
            this.activeContactDisplay3.ContactIndex = 2;
            this.activeContactDisplay3.Location = new System.Drawing.Point(294, 9);
            this.activeContactDisplay3.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.activeContactDisplay3.Name = "activeContactDisplay3";
            this.activeContactDisplay3.Pressure = ((uint)(0u));
            this.activeContactDisplay3.Size = new System.Drawing.Size(132, 217);
            this.activeContactDisplay3.TabIndex = 8;
            this.activeContactDisplay3.X = ((uint)(0u));
            this.activeContactDisplay3.Y = ((uint)(0u));
            // 
            // activeContactDisplay2
            // 
            this.activeContactDisplay2.Active = false;
            this.activeContactDisplay2.ContactIndex = 1;
            this.activeContactDisplay2.Location = new System.Drawing.Point(153, 9);
            this.activeContactDisplay2.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.activeContactDisplay2.Name = "activeContactDisplay2";
            this.activeContactDisplay2.Pressure = ((uint)(0u));
            this.activeContactDisplay2.Size = new System.Drawing.Size(132, 217);
            this.activeContactDisplay2.TabIndex = 7;
            this.activeContactDisplay2.X = ((uint)(0u));
            this.activeContactDisplay2.Y = ((uint)(0u));
            // 
            // activeContactDisplay1
            // 
            this.activeContactDisplay1.Active = false;
            this.activeContactDisplay1.ContactIndex = 0;
            this.activeContactDisplay1.Location = new System.Drawing.Point(20, 9);
            this.activeContactDisplay1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.activeContactDisplay1.Name = "activeContactDisplay1";
            this.activeContactDisplay1.Pressure = ((uint)(0u));
            this.activeContactDisplay1.Size = new System.Drawing.Size(132, 217);
            this.activeContactDisplay1.TabIndex = 6;
            this.activeContactDisplay1.X = ((uint)(0u));
            this.activeContactDisplay1.Y = ((uint)(0u));
            // 
            // activeContactDisplay5
            // 
            this.activeContactDisplay5.Active = false;
            this.activeContactDisplay5.ContactIndex = 4;
            this.activeContactDisplay5.Location = new System.Drawing.Point(576, 9);
            this.activeContactDisplay5.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.activeContactDisplay5.Name = "activeContactDisplay5";
            this.activeContactDisplay5.Pressure = ((uint)(0u));
            this.activeContactDisplay5.Size = new System.Drawing.Size(132, 217);
            this.activeContactDisplay5.TabIndex = 5;
            this.activeContactDisplay5.X = ((uint)(0u));
            this.activeContactDisplay5.Y = ((uint)(0u));
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dragGroupBox);
            this.tabPage2.Controls.Add(this.configGroupBox);
            this.tabPage2.Controls.Add(this.settingsGroupBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Size = new System.Drawing.Size(732, 376);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Configuration";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dragGroupBox
            // 
            this.dragGroupBox.Controls.Add(this.dragGapTimeTextbox);
            this.dragGroupBox.Controls.Add(this.label6);
            this.dragGroupBox.Location = new System.Drawing.Point(478, 14);
            this.dragGroupBox.Name = "dragGroupBox";
            this.dragGroupBox.Size = new System.Drawing.Size(247, 307);
            this.dragGroupBox.TabIndex = 4;
            this.dragGroupBox.TabStop = false;
            this.dragGroupBox.Text = "Double Tap and Drag Settings";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(6, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Max Gap Time Milliseconds";
            // 
            // dragGapTimeTextbox
            // 
            this.dragGapTimeTextbox.Location = new System.Drawing.Point(7, 49);
            this.dragGapTimeTextbox.Name = "dragGapTimeTextbox";
            this.dragGapTimeTextbox.Size = new System.Drawing.Size(234, 26);
            this.dragGapTimeTextbox.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 440);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Eve.TapToClick Configuration";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.notifyIconContextMenuStrip.ResumeLayout(false);
            this.configGroupBox.ResumeLayout(false);
            this.configGroupBox.PerformLayout();
            this.settingsGroupBox.ResumeLayout(false);
            this.settingsGroupBox.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.previousTapGroupBox.ResumeLayout(false);
            this.previousTapGroupBox.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.dragGroupBox.ResumeLayout(false);
            this.dragGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.GroupBox configGroupBox;
        private System.Windows.Forms.TextBox triggerThresholdTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox detectionThresholdTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox maxTapDistanceTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox maxTapMillisecondsTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button applyConfigButton;
        private System.Windows.Forms.ContextMenuStrip notifyIconContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem notifyIconExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notifyIconConfigureMenuItem;
        private System.Windows.Forms.GroupBox settingsGroupBox;
        private System.Windows.Forms.CheckBox startupCheckbox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ActiveContactDisplay activeContactDisplay5;
        private ActiveContactDisplay activeContactDisplay4;
        private ActiveContactDisplay activeContactDisplay3;
        private ActiveContactDisplay activeContactDisplay2;
        private ActiveContactDisplay activeContactDisplay1;
        private System.Windows.Forms.GroupBox previousTapGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label previousContactCountLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label previousDurationLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label previousMaxPressureLabel;
        private System.Windows.Forms.Label previousMaxDistanceLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox dragGroupBox;
        private System.Windows.Forms.TextBox dragGapTimeTextbox;
        private System.Windows.Forms.Label label6;
    }
}

