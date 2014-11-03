using System;
using System.ServiceModel;
using StringsService;
using System.ServiceModel.Description;

namespace StringServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri serviceAddress = new Uri("http://localhost:1234/substring-counter");
            ServiceHost host = new ServiceHost(typeof(StringService), serviceAddress);

            ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
            behavior.HttpGetEnabled = true;
            host.Description.Behaviors.Add(behavior);

            using (host)
            {
                host.Open();
                Console.WriteLine("Service is started: {0}", serviceAddress);
                Console.WriteLine("Press [Enter] to exit.");
                Console.ReadLine();
                ConsumeSercive();
            }
        }

        private static void ConsumeSercive()
        {
        }
    }
}
