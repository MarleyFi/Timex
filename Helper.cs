using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Timex
{
    public static class Helper
    {
        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Autostart Pfad
        /// </summary>
        public const string autorunpath = @"Software\Microsoft\Windows\CurrentVersion\Run";

        #region Methoden

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Autostart Funktion
        /// </summary>
        /// <param name="registryKey">Autostart Funktion</param>
        /// <param name="assemblyLocation">Autostart Funktion</param>
        public static void SetAutoStart(string registryKey, string assemblyLocation)
        {
            RegistryKey autorunregistry = Registry.CurrentUser.CreateSubKey(autorunpath);
            autorunregistry.SetValue(registryKey, assemblyLocation);
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Aktiviert Autostart beim Klick auf Checkbox
        /// </summary>
        /// <param name="registryKey">Autostart Funktion</param>
        /// <param name="assemblyLocation">Autostart Funktion</param>
        /// <returns></returns>
        public static bool IsAutoStartEnabled(string registryKey, string assemblyLocation)
        {
            string dir = Application.StartupPath;
            string[] documents = Directory.GetFiles(dir, "*.xml", SearchOption.AllDirectories);
            for (int i = 0; i < documents.Length; i++)
            {
                documents[i] = Path.GetFileName(documents[i]);
            }

            RegistryKey autorunregistry = Registry.CurrentUser.OpenSubKey(autorunpath);
            if (autorunregistry == null)
                return false;

            string value = (string)autorunregistry.GetValue(registryKey);
            if (value == null)
                return false;

            return (value == assemblyLocation);
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Deaktiviert Autostart
        /// </summary>
        /// <param name="registryKey">Autostart Funktion</param>
        public static void UnSetAutoStart(string registryKey)
        {
            RegistryKey autorunregistry = Registry.CurrentUser.CreateSubKey(autorunpath);
            autorunregistry.DeleteValue(registryKey);
        }

        public static string ComputeWeek(string start)
        {
            DateTime startDate;
            DateTime endDate;
            DateTime.TryParse(start, out startDate);
            endDate = startDate.AddDays(4.0);
            string week = string.Format("{0:dd.MM}-{1:dd.MM}", startDate.Date, endDate.Date);
            return week;
        }

        public static string BuildDateString(DateTime dt)
        {
            CultureInfo ci = new CultureInfo("en-GB");
            string monthName = dt.ToString("MMM", ci);
            return string.Format("{0} the {1}. {2}.", dt.DayOfWeek, dt.Day, monthName);
        }


        public static string GetAM(DateTime time = new DateTime())
        {
            return time.Hour > 11 ? Const.PM : Const.AM;
        }


        public static int GetSecondsToWork(decimal hours, decimal minutes, decimal seconds)
        {
            decimal totalSeconds = 0;
            totalSeconds += hours * 60 * 60;
            totalSeconds += minutes * 60;
            totalSeconds += seconds;
            return Convert.ToInt16(totalSeconds);
        }

        public static string ToTimeString(int seconds)
        {
            string time = string.Format("{0:00}:{1:00}:{2:00}", seconds / 3600, (seconds / 60) % 60, seconds % 60);
            char[] minus = { '-' };
            if (time.Contains("-"))
            {
                time = time.Replace("-", "");
                time = "-" + time;
            }
            return time;
        }

        public static int GetWeekOfYear(DateTime dt)
        {
            CultureInfo ci = new CultureInfo("en-GB");
            return ci.Calendar.GetWeekOfYear(dt, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public static string GetHour(double seconds)
        {
            if (seconds > 3600)
            {
                return "hours";
            }
            else if (seconds < 3600)
            {
                return "minutes";
            }
            else
            {
                return "seconds";
            }
        }

        public static int GetMillisOfMinutes(int minutes)
        {
            return ((minutes * 1000) * 60);
        }

        public static int GetMinutesOfMillis(int millis)
        {
            return ((millis / 1000) / 60);
        }

        public static int GetScrollIndexOfMillis(int millis)
        {
            return (GetMinutesOfMillis(millis) / 5) - 1;
        }

        #endregion Methoden
    }
}