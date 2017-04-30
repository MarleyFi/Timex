using System;
using System.Collections.Generic;
using System.Drawing;
using Timex.Properties;

namespace Timex
{
    public partial class FrmAffen : FrmBase
    {
        #region Konstruktoren

        /// ========================================================================================================================
        /// <summary>
        /// Form 2
        /// </summary>
        public FrmAffen()
        {
            InitializeComponent();

        }

        #endregion Konstruktoren

        #region Interne Variablen

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Würfelliste
        /// </summary>
        private List<MoveablePictureBox> blackCube = new List<MoveablePictureBox>();

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Farbhintergrundwechsel
        /// </summary>
        private int timertickanzahlfarbhintergrund = 0;
        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Affenbildwechsel
        /// </summary>
        private int timertickanzahlaffenbild = 0;

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Farbblockwechsel
        /// </summary>
        private int timertickanzahlfarbblock = 0;

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Zufällige Würfelbewegung
        /// </summary>
        public Random randomizer = new Random();

        #endregion Interne Variablen

        #region Methoden

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Würfelerstellung
        /// </summary>
        private void AddBlackCube()
        {
            MoveablePictureBox box = new MoveablePictureBox();
            this.Controls.Add(box);
            box.BringToFront();
            blackCube.Add(box);
            box.SetImage(Resources.WuerfelHintergrundSchwarz);
            box.SetRandomPosition(randomizer);
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Alle Würfel in Liste bewegen
        /// </summary>
        private void MoveKloetzchen()
        {
            foreach (var box in blackCube)
            {
                box.MoveToNextPosition();
            }
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Farbblock Lila
        /// </summary>
        private void Colorlila()
        {
            pictureBoxFarbblock.Image = Properties.Resources.Lila;
            pictureBoxFarbblock2.Image = Properties.Resources.Lila;
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Farbblock Blau
        /// </summary>
        private void Colorblau()
        {
            pictureBoxFarbblock.Image = Properties.Resources.Blau;
            pictureBoxFarbblock2.Image = Properties.Resources.Blau;
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Farbblock Grün
        /// </summary>
        private void Colorgruen()
        {
            pictureBoxFarbblock.Image = Properties.Resources.Grün;
            pictureBoxFarbblock2.Image = Properties.Resources.Grün;
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Farbblock Gelb
        /// </summary>
        private void Colorgelb()
        {
            pictureBoxFarbblock.Image = Properties.Resources.Gelb;
            pictureBoxFarbblock2.Image = Properties.Resources.Gelb;
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Farbblock Orange
        /// </summary>
        private void Colororange()
        {
            pictureBoxFarbblock.Image = Properties.Resources.Orange;
            pictureBoxFarbblock2.Image = Properties.Resources.Orange;
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Farbblock Rot
        /// </summary>
        private void Colorrot()
        {
            pictureBoxFarbblock.Image = Properties.Resources.Rot;
            pictureBoxFarbblock2.Image = Properties.Resources.Rot;
        }

        #endregion Methoden

        #region Events

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Timer Farbhintergründe
        /// </summary>
        /// <param name="sender">Timer Farbhintergründe</param>
        /// <param name="e">Timer Farbhintergründe</param>
        private void timerFarbhintergrund_Tick(object sender, EventArgs e)
        {
            timertickanzahlfarbhintergrund++;
            //string filepath = Application.StartupPath;
            if (timertickanzahlfarbhintergrund == 1)
                pictureBoxFarbhintergrund.Image = Properties.Resources.Lila;
            else if (timertickanzahlfarbhintergrund == 2)
                pictureBoxFarbhintergrund.Image = Properties.Resources.Blau;
            else if (timertickanzahlfarbhintergrund == 3)
                pictureBoxFarbhintergrund.Image = Properties.Resources.Grün;
            else if (timertickanzahlfarbhintergrund == 4)
                pictureBoxFarbhintergrund.Image = Properties.Resources.Gelb;
            else if (timertickanzahlfarbhintergrund == 5)
                pictureBoxFarbhintergrund.Image = Properties.Resources.Orange;
            else if (timertickanzahlfarbhintergrund == 6)
            {
                pictureBoxFarbhintergrund.Image = Properties.Resources.Rot;
                timertickanzahlfarbhintergrund = 0;
            }
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Timer Affe
        /// </summary>
        /// <param name="sender">Timer Affe</param>
        /// <param name="e">Timer Affe</param>
        private void timerAffe_Tick(object sender, EventArgs e)
        {
            timertickanzahlaffenbild++;

            if (timertickanzahlaffenbild == 1)
                pictureBoxAffe.Image = Properties.Resources.Affe1;
            else if (timertickanzahlaffenbild == 2)
            {
                pictureBoxAffe.Image = Properties.Resources.Affe2;
                timertickanzahlaffenbild = 0;
                AddBlackCube();
            }
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Timer Farbblöcke
        /// </summary>
        /// <param name="sender">Timer Farbblöcke</param>
        /// <param name="e">Timer Farbblöcke</param>
        private void timerFarbblock_Tick(object sender, EventArgs e)
        {
            timertickanzahlfarbblock++;

            if (timertickanzahlfarbblock == 1)
            {
                pictureBoxFarbblock.Location = new Point(84, 61);
                Colorlila();

                pictureBoxFarbblock2.Location = new Point(594, 117);
            }
            else if (timertickanzahlfarbblock == 2)
            {
                pictureBoxFarbblock.Location = new Point(168, 61);
                Colorblau();

                pictureBoxFarbblock2.Location = new Point(594, 187);
            }
            else if (timertickanzahlfarbblock == 3)
            {
                pictureBoxFarbblock.Location = new Point(252, 61);
                Colorgruen();

                pictureBoxFarbblock2.Location = new Point(594, 257);
            }
            else if (timertickanzahlfarbblock == 4)
            {
                pictureBoxFarbblock.Location = new Point(336, 61);
                Colorgelb();

                pictureBoxFarbblock2.Location = new Point(594, 327);
            }
            else if (timertickanzahlfarbblock == 5)
            {
                pictureBoxFarbblock.Location = new Point(420, 61);
                Colororange();

                pictureBoxFarbblock2.Location = new Point(594, 397);
            }
            else if (timertickanzahlfarbblock == 6)
            {
                pictureBoxFarbblock.Location = new Point(504, 61);
                Colorrot();

                pictureBoxFarbblock2.Location = new Point(594, 467);
            }
            else if (timertickanzahlfarbblock == 7)
            {
                pictureBoxFarbblock.Location = new Point(504, 539);
                Colorlila();

                pictureBoxFarbblock2.Location = new Point(28, 467);
            }
            else if (timertickanzahlfarbblock == 8)
            {
                pictureBoxFarbblock.Location = new Point(420, 539);
                Colorblau();

                pictureBoxFarbblock2.Location = new Point(28, 397);
            }
            else if (timertickanzahlfarbblock == 9)
            {
                pictureBoxFarbblock.Location = new Point(336, 539);
                Colorgruen();

                pictureBoxFarbblock2.Location = new Point(28, 327);
            }
            else if (timertickanzahlfarbblock == 10)
            {
                pictureBoxFarbblock.Location = new Point(252, 539);
                Colorgelb();

                pictureBoxFarbblock2.Location = new Point(28, 257);
            }
            else if (timertickanzahlfarbblock == 11)
            {
                pictureBoxFarbblock.Location = new Point(168, 539);
                Colororange();

                pictureBoxFarbblock2.Location = new Point(28, 187);
            }
            else if (timertickanzahlfarbblock == 12)
            {
                pictureBoxFarbblock.Location = new Point(84, 539);
                Colorrot();

                pictureBoxFarbblock2.Location = new Point(28, 117);

                timertickanzahlfarbblock = 0;
            }
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Timer Würfel
        /// </summary>
        /// <param name="sender">Timer Würfel</param>
        /// <param name="e">Timer Würfel</param>
        private void timerCubeMoving_Tick_1(object sender, EventArgs e)
        {
            MoveKloetzchen();
        }

        

        #endregion Events
    }
}