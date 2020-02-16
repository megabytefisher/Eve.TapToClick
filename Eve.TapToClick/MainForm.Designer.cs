namespace Eve.TapToClick
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
            this.readingsDisplay = new System.Windows.Forms.GroupBox();
            this.secondContactActiveCheckbox = new System.Windows.Forms.CheckBox();
            this.firstContactActiveCheckbox = new System.Windows.Forms.CheckBox();
            this.firstYValueLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.firstXValueLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pressureValueLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lastTapDisplay = new System.Windows.Forms.GroupBox();
            this.twoFingerCheckbox = new System.Windows.Forms.CheckBox();
            this.triggerHitCheckbox = new System.Windows.Forms.CheckBox();
            this.contactDurationLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.deltaDistanceLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.maxPressureValueLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.notifyIconContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.notifyIconExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIconConfigureMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readingsDisplay.SuspendLayout();
            this.lastTapDisplay.SuspendLayout();
            this.configGroupBox.SuspendLayout();
            this.notifyIconContextMenuStrip.SuspendLayout();
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
            // readingsDisplay
            // 
            this.readingsDisplay.Controls.Add(this.secondContactActiveCheckbox);
            this.readingsDisplay.Controls.Add(this.firstContactActiveCheckbox);
            this.readingsDisplay.Controls.Add(this.firstYValueLabel);
            this.readingsDisplay.Controls.Add(this.label3);
            this.readingsDisplay.Controls.Add(this.firstXValueLabel);
            this.readingsDisplay.Controls.Add(this.label2);
            this.readingsDisplay.Controls.Add(this.pressureValueLabel);
            this.readingsDisplay.Controls.Add(this.label1);
            this.readingsDisplay.Location = new System.Drawing.Point(12, 12);
            this.readingsDisplay.Name = "readingsDisplay";
            this.readingsDisplay.Size = new System.Drawing.Size(154, 159);
            this.readingsDisplay.TabIndex = 0;
            this.readingsDisplay.TabStop = false;
            this.readingsDisplay.Text = "Current Values";
            // 
            // secondContactActiveCheckbox
            // 
            this.secondContactActiveCheckbox.AutoSize = true;
            this.secondContactActiveCheckbox.Location = new System.Drawing.Point(9, 135);
            this.secondContactActiveCheckbox.Name = "secondContactActiveCheckbox";
            this.secondContactActiveCheckbox.Size = new System.Drawing.Size(136, 17);
            this.secondContactActiveCheckbox.TabIndex = 2;
            this.secondContactActiveCheckbox.Text = "Second Contact Active";
            this.secondContactActiveCheckbox.UseVisualStyleBackColor = true;
            // 
            // firstContactActiveCheckbox
            // 
            this.firstContactActiveCheckbox.AutoSize = true;
            this.firstContactActiveCheckbox.Location = new System.Drawing.Point(9, 112);
            this.firstContactActiveCheckbox.Name = "firstContactActiveCheckbox";
            this.firstContactActiveCheckbox.Size = new System.Drawing.Size(118, 17);
            this.firstContactActiveCheckbox.TabIndex = 1;
            this.firstContactActiveCheckbox.Text = "First Contact Active";
            this.firstContactActiveCheckbox.UseVisualStyleBackColor = true;
            // 
            // firstYValueLabel
            // 
            this.firstYValueLabel.AutoSize = true;
            this.firstYValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstYValueLabel.Location = new System.Drawing.Point(6, 91);
            this.firstYValueLabel.Name = "firstYValueLabel";
            this.firstYValueLabel.Size = new System.Drawing.Size(14, 13);
            this.firstYValueLabel.TabIndex = 1;
            this.firstYValueLabel.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "First Contact Y Position";
            // 
            // firstXValueLabel
            // 
            this.firstXValueLabel.AutoSize = true;
            this.firstXValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstXValueLabel.Location = new System.Drawing.Point(6, 60);
            this.firstXValueLabel.Name = "firstXValueLabel";
            this.firstXValueLabel.Size = new System.Drawing.Size(14, 13);
            this.firstXValueLabel.TabIndex = 1;
            this.firstXValueLabel.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "First Contact X Position";
            // 
            // pressureValueLabel
            // 
            this.pressureValueLabel.AutoSize = true;
            this.pressureValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pressureValueLabel.Location = new System.Drawing.Point(6, 29);
            this.pressureValueLabel.Name = "pressureValueLabel";
            this.pressureValueLabel.Size = new System.Drawing.Size(14, 13);
            this.pressureValueLabel.TabIndex = 1;
            this.pressureValueLabel.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pressure";
            // 
            // lastTapDisplay
            // 
            this.lastTapDisplay.Controls.Add(this.twoFingerCheckbox);
            this.lastTapDisplay.Controls.Add(this.triggerHitCheckbox);
            this.lastTapDisplay.Controls.Add(this.contactDurationLabel);
            this.lastTapDisplay.Controls.Add(this.label8);
            this.lastTapDisplay.Controls.Add(this.deltaDistanceLabel);
            this.lastTapDisplay.Controls.Add(this.label6);
            this.lastTapDisplay.Controls.Add(this.maxPressureValueLabel);
            this.lastTapDisplay.Controls.Add(this.label4);
            this.lastTapDisplay.Location = new System.Drawing.Point(172, 12);
            this.lastTapDisplay.Name = "lastTapDisplay";
            this.lastTapDisplay.Size = new System.Drawing.Size(154, 159);
            this.lastTapDisplay.TabIndex = 1;
            this.lastTapDisplay.TabStop = false;
            this.lastTapDisplay.Text = "Last Contact Info";
            // 
            // twoFingerCheckbox
            // 
            this.twoFingerCheckbox.AutoSize = true;
            this.twoFingerCheckbox.Location = new System.Drawing.Point(8, 135);
            this.twoFingerCheckbox.Name = "twoFingerCheckbox";
            this.twoFingerCheckbox.Size = new System.Drawing.Size(84, 17);
            this.twoFingerCheckbox.TabIndex = 8;
            this.twoFingerCheckbox.Text = "Two Fingers";
            this.twoFingerCheckbox.UseVisualStyleBackColor = true;
            // 
            // triggerHitCheckbox
            // 
            this.triggerHitCheckbox.AutoSize = true;
            this.triggerHitCheckbox.Location = new System.Drawing.Point(8, 112);
            this.triggerHitCheckbox.Name = "triggerHitCheckbox";
            this.triggerHitCheckbox.Size = new System.Drawing.Size(75, 17);
            this.triggerHitCheckbox.TabIndex = 2;
            this.triggerHitCheckbox.Text = "Trigger Hit";
            this.triggerHitCheckbox.UseVisualStyleBackColor = true;
            // 
            // contactDurationLabel
            // 
            this.contactDurationLabel.AutoSize = true;
            this.contactDurationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactDurationLabel.Location = new System.Drawing.Point(6, 91);
            this.contactDurationLabel.Name = "contactDurationLabel";
            this.contactDurationLabel.Size = new System.Drawing.Size(14, 13);
            this.contactDurationLabel.TabIndex = 7;
            this.contactDurationLabel.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Contact Duration";
            // 
            // deltaDistanceLabel
            // 
            this.deltaDistanceLabel.AutoSize = true;
            this.deltaDistanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deltaDistanceLabel.Location = new System.Drawing.Point(6, 60);
            this.deltaDistanceLabel.Name = "deltaDistanceLabel";
            this.deltaDistanceLabel.Size = new System.Drawing.Size(14, 13);
            this.deltaDistanceLabel.TabIndex = 5;
            this.deltaDistanceLabel.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "First Contact Delta Distance";
            // 
            // maxPressureValueLabel
            // 
            this.maxPressureValueLabel.AutoSize = true;
            this.maxPressureValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxPressureValueLabel.Location = new System.Drawing.Point(6, 29);
            this.maxPressureValueLabel.Name = "maxPressureValueLabel";
            this.maxPressureValueLabel.Size = new System.Drawing.Size(14, 13);
            this.maxPressureValueLabel.TabIndex = 3;
            this.maxPressureValueLabel.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Maximum Pressure";
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
            this.configGroupBox.Location = new System.Drawing.Point(332, 12);
            this.configGroupBox.Name = "configGroupBox";
            this.configGroupBox.Size = new System.Drawing.Size(197, 203);
            this.configGroupBox.TabIndex = 2;
            this.configGroupBox.TabStop = false;
            this.configGroupBox.Text = "Configuration";
            // 
            // applyConfigButton
            // 
            this.applyConfigButton.Location = new System.Drawing.Point(6, 175);
            this.applyConfigButton.Name = "applyConfigButton";
            this.applyConfigButton.Size = new System.Drawing.Size(185, 22);
            this.applyConfigButton.TabIndex = 9;
            this.applyConfigButton.Text = "Apply";
            this.applyConfigButton.UseVisualStyleBackColor = true;
            this.applyConfigButton.Click += new System.EventHandler(this.applyConfigButton_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 133);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Max Tap Distance";
            // 
            // maxTapDistanceTextBox
            // 
            this.maxTapDistanceTextBox.Location = new System.Drawing.Point(6, 149);
            this.maxTapDistanceTextBox.Name = "maxTapDistanceTextBox";
            this.maxTapDistanceTextBox.Size = new System.Drawing.Size(185, 20);
            this.maxTapDistanceTextBox.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 13);
            this.label10.TabIndex = 6;
            // 
            // maxTapMillisecondsTextBox
            // 
            this.maxTapMillisecondsTextBox.Location = new System.Drawing.Point(6, 110);
            this.maxTapMillisecondsTextBox.Name = "maxTapMillisecondsTextBox";
            this.maxTapMillisecondsTextBox.Size = new System.Drawing.Size(185, 20);
            this.maxTapMillisecondsTextBox.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Max Tap Milliseconds";
            // 
            // triggerThresholdTextBox
            // 
            this.triggerThresholdTextBox.Location = new System.Drawing.Point(6, 71);
            this.triggerThresholdTextBox.Name = "triggerThresholdTextBox";
            this.triggerThresholdTextBox.Size = new System.Drawing.Size(185, 20);
            this.triggerThresholdTextBox.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Tap Pressure Threshold";
            // 
            // detectionThresholdTextBox
            // 
            this.detectionThresholdTextBox.Location = new System.Drawing.Point(6, 32);
            this.detectionThresholdTextBox.Name = "detectionThresholdTextBox";
            this.detectionThresholdTextBox.Size = new System.Drawing.Size(185, 20);
            this.detectionThresholdTextBox.TabIndex = 1;
            this.detectionThresholdTextBox.TextChanged += new System.EventHandler(this.detectionThresholdTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Min Pressure Detection Threshold";
            // 
            // notifyIconContextMenuStrip
            // 
            this.notifyIconContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notifyIconConfigureMenuItem,
            this.notifyIconExitMenuItem});
            this.notifyIconContextMenuStrip.Name = "notifyIconContextMenuStrip";
            this.notifyIconContextMenuStrip.Size = new System.Drawing.Size(137, 48);
            // 
            // notifyIconExitMenuItem
            // 
            this.notifyIconExitMenuItem.Name = "notifyIconExitMenuItem";
            this.notifyIconExitMenuItem.Size = new System.Drawing.Size(136, 22);
            this.notifyIconExitMenuItem.Text = "Exit";
            this.notifyIconExitMenuItem.Click += new System.EventHandler(this.notifyIconExitMenuItem_Click);
            // 
            // notifyIconConfigureMenuItem
            // 
            this.notifyIconConfigureMenuItem.Name = "notifyIconConfigureMenuItem";
            this.notifyIconConfigureMenuItem.Size = new System.Drawing.Size(136, 22);
            this.notifyIconConfigureMenuItem.Text = "Configure...";
            this.notifyIconConfigureMenuItem.Click += new System.EventHandler(this.notifyIconConfigureMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 227);
            this.Controls.Add(this.configGroupBox);
            this.Controls.Add(this.lastTapDisplay);
            this.Controls.Add(this.readingsDisplay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Eve.TapToClick Configuration";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.readingsDisplay.ResumeLayout(false);
            this.readingsDisplay.PerformLayout();
            this.lastTapDisplay.ResumeLayout(false);
            this.lastTapDisplay.PerformLayout();
            this.configGroupBox.ResumeLayout(false);
            this.configGroupBox.PerformLayout();
            this.notifyIconContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.GroupBox readingsDisplay;
        private System.Windows.Forms.Label pressureValueLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox secondContactActiveCheckbox;
        private System.Windows.Forms.CheckBox firstContactActiveCheckbox;
        private System.Windows.Forms.Label firstYValueLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label firstXValueLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox lastTapDisplay;
        private System.Windows.Forms.CheckBox twoFingerCheckbox;
        private System.Windows.Forms.CheckBox triggerHitCheckbox;
        private System.Windows.Forms.Label contactDurationLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label deltaDistanceLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label maxPressureValueLabel;
        private System.Windows.Forms.Label label4;
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
    }
}

