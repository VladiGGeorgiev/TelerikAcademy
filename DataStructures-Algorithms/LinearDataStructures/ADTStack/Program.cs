using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADTStack
{
    class Program
    {
        static void Main(string[] args)
        {
            ADTStack<int> stack = new ADTStack<int>();

            stack.Push(5);
            stack.Push(19);
            stack.Push(32);
            stack.Push(19);
            stack.Push(32);
            stack.Push(10);
            stack.Push(10);

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());

            stack.Push(99);
            Console.WriteLine(stack.Pop());

            Console.WriteLine(stack.Count);
        }
    }
}
