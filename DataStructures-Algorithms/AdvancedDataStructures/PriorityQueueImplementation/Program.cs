using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<int> queue = new PriorityQueue<int>();
            queue.Enqueue(5);
            queue.Enqueue(3);
            queue.Enqueue(16);
            queue.Enqueue(4);
            queue.Enqueue(8);
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(33);
            queue.Enqueue(6);
            queue.Enqueue(24);
            queue.Enqueue(68);
            queue.Enqueue(19);
            queue.Enqueue(61);
            queue.Enqueue(638);
            queue.Enqueue(213);
            queue.Enqueue(2132);

            int count = queue.Count;
            Console.WriteLine("Get elements from Priority queue one by one:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
