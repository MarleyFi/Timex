using System;
using System.Windows.Forms;
using System.Collections;

namespace Timex
{
    /// ============================================================================================================================
    /// <summary>
    /// Nebenfenster Form2, erscheint wenn Countdown auf 0 steht
    /// </summary>
    public partial class FrmBongoBongo : Form
    {


        #region Konstruktoren

        public FrmBongoBongo()
        {
            InitializeComponent();
        }

        #endregion

        #region Interne Variablen

        
        

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Timertickanzahl Affe 1
        /// </summary>
        public int tickanzahlaffe = 0;

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Timertickanzahl Affe2
        /// </summary>
        public int tickanzahlaffe2 = 0;

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Timertickanzahl Farbblöcke
        /// </summary>
        public int tickanzahlfarbblock = 0;

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Timertickanzahl SchwarzWeiß
        /// </summary>
        public int tickanzahlSW = 0;

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Timertickanzahl Fuchsia
        /// </summary>
        public int tickanzahlfuchsia = 0;

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Timertickanzahl Fuchsia Reihen
        /// </summary>
        public int tickanzahlfuchsiarow = 0;


        #endregion
        #region Methoden
        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Alle Fuchsia Querbalken verstecken
        /// </summary>
        public void HideallRowFuchsia()
        {
            pictureBoxFuchsiarow1.Hide();
            pictureBoxFuchsiarow2.Hide();
            pictureBoxFuchsiarow3.Hide();
            pictureBoxFuchsiarow4.Hide();
            pictureBoxFuchsiarow5.Hide();
            pictureBoxFuchsiarow6.Hide();
            pictureBoxFuchsiarow7.Hide();
            pictureBoxFuchsiarow8.Hide();
            pictureBoxFuchsiarow9.Hide();
            pictureBoxFuchsiarow10.Hide();
            pictureBoxFuchsiarow11.Hide();
            pictureBoxFuchsiarow12.Hide();
            pictureBoxFuchsiarow13.Hide();
            pictureBoxFuchsiarow14.Hide();
            pictureBoxFuchsiarow15.Hide();
            pictureBoxFuchsiarow16.Hide();
            pictureBoxFuchsiarow17.Hide();
            pictureBoxFuchsiarow18.Hide();
            pictureBoxFuchsiarow19.Hide();
            pictureBoxFuchsiarow20.Hide();
            pictureBoxFuchsiarow21.Hide();
            pictureBoxFuchsiarow22.Hide();
            pictureBoxFuchsiarow23.Hide();
            pictureBoxFuchsiarow24.Hide();
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Kein Bild 5 -8
        /// </summary>
        public void Shownonefivetoeight()
        {
            pictureBoxAffe5.Hide();
            pictureBoxAffe6.Hide();
            pictureBoxAffe7.Hide();
            pictureBoxAffe8.Hide();
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Bild 5-8
        /// </summary>
        public void Showallfivetoeight()
        {
            pictureBoxAffe5.Show();
            pictureBoxAffe6.Show();
            pictureBoxAffe7.Show();
            pictureBoxAffe8.Show();
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Bild 5+7
        /// </summary>
        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Bild 6+8
        /// </summary>
        public void Showsixandeight()
        {
            pictureBoxAffe5.Hide();
            pictureBoxAffe6.Show();
            pictureBoxAffe7.Hide();
            pictureBoxAffe8.Show();
        }

        public void Showfiveandseven()
        {
            pictureBoxAffe5.Show();
            pictureBoxAffe6.Hide();
            pictureBoxAffe7.Show();
            pictureBoxAffe8.Hide();
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Alle Fuchsia Balken verstecken
        /// </summary>
        public void HideallFuchsia()
        {
            pictureBoxFuchsia1.Hide();
            pictureBoxFuchsia2.Hide();
            pictureBoxFuchsia3.Hide();
            pictureBoxFuchsia4.Hide();
            pictureBoxFuchsia5.Hide();
            pictureBoxFuchsia6.Hide();
            pictureBoxFuchsia7.Hide();
            pictureBoxFuchsia8.Hide();
            pictureBoxFuchsia9.Hide();
            pictureBoxFuchsia10.Hide();
            pictureBoxFuchsia11.Hide();
            pictureBoxFuchsia12.Hide();
            pictureBoxFuchsia13.Hide();
            pictureBoxFuchsia14.Hide();
            pictureBoxFuchsia15.Hide();
            pictureBoxFuchsia16.Hide();
            pictureBoxFuchsia17.Hide();
            pictureBoxFuchsia18.Hide();
            pictureBoxFuchsia19.Hide();
            pictureBoxFuchsia20.Hide();
            pictureBoxFuchsia21.Hide();
            pictureBoxFuchsia22.Hide();
            pictureBoxFuchsia23.Hide();
            pictureBoxFuchsia24.Hide();
            pictureBoxFuchsia25.Hide();
            pictureBoxFuchsia26.Hide();
            pictureBoxFuchsia27.Hide();
            pictureBoxFuchsia28.Hide();
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Versteckt alle Schwarz Weiß Blöcke
        /// </summary>
        public void HideallBlackWhite()
        {
            pictureBoxSW1.Hide();
            pictureBoxSW2.Hide();
            pictureBoxSW3.Hide();
            pictureBoxSW4.Hide();
            pictureBoxSW5.Hide();
            pictureBoxSW6.Hide();
            pictureBoxSW7.Hide();
            pictureBoxSW8.Hide();
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Alle Farbblöcke verdecken
        /// </summary>
        public void HideAllPictureBox()
        {
            foreach (Control control in this.Controls)
            {
                if (control.GetType().Equals(typeof(PictureBox)))
                {
                    control.Hide();
                }
            }
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Hintergrund Lila-Rot
        /// </summary>
        public void Hidebackgrounds()
        {
            pictureBoxLila.Hide();
            pictureBoxBlau.Hide();
            pictureBoxGrün.Hide();
            pictureBoxGelb.Hide();
            pictureBoxOrange.Hide();
            pictureBoxRot.Hide();
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Bild 1+3
        /// </summary>

        public void Showoneandthree()
        {
            pictureBoxAffe1.Show();
            pictureBoxAffe2.Hide();
            pictureBoxAffe3.Show();
            pictureBoxAffe4.Hide();
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Bild 2+4
        /// </summary>
        public void Showtwoandfour()
        {
            pictureBoxAffe1.Hide();
            pictureBoxAffe2.Show();
            pictureBoxAffe3.Hide();
            pictureBoxAffe4.Show();
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Bild 1-4
        /// </summary>
        public void Showall()
        {
            pictureBoxAffe1.Show();
            pictureBoxAffe2.Show();
            pictureBoxAffe3.Show();
            pictureBoxAffe4.Show();
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Kein Bild
        /// </summary>
        public void Shownone()
        {
            pictureBoxAffe1.Hide();
            pictureBoxAffe2.Hide();
            pictureBoxAffe3.Hide();
            pictureBoxAffe4.Hide();
        }

        #endregion

        #region Events
        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Timer Fuchsia Querbalken
        /// </summary>
        /// <param name="sender">Timer Fuchsia Querbalken</param>
        /// <param name="e">Timer Fuchsia Querbalken</param>
        private void timerFuchsia2_Tick(object sender, EventArgs e)
        {
            tickanzahlfuchsiarow++;

            HideallRowFuchsia();

            if (tickanzahlfuchsiarow == 1)
            {
                pictureBoxFuchsiarow1.Show();
            }

            if (tickanzahlfuchsiarow == 2)
            {
                pictureBoxFuchsiarow2.Show();
            }

            if (tickanzahlfuchsiarow == 3)
            {
                pictureBoxFuchsiarow3.Show();
                pictureBoxFuchsiarow24.Show();
            }

            if (tickanzahlfuchsiarow == 4)
            {
                pictureBoxFuchsiarow4.Show();
                pictureBoxFuchsiarow23.Show();
            }

            if (tickanzahlfuchsiarow == 5)
            {
                pictureBoxFuchsiarow5.Show();
                pictureBoxFuchsiarow22.Show();
            }

            if (tickanzahlfuchsiarow == 6)
            {
                pictureBoxFuchsiarow6.Show();
                pictureBoxFuchsiarow21.Show();
            }

            if (tickanzahlfuchsiarow == 7)
            {
                pictureBoxFuchsiarow7.Show();
                pictureBoxFuchsiarow20.Show();
            }

            if (tickanzahlfuchsiarow == 8)
            {
                pictureBoxFuchsiarow8.Show();
                pictureBoxFuchsiarow19.Show();
            }

            if (tickanzahlfuchsiarow == 9)
            {
                pictureBoxFuchsiarow9.Show();
                pictureBoxFuchsiarow18.Show();
            }

            if (tickanzahlfuchsiarow == 10)
            {
                pictureBoxFuchsiarow10.Show();
                pictureBoxFuchsiarow17.Show();
            }

            if (tickanzahlfuchsiarow == 11)
            {
                pictureBoxFuchsiarow11.Show();
                pictureBoxFuchsiarow16.Show();
            }

            if (tickanzahlfuchsiarow == 12)
            {
                pictureBoxFuchsiarow12.Show();
                pictureBoxFuchsiarow15.Show();
            }

            if (tickanzahlfuchsiarow == 13)
            {
                pictureBoxFuchsiarow13.Show();
                
            }

            if (tickanzahlfuchsiarow == 14)
            {
                pictureBoxFuchsiarow14.Show();
                
            }

            if (tickanzahlfuchsiarow == 15)
            {
                pictureBoxFuchsiarow14.Show();
            }

            if (tickanzahlfuchsiarow == 16)
            {
                pictureBoxFuchsiarow13.Show();
            }

            if (tickanzahlfuchsiarow == 17)
            {
                pictureBoxFuchsiarow12.Show();
                pictureBoxFuchsiarow15.Show();
            }

            if (tickanzahlfuchsiarow == 18)
            {
                pictureBoxFuchsiarow11.Show();
                pictureBoxFuchsiarow16.Show();
            }

            if (tickanzahlfuchsiarow == 19)
            {
                pictureBoxFuchsiarow10.Show();
                pictureBoxFuchsiarow17.Show();
            }

            if (tickanzahlfuchsiarow == 20)
            {
                pictureBoxFuchsiarow9.Show();
                pictureBoxFuchsiarow18.Show();
            }

            if (tickanzahlfuchsiarow == 21)
            {
                pictureBoxFuchsiarow8.Show();
                pictureBoxFuchsiarow19.Show();
            }

            if (tickanzahlfuchsiarow == 22)
            {
                pictureBoxFuchsiarow7.Show();
                pictureBoxFuchsiarow20.Show();
            }

            if (tickanzahlfuchsiarow == 23)
            {
                pictureBoxFuchsiarow6.Show();
                pictureBoxFuchsiarow21.Show();
            }

            if (tickanzahlfuchsiarow == 24)
            {
                pictureBoxFuchsiarow5.Show();
                pictureBoxFuchsiarow22.Show();
            }

            if (tickanzahlfuchsiarow == 25)
            {
                pictureBoxFuchsiarow4.Show();
                pictureBoxFuchsiarow23.Show();
            }

            if (tickanzahlfuchsiarow == 26)
            {
                pictureBoxFuchsiarow3.Show();
                pictureBoxFuchsiarow24.Show();
            }


            if (tickanzahlfuchsiarow == 27)
            {
                pictureBoxFuchsiarow2.Show();
                
            }

            if (tickanzahlfuchsiarow == 28)
            {
                pictureBoxFuchsiarow1.Show();

                tickanzahlfuchsiarow = 0;
            }

        #endregion

        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerAffentanz2_Tick(object sender, EventArgs e)
        {

            tickanzahlaffe2++;


            if (tickanzahlaffe2 == 2)

                Showfiveandseven();



            if (tickanzahlaffe2 == 3)

                Showsixandeight();



            if (tickanzahlaffe2 == 4)

                Showallfivetoeight();


            if (tickanzahlaffe2 == 5)

                Shownonefivetoeight();


            if (tickanzahlaffe2 == 6)

                Showallfivetoeight();


            if (tickanzahlaffe2 == 7)

                Shownonefivetoeight();


            if (tickanzahlaffe2 == 8)

                Showsixandeight();


            if (tickanzahlaffe2 == 9)

                Showfiveandseven();


            if (tickanzahlaffe2 == 10)

                Showallfivetoeight();


            if (tickanzahlaffe2 == 11)

                Shownonefivetoeight();


            if (tickanzahlaffe2 == 12)

                Showallfivetoeight();


            if (tickanzahlaffe2 == 13)
            {
                Shownonefivetoeight();

                tickanzahlaffe2 = 0;
            }

        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Timer Fuchsia
        /// </summary>
        /// <param name="sender">Timer</param>
        /// <param name="e">Timer</param>
        private void timerFuchsia_Tick(object sender, EventArgs e)
        {
            HideallFuchsia();

            tickanzahlfuchsia++;

            if (tickanzahlfuchsia == 1)
            {
                pictureBoxFuchsia1.Show();
            }

            if (tickanzahlfuchsia == 2)
            {
                pictureBoxFuchsia2.Show();
            }

            if (tickanzahlfuchsia == 3)
            {
                pictureBoxFuchsia3.Show();
                pictureBoxFuchsia28.Show();
            }

            if (tickanzahlfuchsia == 4)
            {
                pictureBoxFuchsia4.Show();
                pictureBoxFuchsia27.Show();
            }

            if (tickanzahlfuchsia == 5)
            {
                pictureBoxFuchsia5.Show();
                pictureBoxFuchsia26.Show();
            }

            if (tickanzahlfuchsia == 6)
            {
                pictureBoxFuchsia6.Show();
                pictureBoxFuchsia25.Show();
            }

            if (tickanzahlfuchsia == 7)
            {
                pictureBoxFuchsia7.Show();
                pictureBoxFuchsia24.Show();
            }

            if (tickanzahlfuchsia == 8)
            {
                pictureBoxFuchsia8.Show();
                pictureBoxFuchsia23.Show();
            }

            if (tickanzahlfuchsia == 9)
            {
                pictureBoxFuchsia9.Show();
                pictureBoxFuchsia22.Show();
            }

            if (tickanzahlfuchsia == 10)
            {
                pictureBoxFuchsia10.Show();
                pictureBoxFuchsia21.Show();
            }

            if (tickanzahlfuchsia == 11)
            {
                pictureBoxFuchsia11.Show();
                pictureBoxFuchsia20.Show();
            }

            if (tickanzahlfuchsia == 12)
            {
                pictureBoxFuchsia12.Show();
                pictureBoxFuchsia19.Show();
            }

            if (tickanzahlfuchsia == 13)
            {
                pictureBoxFuchsia13.Show();
                pictureBoxFuchsia18.Show();
            }

            if (tickanzahlfuchsia == 14)
            {
                pictureBoxFuchsia14.Show();
                pictureBoxFuchsia17.Show();
            }

            if (tickanzahlfuchsia == 15)
            {
                pictureBoxFuchsia15.Show();
            }

            if (tickanzahlfuchsia == 16)
            {
                pictureBoxFuchsia16.Show();
            }

            if (tickanzahlfuchsia == 17)
            {
                pictureBoxFuchsia16.Show();
            }

            if (tickanzahlfuchsia == 18)
            {
                pictureBoxFuchsia15.Show();
            }

            if (tickanzahlfuchsia == 19)
            {
                pictureBoxFuchsia14.Show();
                pictureBoxFuchsia17.Show();
            }

            if (tickanzahlfuchsia == 20)
            {
                pictureBoxFuchsia13.Show();
                pictureBoxFuchsia18.Show();
            }

            if (tickanzahlfuchsia == 21)
            {
                pictureBoxFuchsia12.Show();
                pictureBoxFuchsia19.Show();
            }

            if (tickanzahlfuchsia == 22)
            {
                pictureBoxFuchsia11.Show();
                pictureBoxFuchsia20.Show();
            }

            if (tickanzahlfuchsia == 23)
            {
                pictureBoxFuchsia10.Show();
                pictureBoxFuchsia21.Show();
            }

            if (tickanzahlfuchsia == 24)
            {
                pictureBoxFuchsia9.Show();
                pictureBoxFuchsia22.Show();
            }

            if (tickanzahlfuchsia == 25)
            {
                pictureBoxFuchsia8.Show();
                pictureBoxFuchsia23.Show();
            }

            if (tickanzahlfuchsia == 26)
            {
                pictureBoxFuchsia7.Show();
                pictureBoxFuchsia24.Show();
            }

            if (tickanzahlfuchsia == 27)
            {
                pictureBoxFuchsia6.Show();
                pictureBoxFuchsia25.Show();
            }

            if (tickanzahlfuchsia == 28)
            {
                pictureBoxFuchsia5.Show();
                pictureBoxFuchsia26.Show();
            }

            if (tickanzahlfuchsia == 29)
            {
                pictureBoxFuchsia4.Show();
                pictureBoxFuchsia27.Show();
            }

            if (tickanzahlfuchsia == 30)
            {
                pictureBoxFuchsia3.Show();
                pictureBoxFuchsia28.Show();
            }

            if (tickanzahlfuchsia == 31)
            {
                pictureBoxFuchsia2.Show();
            }

            if (tickanzahlfuchsia == 32)
            {
                pictureBoxFuchsia1.Show();

                tickanzahlfuchsia = 0;
            }
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Timer Schwarz Weiß
        /// </summary>
        /// <param name="sender">Timer</param>
        /// <param name="e">Timer</param>
        private void timerSW_Tick(object sender, EventArgs e)
        {
            HideallBlackWhite();

            tickanzahlSW++;

            if (tickanzahlSW == 1)

                pictureBoxSW1.Show();

            if (tickanzahlSW == 2)

                pictureBoxSW2.Show();

            if (tickanzahlSW == 3)

                pictureBoxSW3.Show();

            if (tickanzahlSW == 4)

                pictureBoxSW4.Show();

            if (tickanzahlSW == 5)

                pictureBoxSW5.Show();

            if (tickanzahlSW == 6)

                pictureBoxSW6.Show();

            if (tickanzahlSW == 7)

                pictureBoxSW7.Show();

            if (tickanzahlSW == 8)

                pictureBoxSW8.Show();

            if (tickanzahlSW == 9)
            {
                pictureBoxSW1.Show();
                pictureBoxSW3.Show();
                pictureBoxSW5.Show();
                pictureBoxSW7.Show();
            }

            if (tickanzahlSW == 10)
            {
                pictureBoxSW2.Show();
                pictureBoxSW4.Show();
                pictureBoxSW6.Show();
                pictureBoxSW8.Show();
            }

            if (tickanzahlSW == 11)
            {
                pictureBoxSW1.Show();
                pictureBoxSW3.Show();
                pictureBoxSW5.Show();
                pictureBoxSW7.Show();
            }

            if (tickanzahlSW == 12)
            {
                pictureBoxSW2.Show();
                pictureBoxSW4.Show();
                pictureBoxSW6.Show();
                pictureBoxSW8.Show();
            }

            if (tickanzahlSW == 13)
            {
                pictureBoxSW1.Show();
                pictureBoxSW2.Show();
                pictureBoxSW3.Show();
                pictureBoxSW4.Show();
            }

            if (tickanzahlSW == 14)
            {
                pictureBoxSW5.Show();
                pictureBoxSW6.Show();
                pictureBoxSW7.Show();
                pictureBoxSW8.Show();
            }

            if (tickanzahlSW == 15)
            {
                pictureBoxSW1.Show();
                pictureBoxSW2.Show();
                pictureBoxSW3.Show();
                pictureBoxSW4.Show();
            }

            if (tickanzahlSW == 16)
            {
                pictureBoxSW5.Show();
                pictureBoxSW6.Show();
                pictureBoxSW7.Show();
                pictureBoxSW8.Show();

                tickanzahlSW = 0;
            }
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Tickevent
        /// </summary>
        /// <param name="sender">Timer</param>
        /// <param name="e">Timer</param>
        private void timerAffentanz1_Tick(object sender, EventArgs e)
        {
            Hidebackgrounds();

            tickanzahlaffe++;

            if (tickanzahlaffe == 1)
            {
                Showoneandthree();
                pictureBoxLila.Show();
            }

            if (tickanzahlaffe == 2)
            {
                Showtwoandfour();
                pictureBoxBlau.Show();
            }

            if (tickanzahlaffe == 3)
            {
                Showall();
                pictureBoxGrün.Show();
            }

            if (tickanzahlaffe == 4)
            {
                Shownone();
                pictureBoxGelb.Show();
            }

            if (tickanzahlaffe == 5)
            {
                Showall();
                pictureBoxOrange.Show();
            }

            if (tickanzahlaffe == 6)
            {
                Shownone();
                pictureBoxRot.Show();
            }

            if (tickanzahlaffe == 7)
            {
                Showtwoandfour();
                pictureBoxLila.Show();
            }

            if (tickanzahlaffe == 8)
            {
                Showoneandthree();
                pictureBoxBlau.Show();
            }

            if (tickanzahlaffe == 9)
            {
                Showall();
                pictureBoxGrün.Show();
            }

            if (tickanzahlaffe == 10)
            {
                Shownone();

                pictureBoxGelb.Show();
            }

            if (tickanzahlaffe == 11)
            {
                Showall();

                pictureBoxOrange.Show();
            }

            if (tickanzahlaffe == 12)
            {
                Shownone();

                pictureBoxRot.Show();

                tickanzahlaffe = 0;
            }
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Farbdurchlauf
        /// </summary>
        /// <param name="sender">Timer</param>
        /// <param name="e">Timer</param>

        private void timerFarbdurchlauf_Tick(object sender, EventArgs e)
        {
            HideAllPictureBox();

            tickanzahlfarbblock++;

            if (tickanzahlfarbblock == 1)
            {
                pictureBoxBlock1.Show();
                pictureBoxBlock48.Show();
            }

            if (tickanzahlfarbblock == 2)
            {
                pictureBoxBlock2.Show();
                pictureBoxBlock47.Show();
            }

            if (tickanzahlfarbblock == 3)
            {
                pictureBoxBlock3.Show();
                pictureBoxBlock46.Show();
            }

            if (tickanzahlfarbblock == 4)
            {
                pictureBoxBlock4.Show();
                pictureBoxBlock45.Show();
            }

            if (tickanzahlfarbblock == 5)
            {
                pictureBoxBlock5.Show();
                pictureBoxBlock44.Show();
            }

            if (tickanzahlfarbblock == 6)
            {
                pictureBoxBlock6.Show();
                pictureBoxBlock43.Show();
            }

            if (tickanzahlfarbblock == 7)
            {
                pictureBoxBlock7.Show();
                pictureBoxBlock42.Show();
            }

            if (tickanzahlfarbblock == 8)
            {
                pictureBoxBlock8.Show();
                pictureBoxBlock41.Show();
            }

            if (tickanzahlfarbblock == 9)
            {
                pictureBoxBlock9.Show();
                pictureBoxBlock40.Show();
            }

            if (tickanzahlfarbblock == 10)
            {
                pictureBoxBlock10.Show();
                pictureBoxBlock39.Show();
            }

            if (tickanzahlfarbblock == 11)
            {
                pictureBoxBlock11.Show();
                pictureBoxBlock38.Show();
            }

            if (tickanzahlfarbblock == 12)
            {
                pictureBoxBlock12.Show();
                pictureBoxBlock37.Show();
            }

            if (tickanzahlfarbblock == 13)
            {
                pictureBoxBlock13.Show();
                pictureBoxBlock36.Show();
            }

            if (tickanzahlfarbblock == 14)
            {
                pictureBoxBlock14.Show();
                pictureBoxBlock35.Show();
            }

            if (tickanzahlfarbblock == 15)
            {
                pictureBoxBlock15.Show();
                pictureBoxBlock34.Show();
            }

            if (tickanzahlfarbblock == 16)
            {
                pictureBoxBlock16.Show();
                pictureBoxBlock33.Show();
            }

            if (tickanzahlfarbblock == 17)
            {
                pictureBoxBlock17.Show();
                pictureBoxBlock32.Show();
            }

            if (tickanzahlfarbblock == 18)
            {
                pictureBoxBlock18.Show();
                pictureBoxBlock31.Show();
            }

            if (tickanzahlfarbblock == 19)
            {
                pictureBoxBlock19.Show();
                pictureBoxBlock30.Show();
            }

            if (tickanzahlfarbblock == 20)
            {
                pictureBoxBlock20.Show();
                pictureBoxBlock29.Show();
            }

            if (tickanzahlfarbblock == 21)
            {
                pictureBoxBlock21.Show();
                pictureBoxBlock28.Show();
            }

            if (tickanzahlfarbblock == 22)
            {
                pictureBoxBlock22.Show();
                pictureBoxBlock27.Show();
            }

            if (tickanzahlfarbblock == 23)
            {
                pictureBoxBlock23.Show();
                pictureBoxBlock26.Show();
            }

            if (tickanzahlfarbblock == 24)
            {
                pictureBoxBlock24.Show();
                pictureBoxBlock25.Show();

                tickanzahlfarbblock = 0;
            }
        }

        
    }
}