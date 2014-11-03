using System;

namespace DoubleEndedQueue
{
    internal class Program
    {
        internal static void Main()
        {
            Deque<int> deque = new Deque<int>();
            deque.PushFirst(3);
            deque.PushFirst(5);
            deque.PushFirst(7);
            deque.PushLast(10);
            deque.PushLast(13);
            //The order of elements in Deque is: 7, 5, 3, 10, 13

            //This will write on console first element without removing it from Deque -> 7
            Console.WriteLine("Peek first element: {0}", deque.PeekFirst());

            //This will write on console last element without removing it from Deque -> 13
            Console.WriteLine("Peek last element: {0}", deque.PeekLast());

            //This will write on console first element and remove it from Deque -> 7 again
            Console.WriteLine("Pop first element: {0}", deque.PopFirst());

            //This will write on console first element and remove it from Deque -> 5 again
            Console.WriteLine("Pop first element: {0}", deque.PopFirst());

            //This will write on console last element and remove it from Deque -> 13 again
            Console.WriteLine("Pop last element: {0}", deque.PopLast());

            //In the deque now you have only two elements -> 3 and 10
        }
    }
}
