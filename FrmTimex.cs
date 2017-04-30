using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using Timex.Properties;

namespace Timex
{
    /// ============================================================================================================================
    /// <summary>
    ///
    /// </summary>
    public partial class FrmTimex : FrmBase
    {
        #region Konstruktoren

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        public FrmTimex()
        {
            InitializeComponent();
            notifyIcon.Icon = Resources._1444130278_stopwatch;
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmTimex_Load(object sender, EventArgs e)
        {
            if (Settings.Default.UpgradeRequired)
            {
                Settings.Default.Upgrade();
                Settings.Default.UpgradeRequired = false;
                Settings.Default.Save();
            }
            Init();
        }

        #endregion Konstruktoren

        #region Interne Variablen

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary></summary>
        private bool firstStart = true;

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        private DataGridViewCellStyle dailyCellStyle = new DataGridViewCellStyle();

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Programmname für Autostartfunktion
        /// </summary>
        private string registryKey = "Timex";

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Autostart Pfad der .exe
        /// </summary>
        private string assemblyLocation = System.Reflection.Assembly.GetEntryAssembly().Location;

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Timer der für das Speichern mit Zeitintervall verantwortlich ist
        /// </summary>
        Timer saveTimer = new Timer();

        #endregion Interne Variablen

        #region Properties

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        private DataStore DataStore { get; set; }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        public DateTime ActualDate { get; set; }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        public DateTime ActualTime { get; set; }

        /// ------------------------------------------------------------------------------------------------------------------------
        private Timer theWorkTimer = new Timer();
        /// <summary>
        ///
        /// </summary>
        public Timer TheWorkTimer
        {
            get { return theWorkTimer; }
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        public bool IsDone { get; set; }

        #endregion Properties

        #region Methoden

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        internal void Init()
        {
            //XMLPath = Settings.Default.XMLPath;

            DataStore = new DataStore() { XMLPath = string.Format("{0}\\{1}", Application.StartupPath, Settings.Default.XMLDoc) };
            TryReadXML(DataStore.XMLPath);
            DataStore.CheckTable();
            ConnectEvents();
            StartWorkTimer(false);
            ResumeTimer();
            ResetButtonsToDefault();
            FillLabels();
            CreateSystemTrayMenu();
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        private void FillLabels()
        {
            comboBoxXML.DataSource = GetXMLDocuments();
            comboBoxXML.Text = Path.GetFileName(Settings.Default.XMLPath);

            labelDate.Text = "It's " + Helper.BuildDateString(DateTime.Now);
            labelDataDate.Text = "It's " + Helper.BuildDateString(DateTime.Now);
            labelTime.Text = string.Format("{0} {1}", DateTime.Now.ToString(Const.DATEFORMAT), Helper.GetAM(DateTime.Now));
            labelPredictTime.Text = string.Format("End of Worktime: {0} {1}",
                DataStore.EndTime.ToShortTimeString(), Helper.GetAM(DateTime.Now.AddSeconds(DataStore.SecondsLeft)));
            labelCalculatedEndOfWork.Text = string.Format("Time of surplus: {0}", GetCalculatedEndOfWork());
            labelStartTime.Text = "Started work ";
            labelCurrentCalendarWeek.Text = string.Format("Current calendar week: {0}", DataStore.CurrentWeek);
            labelCurrentWeek.Text = string.Format("CW: {0}", DataStore.CurrentWeek);

            comboBoxCalendarWeek.BeginUpdate();
            try
            {
                comboBoxCalendarWeek.Items.Clear();
                foreach (DataTable table in DataStore.TimeTables.Tables)
                {
                    comboBoxCalendarWeek.Items.Add(table.TableName);
                }
            }
            finally
            {
                comboBoxCalendarWeek.EndUpdate();
            }

            checkBoxAutosave.Checked = Settings.Default.isAutosave;
            checkBoxAutostart.Checked = Settings.Default.isAutostart;
            checkBoxFullWorktime.Checked = Settings.Default.isFullTime;
            checkBoxPCShutdown.Checked = Settings.Default.isShutdown;
            numericUpDownHours.Value = Settings.Default.HoursToWork;
            numericUpDownMinutes.Value = Settings.Default.MinutesToWork;
            numericUpDownSeconds.Value = Settings.Default.SecondsToWork;
            checkBoxSaveNotifications.Checked = Settings.Default.showAutoSaveNotifications;
            checkBoxSaveWorkedTime.Checked = Settings.Default.autoSaveWorkedTime;
            trackBarSaveIntervall.Value = Helper.GetScrollIndexOfMillis(Settings.Default.autoSaveIntervall);
            trackBarSaveIntervall.Enabled = Settings.Default.autoSaveWorkedTime;
            toolStripMenuItemCurrentXML.Text = Path.GetFileName(Settings.Default.XMLPath);
            toolStripMenuItemAutostart.Image = checkBoxAutostart.Checked ? Resources.Enabled : Resources.Disabled;
            toolStripMenuItemAutosave.Image = checkBoxAutosave.Checked ? Resources.Enabled : Resources.Disabled;
            toolStripMenuItemWorktime.Image = checkBoxFullWorktime.Checked ? Resources.Enabled : Resources.Disabled;
            toolStripMenuItemAutoSaveData.Image = checkBoxSaveWorkedTime.Checked ? Resources.Enabled : Resources.Disabled;

            if (!string.IsNullOrEmpty(DataStore.XMLPath))
            {
                textBoxDataPath.Text = DataStore.XMLPath;
                toolStripMenuItemCurrentXML.Text = Path.GetFileName(DataStore.XMLPath);
            }
            else
            {
                textBoxDataPath.Text = Settings.Default.XMLPath;
                toolStripMenuItemCurrentXML.Text = Path.GetFileName(Settings.Default.XMLPath);
            }

            if (checkBoxFullWorktime.Checked)
            {
                checkBoxFullWorktime_CheckedChanged(this, null);
            }

            trackBarSaveIntervall_Scroll(this, null);

            firstStart = false;
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="path"></param>
        public void ChangeXML(string path)
        {
            DataStore.TimeTables.Clear();
            Settings.Default.XMLDoc = Path.GetFileName(path);
            Settings.Default.XMLPath = path;
            Settings.Default.Save();
            DataStore.XMLPath = path;
            TryReadXML(DataStore.XMLPath);
            DataStore.CheckTable();
            FillLabels();
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Fragt den Nutzer, ob er die bereits gebarbeitete Zeit weiterlaufen lassen möchte SOFERN das Datum überein stimmt
        /// </summary>
        /// <param name="path"></param>
        private void ResumeTimer()
        {
            if (Settings.Default.LastSessionDat == DateTime.Now.ToShortDateString()/* && Settings.Default.LastSession > 59*/)
            {
                string plusTime = Helper.ToTimeString(Settings.Default.LastSession);
                DialogResult result = MessageBox.Show(string.Format("You startet Timex today twice.\r\nDo you want to resume your last worktime?\r\n+{0}h", plusTime),
                    "Resume Timex", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DataStore.UpdateWorkDuration(
                        Settings.Default.HoursToWork,
                        Settings.Default.MinutesToWork,
                        Settings.Default.SecondsToWork - Settings.Default.LastSession);
                }
            }
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="path"></param>
        public void TryReadXML(string path)
        {
            try
            {
                DataStore.Reader(DataStore.XMLPath);
            }
            catch (Exception)
            {
                DialogResult result = MessageBox.Show("The directory\r\n" + DataStore.XMLPath + " \r\nis no valid XML-path.\r\n" +
                "If you want to create a new file(TimeTable.xml) press Ja/Yes\r\n" +
                "If you want to import a file press Nein/No\r\n" +
                "If you want to close Timex press Abbrechen/Cancel",
                "No valid XML-file found", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

                if (result == DialogResult.Yes)
                {
                    DataStore.CreateNewXMLDocument("TimeTable", string.Format("{0}\\TimeTable.xml", Application.StartupPath));
                }
                else if (result == DialogResult.No)
                {
                    buttonXMLImport_Click(this, null);
                }
                else
                {
                    Close();
                }
            }
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        private void StartWorkTimer(bool isReset)
        {
            if (firstStart || isReset)
            {
                DataStore.UpdateWorkDuration(Settings.Default.HoursToWork, Settings.Default.MinutesToWork,
                    Settings.Default.SecondsToWork);

                theWorkTimer.Tick += new EventHandler(WorkTimer_Tick);
            }
            StartSaveTimer();
            buttonStart.Enabled = false;
            buttonPause.Enabled = true;
            labelTimer.ForeColor = System.Drawing.Color.Black;
            theWorkTimer.Interval = 1000;
            theWorkTimer.Start();
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        public void StopWorkTimer()
        {
            theWorkTimer.Stop();
            saveTimer.Stop();
            labelTimer.Text = "Process stopped";
            labelTimer.ForeColor = System.Drawing.Color.Red;
            labelHourOrMinute.Text = string.Empty;
            progressBar.Value = 0;
            buttonPause.Enabled = false;
            buttonStart.Enabled = true;
            ResetButtonsToDefault();
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        public void ResizeDataGrid()
        {
            dataGridView.AutoResizeColumnHeadersHeight();
            dataGridView.AutoResizeColumns();
            dataGridView.AutoResizeRows();
            int businessDayNumber = (int)DateTime.Now.DayOfWeek - 1;
            dailyCellStyle.Font = new Font(dataGridView.Font, FontStyle.Bold);
            dataGridView.Rows[5].Cells[1].Style.BackColor = Color.Gray;
            dataGridView.Rows[5].Cells[2].Style.BackColor = Color.Gray;
            dataGridView.Rows[5].Cells[3].Style.BackColor = Color.Green;
            dataGridView.Rows[5].Cells[4].Style.BackColor = Color.Gray;
            string diff;
            if (comboBoxCalendarWeek.Text != null)
            {
                diff = DataStore.TimeTables.Tables[comboBoxCalendarWeek.Text].Rows[5][5].ToString();
            }
            else
            {
                diff = DataStore.TimeTables.Tables[DataStore.CurrentWeek.ToString()].Rows[5][5].ToString();
            }
            TimeSpan diffInTime;
            TimeSpan.TryParse(diff, out diffInTime);
            if (diffInTime.TotalSeconds > 0)
            {
                dataGridView.Rows[5].Cells[5].Style.BackColor = Color.Green;
            }
            else
            {
                dataGridView.Rows[5].Cells[5].Style.BackColor = Color.Red;
            }

            dataGridView.Rows[5].DefaultCellStyle = dailyCellStyle;
            for (int i = 0; i < 6; i++)
            {
                dataGridView.Rows[businessDayNumber].Cells[i].Style.BackColor = Color.LightGray;
            }
        }

        private string GetCalculatedEndOfWork()
        {
            string endOfWork;
            TimeSpan diff = DataStore.GetLastDiffernce(DataStore.CurrentWeek);
            endOfWork = (DataStore.EndTime - diff).ToShortTimeString();
            return endOfWork+ " "+ Helper.GetAM(DateTime.Now.AddSeconds(DataStore.SecondsLeft));
        }
        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        private void ResetButtonsToDefault()
        {
            theWorkTimer.Stop();
            buttonStart.Enabled = true;
            buttonResizeDataGrid.Enabled = false;
            btnUpdateDataGrid.Enabled = false;
            progressBar.Value = 0;
            DataStore.CurrentWeek = Helper.GetWeekOfYear(DateTime.Now);
            labelPredictTime.Text = "Expected end of Work";
            labelStartTime.Text = "Time you started working";
            labelTime.Text = "Updating time...";
            labelDate.Text = "It's " + Helper.BuildDateString(DateTime.Now);
            comboBoxXML.DataSource = GetXMLDocuments();
            if (firstStart)
            {
                buttonStart.Enabled = false;
                theWorkTimer.Interval = 1000;
                theWorkTimer.Enabled = true;
            }
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        private void ConnectEvents()
        {
            btnUpdateDataGrid.Click += btnUpdateDataGrid_Click;
            this.Resize += FrmTimex_Resize;
            notifyIcon.DoubleClick += notifyIcon_DoubleClick;
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private string[] GetXMLDocuments()
        {
            string dir = Application.StartupPath;
            string[] documents = Directory.GetFiles(dir, "*.xml", SearchOption.AllDirectories);
            for (int i = 0; i < documents.Length; i++)
            {
                documents[i] = Path.GetFileName(documents[i]);
            }

            return documents;
        }

        /// <summary>
        /// Öffnet den mitgegebenen Pfad im Windows-Explorer
        /// </summary>
        /// <param name="path"></param>
        private void OpenPath(string path)
        {
            if (Directory.Exists(path))
                Process.Start("explorer.exe", path);
        }

        private void buttonXMLImport_ClickExtracted()
        {
            openFileDialogImportXML.Title = "Import a XML document";
            openFileDialogImportXML.Filter = "XML files (*.xml)|*.xml";
            if (openFileDialogImportXML.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (openFileDialogImportXML.FileName != null)
                    {
                        string filePath = Application.StartupPath;
                        string dirName = openFileDialogImportXML.FileName;
                        string fileName = System.IO.Path.GetFileName(openFileDialogImportXML.FileName);
                        System.IO.File.Copy(dirName, string.Format("{0}\\{1}", filePath, fileName));
                        comboBoxXML.DataSource = GetXMLDocuments();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message, "Import failed", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
            }
        }
        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Notify Icon des System-Trays
        /// </summary>
        private void Notify(string text, string title, int milliseconds)
        {
            notifyIcon.ShowBalloonTip(milliseconds, title, text, ToolTipIcon.Info);
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Startet den Intervall für das speichern des abgearbeiteten Zeit, sofern Autosave aktiviert ist
        /// </summary>
        private void StartSaveTimer()
        {
            if (Settings.Default.isAutosave)
            {
                saveTimer.Interval = 300000;
                saveTimer.Tick += saveTimer_Tick;
                saveTimer.Start();
            }
            else
            {
                Notify(string.Format("Autosave isn't enabled!{0}On execute of the Timex process, your data will be lost",
                    Environment.NewLine), "Autosave disabled", 250);
            }
        }



        #endregion Methoden

        #region Events
        private void trackBarSaveIntervall_Scroll(object sender, EventArgs e)
        {
            int minuteIntverval = ((trackBarSaveIntervall.Value * 5) + 5);
            labelIntervall.Text = minuteIntverval + "min";
            int milliInterval = Helper.GetMillisOfMinutes(minuteIntverval);
            saveTimer.Interval = milliInterval;
            Settings.Default.autoSaveIntervall = milliInterval;
        }

        private void tabPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabPanel.SelectedIndex == 1)
                this.MinimumSize = new Size(695, 332);

            if (tabPanel.SelectedIndex == 0)
            {
                this.Size = new Size(650, 332);
                this.MinimumSize = new Size(650, 332);
            }

            if (tabPanel.SelectedIndex == 2)
            {
                this.Size = new Size(650, 332);
                this.MinimumSize = new Size(650, 332);
            }
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPreferencesSemiReset_Click(object sender, EventArgs e)
        {
            FillLabels();
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPreferencesReset_Click(object sender, EventArgs e)
        {
            var dialoRresult = MessageBox.Show("Reset timer?\r\nThis action is not able to revert", "Reset Timer",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialoRresult == DialogResult.Yes)
            {
                ResetButtonsToDefault();
                FillLabels();
                StopWorkTimer();
            }
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemCurrentXML_Click(object sender, EventArgs e)
        {
            tabPanel.SelectedIndex = 2;
            //tabPagePreferences.Focus();
            comboBoxXML.Focus();
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRefreshSurplus_Click(object sender, EventArgs e)
        {
            buttonDailyGrid_Click(sender, null);
            btnUpdateDataGrid_Click(sender, null);
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonXMLConfirm_Click(object sender, EventArgs e)
        {
            ChangeXML(Application.StartupPath + "\\" + comboBoxXML.Text);
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonXMLImport_Click(object sender, EventArgs e)
        {
            buttonXMLImport_ClickExtracted();
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonXMLOpen_Click(object sender, EventArgs e)
        {
            OpenPath(Application.StartupPath);
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDailyGrid_Click(object sender, EventArgs e)
        {
            comboBoxCalendarWeek.SelectedIndex = DataStore.TimeTables.Tables.IndexOf(DataStore.CurrentWeek.ToString());
            buttonResizeDataGrid.Enabled = true;
            btnUpdateDataGrid.Enabled = true;
            buttonSave.Enabled = true;
        }


        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmTimex_FormClosing(object sender, FormClosingEventArgs e)
        {
            int prePlusTime = Settings.Default.LastSession;
            Settings.Default.LastSession = DataStore.SecondsDone;
            if (DateTime.Now.ToShortDateString() == Settings.Default.LastSessionDat)
            {
                Settings.Default.LastSession += prePlusTime;
            }
            Settings.Default.LastSessionDat = DateTime.Now.ToShortDateString();
            if (checkBoxAutosave.Checked)
            {
                DataStore.Writer(Settings.Default.XMLPath);
                Settings.Default.Save();
                e.Cancel = false;
            }
            else
            {
                var dialogResult = MessageBox.Show("Do you want to close Timex? All unsaved data will be lost.\r\nYou can enable Autosave in Preferences for a prompt and secure exit.",
                    "Shutdown process", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.No)
                    e.Cancel = true;
                else
                    e.Cancel = false;
            }
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Speichert die abgearbeitete Zeit ab
        /// </summary>
        void saveTimer_Tick(object sender, EventArgs e)
        {
            if (Settings.Default.autoSaveWorkedTime)
            {
                buttonDailyGrid_Click(this, null);
                buttonResizeDataGrid_Click(this, null);
                btnUpdateDataGrid_Click(this, null);
                DataStore.Writer(Settings.Default.XMLPath);
                if (Settings.Default.showAutoSaveNotifications)
                {
                    Notify("Timex saved your worked time...", "Autosave", 100);
                }
            }
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorkTimer_Tick(object sender, EventArgs e)
        {
            labelTime.Text = string.Format("{0} {1}", DateTime.Now.ToLongTimeString(), Helper.GetAM());
            int percent = DataStore.GetPercent();
            labelPercent.Text = percent + "%";
            progressBar.Value = percent;

            if (DataStore.SecondsLeft > 0)
            {
                labelTimer.Text = Helper.ToTimeString(DataStore.SecondsLeft);
                textBoxWorkedToday.Text = Helper.ToTimeString(DataStore.SecondsDone) + " h";
                textBoxStartTime.Text = string.Format("{0} {1}", DataStore.StartTime.ToLongTimeString(), Helper.GetAM(DataStore.StartTime));
                //textBoxWeeklySurplus.Text = DataStore.TimeTables.Tables[DataStore.CurrentWeek.ToString()].Rows[5][5].ToString();
                labelHourOrMinute.Text = Helper.GetHour(DataStore.SecondsLeft) + " left";
                //labelHourOrMinute.Text = /* Helper.GetHour(SecondsLeft) + */ " remaining";
            }
            else
            {
                IsDone = true;

                if (checkBoxPCShutdown.Checked)
                {
                    theWorkTimer.Stop();
                    Process.Start("shutdown", "/s /t 0");
                    DialogResult pcShutdown = MessageBox.Show("Prepare for shutdown - 10 sec left", "PC shutdown", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    if (pcShutdown == DialogResult.Cancel)
                    {
                        Process.Start("shutdown", "/a");
                    }
                }

                labelTimer.ForeColor = Color.Green;

                //textBoxWeeklySurplus.Text = DataStore.TimeTables.Tables[DataStore.CurrentWeek.ToString()].Rows[5][5].ToString();
                textBoxWorkedToday.Text = Helper.ToTimeString(DataStore.SecondsDone) + " h";
                labelHourOrMinute.Text = "overtime";
                labelTimer.Text = Helper.ToTimeString(DataStore.SecondsPlus - DataStore.SecondsLeft);
            }

            if (DataStore.SecondsPlus == 1)
            {
                FrmAffen frmaffen = new FrmAffen();
                frmaffen.ShowDialog();
            }
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            labelTime.Text = string.Format("{0} {1}", DateTime.Now.ToLongTimeString(), Helper.GetAM());
        }

        #region Buttons

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateNewXML_Click(object sender, EventArgs e)
        {
            string xmlPath = Application.StartupPath + "\\" + textBoxCreateNewXML.Text + ".xml";
            textBoxCreateNewXML.Focus();
            if (!string.IsNullOrWhiteSpace(textBoxCreateNewXML.Text))
            {
                try
                {
                    DataStore.CreateNewXMLDocument(textBoxCreateNewXML.Text, xmlPath);
                }
                catch (Exception)
                {
                    MessageBox.Show(e.ToString());
                }
                string filename = Path.GetFileName(xmlPath);
                DialogResult result = MessageBox.Show("Use this XML-file from now?", "Use new XML", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ChangeXML(xmlPath);
                    comboBoxXML.DataSource = GetXMLDocuments();
                    comboBoxXML.Text = filename;
                    buttonXMLConfirm_Click(this, null);
                }
                else if (result == DialogResult.No)
                {
                    comboBoxXML.DataSource = GetXMLDocuments();
                }
                else
                {
                    System.IO.File.Delete(xmlPath);
                    MessageBox.Show("The XML-file " + filename + " was deleted.", "Action aborted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please type name of XML-file", "Filename is null or whitespace", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxCreateNewXML.Focus();
            }
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            btnUpdateDataGrid_Click(this, null);
            DataStore.Writer(Settings.Default.XMLPath);
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateDataGrid_Click(object sender, EventArgs e)
        {
            DataStore.FillDailyRow();
            textBoxWeeklySurplus.Text = DataStore.TimeTables.Tables[DataStore.CurrentWeek.ToString()].Rows[5][5].ToString();
            ResizeDataGrid();
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonResizeDataGrid_Click(object sender, EventArgs e)
        {
            ResizeDataGrid();
            btnUpdateDataGrid_Click(sender, null);
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreferencesSubmit_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Reset timer?\r\nThis action requires a reset of the timer.", "Reset Timer",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                theWorkTimer.Stop();
                ResetButtonsToDefault();
                DataStore.UpdateWorkDuration((int)numericUpDownHours.Value, (int)numericUpDownMinutes.Value, (int)numericUpDownSeconds.Value);
                Settings.Default.HoursToWork = Convert.ToInt32(numericUpDownHours.Value);
                Settings.Default.MinutesToWork = Convert.ToInt32(numericUpDownMinutes.Value);
                Settings.Default.SecondsToWork = Convert.ToInt32(numericUpDownSeconds.Value);
                Settings.Default.Save();
                StartWorkTimer(true);
                FillLabels();
                tabPanel.SelectedIndex = 0;
            }
            else
            {
                //
            }
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClipboardAll_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(string.Format("I've started working at {0}. Since monday, I've made a total plus of {1} hours.\r\nUntil now, I've been working for {2} hours", textBoxStartTime.Text, textBoxWeeklySurplus.Text, textBoxWorkedToday.Text));
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClipboard3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(string.Format("I've started working at {0}", textBoxStartTime.Text));
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClipboard2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(string.Format("Since monday, I've made a total plus of {0} hours", textBoxWeeklySurplus.Text));
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClipboard1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(string.Format("Until now, I've been working for {0} hours", textBoxWorkedToday.Text));
        }

        private void buttonClipboardXMLPath_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(DataStore.XMLPath);
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPause_Click(object sender, EventArgs e)
        {
            buttonPause.Enabled = false;
            theWorkTimer.Interval = 9999999;
            saveTimer.Interval = 9999999;
            buttonStart.Enabled = true;
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Stop Timer?\r\nThis action is not able to revert", "Stop Timer", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                StopWorkTimer();
                DataStore.FillDailyRow();
            }
            else
            {
                //
            }
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            StartWorkTimer(false);
        }

        #region HelpButtons

        private void ButtonHelpData_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The combobox shows your current file which stores your worktime.\r\n" +
            "You can change the XML-file by import a new or copy one to the timex directory.\r\n" +
            "If you want to switch files don't forget to apply your changes by pressing the save button beside."
            , "Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonHelpFunctions_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The autostart-function is responsible to start timex on boot to make sure that your worktime will be recorded.\r\n" +
                "The autosave-on-exit is responsible to save your recorded stats on closing or shutdown.\r\n" +
                "If checked, the full worktime (means 8 1/2 hours) is locked to the system and will set on start."
                , "Functions", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonHelpEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This option only exist for the case of errors by timex\r\n" +
            "Enter password and click on the checkbox to disable readonly for the datagrid."
            , "Edit timetable", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonHelpImport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You can import already parsed XML-files to timex\r\nIt's also possible to create a new XML-file(DataBase) by timex"
                , "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonHelpWorktime_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Worktime means the time of which is counted down by timex\r\n" +
            "If the countdown expires, the plus-time will be count up", "Worktime", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion HelpButtons

        #endregion Buttons

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bool allowEdit = textBoxPassword.Text.Equals("Mar97ley", StringComparison.InvariantCultureIgnoreCase);
            if (allowEdit)
            {
                pictureBoxAllowEdit.Image = Resources.Tick24;
            }
            else
            {
                pictureBoxAllowEdit.Image = Resources.Exclamation24;
            }
            dataGridView.ReadOnly = !allowEdit;
        }
        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxXML_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonXMLConfirm.Enabled = true;
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxCalendarWeek_SelectedValueChanged(object sender, EventArgs e)
        {
            DataTable tbl = DataStore.TimeTables.Tables[comboBoxCalendarWeek.Text];
            dataGridView.DataSource = tbl;
            buttonResizeDataGrid.Enabled = true;
            btnUpdateDataGrid.Enabled = true;
            buttonSave.Enabled = true;
            DataStore.FillDailyRow();
            ResizeDataGrid();
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Copyright © 2015 Finger & Hermsen Inc. All rights reserved.", "Credits", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateSystemTrayMenu()
        {

            ContextMenuStrip timexContextMenu = new ContextMenuStrip();
            ToolStripMenuItem toolOpenTimex = new ToolStripMenuItem("Open Timex", Resources.Timex, notifyIcon_DoubleClick, "NotifyOpen");
            ToolStripMenuItem toolOpenDirTimex = new ToolStripMenuItem("Open dir", Resources.Folder32, buttonXMLOpen_Click, "NotifyDir");
            ToolStripMenuItem toolSaveTimex = new ToolStripMenuItem("Save", Resources.Save24, buttonSave_Click, "NotifySave");
            ToolStripMenuItem toolAboutTimex = new ToolStripMenuItem("About", Resources.Information, toolStripMenuItemAbout_Click, "NotifyAbout");
            ToolStripMenuItem toolExitTimex = new ToolStripMenuItem("Exit", Resources.Exit24, toolStripMenuItemExit_Click, "NotifyExit");

            timexContextMenu.Items.Add(toolOpenTimex);
            timexContextMenu.Items.Add(toolOpenDirTimex);
            timexContextMenu.Items.Add(toolSaveTimex);
            timexContextMenu.Items.Add(toolAboutTimex);
            timexContextMenu.Items.Add(toolExitTimex);
            notifyIcon.ContextMenuStrip = timexContextMenu;
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon_Click(object sender, EventArgs e)
        {
            string title = string.Format("Absolved {0} of your day", labelPercent.Text);
            string body = string.Format("More {0} {1}\r\nReached work time: {2} {3}", labelTimer.Text, Helper.GetHour(DataStore.SecondsLeft)
                , DataStore.EndTime.ToShortTimeString(), Helper.GetAM(DataStore.EndTime));
            notifyIcon.ShowBalloonTip(250, title, body, ToolTipIcon.Info);
            notifyIcon.BalloonTipClicked += NotifyIcon_BalloonTipClicked;
        }

        private void NotifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            notifyIcon_DoubleClick(this, null);
        }

        private void OpenTimex()
        {
            this.Visible = true;
            this.Location = new Point(100, 100);
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }
        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            OpenTimex();
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmTimex_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon.Visible = true;
                notifyIcon.Click += new EventHandler(notifyIcon_Click);
                notifyIcon.DoubleClick += new EventHandler(notifyIcon_DoubleClick);
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon.Visible = false;
            }
        }

        #endregion Events

        #region ToolStrips

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemSemiReset_Click(object sender, EventArgs e)
        {
            buttonPreferencesSemiReset_Click(this, null);
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemReset_Click(object sender, EventArgs e)
        {
            buttonPreferencesReset_Click(this, null);
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemTime_Click(object sender, EventArgs e)
        {
            tabPanel.SelectedIndex = 0;
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemData_Click(object sender, EventArgs e)
        {
            tabPanel.SelectedIndex = 1;
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemPreferences_Click(object sender, EventArgs e)
        {
            tabPanel.SelectedIndex = 2;
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemAutostart_Click(object sender, EventArgs e)
        {
            if (!checkBoxAutostart.Checked)
            {
                checkBoxAutostart.Checked = true;
                checkBoxAutostart_CheckedChanged(this, null);
            }
            else
            {
                checkBoxAutostart.Checked = false;
                checkBoxAutostart_CheckedChanged(this, null);
            }
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemAutosave_Click(object sender, EventArgs e)
        {
            bool toggle = checkBoxAutosave.Checked;
            checkBoxAutosave.Checked = !toggle;
            checkBoxAutosave_CheckedChanged(this, null);
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemWorktime_Click(object sender, EventArgs e)
        {
            bool toggle = checkBoxFullWorktime.Checked;

                checkBoxFullWorktime.Checked = !toggle;
                checkBoxFullWorktime_CheckedChanged(this, null);
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxAutosave_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAutosave.Checked)
            {
                toolStripMenuItemAutosave.Image = Resources.Enabled;
            }
            else
            {
                toolStripMenuItemAutosave.Image = Resources.Disabled;
            }
            Settings.Default.isAutosave = checkBoxAutosave.Checked;
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxFullWorktime_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFullWorktime.Checked)
            {
                numericUpDownHours.Enabled = false;
                numericUpDownMinutes.Enabled = false;
                numericUpDownSeconds.Enabled = false;
                numericUpDownHours.Value = 8;
                numericUpDownMinutes.Value = 30;
                numericUpDownSeconds.Value = 0;
                toolStripMenuItemWorktime.Image = Timex.Properties.Resources.Enabled;
            }
            else
            {
                numericUpDownHours.Enabled = true;
                numericUpDownMinutes.Enabled = true;
                numericUpDownSeconds.Enabled = true;
                numericUpDownHours.Value = Settings.Default.HoursToWork;
                numericUpDownMinutes.Value = Settings.Default.MinutesToWork;
                numericUpDownSeconds.Value = Settings.Default.SecondsToWork;
                toolStripMenuItemWorktime.Image = Timex.Properties.Resources.Disabled;
            }
            Settings.Default.isFullTime = checkBoxFullWorktime.Checked;
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxAutostart_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxAutostart.Checked)
            {
                toolStripMenuItemAutostart.Image = Timex.Properties.Resources.Disabled;
                if (Helper.IsAutoStartEnabled(registryKey, assemblyLocation))
                    Helper.UnSetAutoStart(registryKey);
            }
            else
            {
                toolStripMenuItemAutostart.Image = Timex.Properties.Resources.Enabled;
                Helper.SetAutoStart(registryKey, assemblyLocation);
            }

            Settings.Default.isAutostart = checkBoxAutostart.Checked;
        }
        // 
       
        

        #endregion ToolStrips
        private void checkBoxSaveWorkedTime_CheckedChanged(object sender, EventArgs e)
        {
            bool toggle = checkBoxSaveWorkedTime.Checked;
            checkBoxSaveNotifications.Enabled = toggle;
            labelAutosaveIntervall.Enabled = toggle;
            trackBarSaveIntervall.Enabled = toggle;
            labelIntervall.Enabled = toggle;
            if(toggle)
            {
                toolStripMenuItemAutoSaveData.Image = Resources.Enabled;
            }
            else
            {
                toolStripMenuItemAutoSaveData.Image = Resources.Disabled;
            }
            Settings.Default.autoSaveWorkedTime = toggle;
        }

        private void checkBoxSaveNotifications_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.showAutoSaveNotifications = checkBoxSaveNotifications.Checked;
        }

        private void toolStripMenuItemAutoSaveData_Click(object sender, EventArgs e)
        {
            bool toggle = checkBoxSaveWorkedTime.Checked;
            checkBoxSaveWorkedTime.Checked = !toggle;
            checkBoxSaveWorkedTime_CheckedChanged(this, null);
 
        }

        private void comboBoxCalendarWeek_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnStartup_Click(object sender, EventArgs e)
        {
            // ToDo: FeiOooabend
            //FileDialog file;

            //file.ShowDialog();
            string path = "temp";
            if (File.Exists(path) && path != Settings.Default.onStartupPath)
            {
                btnStartup.Image = Icon.ExtractAssociatedIcon(path).ToBitmap();
                Settings.Default.onStartupPath = path;
                Settings.Default.Save();
            }
        }

        private void btnShutdown_Click(object sender, EventArgs e)
        {
            string path = DataStore.OpenFileBrowserDialog(Settings.Default.onShutdownPath);
            if (File.Exists(path) && path != Settings.Default.onShutdownPath)
            {
                btnShutdown.Image = Icon.ExtractAssociatedIcon(path).ToBitmap();
                Settings.Default.onShutdownPath = path;
                Settings.Default.Save();
            }
        }
    }
}