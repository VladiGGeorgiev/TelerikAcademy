using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Common
{
    public class OutOfShipLengthException : Exception
    {
        public OutOfShipLengthException(int length)
        {
            Console.WriteLine("The maximal permitted length of ship for the current sea dimentions is: {0}",length);
        }

        public OutOfShipLengthException(string message,int length)
            : base(message)
        {
            Console.WriteLine("The maximal permitted length of ship for the current sea dimentions is: {0}", length);
        }
    }
}
