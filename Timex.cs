using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timex.Properties;

namespace Timex
{
    public partial class TimexForm : FrmBase
    {
        public TimexForm()
        {
            InitializeComponent();
            ResetButtonsToDefault();
            StartWorkTimer();
            StartClockTimer();
            MyTimeTable.FillTimeTable();
            FillLabels();
        }

        #region Klassen
        DateTimeHandler MyDateTimeHandler = new DateTimeHandler();
        Timers MyTimers = new Timers();
        TimeTable MyTimeTable = new TimeTable();
        #endregion Klassen


        #region Properties

        public DateTime ActualDate { get; set; }
        public DateTime ActualTime { get; set; }
        public Timer TheWorkTimer { get { return WorkTimer; } }
        public int SecondsLeft { get; set; }
        public int SecondsDone { get; set; }
        public int SecondsPlus { get; set; }
        public bool isDone { get; set; }
        public int currentWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        #region Methoden

        public string ToTimeString(int seconds)
        {
            return string.Format("{0:00}:{1:00}:{2:00}", seconds / 3600, (seconds / 60) % 60, seconds % 60);
        }

        public string ToTimeString(double seconds)
        {
            return string.Format("{0:00}:{1:00}:{2:00}", seconds / 3600, (seconds / 60) % 60, seconds % 60);
        }

        public void setDataGrid()
        {
            //dataGridView.DataSource = MyTimeTable.FillTimeTable();
        }

        private void StartWorkTimer()
        {
            if (firstStart)
            {
                SecondsLeft = MyDateTimeHandler.GetSecondsToWork(numericUpDownHours.Value.ToString(), numericUpDownMinutes.Value.ToString(), numericUpDownSeconds.Value.ToString());
                WorkTimer.Tick += new EventHandler(WorkTimer_Tick);
                StartTime = DateTime.Now;
                EndTime = DateTime.Now.AddSeconds(SecondsLeft);
                progressBar.Maximum = Convert.ToInt32(SecondsLeft);
            }
            labelPredictTime.Text = "Expected end of Work: " + EndTime.ToShortTimeString() + " " + MyDateTimeHandler.GetAM(EndTime);
            buttonStart.Enabled = false;
            buttonPause.Enabled = true;
            labelTimer.ForeColor = System.Drawing.Color.Black;
            WorkTimer.Interval = 1000;
            WorkTimer.Start();

        }

        public void StopWorkTimer()
        {
            WorkTimer.Stop();
            SecondsLeft = 0;
            labelTimer.Text = "Process stopped";
            labelTimer.ForeColor = System.Drawing.Color.Red;
            labelHourOrMinute.Text = string.Empty;
            progressBar.Value = 0;
            buttonPause.Enabled = false;
            buttonStart.Enabled = true;
            ResetButtonsToDefault();
        }

        public void ResizeDataGrid()
        {
            dataGridView.AutoResizeColumns();
            dataGridView.AutoResizeColumnHeadersHeight();
            dataGridView.AutoResizeColumns();
            dataGridView.AutoResizeRows();
        }

        private void FillLabels()
        {
            labelDate.Text = "It's " + DateTimeHandler.DateString;
            labelTime.Text = MyDateTimeHandler.TimeString + " Uhr " + MyDateTimeHandler.GetAM();
            labelPredictTime.Text = "Expected end of Work: " + EndTime.ToShortTimeString() + " Uhr";
            labelStartTime.Text = "Started work ";
            labelCurrentCalendarWeek.Text = "Current calendar week: " + currentWeek.ToString();
            labelCurrentWeek.Text = "Current week: " + currentWeek.ToString();
            comboBoxCalendarWeek.Items.Clear();
            foreach (DataTable table in MyTimeTable.TimeTables.Tables)
            {
                comboBoxCalendarWeek.Items.Add(table.TableName);
            }
            firstStart = false;
        }

        private void ResetButtonsToDefault()
        {

            WorkTimer.Stop();
            SecondsLeft = MyDateTimeHandler.GetSecondsToWork(numericUpDownHours.Value.ToString(), numericUpDownMinutes.Value.ToString(), numericUpDownSeconds.Value.ToString());
            buttonStart.Enabled = true;
            progressBar.Value = 0;
            currentWeek = MyTimeTable.GetWeekOfYear(DateTime.Now);
            labelPredictTime.Text = "Expected end of Work: ";
            labelStartTime.Text = "Started work ";
            labelTime.Text = MyDateTimeHandler.TimeString + " Uhr " + MyDateTimeHandler.GetAM();
            labelDate.Text = "It's " + DateTimeHandler.DateString;
            if (firstStart)
            {
                buttonStart.Enabled = false;
                WorkTimer.Interval = 1000;
                WorkTimer.Enabled = true;
            }
        }
        private string GetHour(double seconds)
        {
            if (seconds < 3600)
            {
                return "minutes";
            }
            else
            {
                return "hours";
            }
        }

        #endregion Methoden

        #endregion Properties


        #region Interne Variablen

        private Timer WorkTimer = new Timer();
        bool firstStart = true;

        #endregion Interne Variablen

        #region Eventhandler

