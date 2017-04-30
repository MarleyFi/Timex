using System;
using System.Windows.Forms;

namespace Timex
{
    internal static class Program
    {
        /// ============================================================================================================================
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.ThreadException += Application_ThreadException;

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                FrmTimex frm = new FrmTimex();
                Application.Run(frm);
            }
            catch (Exception e)
            {
                ShowException(e);
            }
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        private static void ShowException(Exception e)
        {
            MessageBox.Show(e.Message);
            Application.Exit();
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            ShowException(e.Exception);
        }
    }
}