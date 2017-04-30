namespace Timex
{
    /// ============================================================================================================================
    /// <summary>
    /// Würfel
    /// </summary>
    internal class Bounds
    {
        #region Konstruktoren

        public Bounds(int top, int right, int bottom, int left)
        {
            this.Top = top;
            this.Right = right;
            this.Bottom = bottom;
            this.Left = left;
        }

        #endregion Konstruktoren

        #region Properties

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Breite
        /// </summary>
        public int Left { get; private set; }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Höhe
        /// </summary>
        public int Top { get; private set; }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// x-Koordinate
        /// </summary>
        public int Right { get; private set; }

        /// ------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// y-Koordinate
        /// </summary>
        public int Bottom { get; private set; }

        #endregion Properties
    }
}