        public void WorkTimer_Tick(object sender, EventArgs e)
        {
            if (SecondsLeft > 0)
            {
                SecondsLeft--;
                SecondsDone++;
                progressBar.Value++;
                labelTimer.Text = ToTimeString(SecondsLeft);
                textBoxWorkedToday.Text = ToTimeString(SecondsDone) + " h";
                textBoxStartTime.Text = StartTime.ToLongTimeString() + " " + MyDateTimeHandler.GetAM(DateTime.Now);
                labelHourOrMinute.Text = GetHour(SecondsLeft) + " left";

            }
            else
            {
                isDone = true;
                if (checkBoxPCShutdown.Checked)
                {
                    WorkTimer.Stop();
                    Process.Start("shutdown -s -t 00");
                    DialogResult pcShutdown = MessageBox.Show("Prepare for shutdown", "PC shutdown", MessageBoxButtons.OKCancel);
                    if (DialogResult == DialogResult.Cancel)
                    {
                        Process.Start("shutdown -a");
                    }
                }
                SecondsDone++;
                SecondsPlus++;
                textBoxWorkedToday.Text = ToTimeString(SecondsDone) + " h";
                labelTimer.ForeColor = System.Drawing.Color.Green;
                labelHourOrMinute.Text = "overtime";
                labelTimer.Text = ToTimeString(SecondsPlus);
            }
        }
        #endregion Eventhandler

        #region Konstruktoren

        private void buttonStart_Click(object sender, EventArgs e)
        {
            StartWorkTimer();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Stop Timer?\r\nThis action is not able to revert", "Stop Timer", MessageBoxButtons.YesNo);
            if (DialogResult == DialogResult.Yes)
            {
                StopWorkTimer();
            }
            else
            {
                //
            }
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            buttonPause.Enabled = false;
            WorkTimer.Interval = 9999999;
            buttonStart.Enabled = true;
        }

        public void StartClockTimer()
        {
            Timer ClockTimer = new Timer();
            ClockTimer.Interval = 1000;
            ClockTimer.Start();
            ClockTimer.Tick += new EventHandler(ClockTimer_Tick);
        }
        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToLongTimeString() + " " + MyDateTimeHandler.GetAM();
        }

        #endregion Konstruktoren
        #region Buttons
        #endregion Buttons
        private void buttonClipboard1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("Until now, I've been working for " + textBoxWorkedToday.Text + " hours");
        }

        private void buttonClipboard2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("Since monday, I've worked for " + textBoxWeeklySurplus.Text + " hours");
        }

        private void buttonClipboard3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("I've started working at " + textBoxStartTime.Text + " " + MyDateTimeHandler.GetAM(StartTime));
        }

        private void buttonClipboardAll_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("I've started working at " + textBoxStartTime.Text + " " + MyDateTimeHandler.GetAM(StartTime) + " Since monday, I've worked for " + textBoxWeeklySurplus.Text + " hours." + "\r\nUntil now, I've been working for " + textBoxWorkedToday.Text + " hours");
        }
        private void buttonPreferencesSubmit_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Reset timer?\r\nThis action requieres a reset of the timer.", "Reset Timer", MessageBoxButtons.YesNo);
            if (DialogResult == DialogResult.Yes)
            {
                WorkTimer.Stop();
                ResetButtonsToDefault();
                SecondsLeft = MyDateTimeHandler.GetSecondsToWork(numericUpDownHours.Value.ToString(), numericUpDownMinutes.Value.ToString(), numericUpDownSeconds.Value.ToString());
                //StartTime = DateTime.Now;
                EndTime = DateTime.Now.AddSeconds(SecondsLeft);
                progressBar.Maximum = Convert.ToInt32(SecondsLeft);
                StartWorkTimer();
                tabPanel.SelectedIndex = 0;
            }
            else
            {
                //
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "einbauküche")
            {
                checkBoxAllowEdit.Enabled = true;
            }
            else if (textBoxPassword.Text == "Einbauküche")
            {
                checkBoxAllowEdit.Enabled = true;
            }
            else
            {
                checkBoxAllowEdit.Enabled = false;
            }
        }

        private void checkBoxAllowEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAllowEdit.Checked)
            {
                dataGridView.ReadOnly = false;
            }
            else
            {
                dataGridView.ReadOnly = false;
            }
        }

        private void buttonResizeDataGrid_Click(object sender, EventArgs e)
        {
            ResizeDataGrid();
        }

        private void comboBoxCalendarWeek_SelectedValueChanged(object sender, EventArgs e)
        {
            //DataTable dataTable; 
            //if (MyTimeTable.TimeTables.TryGetValue(comboBoxCalendarWeek.SelectedValue as string, out dataTable))
            //{
            //    dataGridView.DataSource = dataTable;
            //}
            DataTable tbl = MyTimeTable.TimeTables.Tables[comboBoxCalendarWeek.Text];
            dataGridView.DataSource = tbl;
            ResizeDataGrid();

        }

        #region Dialog

        private void toolStripMenuItemReset_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Reset timer?\r\nThis action is not able to revert", "Reset Timer", MessageBoxButtons.YesNo);
            if (DialogResult == DialogResult.Yes)
            {
                ResetButtonsToDefault();
                StopWorkTimer();
            }
            else
            {
                //
            }
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItemPreferences_Click(object sender, EventArgs e)
        {
            tabPanel.SelectedIndex = 2;
        }

        #endregion Dialog

        private void toolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Copyright © 2015 Finger & Hermsen Inc. All rights reserved.", "Credits");
        }


    }
}
