namespace Random_Mouse_Clicker
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
            this.buttonDrawArea = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.comboBoxClickEveryMin = new System.Windows.Forms.ComboBox();
            this.numericClickEveryMin = new System.Windows.Forms.NumericUpDown();
            this.labelClickEvery = new System.Windows.Forms.Label();
            this.radioEndManually = new System.Windows.Forms.RadioButton();
            this.radioEndAutomatically = new System.Windows.Forms.RadioButton();
            this.groupBoxDuration = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxMouseMovement = new System.Windows.Forms.GroupBox();
            this.radioInstant = new System.Windows.Forms.RadioButton();
            this.radioFast = new System.Windows.Forms.RadioButton();
            this.radioNormal = new System.Windows.Forms.RadioButton();
            this.radioSlow = new System.Windows.Forms.RadioButton();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.numericClickEachArea = new System.Windows.Forms.NumericUpDown();
            this.numericDivideIntoEqualAreas = new System.Windows.Forms.NumericUpDown();
            this.checkBoxDivideInto = new System.Windows.Forms.CheckBox();
            this.labelTo = new System.Windows.Forms.Label();
            this.labelAfter = new System.Windows.Forms.Label();
            this.numericDuration = new System.Windows.Forms.NumericUpDown();
            this.comboBoxDuration = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabBasic = new System.Windows.Forms.TabPage();
            this.numericClickEveryMax = new System.Windows.Forms.NumericUpDown();
            this.labelCannotBeChanged = new System.Windows.Forms.Label();
            this.tabAdvanced = new System.Windows.Forms.TabPage();
            this.labelWidthHeight = new System.Windows.Forms.Label();
            this.tabPreview = new System.Windows.Forms.TabPage();
            this.labelPreviewInstructions = new System.Windows.Forms.Label();
            this.previewPictureBox = new System.Windows.Forms.PictureBox();
            this.labelClickEachArea = new System.Windows.Forms.Label();
            this.labelClickEachTimes = new System.Windows.Forms.Label();
            this.comboBoxDividedAreas = new System.Windows.Forms.ComboBox();
            this.labelOf = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericClickEveryMin)).BeginInit();
            this.groupBoxMouseMovement.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericClickEachArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDivideIntoEqualAreas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDuration)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericClickEveryMax)).BeginInit();
            this.tabAdvanced.SuspendLayout();
            this.tabPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonDrawArea
            // 
            this.buttonDrawArea.Location = new System.Drawing.Point(105, 16);
            this.buttonDrawArea.Name = "buttonDrawArea";
            this.buttonDrawArea.Size = new System.Drawing.Size(124, 23);
            this.buttonDrawArea.TabIndex = 0;
            this.buttonDrawArea.Text = "Draw Clicking Area";
            this.toolTip1.SetToolTip(this.buttonDrawArea, "Draw the area to click within");
            this.buttonDrawArea.UseVisualStyleBackColor = true;
            this.buttonDrawArea.Click += new System.EventHandler(this.selectAreaButton_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Location = new System.Drawing.Point(130, 250);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.toolTip1.SetToolTip(this.buttonStart, "Begin clicking");
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.startButton_Click);
            // 
            // comboBoxClickEveryMin
            // 
            this.comboBoxClickEveryMin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClickEveryMin.DropDownWidth = 75;
            this.comboBoxClickEveryMin.FormattingEnabled = true;
            this.comboBoxClickEveryMin.Items.AddRange(new object[] {
            "millisecond(s)",
            "second(s)",
            "minute(s)",
            "hour(s)",
            "day(s)"});
            this.comboBoxClickEveryMin.Location = new System.Drawing.Point(120, 92);
            this.comboBoxClickEveryMin.Name = "comboBoxClickEveryMin";
            this.comboBoxClickEveryMin.Size = new System.Drawing.Size(93, 21);
            this.comboBoxClickEveryMin.TabIndex = 4;
            // 
            // numericClickEveryMin
            // 
            this.numericClickEveryMin.Location = new System.Drawing.Point(48, 64);
            this.numericClickEveryMin.Maximum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            0});
            this.numericClickEveryMin.Name = "numericClickEveryMin";
            this.numericClickEveryMin.Size = new System.Drawing.Size(100, 20);
            this.numericClickEveryMin.TabIndex = 5;
            this.numericClickEveryMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericClickEveryMin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelClickEvery
            // 
            this.labelClickEvery.AutoSize = true;
            this.labelClickEvery.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClickEvery.Location = new System.Drawing.Point(45, 48);
            this.labelClickEvery.Name = "labelClickEvery";
            this.labelClickEvery.Size = new System.Drawing.Size(71, 13);
            this.labelClickEvery.TabIndex = 6;
            this.labelClickEvery.Text = "Click Every";
            this.toolTip1.SetToolTip(this.labelClickEvery, "Set the time between clicks");
            // 
            // radioEndManually
            // 
            this.radioEndManually.AutoSize = true;
            this.radioEndManually.Checked = true;
            this.radioEndManually.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioEndManually.Location = new System.Drawing.Point(43, 125);
            this.radioEndManually.Name = "radioEndManually";
            this.radioEndManually.Size = new System.Drawing.Size(101, 30);
            this.radioEndManually.TabIndex = 8;
            this.radioEndManually.TabStop = true;
            this.radioEndManually.Text = "End Manually\r\n(ESC key)";
            this.toolTip1.SetToolTip(this.radioEndManually, "Stop the program manually");
            this.radioEndManually.UseVisualStyleBackColor = true;
            this.radioEndManually.CheckedChanged += new System.EventHandler(this.endManuallyRadio_CheckedChanged);
            // 
            // radioEndAutomatically
            // 
            this.radioEndAutomatically.AutoSize = true;
            this.radioEndAutomatically.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioEndAutomatically.Location = new System.Drawing.Point(176, 132);
            this.radioEndAutomatically.Name = "radioEndAutomatically";
            this.radioEndAutomatically.Size = new System.Drawing.Size(126, 17);
            this.radioEndAutomatically.TabIndex = 9;
            this.radioEndAutomatically.Text = "End Automatically";
            this.toolTip1.SetToolTip(this.radioEndAutomatically, "Stop the program when finished");
            this.radioEndAutomatically.UseVisualStyleBackColor = true;
            this.radioEndAutomatically.CheckedChanged += new System.EventHandler(this.endAutomaticallyRadio_CheckedChanged);
            // 
            // groupBoxDuration
            // 
            this.groupBoxDuration.Enabled = false;
            this.groupBoxDuration.Location = new System.Drawing.Point(29, 172);
            this.groupBoxDuration.Name = "groupBoxDuration";
            this.groupBoxDuration.Size = new System.Drawing.Size(273, 70);
            this.groupBoxDuration.TabIndex = 10;
            this.groupBoxDuration.TabStop = false;
            this.groupBoxDuration.Text = "Duration";
            this.toolTip1.SetToolTip(this.groupBoxDuration, "How long to run the program for");
            // 
            // groupBoxMouseMovement
            // 
            this.groupBoxMouseMovement.Controls.Add(this.radioInstant);
            this.groupBoxMouseMovement.Controls.Add(this.radioFast);
            this.groupBoxMouseMovement.Controls.Add(this.radioNormal);
            this.groupBoxMouseMovement.Controls.Add(this.radioSlow);
            this.groupBoxMouseMovement.Location = new System.Drawing.Point(19, 189);
            this.groupBoxMouseMovement.Name = "groupBoxMouseMovement";
            this.groupBoxMouseMovement.Size = new System.Drawing.Size(299, 78);
            this.groupBoxMouseMovement.TabIndex = 3;
            this.groupBoxMouseMovement.TabStop = false;
            this.groupBoxMouseMovement.Text = "Mouse Movement";
            this.toolTip1.SetToolTip(this.groupBoxMouseMovement, "Set the mouse movement speed");
            // 
            // radioInstant
            // 
            this.radioInstant.AutoSize = true;
            this.radioInstant.Location = new System.Drawing.Point(212, 36);
            this.radioInstant.Name = "radioInstant";
            this.radioInstant.Size = new System.Drawing.Size(57, 17);
            this.radioInstant.TabIndex = 3;
            this.radioInstant.Text = "Instant";
            this.radioInstant.UseVisualStyleBackColor = true;
            // 
            // radioFast
            // 
            this.radioFast.AutoSize = true;
            this.radioFast.Location = new System.Drawing.Point(154, 36);
            this.radioFast.Name = "radioFast";
            this.radioFast.Size = new System.Drawing.Size(45, 17);
            this.radioFast.TabIndex = 2;
            this.radioFast.Text = "Fast";
            this.radioFast.UseVisualStyleBackColor = true;
            // 
            // radioNormal
            // 
            this.radioNormal.AutoSize = true;
            this.radioNormal.Checked = true;
            this.radioNormal.Location = new System.Drawing.Point(86, 36);
            this.radioNormal.Name = "radioNormal";
            this.radioNormal.Size = new System.Drawing.Size(58, 17);
            this.radioNormal.TabIndex = 1;
            this.radioNormal.TabStop = true;
            this.radioNormal.Text = "Normal";
            this.radioNormal.UseVisualStyleBackColor = true;
            // 
            // radioSlow
            // 
            this.radioSlow.AutoSize = true;
            this.radioSlow.Location = new System.Drawing.Point(26, 36);
            this.radioSlow.Name = "radioSlow";
            this.radioSlow.Size = new System.Drawing.Size(48, 17);
            this.radioSlow.TabIndex = 0;
            this.radioSlow.Text = "Slow";
            this.radioSlow.UseVisualStyleBackColor = true;
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.labelOf);
            this.groupBoxOptions.Controls.Add(this.comboBoxDividedAreas);
            this.groupBoxOptions.Controls.Add(this.labelClickEachTimes);
            this.groupBoxOptions.Controls.Add(this.labelClickEachArea);
            this.groupBoxOptions.Controls.Add(this.numericClickEachArea);
            this.groupBoxOptions.Controls.Add(this.numericDivideIntoEqualAreas);
            this.groupBoxOptions.Controls.Add(this.checkBoxDivideInto);
            this.groupBoxOptions.Location = new System.Drawing.Point(19, 61);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(299, 113);
            this.groupBoxOptions.TabIndex = 2;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Options";
            this.toolTip1.SetToolTip(this.groupBoxOptions, "Divide your drawn area into sub-areas");
            // 
            // numericClickEachArea
            // 
            this.numericClickEachArea.Enabled = false;
            this.numericClickEachArea.Location = new System.Drawing.Point(118, 79);
            this.numericClickEachArea.Maximum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            0});
            this.numericClickEachArea.Name = "numericClickEachArea";
            this.numericClickEachArea.Size = new System.Drawing.Size(100, 20);
            this.numericClickEachArea.TabIndex = 9;
            this.numericClickEachArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericClickEachArea.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericClickEachArea.ValueChanged += new System.EventHandler(this.numericClickEachArea_ValueChanged);
            // 
            // numericDivideIntoEqualAreas
            // 
            this.numericDivideIntoEqualAreas.Enabled = false;
            this.numericDivideIntoEqualAreas.Location = new System.Drawing.Point(105, 18);
            this.numericDivideIntoEqualAreas.Maximum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            0});
            this.numericDivideIntoEqualAreas.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericDivideIntoEqualAreas.Name = "numericDivideIntoEqualAreas";
            this.numericDivideIntoEqualAreas.Size = new System.Drawing.Size(100, 20);
            this.numericDivideIntoEqualAreas.TabIndex = 6;
            this.numericDivideIntoEqualAreas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericDivideIntoEqualAreas.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericDivideIntoEqualAreas.ValueChanged += new System.EventHandler(this.numericDivideIntoEqualAreas_ValueChanged);
            // 
            // checkBoxDivideInto
            // 
            this.checkBoxDivideInto.AutoSize = true;
            this.checkBoxDivideInto.Enabled = false;
            this.checkBoxDivideInto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxDivideInto.Location = new System.Drawing.Point(19, 19);
            this.checkBoxDivideInto.Name = "checkBoxDivideInto";
            this.checkBoxDivideInto.Size = new System.Drawing.Size(265, 17);
            this.checkBoxDivideInto.TabIndex = 1;
            this.checkBoxDivideInto.Text = "Divide into                            equal areas";
            this.checkBoxDivideInto.UseVisualStyleBackColor = true;
            this.checkBoxDivideInto.CheckedChanged += new System.EventHandler(this.divideIntoEqualAreasCheckbox_CheckedChanged);
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTo.Location = new System.Drawing.Point(157, 66);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(18, 13);
            this.labelTo.TabIndex = 17;
            this.labelTo.Text = "to";
            this.toolTip1.SetToolTip(this.labelTo, "Set the time between clicks");
            // 
            // labelAfter
            // 
            this.labelAfter.AutoSize = true;
            this.labelAfter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAfter.Location = new System.Drawing.Point(59, 190);
            this.labelAfter.Name = "labelAfter";
            this.labelAfter.Size = new System.Drawing.Size(34, 13);
            this.labelAfter.TabIndex = 13;
            this.labelAfter.Text = "After";
            // 
            // numericDuration
            // 
            this.numericDuration.Enabled = false;
            this.numericDuration.Location = new System.Drawing.Point(62, 206);
            this.numericDuration.Maximum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            0});
            this.numericDuration.Name = "numericDuration";
            this.numericDuration.Size = new System.Drawing.Size(100, 20);
            this.numericDuration.TabIndex = 12;
            this.numericDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericDuration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comboBoxDuration
            // 
            this.comboBoxDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDuration.DropDownWidth = 75;
            this.comboBoxDuration.Enabled = false;
            this.comboBoxDuration.FormattingEnabled = true;
            this.comboBoxDuration.Items.AddRange(new object[] {
            "click(s)",
            "millisecond(s)",
            "second(s)",
            "minute(s)",
            "hour(s)",
            "day(s)"});
            this.comboBoxDuration.Location = new System.Drawing.Point(177, 205);
            this.comboBoxDuration.Name = "comboBoxDuration";
            this.comboBoxDuration.Size = new System.Drawing.Size(93, 21);
            this.comboBoxDuration.TabIndex = 11;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabBasic);
            this.tabControl1.Controls.Add(this.tabAdvanced);
            this.tabControl1.Controls.Add(this.tabPreview);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(334, 312);
            this.tabControl1.TabIndex = 14;
            // 
            // tabBasic
            // 
            this.tabBasic.Controls.Add(this.labelTo);
            this.tabBasic.Controls.Add(this.numericClickEveryMax);
            this.tabBasic.Controls.Add(this.labelCannotBeChanged);
            this.tabBasic.Controls.Add(this.buttonDrawArea);
            this.tabBasic.Controls.Add(this.labelAfter);
            this.tabBasic.Controls.Add(this.buttonStart);
            this.tabBasic.Controls.Add(this.numericDuration);
            this.tabBasic.Controls.Add(this.comboBoxClickEveryMin);
            this.tabBasic.Controls.Add(this.comboBoxDuration);
            this.tabBasic.Controls.Add(this.numericClickEveryMin);
            this.tabBasic.Controls.Add(this.groupBoxDuration);
            this.tabBasic.Controls.Add(this.labelClickEvery);
            this.tabBasic.Controls.Add(this.radioEndAutomatically);
            this.tabBasic.Controls.Add(this.radioEndManually);
            this.tabBasic.Location = new System.Drawing.Point(4, 22);
            this.tabBasic.Name = "tabBasic";
            this.tabBasic.Padding = new System.Windows.Forms.Padding(3);
            this.tabBasic.Size = new System.Drawing.Size(326, 286);
            this.tabBasic.TabIndex = 0;
            this.tabBasic.Text = "Basic";
            this.tabBasic.UseVisualStyleBackColor = true;
            // 
            // numericClickEveryMax
            // 
            this.numericClickEveryMax.Location = new System.Drawing.Point(189, 64);
            this.numericClickEveryMax.Maximum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            0});
            this.numericClickEveryMax.Name = "numericClickEveryMax";
            this.numericClickEveryMax.Size = new System.Drawing.Size(100, 20);
            this.numericClickEveryMax.TabIndex = 16;
            this.numericClickEveryMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericClickEveryMax.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // labelCannotBeChanged
            // 
            this.labelCannotBeChanged.AutoSize = true;
            this.labelCannotBeChanged.ForeColor = System.Drawing.Color.Red;
            this.labelCannotBeChanged.Location = new System.Drawing.Point(18, 156);
            this.labelCannotBeChanged.Name = "labelCannotBeChanged";
            this.labelCannotBeChanged.Size = new System.Drawing.Size(292, 13);
            this.labelCannotBeChanged.TabIndex = 14;
            this.labelCannotBeChanged.Text = "Cannot be changed due to choosing to divide into sub-areas";
            this.labelCannotBeChanged.Visible = false;
            // 
            // tabAdvanced
            // 
            this.tabAdvanced.Controls.Add(this.groupBoxMouseMovement);
            this.tabAdvanced.Controls.Add(this.groupBoxOptions);
            this.tabAdvanced.Controls.Add(this.labelWidthHeight);
            this.tabAdvanced.Location = new System.Drawing.Point(4, 22);
            this.tabAdvanced.Name = "tabAdvanced";
            this.tabAdvanced.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdvanced.Size = new System.Drawing.Size(326, 286);
            this.tabAdvanced.TabIndex = 1;
            this.tabAdvanced.Text = "Advanced";
            this.tabAdvanced.UseVisualStyleBackColor = true;
            // 
            // labelWidthHeight
            // 
            this.labelWidthHeight.AutoSize = true;
            this.labelWidthHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWidthHeight.Location = new System.Drawing.Point(69, 19);
            this.labelWidthHeight.Name = "labelWidthHeight";
            this.labelWidthHeight.Size = new System.Drawing.Size(189, 30);
            this.labelWidthHeight.TabIndex = 0;
            this.labelWidthHeight.Text = "Draw an area in the first tab to \r\nview width and height information";
            // 
            // tabPreview
            // 
            this.tabPreview.Controls.Add(this.labelPreviewInstructions);
            this.tabPreview.Controls.Add(this.previewPictureBox);
            this.tabPreview.Location = new System.Drawing.Point(4, 22);
            this.tabPreview.Name = "tabPreview";
            this.tabPreview.Size = new System.Drawing.Size(326, 286);
            this.tabPreview.TabIndex = 2;
            this.tabPreview.Text = "Preview";
            this.tabPreview.UseVisualStyleBackColor = true;
            // 
            // labelPreviewInstructions
            // 
            this.labelPreviewInstructions.AutoSize = true;
            this.labelPreviewInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPreviewInstructions.Location = new System.Drawing.Point(64, 118);
            this.labelPreviewInstructions.Name = "labelPreviewInstructions";
            this.labelPreviewInstructions.Size = new System.Drawing.Size(207, 30);
            this.labelPreviewInstructions.TabIndex = 1;
            this.labelPreviewInstructions.Text = "Draw an area in the first tab to \r\nview a preview of what will be clicked";
            // 
            // previewPictureBox
            // 
            this.previewPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewPictureBox.Location = new System.Drawing.Point(0, 0);
            this.previewPictureBox.Name = "previewPictureBox";
            this.previewPictureBox.Size = new System.Drawing.Size(326, 286);
            this.previewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.previewPictureBox.TabIndex = 0;
            this.previewPictureBox.TabStop = false;
            this.previewPictureBox.Visible = false;
            // 
            // labelClickEachArea
            // 
            this.labelClickEachArea.AutoSize = true;
            this.labelClickEachArea.Enabled = false;
            this.labelClickEachArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClickEachArea.Location = new System.Drawing.Point(16, 81);
            this.labelClickEachArea.Name = "labelClickEachArea";
            this.labelClickEachArea.Size = new System.Drawing.Size(96, 13);
            this.labelClickEachArea.TabIndex = 10;
            this.labelClickEachArea.Text = "Click each area";
            this.toolTip1.SetToolTip(this.labelClickEachArea, "Set the time between clicks");
            // 
            // labelClickEachTimes
            // 
            this.labelClickEachTimes.AutoSize = true;
            this.labelClickEachTimes.Enabled = false;
            this.labelClickEachTimes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClickEachTimes.Location = new System.Drawing.Point(225, 81);
            this.labelClickEachTimes.Name = "labelClickEachTimes";
            this.labelClickEachTimes.Size = new System.Drawing.Size(44, 13);
            this.labelClickEachTimes.TabIndex = 11;
            this.labelClickEachTimes.Text = "time(s)";
            this.toolTip1.SetToolTip(this.labelClickEachTimes, "Set the time between clicks");
            // 
            // comboBoxDividedAreas
            // 
            this.comboBoxDividedAreas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDividedAreas.Enabled = false;
            this.comboBoxDividedAreas.FormattingEnabled = true;
            this.comboBoxDividedAreas.Location = new System.Drawing.Point(97, 47);
            this.comboBoxDividedAreas.Name = "comboBoxDividedAreas";
            this.comboBoxDividedAreas.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDividedAreas.TabIndex = 12;
            // 
            // labelOf
            // 
            this.labelOf.AutoSize = true;
            this.labelOf.Enabled = false;
            this.labelOf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOf.Location = new System.Drawing.Point(72, 50);
            this.labelOf.Name = "labelOf";
            this.labelOf.Size = new System.Drawing.Size(18, 13);
            this.labelOf.TabIndex = 13;
            this.labelOf.Text = "of";
            this.toolTip1.SetToolTip(this.labelOf, "Set the time between clicks");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(334, 312);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Random Mouse Clicker";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericClickEveryMin)).EndInit();
            this.groupBoxMouseMovement.ResumeLayout(false);
            this.groupBoxMouseMovement.PerformLayout();
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericClickEachArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDivideIntoEqualAreas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDuration)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabBasic.ResumeLayout(false);
            this.tabBasic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericClickEveryMax)).EndInit();
            this.tabAdvanced.ResumeLayout(false);
            this.tabAdvanced.PerformLayout();
            this.tabPreview.ResumeLayout(false);
            this.tabPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonDrawArea;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.ComboBox comboBoxClickEveryMin;
        private System.Windows.Forms.NumericUpDown numericClickEveryMin;
        private System.Windows.Forms.Label labelClickEvery;
        private System.Windows.Forms.RadioButton radioEndManually;
        private System.Windows.Forms.RadioButton radioEndAutomatically;
        private System.Windows.Forms.GroupBox groupBoxDuration;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label labelAfter;
        private System.Windows.Forms.NumericUpDown numericDuration;
        private System.Windows.Forms.ComboBox comboBoxDuration;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabBasic;
        private System.Windows.Forms.TabPage tabAdvanced;
        private System.Windows.Forms.TabPage tabPreview;
        private System.Windows.Forms.Label labelWidthHeight;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.NumericUpDown numericDivideIntoEqualAreas;
        private System.Windows.Forms.CheckBox checkBoxDivideInto;
        private System.Windows.Forms.NumericUpDown numericClickEachArea;
        private System.Windows.Forms.Label labelCannotBeChanged;
        private System.Windows.Forms.PictureBox previewPictureBox;
        private System.Windows.Forms.GroupBox groupBoxMouseMovement;
        private System.Windows.Forms.RadioButton radioInstant;
        private System.Windows.Forms.RadioButton radioFast;
        private System.Windows.Forms.RadioButton radioNormal;
        private System.Windows.Forms.RadioButton radioSlow;
        private System.Windows.Forms.Label labelPreviewInstructions;
        private System.Windows.Forms.NumericUpDown numericClickEveryMax;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.Label labelClickEachTimes;
        private System.Windows.Forms.Label labelClickEachArea;
        private System.Windows.Forms.ComboBox comboBoxDividedAreas;
        private System.Windows.Forms.Label labelOf;
    }
}

