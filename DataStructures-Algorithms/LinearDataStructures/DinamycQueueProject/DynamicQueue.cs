using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinamycQueueProject
{
    public class DynamicQueue<T>
    {
        private Item<T> head;
        private Item<T> tail;
        
        public void Enqueue(T element)
        {
            if (this.head == null)
            {
                this.head = new Item<T>(element, null);
                this.tail = this.head;
            }
            else
            {
                var currentElement = new Item<T>(element, null);
                this.tail.NextElement = currentElement;
                this.tail = currentElement;
            }
        }

        public T Dequeue()
        {
            if (this.head == null)
            {
                throw new ArgumentNullException("The queue is empty!");
            }

            var head = this.head.Element;
            this.head = this.head.NextElement;

            return head;
        }

        public T Peek()
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

        public bool Contains(T element)
        {
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
    }
}
