using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueImplementation
{
    class PriorityQueue<T> where T : IComparable
    {
        private const int DefaultCapacity = 16;
        private T[] queue;
        private int count;
        private int capacity;

        public PriorityQueue()
        {
            this.queue = new T[DefaultCapacity];
            this.capacity = DefaultCapacity;
            this.count = 0;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Enqueue(T element)
        {
            if (this.count == this.capacity - 1)
            {
                this.EnlargeQueue();
            }

            this.queue[count] = element;
            if (this.count > 0)
            {
                this.MoveElementUp(element);
            }
            this.count++;
        }

        public T Dequeue()
        {
            T root = this.queue[0];

            this.count--;
            this.queue[0] = this.queue[count];
            this.queue[count] = this.queue[count + 1];

            this.MoveElementDown(0);

            return root;
        }

        private void MoveElementDown(int index)
        {
            int left = 2 * index + 1;
            int right = 2 * index + 2;
            int largest = index;

            if (left < this.queue.Length && this.queue[left].CompareTo(this.queue[largest]) == 1)
            {
                largest = left;
            }
            if (right < this.queue.Length && this.queue[right].CompareTo(this.queue[largest]) == 1)
	        {
		        largest = right;
	        }
            if (largest != index)
	        {
                this.Swap(ref this.queue[index], ref this.queue[largest]);
                this.MoveElementDown(largest);
	        }
        }

        private void MoveElementUp(T element)
        {
            int parentIndex = (int)Math.Floor((count - 1) / (double)2);
            T parentElement = queue[parentIndex];
            int childIndex = count;
            while (parentElement.CompareTo(element) == -1)
            {
                this.Swap(ref this.queue[parentIndex], ref this.queue[childIndex]);

                if (parentIndex == 0)
                {
                    break;
                }

                childIndex = parentIndex;
                parentIndex = (int)Math.Floor((parentIndex - 1) / (double)2);
                parentElement = queue[parentIndex];
            }
        }

        private void Swap(ref T t1, ref T t2)
        {
            T temp = t1;
            t1 = t2;
            t2 = temp;
        }

        private void EnlargeQueue()
        {
            T[] tempQueue = new T[queue.Length * 2];

            for (int i = 0; i < queue.Length; i++)
            {
                tempQueue[i] = queue[i];
            }

            this.queue = tempQueue;
            this.capacity = tempQueue.Length;
        }
    }
}
