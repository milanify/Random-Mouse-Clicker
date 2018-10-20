namespace Random_Mouse_Clicker
{
    partial class CustomizeSettingsForm
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
            this.textBoxUserDefinedExitShortcut = new System.Windows.Forms.TextBox();
            this.buttonSaveSettings = new System.Windows.Forms.Button();
            this.labelExitProgramShortcut = new System.Windows.Forms.Label();
            this.numericClickEachTime = new System.Windows.Forms.NumericUpDown();
            this.labelNumberOfClicksEachTime = new System.Windows.Forms.Label();
            this.labelExampleShortcut = new System.Windows.Forms.Label();
            this.labelExampleClicksEachTime = new System.Windows.Forms.Label();
            this.labelPauseShortcut = new System.Windows.Forms.Label();
            this.labelPauseProgramShortcut = new System.Windows.Forms.Label();
            this.textBoxUserDefinedPauseShortcut = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericClickEachTime)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxUserDefinedExitShortcut
            // 
            this.textBoxUserDefinedExitShortcut.Location = new System.Drawing.Point(159, 12);
            this.textBoxUserDefinedExitShortcut.Name = "textBoxUserDefinedExitShortcut";
            this.textBoxUserDefinedExitShortcut.Size = new System.Drawing.Size(134, 20);
            this.textBoxUserDefinedExitShortcut.TabIndex = 0;
            this.textBoxUserDefinedExitShortcut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxUserDefinedExitShortcut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxUserDefinedExitShortcut_KeyDown);
            // 
            // buttonSaveSettings
            // 
            this.buttonSaveSettings.Location = new System.Drawing.Point(115, 152);
            this.buttonSaveSettings.Name = "buttonSaveSettings";
            this.buttonSaveSettings.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveSettings.TabIndex = 1;
            this.buttonSaveSettings.Text = "Save";
            this.buttonSaveSettings.UseVisualStyleBackColor = true;
            this.buttonSaveSettings.Click += new System.EventHandler(this.buttonSaveSettings_Click);
            // 
            // labelExitProgramShortcut
            // 
            this.labelExitProgramShortcut.AutoSize = true;
            this.labelExitProgramShortcut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExitProgramShortcut.Location = new System.Drawing.Point(12, 15);
            this.labelExitProgramShortcut.Name = "labelExitProgramShortcut";
            this.labelExitProgramShortcut.Size = new System.Drawing.Size(127, 13);
            this.labelExitProgramShortcut.TabIndex = 2;
            this.labelExitProgramShortcut.Text = "Exit program shortcut";
            // 
            // numericClickEachTime
            // 
            this.numericClickEachTime.Location = new System.Drawing.Point(179, 105);
            this.numericClickEachTime.Maximum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            0});
            this.numericClickEachTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericClickEachTime.Name = "numericClickEachTime";
            this.numericClickEachTime.Size = new System.Drawing.Size(79, 20);
            this.numericClickEachTime.TabIndex = 6;
            this.numericClickEachTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericClickEachTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelNumberOfClicksEachTime
            // 
            this.labelNumberOfClicksEachTime.AutoSize = true;
            this.labelNumberOfClicksEachTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumberOfClicksEachTime.Location = new System.Drawing.Point(12, 107);
            this.labelNumberOfClicksEachTime.Name = "labelNumberOfClicksEachTime";
            this.labelNumberOfClicksEachTime.Size = new System.Drawing.Size(161, 13);
            this.labelNumberOfClicksEachTime.TabIndex = 7;
            this.labelNumberOfClicksEachTime.Text = "Number of clicks each time";
            // 
            // labelExampleShortcut
            // 
            this.labelExampleShortcut.AutoSize = true;
            this.labelExampleShortcut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExampleShortcut.Location = new System.Drawing.Point(12, 35);
            this.labelExampleShortcut.Name = "labelExampleShortcut";
            this.labelExampleShortcut.Size = new System.Drawing.Size(265, 13);
            this.labelExampleShortcut.TabIndex = 8;
            this.labelExampleShortcut.Text = "(Use a combination of Ctrl, Alt, or Shift + one other key)";
            // 
            // labelExampleClicksEachTime
            // 
            this.labelExampleClicksEachTime.AutoSize = true;
            this.labelExampleClicksEachTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExampleClicksEachTime.Location = new System.Drawing.Point(12, 128);
            this.labelExampleClicksEachTime.Name = "labelExampleClicksEachTime";
            this.labelExampleClicksEachTime.Size = new System.Drawing.Size(266, 13);
            this.labelExampleClicksEachTime.TabIndex = 10;
            this.labelExampleClicksEachTime.Text = "(For example, setting this to two performs double clicks)";
            // 
            // labelPauseShortcut
            // 
            this.labelPauseShortcut.AutoSize = true;
            this.labelPauseShortcut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPauseShortcut.Location = new System.Drawing.Point(12, 82);
            this.labelPauseShortcut.Name = "labelPauseShortcut";
            this.labelPauseShortcut.Size = new System.Drawing.Size(207, 13);
            this.labelPauseShortcut.TabIndex = 13;
            this.labelPauseShortcut.Text = "(Must be different from the above shortcut)";
            // 
            // labelPauseProgramShortcut
            // 
            this.labelPauseProgramShortcut.AutoSize = true;
            this.labelPauseProgramShortcut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPauseProgramShortcut.Location = new System.Drawing.Point(12, 62);
            this.labelPauseProgramShortcut.Name = "labelPauseProgramShortcut";
            this.labelPauseProgramShortcut.Size = new System.Drawing.Size(141, 13);
            this.labelPauseProgramShortcut.TabIndex = 12;
            this.labelPauseProgramShortcut.Text = "Pause program shortcut";
            // 
            // textBoxUserDefinedPauseShortcut
            // 
            this.textBoxUserDefinedPauseShortcut.Location = new System.Drawing.Point(159, 59);
            this.textBoxUserDefinedPauseShortcut.Name = "textBoxUserDefinedPauseShortcut";
            this.textBoxUserDefinedPauseShortcut.Size = new System.Drawing.Size(134, 20);
            this.textBoxUserDefinedPauseShortcut.TabIndex = 11;
            this.textBoxUserDefinedPauseShortcut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxUserDefinedPauseShortcut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxUserDefinedPauseShortcut_KeyDown);
            // 
            // CustomizeSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 187);
            this.Controls.Add(this.labelPauseShortcut);
            this.Controls.Add(this.labelPauseProgramShortcut);
            this.Controls.Add(this.textBoxUserDefinedPauseShortcut);
            this.Controls.Add(this.labelExampleClicksEachTime);
            this.Controls.Add(this.labelExampleShortcut);
            this.Controls.Add(this.labelNumberOfClicksEachTime);
            this.Controls.Add(this.numericClickEachTime);
            this.Controls.Add(this.labelExitProgramShortcut);
            this.Controls.Add(this.buttonSaveSettings);
            this.Controls.Add(this.textBoxUserDefinedExitShortcut);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomizeSettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Customizable settings";
            this.Load += new System.EventHandler(this.CustomizeSettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericClickEachTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUserDefinedExitShortcut;
        private System.Windows.Forms.Button buttonSaveSettings;
        private System.Windows.Forms.Label labelExitProgramShortcut;
        private System.Windows.Forms.NumericUpDown numericClickEachTime;
        private System.Windows.Forms.Label labelNumberOfClicksEachTime;
        private System.Windows.Forms.Label labelExampleShortcut;
        private System.Windows.Forms.Label labelExampleClicksEachTime;
        private System.Windows.Forms.Label labelPauseShortcut;
        private System.Windows.Forms.Label labelPauseProgramShortcut;
        private System.Windows.Forms.TextBox textBoxUserDefinedPauseShortcut;
    }
}