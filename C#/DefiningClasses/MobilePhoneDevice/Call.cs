namespace MobilePhoneDevice
{
    using System;

    //Exercise 8
    public class Call
    {
        private DateTime? date;
        private long duration;

        public Call() : this(DateTime.Now, 0)
        {
        }

        public Call(long duration) : this(DateTime.Now, duration)
        {
        }

        public Call(DateTime date, long duration)
        {
            this.date = date;
            this.duration = duration;
        }

        public long Duration
        {
            get { return this.duration; }
        }
    }
}
