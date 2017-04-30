using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using DirectoryExchanger;

namespace Timex
{
    internal class DataStore
    {
        #region Konstruktoren

        public DataStore()
        {
            TimeTables = new DataSet();
            CurrentWeek = Helper.GetWeekOfYear(DateTime.Now);
            StartTime = DateTime.Now;
        }

        #endregion Konstruktoren


        #region Properties

        public int SecondsPlus;
        //{
        //    get
        //    {
        //        if (SecondsLeft < 0)
        //            return (SecondsLeft * -1);
        //        return 0;
        //    }
        //}

        public TimeSpan PlusOfWeek;

        public int CurrentWeek { get; set; }

        public int DailyIndex { get; set; }

        public DataSet TimeTables { get; set; }

        public string XMLPath { get; set; }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Zeit bei Programmstart
        /// </summary>
        public DateTime StartTime { get; private set; }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Berechnetes Arbeitszeitende
        /// </summary>
        public DateTime EndTime { get; private set; }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        public int WorkDuration { get { return (int)(EndTime - StartTime).TotalSeconds; } }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        public int SecondsDone { get { return (int)(DateTime.Now - StartTime).TotalSeconds; } }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        public int SecondsLeft { get { return (int)(EndTime - DateTime.Now).TotalSeconds; } }

        #endregion Properties

