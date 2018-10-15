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
            this.textBoxUserDefinedShortcut = new System.Windows.Forms.TextBox();
            this.buttonSaveSettings = new System.Windows.Forms.Button();
            this.labelExitProgramShortcut = new System.Windows.Forms.Label();
            this.checkBoxRestartProgramUsingShortcut = new System.Windows.Forms.CheckBox();
            this.numericClickEachTime = new System.Windows.Forms.NumericUpDown();
            this.labelNumberOfClicksEachTime = new System.Windows.Forms.Label();
            this.labelExampleShortcut = new System.Windows.Forms.Label();
            this.labelExampleClicksEachTime = new System.Windows.Forms.Label();
            this.labelRestartProgramUsingShortcut = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericClickEachTime)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxUserDefinedShortcut
            // 
            this.textBoxUserDefinedShortcut.Location = new System.Drawing.Point(145, 12);
            this.textBoxUserDefinedShortcut.Name = "textBoxUserDefinedShortcut";
            this.textBoxUserDefinedShortcut.Size = new System.Drawing.Size(148, 20);
            this.textBoxUserDefinedShortcut.TabIndex = 0;
            this.textBoxUserDefinedShortcut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxUserDefinedShortcut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxUserDefinedShortcut_KeyDown);
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
            // checkBoxRestartProgramUsingShortcut
            // 
            this.checkBoxRestartProgramUsingShortcut.AutoSize = true;
            this.checkBoxRestartProgramUsingShortcut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxRestartProgramUsingShortcut.Location = new System.Drawing.Point(15, 61);
            this.checkBoxRestartProgramUsingShortcut.Name = "checkBoxRestartProgramUsingShortcut";
            this.checkBoxRestartProgramUsingShortcut.Size = new System.Drawing.Size(276, 17);
            this.checkBoxRestartProgramUsingShortcut.TabIndex = 3;
            this.checkBoxRestartProgramUsingShortcut.Text = "Restart the program after using exit shortcut";
            this.checkBoxRestartProgramUsingShortcut.UseVisualStyleBackColor = true;
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
            this.labelExampleShortcut.Size = new System.Drawing.Size(215, 13);
            this.labelExampleShortcut.TabIndex = 8;
            this.labelExampleShortcut.Text = "(Click the textbox then hold down your keys)";
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
            // labelRestartProgramUsingShortcut
            // 
            this.labelRestartProgramUsingShortcut.AutoSize = true;
            this.labelRestartProgramUsingShortcut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRestartProgramUsingShortcut.Location = new System.Drawing.Point(12, 81);
            this.labelRestartProgramUsingShortcut.Name = "labelRestartProgramUsingShortcut";
            this.labelRestartProgramUsingShortcut.Size = new System.Drawing.Size(85, 13);
            this.labelRestartProgramUsingShortcut.TabIndex = 11;
            this.labelRestartProgramUsingShortcut.Text = "(Recommended)";
            // 
            // CustomizeSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 187);
            this.Controls.Add(this.labelRestartProgramUsingShortcut);
            this.Controls.Add(this.labelExampleClicksEachTime);
            this.Controls.Add(this.labelExampleShortcut);
            this.Controls.Add(this.labelNumberOfClicksEachTime);
            this.Controls.Add(this.numericClickEachTime);
            this.Controls.Add(this.checkBoxRestartProgramUsingShortcut);
            this.Controls.Add(this.labelExitProgramShortcut);
            this.Controls.Add(this.buttonSaveSettings);
            this.Controls.Add(this.textBoxUserDefinedShortcut);
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

        private System.Windows.Forms.TextBox textBoxUserDefinedShortcut;
        private System.Windows.Forms.Button buttonSaveSettings;
        private System.Windows.Forms.Label labelExitProgramShortcut;
        private System.Windows.Forms.CheckBox checkBoxRestartProgramUsingShortcut;
        private System.Windows.Forms.NumericUpDown numericClickEachTime;
        private System.Windows.Forms.Label labelNumberOfClicksEachTime;
        private System.Windows.Forms.Label labelExampleShortcut;
        private System.Windows.Forms.Label labelExampleClicksEachTime;
        private System.Windows.Forms.Label labelRestartProgramUsingShortcut;
    }
}