namespace Point
{
    using System;
    using System.Linq;

    class GenericList<T> where T : IComparable
    {
        private int capacity;
        private T[] elements;
        private int length = 0;

        public GenericList(int capacity)
        {
            this.capacity = capacity;
            this.elements = new T[capacity];
        }

        public int Length
        {
            get { return this.length; }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > this.length)
                {
                    throw new IndexOutOfRangeException(string.Format("Invalid index: {0}", index));
                }

                return this.elements[index];
            }

            set
            {
                if (index <= 0 || index >= this.length)
                {
                    throw new IndexOutOfRangeException(string.Format("Invalid index: {0}", index));
                }

                this.elements[index] = value;
            }
        }

        #region Methods

        public void Add(T element)
        {
            if (this.length == this.elements.Length)
            {
                this.AutoGrow();
            }

            this.elements[this.length] = element;
            this.length++;
        }

        public void Remove(int index)
        {
            T[] tempElements = new T[this.elements.Length - 1];
            for (int i = 0, j = 0; i < this.elements.Length; i++, j++)
            {
                if (i != index)
                {
                    tempElements[j] = this.elements[i];
                }
                else
                {
                    j--;
                }
            }

            this.length--;
            this.elements = tempElements;
        }

        public void Insert(T element, int position)
        {
            T[] tempElements = new T[this.elements.Length + 1];
            for (int i = 0, j = 0; i < tempElements.Length; i++, j++)
            {
                if (i != position)
                {
                    tempElements[i] = this.elements[j];
                }
                else
                {
                    tempElements[j] = element;
                    j--;
                }
            }

            this.length++;
            this.elements = tempElements;
        }

        public void Clear()
        {
            this.elements = new T[this.capacity];
            this.length = 0;
        }

        public T Max()
        {
            T maxElement = this.elements.Max<T>();
            return maxElement;
        }

        public T Min()
        {
            T minElement = this.elements.Min<T>();
            return minElement;
        }

        private void AutoGrow()
        {
            T[] tempElements = new T[this.elements.Length * 2];
            Array.Copy(this.elements, tempElements, this.elements.Length);
            this.elements = tempElements;
            this.capacity = this.elements.Length;
        }
        #endregion
    }
}
