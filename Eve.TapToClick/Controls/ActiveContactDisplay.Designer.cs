namespace Eve.TapToClick.Controls
{
    partial class ActiveContactDisplay
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.valueGroupBox = new System.Windows.Forms.GroupBox();
            this.yLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.xLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pressureValueLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.activeCheckbox = new System.Windows.Forms.CheckBox();
            this.valueGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // valueGroupBox
            // 
            this.valueGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.valueGroupBox.Controls.Add(this.yLabel);
            this.valueGroupBox.Controls.Add(this.label4);
            this.valueGroupBox.Controls.Add(this.xLabel);
            this.valueGroupBox.Controls.Add(this.label2);
            this.valueGroupBox.Controls.Add(this.pressureValueLabel);
            this.valueGroupBox.Controls.Add(this.label1);
            this.valueGroupBox.Controls.Add(this.activeCheckbox);
            this.valueGroupBox.Location = new System.Drawing.Point(3, 3);
            this.valueGroupBox.Name = "valueGroupBox";
            this.valueGroupBox.Size = new System.Drawing.Size(86, 136);
            this.valueGroupBox.TabIndex = 0;
            this.valueGroupBox.TabStop = false;
            this.valueGroupBox.Text = "Contact #0";
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yLabel.Location = new System.Drawing.Point(6, 116);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(35, 13);
            this.yLabel.TabIndex = 6;
            this.yLabel.Text = "1234";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Y Value";
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel.Location = new System.Drawing.Point(6, 82);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(35, 13);
            this.xLabel.TabIndex = 4;
            this.xLabel.Text = "1234";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "X Value";
            // 
            // pressureValueLabel
            // 
            this.pressureValueLabel.AutoSize = true;
            this.pressureValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pressureValueLabel.Location = new System.Drawing.Point(6, 52);
            this.pressureValueLabel.Name = "pressureValueLabel";
            this.pressureValueLabel.Size = new System.Drawing.Size(21, 13);
            this.pressureValueLabel.TabIndex = 2;
            this.pressureValueLabel.Text = "12";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pressure";
            // 
            // activeCheckbox
            // 
            this.activeCheckbox.AutoSize = true;
            this.activeCheckbox.Location = new System.Drawing.Point(8, 19);
            this.activeCheckbox.Name = "activeCheckbox";
            this.activeCheckbox.Size = new System.Drawing.Size(56, 17);
            this.activeCheckbox.TabIndex = 0;
            this.activeCheckbox.Text = "Active";
            this.activeCheckbox.UseVisualStyleBackColor = true;
            // 
            // ActiveContractDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.valueGroupBox);
            this.Name = "ActiveContractDisplay";
            this.Size = new System.Drawing.Size(92, 142);
            this.valueGroupBox.ResumeLayout(false);
            this.valueGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox valueGroupBox;
        private System.Windows.Forms.Label pressureValueLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox activeCheckbox;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label label2;
    }
}
