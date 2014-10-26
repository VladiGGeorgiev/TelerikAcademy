namespace MobilePhoneDevice
{
    public class Battery 
    {
        //Fields
        private string model;
        private int hoursIdle;
        private int hoursTalk;
        private BatteryType type;
        

        //Constructors:
        public Battery()
            : this(null, 0, 0, 0)
        {
        }

        public Battery(string model, BatteryType type)
            : this(model, type, 0, 0)
        {
        }

        public Battery(string model, BatteryType type, int hours, int talk)
        {
            this.type = type;
            this.model = model;
            this.hoursIdle = hours;
            this.hoursTalk = talk;
        }

        public enum BatteryType 
        { 
            Lilon, 
            NiMH, 
            NiCd 
        }

        //Properties
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public int HoursIdle
        {
            get { return this.hoursIdle; }
            set { this.hoursIdle = value; }
        }

        public int HoursTalk
        {
            get { return this.hoursTalk; }
            set { this.hoursTalk = value; }
        }

        public BatteryType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
    }
}
