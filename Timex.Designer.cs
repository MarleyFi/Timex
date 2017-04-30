namespace Timex
{
    partial class TimexForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimexForm));
            this.buttonStart = new System.Windows.Forms.Button();
            this.checkBoxPCShutdown = new System.Windows.Forms.CheckBox();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.groupBoxDateTime = new System.Windows.Forms.GroupBox();
            this.labelPredictTime = new System.Windows.Forms.Label();
            this.buttonStop = new System.Windows.Forms.Button();
            this.labelTimer = new System.Windows.Forms.Label();
            this.labelStartTime = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemReset = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPreferences = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPanel = new System.Windows.Forms.TabControl();
            this.tabPageTime = new System.Windows.Forms.TabPage();
            this.labelHourOrMinute = new System.Windows.Forms.Label();
            this.groupBoxStatistics = new System.Windows.Forms.GroupBox();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonClipboardAll = new System.Windows.Forms.Button();
            this.buttonClipboard3 = new System.Windows.Forms.Button();
            this.textBoxStartTime = new System.Windows.Forms.TextBox();
            this.labelCurrentWeek = new System.Windows.Forms.Label();
            this.buttonClipboard2 = new System.Windows.Forms.Button();
            this.buttonClipboard1 = new System.Windows.Forms.Button();
            this.textBoxWeeklySurplus = new System.Windows.Forms.TextBox();
            this.labelWeeklySurplus = new System.Windows.Forms.Label();
            this.textBoxWorkedToday = new System.Windows.Forms.TextBox();
            this.labelWorkedToday = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tabPageData = new System.Windows.Forms.TabPage();
            this.groupBoxData = new System.Windows.Forms.GroupBox();
            this.labelCurrentCalendarWeek = new System.Windows.Forms.Label();
            this.buttonResizeDataGrid = new System.Windows.Forms.Button();
            this.comboBoxCalendarWeek = new System.Windows.Forms.ComboBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.tabPagePreferences = new System.Windows.Forms.TabPage();
            this.groupBoxEdit = new System.Windows.Forms.GroupBox();
            this.checkBoxAllowEdit = new System.Windows.Forms.CheckBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.groupBoxWorkingTime = new System.Windows.Forms.GroupBox();
            this.buttonPreferencesSubmit = new System.Windows.Forms.Button();
            this.labelPreferencesMinutes = new System.Windows.Forms.Label();
            this.labelPreferencesHours = new System.Windows.Forms.Label();
            this.labelPreferencesSeconds = new System.Windows.Forms.Label();
            this.numericUpDownHours = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMinutes = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSeconds = new System.Windows.Forms.NumericUpDown();
            this.groupBoxDateTime.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabPanel.SuspendLayout();
            this.tabPageTime.SuspendLayout();
            this.groupBoxStatistics.SuspendLayout();
            this.tabPageData.SuspendLayout();
            this.groupBoxData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tabPagePreferences.SuspendLayout();
            this.groupBoxEdit.SuspendLayout();
            this.groupBoxWorkingTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeconds)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("MS Reference Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Image = global::Timex.Properties.Resources._1444157651_icon_play;
            this.buttonStart.Location = new System.Drawing.Point(6, 156);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(50, 46);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // checkBoxPCShutdown
            // 
            this.checkBoxPCShutdown.AutoSize = true;
            this.checkBoxPCShutdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxPCShutdown.Location = new System.Drawing.Point(6, 120);
            this.checkBoxPCShutdown.Name = "checkBoxPCShutdown";
            this.checkBoxPCShutdown.Size = new System.Drawing.Size(176, 17);
            this.checkBoxPCShutdown.TabIndex = 1;
            this.checkBoxPCShutdown.Text = "Shutdown PC on Countdown (*)";
            this.checkBoxPCShutdown.UseVisualStyleBackColor = true;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(6, 19);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(60, 13);
            this.labelDate.TabIndex = 2;
            this.labelDate.Text = "ActualDate";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.Location = new System.Drawing.Point(138, 19);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(70, 13);
            this.labelTime.TabIndex = 3;
            this.labelTime.Text = "ActualTime";
            // 
            // groupBoxDateTime
            // 
            this.groupBoxDateTime.Controls.Add(this.labelPredictTime);
            this.groupBoxDateTime.Controls.Add(this.labelDate);
            this.groupBoxDateTime.Controls.Add(this.labelTime);
            this.groupBoxDateTime.Location = new System.Drawing.Point(378, 220);
            this.groupBoxDateTime.Name = "groupBoxDateTime";
            this.groupBoxDateTime.Size = new System.Drawing.Size(226, 62);
            this.groupBoxDateTime.TabIndex = 4;
            this.groupBoxDateTime.TabStop = false;
            this.groupBoxDateTime.Text = "Date and Time";
            // 
            // labelPredictTime
            // 
            this.labelPredictTime.AutoSize = true;
            this.labelPredictTime.Location = new System.Drawing.Point(7, 43);
            this.labelPredictTime.Name = "labelPredictTime";
            this.labelPredictTime.Size = new System.Drawing.Size(111, 13);
            this.labelPredictTime.TabIndex = 4;
            this.labelPredictTime.Text = "Expected end of work";
            // 
            // buttonStop
            // 
            this.buttonStop.Image = global::Timex.Properties.Resources._1444157657_black_4_audio_stop;
            this.buttonStop.Location = new System.Drawing.Point(116, 156);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(50, 46);
            this.buttonStop.TabIndex = 5;
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Font = new System.Drawing.Font("Impact", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimer.Location = new System.Drawing.Point(3, 15);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(400, 60);
            this.labelTimer.TabIndex = 6;
            this.labelTimer.Text = "Starting process...";
            // 
            // labelStartTime
            // 
            this.labelStartTime.AutoSize = true;
            this.labelStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStartTime.Location = new System.Drawing.Point(2, 31);
            this.labelStartTime.Name = "labelStartTime";
            this.labelStartTime.Size = new System.Drawing.Size(61, 13);
            this.labelStartTime.TabIndex = 7;
            this.labelStartTime.Text = "StartTime";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(627, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemReset,
            this.toolStripMenuItemExit});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem2.Text = "File";
            // 
            // toolStripMenuItemReset
            // 
            this.toolStripMenuItemReset.Name = "toolStripMenuItemReset";
            this.toolStripMenuItemReset.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItemReset.Text = "Reset";
            this.toolStripMenuItemReset.Click += new System.EventHandler(this.toolStripMenuItemReset_Click);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItemExit.Text = "Exit";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemPreferences});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(39, 20);
            this.toolStripMenuItem3.Text = "Edit";
            // 
            // toolStripMenuItemPreferences
            // 
            this.toolStripMenuItemPreferences.Name = "toolStripMenuItemPreferences";
            this.toolStripMenuItemPreferences.Size = new System.Drawing.Size(135, 22);
            this.toolStripMenuItemPreferences.Text = "Preferences";
            this.toolStripMenuItemPreferences.Click += new System.EventHandler(this.toolStripMenuItemPreferences_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAbout});
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItem4.Text = "Help";
            // 
            // toolStripMenuItemAbout
            // 
            this.toolStripMenuItemAbout.Name = "toolStripMenuItemAbout";
            this.toolStripMenuItemAbout.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItemAbout.Text = "About";
            this.toolStripMenuItemAbout.Click += new System.EventHandler(this.toolStripMenuItemAbout_Click);
            // 
            // tabPanel
            // 
            this.tabPanel.Controls.Add(this.tabPageTime);
            this.tabPanel.Controls.Add(this.tabPageData);
            this.tabPanel.Controls.Add(this.tabPagePreferences);
            this.tabPanel.Location = new System.Drawing.Point(9, 27);
            this.tabPanel.Name = "tabPanel";
            this.tabPanel.SelectedIndex = 0;
            this.tabPanel.Size = new System.Drawing.Size(618, 324);
            this.tabPanel.TabIndex = 9;
            // 
            // tabPageTime
            // 
            this.tabPageTime.Controls.Add(this.labelHourOrMinute);
            this.tabPageTime.Controls.Add(this.groupBoxStatistics);
            this.tabPageTime.Controls.Add(this.progressBar);
            this.tabPageTime.Controls.Add(this.groupBoxDateTime);
            this.tabPageTime.Controls.Add(this.labelTimer);
            this.tabPageTime.Location = new System.Drawing.Point(4, 22);
            this.tabPageTime.Name = "tabPageTime";
            this.tabPageTime.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTime.Size = new System.Drawing.Size(610, 298);
            this.tabPageTime.TabIndex = 0;
            this.tabPageTime.Text = "Time";
            this.tabPageTime.UseVisualStyleBackColor = true;
            // 
            // labelHourOrMinute
            // 
            this.labelHourOrMinute.AutoSize = true;
            this.labelHourOrMinute.Font = new System.Drawing.Font("Impact", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHourOrMinute.Location = new System.Drawing.Point(196, 28);
            this.labelHourOrMinute.Name = "labelHourOrMinute";
            this.labelHourOrMinute.Size = new System.Drawing.Size(0, 46);
            this.labelHourOrMinute.TabIndex = 10;
            // 
            // groupBoxStatistics
            // 
            this.groupBoxStatistics.Controls.Add(this.buttonPause);
            this.groupBoxStatistics.Controls.Add(this.buttonClipboardAll);
            this.groupBoxStatistics.Controls.Add(this.buttonClipboard3);
            this.groupBoxStatistics.Controls.Add(this.textBoxStartTime);
            this.groupBoxStatistics.Controls.Add(this.labelCurrentWeek);
            this.groupBoxStatistics.Controls.Add(this.checkBoxPCShutdown);
            this.groupBoxStatistics.Controls.Add(this.buttonClipboard2);
            this.groupBoxStatistics.Controls.Add(this.buttonClipboard1);
            this.groupBoxStatistics.Controls.Add(this.buttonStart);
            this.groupBoxStatistics.Controls.Add(this.textBoxWeeklySurplus);
            this.groupBoxStatistics.Controls.Add(this.buttonStop);
            this.groupBoxStatistics.Controls.Add(this.labelWeeklySurplus);
            this.groupBoxStatistics.Controls.Add(this.labelStartTime);
            this.groupBoxStatistics.Controls.Add(this.textBoxWorkedToday);
            this.groupBoxStatistics.Controls.Add(this.labelWorkedToday);
            this.groupBoxStatistics.Location = new System.Drawing.Point(404, 6);
            this.groupBoxStatistics.Name = "groupBoxStatistics";
            this.groupBoxStatistics.Size = new System.Drawing.Size(198, 208);
            this.groupBoxStatistics.TabIndex = 9;
            this.groupBoxStatistics.TabStop = false;
            this.groupBoxStatistics.Text = "Statistics";
            // 
            // buttonPause
            // 
            this.buttonPause.Image = global::Timex.Properties.Resources._1444157655_icon_pause;
            this.buttonPause.Location = new System.Drawing.Point(62, 156);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(50, 46);
            this.buttonPause.TabIndex = 12;
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonClipboardAll
            // 
            this.buttonClipboardAll.Image = global::Timex.Properties.Resources._1444156907_icon_clipboard;
            this.buttonClipboardAll.Location = new System.Drawing.Point(172, 156);
            this.buttonClipboardAll.Name = "buttonClipboardAll";
            this.buttonClipboardAll.Size = new System.Drawing.Size(25, 46);
            this.buttonClipboardAll.TabIndex = 11;
            this.buttonClipboardAll.UseVisualStyleBackColor = true;
            this.buttonClipboardAll.Click += new System.EventHandler(this.buttonClipboardAll_Click);
            // 
            // buttonClipboard3
            // 
            this.buttonClipboard3.Image = ((System.Drawing.Image)(resources.GetObject("buttonClipboard3.Image")));
            this.buttonClipboard3.Location = new System.Drawing.Point(173, 22);
            this.buttonClipboard3.Name = "buttonClipboard3";
            this.buttonClipboard3.Size = new System.Drawing.Size(24, 23);
            this.buttonClipboard3.TabIndex = 10;
            this.buttonClipboard3.UseVisualStyleBackColor = true;
            this.buttonClipboard3.Click += new System.EventHandler(this.buttonClipboard3_Click);
            // 
            // textBoxStartTime
            // 
            this.textBoxStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStartTime.Location = new System.Drawing.Point(86, 24);
            this.textBoxStartTime.Name = "textBoxStartTime";
            this.textBoxStartTime.ReadOnly = true;
            this.textBoxStartTime.Size = new System.Drawing.Size(82, 20);
            this.textBoxStartTime.TabIndex = 9;
            // 
            // labelCurrentWeek
            // 
            this.labelCurrentWeek.AutoSize = true;
            this.labelCurrentWeek.Location = new System.Drawing.Point(2, 140);
            this.labelCurrentWeek.Name = "labelCurrentWeek";
            this.labelCurrentWeek.Size = new System.Drawing.Size(73, 13);
            this.labelCurrentWeek.TabIndex = 8;
            this.labelCurrentWeek.Text = "Current week:";
            // 
            // buttonClipboard2
            // 
            this.buttonClipboard2.Image = global::Timex.Properties.Resources._1444156907_icon_clipboard;
            this.buttonClipboard2.Location = new System.Drawing.Point(173, 91);
            this.buttonClipboard2.Name = "buttonClipboard2";
            this.buttonClipboard2.Size = new System.Drawing.Size(24, 23);
            this.buttonClipboard2.TabIndex = 5;
            this.buttonClipboard2.UseVisualStyleBackColor = true;
            this.buttonClipboard2.Click += new System.EventHandler(this.buttonClipboard2_Click);
            // 
            // buttonClipboard1
            // 
            this.buttonClipboard1.Image = global::Timex.Properties.Resources._1444156907_icon_clipboard;
            this.buttonClipboard1.Location = new System.Drawing.Point(173, 56);
            this.buttonClipboard1.Name = "buttonClipboard1";
            this.buttonClipboard1.Size = new System.Drawing.Size(24, 23);
            this.buttonClipboard1.TabIndex = 4;
            this.buttonClipboard1.UseVisualStyleBackColor = true;
            this.buttonClipboard1.Click += new System.EventHandler(this.buttonClipboard1_Click);
            // 
            // textBoxWeeklySurplus
            // 
            this.textBoxWeeklySurplus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxWeeklySurplus.Location = new System.Drawing.Point(85, 94);
            this.textBoxWeeklySurplus.Name = "textBoxWeeklySurplus";
            this.textBoxWeeklySurplus.ReadOnly = true;
            this.textBoxWeeklySurplus.Size = new System.Drawing.Size(82, 20);
            this.textBoxWeeklySurplus.TabIndex = 3;
            // 
            // labelWeeklySurplus
            // 
            this.labelWeeklySurplus.AutoSize = true;
            this.labelWeeklySurplus.Location = new System.Drawing.Point(3, 96);
            this.labelWeeklySurplus.Name = "labelWeeklySurplus";
            this.labelWeeklySurplus.Size = new System.Drawing.Size(84, 13);
            this.labelWeeklySurplus.TabIndex = 2;
            this.labelWeeklySurplus.Text = "Weekly Surplus:";
            // 
            // textBoxWorkedToday
            // 
            this.textBoxWorkedToday.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxWorkedToday.Location = new System.Drawing.Point(85, 58);
            this.textBoxWorkedToday.Name = "textBoxWorkedToday";
            this.textBoxWorkedToday.ReadOnly = true;
            this.textBoxWorkedToday.Size = new System.Drawing.Size(82, 20);
            this.textBoxWorkedToday.TabIndex = 1;
            // 
            // labelWorkedToday
            // 
            this.labelWorkedToday.AutoSize = true;
            this.labelWorkedToday.Location = new System.Drawing.Point(2, 63);
            this.labelWorkedToday.Name = "labelWorkedToday";
            this.labelWorkedToday.Size = new System.Drawing.Size(77, 13);
            this.labelWorkedToday.TabIndex = 0;
            this.labelWorkedToday.Text = "Worked today:";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(6, 259);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(369, 23);
            this.progressBar.TabIndex = 8;
            // 
            // tabPageData
            // 
            this.tabPageData.Controls.Add(this.groupBoxData);
            this.tabPageData.Controls.Add(this.dataGridView);
            this.tabPageData.Location = new System.Drawing.Point(4, 22);
            this.tabPageData.Name = "tabPageData";
            this.tabPageData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageData.Size = new System.Drawing.Size(610, 298);
            this.tabPageData.TabIndex = 1;
            this.tabPageData.Text = "Data";
            this.tabPageData.UseVisualStyleBackColor = true;
            // 
            // groupBoxData
            // 
            this.groupBoxData.Controls.Add(this.labelCurrentCalendarWeek);
            this.groupBoxData.Controls.Add(this.buttonResizeDataGrid);
            this.groupBoxData.Controls.Add(this.comboBoxCalendarWeek);
            this.groupBoxData.Location = new System.Drawing.Point(6, 7);
            this.groupBoxData.Name = "groupBoxData";
            this.groupBoxData.Size = new System.Drawing.Size(448, 60);
            this.groupBoxData.TabIndex = 1;
            this.groupBoxData.TabStop = false;
            this.groupBoxData.Text = "Selection";
            // 
            // labelCurrentCalendarWeek
            // 
            this.labelCurrentCalendarWeek.AutoSize = true;
            this.labelCurrentCalendarWeek.Location = new System.Drawing.Point(6, 17);
            this.labelCurrentCalendarWeek.Name = "labelCurrentCalendarWeek";
            this.labelCurrentCalendarWeek.Size = new System.Drawing.Size(65, 13);
            this.labelCurrentCalendarWeek.TabIndex = 3;
            this.labelCurrentCalendarWeek.Text = "Current CW:";
            // 
            // buttonResizeDataGrid
            // 
            this.buttonResizeDataGrid.Location = new System.Drawing.Point(367, 33);
            this.buttonResizeDataGrid.Name = "buttonResizeDataGrid";
            this.buttonResizeDataGrid.Size = new System.Drawing.Size(75, 23);
            this.buttonResizeDataGrid.TabIndex = 2;
            this.buttonResizeDataGrid.Text = "Resize grid";
            this.buttonResizeDataGrid.UseVisualStyleBackColor = true;
            this.buttonResizeDataGrid.Click += new System.EventHandler(this.buttonResizeDataGrid_Click);
            // 
            // comboBoxCalendarWeek
            // 
            this.comboBoxCalendarWeek.FormattingEnabled = true;
            this.comboBoxCalendarWeek.Location = new System.Drawing.Point(6, 33);
            this.comboBoxCalendarWeek.MaxDropDownItems = 20;
            this.comboBoxCalendarWeek.Name = "comboBoxCalendarWeek";
            this.comboBoxCalendarWeek.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCalendarWeek.TabIndex = 0;
            this.comboBoxCalendarWeek.Text = "Calendar week #";
            this.comboBoxCalendarWeek.SelectedValueChanged += new System.EventHandler(this.comboBoxCalendarWeek_SelectedValueChanged);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(6, 73);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(596, 219);
            this.dataGridView.TabIndex = 0;
            // 
            // tabPagePreferences
            // 
            this.tabPagePreferences.Controls.Add(this.groupBoxEdit);
            this.tabPagePreferences.Controls.Add(this.groupBoxWorkingTime);
            this.tabPagePreferences.Controls.Add(this.buttonPreferencesSubmit);
            this.tabPagePreferences.Location = new System.Drawing.Point(4, 22);
            this.tabPagePreferences.Name = "tabPagePreferences";
            this.tabPagePreferences.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePreferences.Size = new System.Drawing.Size(610, 298);
            this.tabPagePreferences.TabIndex = 2;
            this.tabPagePreferences.Text = "Preferences";
            this.tabPagePreferences.UseVisualStyleBackColor = true;
            // 
            // groupBoxEdit
            // 
            this.groupBoxEdit.Controls.Add(this.checkBoxAllowEdit);
            this.groupBoxEdit.Controls.Add(this.textBoxPassword);
            this.groupBoxEdit.Location = new System.Drawing.Point(6, 92);
            this.groupBoxEdit.Name = "groupBoxEdit";
            this.groupBoxEdit.Size = new System.Drawing.Size(218, 54);
            this.groupBoxEdit.TabIndex = 6;
            this.groupBoxEdit.TabStop = false;
            this.groupBoxEdit.Text = "Edit Timetable";
            // 
            // checkBoxAllowEdit
            // 
            this.checkBoxAllowEdit.AutoSize = true;
            this.checkBoxAllowEdit.Enabled = false;
            this.checkBoxAllowEdit.Location = new System.Drawing.Point(117, 23);
            this.checkBoxAllowEdit.Name = "checkBoxAllowEdit";
            this.checkBoxAllowEdit.Size = new System.Drawing.Size(83, 17);
            this.checkBoxAllowEdit.TabIndex = 1;
            this.checkBoxAllowEdit.Text = "Allow to edit";
            this.checkBoxAllowEdit.UseVisualStyleBackColor = true;
            this.checkBoxAllowEdit.CheckedChanged += new System.EventHandler(this.checkBoxAllowEdit_CheckedChanged);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(6, 21);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(100, 20);
            this.textBoxPassword.TabIndex = 0;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // groupBoxWorkingTime
            // 
            this.groupBoxWorkingTime.Controls.Add(this.numericUpDownSeconds);
            this.groupBoxWorkingTime.Controls.Add(this.numericUpDownMinutes);
            this.groupBoxWorkingTime.Controls.Add(this.numericUpDownHours);
            this.groupBoxWorkingTime.Controls.Add(this.labelPreferencesSeconds);
            this.groupBoxWorkingTime.Controls.Add(this.labelPreferencesMinutes);
            this.groupBoxWorkingTime.Controls.Add(this.labelPreferencesHours);
            this.groupBoxWorkingTime.Location = new System.Drawing.Point(6, 22);
            this.groupBoxWorkingTime.Name = "groupBoxWorkingTime";
            this.groupBoxWorkingTime.Size = new System.Drawing.Size(303, 54);
            this.groupBoxWorkingTime.TabIndex = 5;
            this.groupBoxWorkingTime.TabStop = false;
            this.groupBoxWorkingTime.Text = "Working time (daily)";
            // 
            // buttonPreferencesSubmit
            // 
            this.buttonPreferencesSubmit.Location = new System.Drawing.Point(326, 49);
            this.buttonPreferencesSubmit.Name = "buttonPreferencesSubmit";
            this.buttonPreferencesSubmit.Size = new System.Drawing.Size(48, 23);
            this.buttonPreferencesSubmit.TabIndex = 4;
            this.buttonPreferencesSubmit.Text = "Submit";
            this.buttonPreferencesSubmit.UseVisualStyleBackColor = true;
            this.buttonPreferencesSubmit.Click += new System.EventHandler(this.buttonPreferencesSubmit_Click);
            // 
            // labelPreferencesMinutes
            // 
            this.labelPreferencesMinutes.AutoSize = true;
            this.labelPreferencesMinutes.Location = new System.Drawing.Point(135, 32);
            this.labelPreferencesMinutes.Name = "labelPreferencesMinutes";
            this.labelPreferencesMinutes.Size = new System.Drawing.Size(43, 13);
            this.labelPreferencesMinutes.TabIndex = 3;
            this.labelPreferencesMinutes.Text = "minutes";
            // 
            // labelPreferencesHours
            // 
            this.labelPreferencesHours.AutoSize = true;
            this.labelPreferencesHours.Location = new System.Drawing.Point(51, 32);
            this.labelPreferencesHours.Name = "labelPreferencesHours";
            this.labelPreferencesHours.Size = new System.Drawing.Size(33, 13);
            this.labelPreferencesHours.TabIndex = 2;
            this.labelPreferencesHours.Text = "hours";
            // 
            // labelPreferencesSeconds
            // 
            this.labelPreferencesSeconds.AutoSize = true;
            this.labelPreferencesSeconds.Location = new System.Drawing.Point(224, 32);
            this.labelPreferencesSeconds.Name = "labelPreferencesSeconds";
            this.labelPreferencesSeconds.Size = new System.Drawing.Size(47, 13);
            this.labelPreferencesSeconds.TabIndex = 6;
            this.labelPreferencesSeconds.Text = "seconds";
            // 
            // numericUpDownHours
            // 
            this.numericUpDownHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownHours.Location = new System.Drawing.Point(6, 25);
            this.numericUpDownHours.Name = "numericUpDownHours";
            this.numericUpDownHours.Size = new System.Drawing.Size(39, 20);
            this.numericUpDownHours.TabIndex = 7;
            // 
            // numericUpDownMinutes
            // 
            this.numericUpDownMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownMinutes.Location = new System.Drawing.Point(90, 25);
            this.numericUpDownMinutes.Name = "numericUpDownMinutes";
            this.numericUpDownMinutes.Size = new System.Drawing.Size(39, 20);
            this.numericUpDownMinutes.TabIndex = 8;
            // 
            // numericUpDownSeconds
            // 
            this.numericUpDownSeconds.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownSeconds.Location = new System.Drawing.Point(179, 25);
            this.numericUpDownSeconds.Name = "numericUpDownSeconds";
            this.numericUpDownSeconds.Size = new System.Drawing.Size(39, 20);
            this.numericUpDownSeconds.TabIndex = 9;
            // 
            // TimexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 354);
            this.Controls.Add(this.tabPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TimexForm";
            this.Text = "Timex";
            this.groupBoxDateTime.ResumeLayout(false);
            this.groupBoxDateTime.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPanel.ResumeLayout(false);
            this.tabPageTime.ResumeLayout(false);
            this.tabPageTime.PerformLayout();
            this.groupBoxStatistics.ResumeLayout(false);
            this.groupBoxStatistics.PerformLayout();
            this.tabPageData.ResumeLayout(false);
            this.groupBoxData.ResumeLayout(false);
            this.groupBoxData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tabPagePreferences.ResumeLayout(false);
            this.groupBoxEdit.ResumeLayout(false);
            this.groupBoxEdit.PerformLayout();
            this.groupBoxWorkingTime.ResumeLayout(false);
            this.groupBoxWorkingTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeconds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.CheckBox checkBoxPCShutdown;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.GroupBox groupBoxDateTime;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label labelPredictTime;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Label labelStartTime;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemReset;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.TabControl tabPanel;
        private System.Windows.Forms.TabPage tabPageTime;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TabPage tabPageData;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox groupBoxStatistics;
        private System.Windows.Forms.GroupBox groupBoxData;
        private System.Windows.Forms.ComboBox comboBoxCalendarWeek;
        private System.Windows.Forms.Label labelHourOrMinute;
        private System.Windows.Forms.Label labelWorkedToday;
        private System.Windows.Forms.TextBox textBoxWorkedToday;
        private System.Windows.Forms.TextBox textBoxWeeklySurplus;
        private System.Windows.Forms.Label labelWeeklySurplus;
        private System.Windows.Forms.Button buttonClipboard2;
        private System.Windows.Forms.Button buttonClipboard1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPreferences;
        private System.Windows.Forms.TabPage tabPagePreferences;
        private System.Windows.Forms.GroupBox groupBoxWorkingTime;
        private System.Windows.Forms.Button buttonPreferencesSubmit;
        private System.Windows.Forms.Label labelPreferencesMinutes;
        private System.Windows.Forms.Label labelPreferencesHours;
        private System.Windows.Forms.GroupBox groupBoxEdit;
        private System.Windows.Forms.CheckBox checkBoxAllowEdit;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonResizeDataGrid;
        private System.Windows.Forms.Label labelCurrentCalendarWeek;
        private System.Windows.Forms.Label labelCurrentWeek;
        private System.Windows.Forms.TextBox textBoxStartTime;
        private System.Windows.Forms.Button buttonClipboard3;
        private System.Windows.Forms.Button buttonClipboardAll;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAbout;
        private System.Windows.Forms.Label labelPreferencesSeconds;
        private System.Windows.Forms.NumericUpDown numericUpDownHours;
        private System.Windows.Forms.NumericUpDown numericUpDownSeconds;
        private System.Windows.Forms.NumericUpDown numericUpDownMinutes;
    }
}

