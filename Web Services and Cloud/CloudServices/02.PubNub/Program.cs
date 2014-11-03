using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _02.PubNub
{
    class Program
    {
        static void Main(string[] args)
        {
            Process.Start("..\\..\\RecieverPage.html");

            System.Threading.Thread.Sleep(2000);

            PubnubAPI pubnub = new PubnubAPI(
                "pub-c-d9aadadf-abba-443c-a767-62023d43411a",               // PUBLISH_KEY
                "sub-c-102d0358-073f-11e3-916b-02ee2ddab7fe",               // SUBSCRIBE_KEY
                "sec-c-YmI4NDcxNzQtOWZhYi00MTRmLWI4ODktMDI2ZjViMjQyYzdj",   // SECRET_KEY
                false                                                        // SSL_ON?
            );
            string channel = "PublishApp";

            List<object> publishResult = pubnub.Publish(channel, "Hello Pubnub!");
            Console.WriteLine(
                "Publish Success: " + publishResult[0].ToString() + "\n" +
                "Publish Info: " + publishResult[1]
            );

            object serverTime = pubnub.Time();
            Console.WriteLine("Server Time: " + serverTime.ToString());

            System.Threading.Tasks.Task t = new System.Threading.Tasks.Task(
                () =>
                pubnub.Subscribe(
                    channel,
                    delegate(object message)
                    {
                        Console.WriteLine("Received Message -> '" + message + "'");
                        return true;
                    }
                )
            );
            t.Start();

            while (true)
            {
                Console.Write("Enter a message to be sent to Pubnub: ");
                string msg = Console.ReadLine();
                pubnub.Publish(channel, msg);
                Console.WriteLine("Message {0} sent.", msg);
            }
        }
    }
}
