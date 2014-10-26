using System;
using System.Linq;

namespace SetInterval
{
    public delegate void Functions(string value);

    internal class Timer
    {
        private int interval;

        public Timer(int interval)
        {
            this.interval = interval;
        }

        public int Interval
        {
            get { return this.interval; }
        }

        public void Run()
        {
            Functions funct = Test.PrintName;
            funct += this.Print;

            while (true)
            {
                System.Threading.Thread.Sleep(this.interval);
                funct("Pesho Minkov");
            }
        }

        private void Print(string name)
        {
            Console.WriteLine("{1} write this on every: {0} seconds", (this.interval / (double)1000), name);
        }
    }
}