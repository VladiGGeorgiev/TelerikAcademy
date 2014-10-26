using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneDevice
{
    class GSM
    {
        //Fields
        private string model;
        private string manufacturer;
        private decimal price;
        private string owner;
        private Display displayCharacteristics;
        private Battery batteryCharacteristics;
        public static GSM IPhone4S = new GSM("IPhone 4S", "Apple", 1200m, "Gosho", new Display(4.3d, 260000), new Battery("Apple", Battery.BatteryType.NiMH));

        //Constructors
        public GSM() : this(null, null, 0, null, null, null)
        {
        }

        public GSM(string model, string manufact, string owner) 
            : this(model, manufact, 0m, owner, null, null)
        {
        }

        public GSM(string model, string manufact, decimal price, string owner,
            Display displayChar, Battery batteryChar)
        {
            this.model = model;
            this.manufacturer = manufact;
            this.price = price;
            this.owner = owner;
            this.displayCharacteristics = displayChar;
            this.batteryCharacteristics = batteryChar;
        }

        //Properties
        public string Model
        { 
            get { return this.model; } 
            set { this.model = value; } 
        }
        public string Manufacturer
        {
            get { return this.manufacturer; }
            set { this.manufacturer = value; }
        }
        public decimal Price
        {
            get { return this.manufacturer; }
            set { this.manufacturer = value; }
        }
        public string Owner
        {
            get { return this.manufacturer; }
            set { this.manufacturer = value; }
        }
        public Display DisplayCharacteristics { get; set; }
        public Battery BatteryCharacteristics { get; set; }

        //To string methods return all information.
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("Model: " + this.model + "\n");
            result.Append("Manufacturer: " + this.manufacturer + "\n");
            result.Append("Price: " + this.price + "\n");
            result.Append("Owner: " + this.owner + "\n");
            result.Append("Battery type" + this.

            return result.ToString();
        }
    }
}
