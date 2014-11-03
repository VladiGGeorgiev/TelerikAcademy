using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StringService.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            StringServiceClient client = new StringServiceClient();
            int count = client.GetContainsCount("is", "Hello my friend this is my app. I hope this likes you!");
            Console.WriteLine(count);
        }
    }
}
