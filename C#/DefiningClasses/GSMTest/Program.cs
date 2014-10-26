using System;
using MobilePhoneDevice;

namespace GSMTest
{
    class Program
    {
        static void Main(string[] args)
        {
            GSM[] gsmDevices = new GSM[5];

            gsmDevices[0] = new GSM(
                "N95",
                "Nokia",
                650.60m,
                "Kukata",
                new Display(15, 65000),
                new Battery("Takashi", Battery.BatteryType.NiMH, 0, 0));

            gsmDevices[1] = new GSM("Touch Pro 2", "HTC", "VGeorgiev");
            gsmDevices[2] = new GSM("Galaxy", "Samsung", "Penka");
            gsmDevices[3] = new GSM("Touch Diamond", "HTC", "Stoki");
            gsmDevices[4] = new GSM();

            for (int i = 0; i < gsmDevices.Length; i++)
            {
                Console.WriteLine("Manufacturer: {0} , Model: {1}", gsmDevices[i].Manufacturer, gsmDevices[i].Model);
            }

            Console.WriteLine();

            Console.WriteLine(GSM.IPhone4S.ToString());

            // CAll i

                var device = new GSM("Touch Pro 2", "HTC", "Vlado");

                Call firstCall = new Call(DateTime.Now, 180);
                Call secondCall = new Call(DateTime.Now, 560);
                Call thirdCall = new Call(DateTime.Now, 340);
                device.AddCall(firstCall);
                device.AddCall(secondCall);
                device.AddCall(thirdCall);

                device.DeleteCall(firstCall);

                Console.WriteLine("Call duration: {0}s, Call price: {1:c}", device.CallHistoryDuration(), device.CallHystoryPrice());

                GSM.IPhone4S.Owner = "Pesho";
                Console.WriteLine(GSM.IPhone4S.Owner);


        }
    }
}
