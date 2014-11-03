using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinamycQueueProject
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicQueue<int> queue = new DynamicQueue<int>();
            queue.Enqueue(5);
            queue.Enqueue(31);
            queue.Enqueue(100);

            Console.WriteLine(queue.Contains(101));

            Console.WriteLine(queue.Peek());
            Console.WriteLine(queue.Peek());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Peek());
            queue.Enqueue(666);
            Console.WriteLine(queue.Dequeue());
        }
    }
}
