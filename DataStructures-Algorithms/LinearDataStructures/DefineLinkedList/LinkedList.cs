using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DefineLinkedList
{
    public class LinkedList<T>
    {
        class ListItem<T>
        {
            public ListItem(T element, ListItem<T> previousItem)
            {
                this.Element = element;
                previousItem.NextItem = this;
            }

            public ListItem(T element)
            {
                this.Element = element;
                this.NextItem = null;
            }

            public T Element { get; set; }

            public ListItem<T> NextItem { get; set; }

            public override string ToString()
            {
                return this.Element.ToString();
            }
        }

        public LinkedList()
        {
            this.FirstElement = null;
            this.LastElement = null;
            this.Count = 0;
        }

        public int Count { get; private set; }

        private ListItem<T> FirstElement { get; set; }

        private ListItem<T> LastElement { get; set; }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException("Invalid index! It can not be smaller than 0 and greater than number of elements!");
                }

                ListItem<T> node = this.FirstElement;
                for (int i = 0; i < index; i++)
                {
                    node = node.NextItem;
                }

                return node.Element;
            }

            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException("Invalid index! It can not be smaller than 0 and greater than number of elements!");
                }

                ListItem<T> node = this.FirstElement;
                for (int i = 0; i < index; i++)
                {
                    node = node.NextItem;
                }

                node.Element = value;
            }
        }

        public void Add(T item)
        {
            if (this.FirstElement == null)
            {
                this.FirstElement = new ListItem<T>(item);
                this.LastElement = this.FirstElement;
            }
            else
            {
                ListItem<T> newElement = new ListItem<T>(item, this.LastElement);
                this.LastElement = newElement;
            }

            this.Count++;
        }

        public void AddFirst(T value)
        {
            if (this.FirstElement == null)
            {
                this.FirstElement = new ListItem<T>(value);
            }
            else
            {
                ListItem<T> newItem = new ListItem<T>(value);
                newItem.NextItem = this.FirstElement;
                this.FirstElement = newItem;
            }

            this.Count++;
        }

        public void AddLast(T value)
        {
            if (this.FirstElement == null)
            {
                this.FirstElement = new ListItem<T>(value);
            }
            else
            {
                ListItem<T> currentItem = this.FirstElement;

                while (currentItem.NextItem != null)
                {
                    currentItem = currentItem.NextItem;
                }

                currentItem.NextItem = new ListItem<T>(value);
            }

            this.Count++;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid index! It can not be smaller than 0 and greater than number of elements!");
            }

            int currentIndex = 0;
            ListItem<T> currentElement = this.FirstElement;
            ListItem<T> previousElement = null;

            while (currentIndex < index)
            {
                previousElement = currentElement;
                currentElement = currentElement.NextItem;
                currentIndex++;
            }

            this.Count--;

            if (this.Count == 0)
            {
                this.FirstElement = null;
            }
            else if (previousElement == null)
            {
                this.FirstElement = currentElement.NextItem;
            }
            else
            {
                previousElement.NextItem = currentElement.NextItem;
            }
        }

        public T[] GetElements()
        {
            ListItem<T> currentNode = this.FirstElement;

            T[] result = new T[this.Count];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = this[i];
            }

            return result;
        }
    }
}
