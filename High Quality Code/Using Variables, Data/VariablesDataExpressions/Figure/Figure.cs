namespace Figure
{
    using System;

    /// <summary>
    ///     Some figure
    /// </summary>
    public class Figure
    {
        /// <summary>
        ///     Figure width
        /// </summary>
        private double width;

        /// <summary>
        ///     Figure height
        /// </summary>
        private double height;

        /// <summary>
        ///     Initializes a new instance of the Figure class.
        /// </summary>
        /// <param name="width">Figure width</param>
        /// <param name="height">Figure height</param>
        public Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        ///     Gets or sets height and check for wrong value.
        /// </summary>
        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("The height can not be negative number!");
                }

                this.height = value;
            }
        }

        /// <summary>
        ///     Gets or sets width and check for wrong value.
        /// </summary>
        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("The width can not be negative number!");
                }

                this.width = value;
            }
        }
    }
}
