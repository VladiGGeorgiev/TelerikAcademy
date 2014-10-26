using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneDevice
{
    class GSMTest
    {
        static void Main()
        {
            GSM[] gsmDevices = new GSM[5];

            gsmDevices[0] = new GSM("N95", "Nokia", 650.60m, "Kukata",
                new Display(15, 65000), new Battery("Takashi", Battery.BatteryType.NiMH, 0, 0));
            gsmDevices[1] = new GSM("Touch Pro 2", "HTC", "VGeorgiev");
            gsmDevices[2] = new GSM("Galaxy", "Samsung", "Penka");
            gsmDevices[3] = new GSM("Touch Diamond", "HTC", "Stoki");
            gsmDevices[4] = new GSM();

            for (int i = 0; i < gsmDevices.Length; i++)
            {
                Console.WriteLine("Manufacturer: {0} , Model: {1}", 
                    gsmDevices[i].Manufacturer, gsmDevices[i].Model);
            }

            Console.WriteLine();

            Console.WriteLine(GSM.IPhone4S.ToString());

        }
    }
}
