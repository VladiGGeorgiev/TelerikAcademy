using System;
using System.Collections.Generic;
using System.Text;
using Wintellect.PowerCollections;

namespace SupermarketQueue
{
    class Item
    {
        public string Element { get; set; }
        public Item NextElement { get; set; }

        public Item(string element, Item previous)
        {
            this.Element = element;
            this.NextElement = previous;
        }
    }

    public class DynamicQueue
    {
        private Item head;
        private Item tail;
        private int count;

        public DynamicQueue()
        {
            this.count = 0;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Enqueue(string element)
        {
            if (this.head == null)
            {
                this.head = new Item(element, null);
                this.tail = this.head;
            }
            else
            {
                var currentElement = new Item(element, null);
                this.tail.NextElement = currentElement;
                this.tail = currentElement;
            }
            this.count++;
        }

        public string Dequeue()
        {
            if (this.head == null)
            {
                throw new ArgumentNullException("The queue is empty!");
            }

            var head = this.head.Element;
            this.head = this.head.NextElement;

            this.count--;
            return head;
        }

        public string Peek()
        {
            if (this.head == null)
            {
                throw new ArgumentNullException("The queue is empty!");
            }

            var head = this.head.Element;
            return head;
        }

        public void Clear()
        {
            this.head = null;
            this.tail = null;
        }

        public bool Contains(string element)
        {
            if (this.count == 0)
            {
                return false;
            }

            var currentItem = this.head;
            bool isContains = false;
            while (currentItem != null)
            {
                if (currentItem.Element.Equals(element))
                {
                    isContains = true;
                    break;
                }

                currentItem = currentItem.NextElement;
            }

            return isContains;
        }

        public void Insert(string element, int index)
        {
            var currentItem = this.head;
            if (index == this.Count)
            {
                var newItem = new Item(element, this.tail.NextElement);
                this.tail.NextElement = newItem;
                this.tail = newItem;
            }
            else if (index == 0)
            {
                var newItem = new Item(element, currentItem.NextElement);
                newItem.NextElement = this.head;
                this.head = newItem;
            }
            else
            {
                int currentIndex = 0;
                while (currentItem != null)
                {
                    if (currentIndex == index - 1)
                    {
                        var newItemm = new Item(element, currentItem.NextElement);
                        newItemm.NextElement = currentItem.NextElement;
                        currentItem.NextElement = newItemm;
                        break;
                    }
                    currentItem = currentItem.NextElement;
                    currentIndex++;
                }

            }

            this.count++;
        }
    }

    class SupermarketQueue
    {
        static DynamicQueue queue = new DynamicQueue();
        static StringBuilder result = new StringBuilder();
        static Dictionary<string, int> names = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            BigList<string> list = new BigList<string>();
            string line = Console.ReadLine();
            while (line != "End")
            {
                string[] tokens = line.Split(' ');
                string command = tokens[0];
                if (command == "Append")
                {
                    AppendClient(tokens[1]);
                }
                else if (command == "Serve")
                {
                    ServeClient(int.Parse(tokens[1]));
                }
                else if (command == "Insert")
                {
                    InsertClient(int.Parse(tokens[1]), tokens[2]);
                }
                else if (command == "Find")
                {
                    FindClient(tokens[1]);
                }

                line = Console.ReadLine();
            }
            result.Length--;
            Console.WriteLine(result.ToString());
        }

        private static void AppendClient(string name)
        {
            queue.Enqueue(name);
            if (names.ContainsKey(name))
            {
                names[name]++;
            }
            else
            {
                names.Add(name, 1);
            }

            result.AppendLine("OK");
        }

        private static void ServeClient(int count)
        {
            if (count <= queue.Count)
            {
                for (int i = 0; i < count; i++)
                {
                    string name = queue.Dequeue();
                    result.Append(name + " ");
                    if (names[name] == 1)
                    {
                        names.Remove(name);
                    }
                    else
                    {
                        names[name]--;
                    }
                }
                result.Length--;
                result.AppendLine();
            }
            else
	        {
                result.AppendLine("Error");
	        }
        }

        private static void FindClient(string name)
        {
            if (names.ContainsKey(name))
            {
                result.AppendLine(names[name].ToString());
            }
            else
            {
                result.AppendLine(0.ToString());
            }
        }
  
        private static void InsertClient(int position, string name)
        {
            if (position >= 0 && position <= queue.Count)
            {
                queue.Insert(name, position);

                if (names.ContainsKey(name))
                {
                    names[name]++;
                }
                else
                {
                    names.Add(name, 1);
                }

                result.AppendLine("OK");
            }
            else
            {
                result.AppendLine("Error");
            }
        }
    }
}
