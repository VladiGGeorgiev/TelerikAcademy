using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePhoneDevice;

namespace MobilePhoneTest
{
    public class CallHystory
    {
        static void Main(string[] args)
        {
            var device = new GSM("Touch Pro 2", "HTC", "Vlado");

            Call firstCall = new Call(180);
            device.AddCall(firstCall);

            Console.WriteLine(device.CallHystoryPrice());
        }
    }
}
