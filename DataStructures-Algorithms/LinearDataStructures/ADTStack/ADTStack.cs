using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Implement the ADT stack as auto-resizable array. Resize the capacity on demand (when no space is available to add / insert a new element).
*/
namespace ADTStack
{
    public class ADTStack<T>
    {
        private T[] elements;

        private int count = 0;
        private int capacity;
        
        public ADTStack()
        {
            this.elements = new T[4];
            this.Capacity = elements.Length;
        }

        public ADTStack(int capacity)
        {
            this.elements = new T[capacity];
            this.Capacity = capacity;
        }

        public int Count
        {
            get
            {
                return this.count;
            }

            private set
            {
                this.count = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            private set
            {
                this.capacity = value;
            }
        }

        public void Push(T value)
        {
            elements[count] = value;
            this.count++;

            if (this.count == this.Capacity)
            {
                this.ExtendCapacity();
            }
        }

        public T Pop()
        {
            if (this.count == 0)
            {
                throw new ArgumentNullException("The stack is empty!");
            }

            this.Count--;
            return this.elements[this.Count];
        }

        private void ExtendCapacity()
        {
            T[] tempArray = new T[this.Capacity * 2];

            for (int i = 0; i < this.Count; i++)
            {
                tempArray[i] = elements[i];
            }

            this.elements = tempArray;
            this.Capacity = tempArray.Length;
        }
    }
}
