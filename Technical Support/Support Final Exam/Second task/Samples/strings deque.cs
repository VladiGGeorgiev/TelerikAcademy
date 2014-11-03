using System;

namespace DoubleEndedQueue
{
    internal class Program
    {
        internal static void Main()
        {
            Deque<string> deque = new Deque<string>();
            string peterName = "Peter";
            deque.PushFirst(peterName);
            deque.PushLast("Last element");
            deque.PushFirst("Before Peter");
            deque.PushLast("After last element");

            //This will return 4
            Console.WriteLine("Number of elements: {0}", deque.Count);

            //This will return true, because "Peter" is in the deque
            Console.WriteLine("If deque contains: {0}, -> {1}", peterName, deque.Contains(peterName));

            //This will return first element without removing it.
            Console.WriteLine(deque.PeekFirst());

            //This will return last element and remove it.
            Console.WriteLine(deque.PopLast());
        }
    }
}
