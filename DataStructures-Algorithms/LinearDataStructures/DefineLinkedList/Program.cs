using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            list.Add(5);
            list.Add(7);
            list.Add(3);
            list.Add(0);
            list.Add(9);
            list.Remove(2);

            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }

            int[] array = list.GetElements();
            
            Console.WriteLine(Environment.NewLine + string.Join(" ", array));
        }
    }
}
