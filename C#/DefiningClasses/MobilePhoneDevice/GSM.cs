namespace MobilePhoneDevice
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GSM
    {
        #region Fields
        private string model;
        private string manufacturer;
        private decimal price;
        private string owner;
        private Display displayCharacteristics;
        private Battery batteryCharacteristics;
        private static GSM iPhone4S = new GSM("IPhone 4S", "Apple", null);
        private List<Call> callHistory = new List<Call>();
        #endregion

        #region Constructors
        public GSM() : this(null, null, 0, null, null, null)
        {
        }

        public GSM(string model, string manufact, string owner)
        {
            this.model = model;
            this.manufacturer = manufact;
            this.owner = owner;
        }

        public GSM(string model, string manufact, decimal price, string owner, Display displayChar, Battery batteryChar)
        {
            this.model = model;
            this.manufacturer = manufact;
            this.price = price;
            this.owner = owner;
            this.displayCharacteristics = displayChar;
            this.batteryCharacteristics = batteryChar;
        }
        #endregion

        #region Properties
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
            get { return this.price; }
            set { this.price = value; }
        }

        public string Owner
        {
            get { return this.manufacturer; }
            set { this.manufacturer = value; }
        }

        public static GSM IPhone4S
        {
            get
            {
                return iPhone4S;
            }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("Model: " + this.model + "\n");
            result.Append("Manufacturer: " + this.manufacturer + "\n");
            result.Append("Price: " + this.price + "\n");
            result.Append("Owner: " + this.owner + "\n");

            return result.ToString();
        }

        public void AddCall(Call call)
        {
            this.callHistory.Add(call);
        }

        public void DeleteCall(Call call)
        {
            for (int i = 0; i < this.callHistory.Count; i++)
            {
                if (this.callHistory[i] == call)
                {
                    this.callHistory.RemoveAt(i);
                }
            }
        }

        public void ClearCallHystory()
        {
            this.callHistory.Clear();
        }

        public double CallHystoryPrice(double minutePrice = 0.35)
        {
            long allCallDuration = 0;

            for (int i = 0; i < this.callHistory.Count; i++)
            {
                allCallDuration += this.callHistory[i].Duration;
            }

            double totalPrice = (allCallDuration / 60) * minutePrice;
            return totalPrice;
        }

        public long CallHistoryDuration()
        {
            long allDuration = 0;
            for (int i = 0; i < callHistory.Count; i++)
            {
                allDuration += callHistory[i].Duration;
            }

            return allDuration;
        }
        #endregion
    }
}
