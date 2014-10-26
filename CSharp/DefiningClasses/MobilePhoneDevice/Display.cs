using System;

namespace MobilePhoneDevice
{
    class Display
    {
        //Fields
        private double size;
        private int numberOfColors;

        //Constructor
        public Display()
            : this(0, 0)
        {
        }

        public Display(double size, int numberColors)
        {
            this.size = size;
            this.numberOfColors = numberColors;
        }

        //Properties
        public double Size
        {
            get { return this.size; }
            set { this.size = value; }
        }

        public int NumberOfColors
        {
            get { return this.numberOfColors; }
            set { this.numberOfColors = value; }
        }
    }
}
