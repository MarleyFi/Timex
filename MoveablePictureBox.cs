using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Timex
{
    internal class MoveablePictureBox : PictureBox
    {
        #region Konstruktoren

        public MoveablePictureBox()
            : base()
        {
            // nothing to do
        }

        #endregion Konstruktoren

        #region Properties

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// vertikale Richtung
        /// </summary>
        [Category("Timex")]
        [Browsable(true)]
        public MoveDirection VerticalDirection { get; set; }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// horizontale Richtung
        /// </summary>
        [Category("Timex")]
        [Browsable(true)]
        public MoveDirection HorizontalDirection { get; set; }

        /// ------------------------------------------------------------------------------------------------------------------------
        private Form parentFrm;

        /// <summary>
        ///
        /// </summary>
        public Form ParentFrm
        {
            get
            {
                if (parentFrm == null)
                    parentFrm = this.FindForm();
                return parentFrm;
            }
        }

        #endregion Properties

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Würfel Bewegungsrichtung
        /// </summary>
        public void MoveToNextPosition()
        {
            int step = 1;

            int x = this.Location.X;
            int y = this.Location.Y;
            int height = this.Height;
            int width = this.Width;

            if (HorizontalDirection != MoveDirection.Minus && (x + width + step > ParentFrm.ClientSize.Width))
                HorizontalDirection = MoveDirection.Minus;
            else if (HorizontalDirection != MoveDirection.Plus && (x - step < 1))
                HorizontalDirection = MoveDirection.Plus;

            if (VerticalDirection != MoveDirection.Minus && (y + height + step > ParentFrm.ClientSize.Height))
                VerticalDirection = MoveDirection.Minus;
            else if (VerticalDirection != MoveDirection.Plus && (y - step < 1))
                VerticalDirection = MoveDirection.Plus;

            int newX = x + (step * (int)HorizontalDirection);
            int newY = y + (step * (int)VerticalDirection);
            this.Location = new Point(newX, newY);
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Würfel Startposition
        /// </summary>
        /// <param name="randomizer">Würfel Startposition</param>
        internal void SetRandomPosition(System.Random randomizer)
        {
            VerticalDirection = randomizer.Next(0, 2) == 0 ? MoveDirection.Plus : MoveDirection.Minus;
            HorizontalDirection = randomizer.Next(0, 2) == 0 ? MoveDirection.Plus : MoveDirection.Minus;

            this.Location = new Point(randomizer.Next(0, ParentFrm.Width - this.Width), randomizer.Next(0, ParentFrm.Height - this.Height));
        }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Würfel Bild
        /// </summary>
        /// <param name="img">Würfel Bild</param>
        public void SetImage(Image img)
        {
            this.Image = img;
            this.Height = this.Image.Height;
            this.Width = this.Image.Width;
        }
    }
}