        #region Methoden


        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Aktualisiert die Reihe für den jeweiligen Tag
        /// </summary>
        public void FillDailyRow()
        {
            try
            {
                int i = TimeTables.Tables.IndexOf(CurrentWeek.ToString());
                DataTable tbl = TimeTables.Tables[i];
                int businessDayNumber = (int)DateTime.Now.DayOfWeek - 1;
                
                tbl.Rows[businessDayNumber][1] = DateTime.Now.Date.ToShortDateString();
                tbl.Rows[businessDayNumber][2] = StartTime.ToLongTimeString();
                tbl.Rows[businessDayNumber][3] = string.Format("{0:00}:{1:00}:{2:00}", SecondsDone / 3600, (SecondsDone / 60) % 60, SecondsDone % 60);
                tbl.Rows[businessDayNumber][4] = EndTime.ToLongTimeString();
                tbl.Rows[businessDayNumber][5] = Helper.ToTimeString(SecondsPlus - SecondsLeft);

                tbl.Rows[5][1] = Helper.ComputeWeek(tbl.Rows[0][1].ToString());
                tbl.Rows[5][2] = ComputeAverage(2);
                tbl.Rows[5][3] = ComputeSum(3);
                tbl.Rows[5][4] = ComputeAverage(4);
                tbl.Rows[5][5] = ComputeSum(5) + GetLastDiffernce(CurrentWeek);
                PlusOfWeek = TimeSpan.Parse(tbl.Rows[5][5].ToString());
                TimeTables.Tables[i].AcceptChanges();
                if(PlusOfWeek.Ticks < 0)
                {
                    PlusOfWeek = TimeSpan.Zero;
                }
            }
            catch (Exception)
            {
                CreateNextTable(Helper.GetWeekOfYear(DateTime.Now));
            }
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Prüft, ob die Tabelle für die jeweilige Woche bereits angelegt ist
        /// </summary>
        public void CheckTable()
        {
            CurrentWeek = Helper.GetWeekOfYear(DateTime.Now);
            if (!TimeTables.Tables.Contains(CurrentWeek.ToString()))
            {
                CreateNextTable(CurrentWeek);
            }
            DailyIndex = TimeTables.Tables.IndexOf(CurrentWeek.ToString());

            FillDailyRow();
        }

        /// <summary>
        /// Tabelle
        /// </summary>
        /// <param name="week">einzelne Tage</param>
        public void CreateNextTable(int week)
        {
            DataTable dtx = new DataTable();
            DataRow Monday = dtx.NewRow();
            DataRow Tuesday = dtx.NewRow();
            DataRow Wednesday = dtx.NewRow();
            DataRow Thursday = dtx.NewRow();
            DataRow Friday = dtx.NewRow();
            DataRow AvgSum = dtx.NewRow();

            DataColumn weekday = new DataColumn() { ColumnName = "Weekday" };
            DataColumn date = new DataColumn() { ColumnName = "Date" };
            DataColumn startOfWork = new DataColumn() { ColumnName = "Started work" };
            DataColumn workedToday = new DataColumn() { ColumnName = "Whole worked" };
            DataColumn workEnd = new DataColumn() { ColumnName = "End of work" };
            DataColumn plusTime = new DataColumn() { ColumnName = "Difference of day" };

            dtx.Columns.Add(weekday);
            dtx.Columns.Add(date);
            dtx.Columns.Add(startOfWork);
            dtx.Columns.Add(workedToday);
            dtx.Columns.Add(workEnd);
            dtx.Columns.Add(plusTime);

            Monday[0] = "Monday";
            Tuesday[0] = "Tuesday";
            Wednesday[0] = "Wednesday";
            Thursday[0] = "Thursday";
            Friday[0] = "Friday";
            AvgSum[0] = "Avg & Sum";

            dtx.Rows.Add(Monday);
            dtx.Rows.Add(Tuesday);
            dtx.Rows.Add(Wednesday);
            dtx.Rows.Add(Thursday);
            dtx.Rows.Add(Friday);
            dtx.Rows.Add(AvgSum);

            string weekNumber = week.ToString();
            dtx.TableName = weekNumber;
            if (!TimeTables.Tables.Contains(weekNumber))
            {
                TimeTables.Tables.Add(dtx);
            }
            else
            {
                DialogResult result = MessageBox.Show("The XML-file you've imported is broken, do you want to override the corruped parts?\r\n" +
                    "If you choose Nein/No, the default Table will be restored.", "Duplicate Tablenames", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    TimeTables.Tables.Remove(weekNumber);
                    TimeTables.Tables.Add(dtx);
                    Writer(XMLPath);
                }
                else
                {
                    string path = string.Format("{0}\\TimeTable.xml", Application.StartupPath);
                    Reader(path);
                    XMLPath = path;
                    MessageBox.Show(string.Format("The default XML-file\r\nPath: {0}\r\nhas been restored and set as default.\r\n"
                    , path), "XML restored", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); //ToDo: Klasse ChangeXML bzw deren Komponenten aufrufen oder If-Abfrage in FrmTimex auslagern
                }
            }
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Mittelwert errechner
        /// </summary>
        private string ComputeAverage(int column)
        {
            List<DateTime> times = new List<DateTime>();
            for (int i = 0; i < 5; i++)
            {
                DateTime time;
                string currenttime = TimeTables.Tables[DailyIndex].Rows[i][column].ToString();
                if (!string.IsNullOrEmpty(currenttime))
                {
                    DateTime.TryParse(currenttime, out time);
                    times.Add(time);
                }
            }
            long[] lngTicks = new long[times.Count];
            long lngTotal = 0;

            for (int i = 0; i < times.Count; i++)
            {
                lngTicks[i] = times[i].Ticks;
                lngTotal += lngTicks[i];
            }
            DateTime dt = new DateTime(lngTotal / lngTicks.Length);
            return string.Format("{0} {1}", new DateTime(lngTotal / lngTicks.Length).ToShortTimeString(), Helper.GetAM(dt));
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Summen errechner
        /// </summary>
        private TimeSpan ComputeSum(int column)
        {
            List<string> plus = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                plus.Add(TimeTables.Tables[DailyIndex].Rows[i][column].ToString());
            }
            TimeSpan plusTime = new TimeSpan();
            TimeSpan singlePlusTime = new TimeSpan();
            foreach (string plusOfDay in plus)
            {
                if (!string.IsNullOrEmpty(plusOfDay))
                {
                    TimeSpan.TryParse(plusOfDay, out singlePlusTime);
                    plusTime += singlePlusTime;
                }
            }
            return plusTime;
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Neues XML-Dokument anlegen & dem DataSet hinzufügen
        /// </summary>
        public void CreateNewXMLDocument(string name, string path)
        {
            TimeTables.Tables.Add(name);
            TimeTables.Tables[name].WriteXml(path);
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Rechnet die Plus/Minus Zeit der letzten Woche in die aktuelle Woche, wenn ein DataTable für die letzte Woche vorhanden ist
        /// </summary>
        public TimeSpan GetLastDiffernce(int NormalWeek) 
        {
            TimeSpan diff = new TimeSpan();
            int lastWeekIndex = NormalWeek - 1;
            string lastTable = lastWeekIndex.ToString();
            if (TimeTables.Tables.IndexOf(TimeTables.Tables[NormalWeek.ToString()]) >= 1)
            {
                try
                {
                    string toParse = TimeTables.Tables[lastTable].Rows[5][5].ToString();
                    TimeSpan.TryParse(toParse, out diff);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Could not calculate last time-difference\r\n"+e.Message, "Error while parsing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
            
            return diff; 
            }
            else
            {
                return diff;
            }
            
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// XML Writer
        /// </summary>
        public void Writer(string path)
        {
            TimeTables.WriteXml(path);
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// XML Reader
        /// </summary>
        public void Reader(string path)
        {
            TimeTables.ReadXml(path);
        }

        internal void UpdateWorkDuration(int hours, int minutes, int seconds)
        {
            EndTime = StartTime.Add(new TimeSpan(hours, minutes, seconds));
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///
        /// </summary>
        public int GetPercent()
        {
            float percent = 0;
            if (SecondsDone > WorkDuration)
            {
                percent = 100;
            }
            else if (WorkDuration > 0)
            {
                percent = 100f * SecondsDone / WorkDuration;
            }
            return Convert.ToInt32(percent);
        }

        /// <summary>
        /// Öffnet einen FolderBrowserDialog und gibt den entsprechenden Pfad in die Textbox zurück || string.Empty
        /// </summary>
        public static string OpenFileBrowserDialog(string path = "")
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            FolderBrowserDialogEx openPath = new FolderBrowserDialogEx()
            {
                Description = "Choose a directory",
                ShowNewFolderButton = false,
                SelectedPath = Directory.Exists(path) ? path : desktop,
                ShowEditBox = true,
                ShowFullPathInEditBox = true
            };

            DialogResult result = openPath.ShowDialog();
            if ((Directory.Exists(openPath.SelectedPath) || openPath.SelectedPath == desktop) && result == DialogResult.OK)
            {
                return openPath.SelectedPath;
            }
            else
            {
                return string.Empty;
            }
        }

        public static string OpenFolderBrowserDialog(string path = "")
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            FolderBrowserDialogEx openPath = new FolderBrowserDialogEx()
            {
                Description = "Choose a directory",
                ShowNewFolderButton = false,
                SelectedPath = Directory.Exists(path) ? path : desktop,
                ShowEditBox = true,
                ShowFullPathInEditBox = true
            };
            DialogResult result = openPath.ShowDialog();
            if ((Directory.Exists(openPath.SelectedPath) || openPath.SelectedPath == desktop) && result == DialogResult.OK)
            {
                return openPath.SelectedPath;
            }
            return string.Empty;
        }

        #endregion Methoden
    }
}