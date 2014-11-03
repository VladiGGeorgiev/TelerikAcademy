namespace DoubleEndedQueue
{
    using System.Collections.Generic;

    /// <summary>
    /// Generic Deque implementation with LinkedList
    /// </summary>
    /// <typeparam name="T">Parameter with you choise</typeparam>
    public class Deque<T> : IDeque<T>
    {
        /// <summary>
        /// The storage of elements of dequeue.
        /// </summary>
        private LinkedList<T> data;

        /// <summary>
        /// Initializes a new instance of the <see cref="Deque{T}"/> class.
        /// </summary>
        public Deque()
        {
            this.data = new LinkedList<T>();
        }

        /// <summary>
        /// Gets the number of elements in dequeue.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }

        /// <summary>
        /// Inserts element at the beginning of the dequeue.
        /// </summary>
        /// <param name="element">The element you want to push in dequeue.</param>
        public void PushFirst(T element)
        {
            this.data.AddFirst(element);
        }

        /// <summary>
        /// Inserts element at the end of the dequeue.
        /// </summary>
        /// <param name="element">The element you want to push in dequeue.</param>
        public void PushLast(T element)
        {
            this.data.AddLast(element);
        }

        /// <summary>
        /// Returns and removes the element at the beginning of the dequeue.
        /// </summary>
        /// <returns>First element of dequeue</returns>
        public T PopFirst()
        {
            T firstElement = this.data.First.Value;
            this.data.RemoveFirst();
            return firstElement;
        }

        /// <summary>
        /// Returns and removes the element at the end of dequeue.
        /// </summary>
        /// <returns>Last element of dequeue</returns>
        public T PopLast()
        {
            T lastElement = this.data.Last.Value;
            this.data.RemoveLast();
            return lastElement;
        }

        /// <summary>
        /// Only returns the element at the beginning of the dequeue (without removing it).
        /// </summary>
        /// <returns>First element of dequeue</returns>
        public T PeekFirst()
        {
            T firstElement = this.data.First.Value;
            return firstElement;
        }

        /// <summary>
        /// Only returns the element at the end of the dequeue (without removing it).
        /// </summary>
        /// <returns>Last element of dequeue</returns>
        public T PeekLast()
        {
            T lastElement = this.data.Last.Value;
            return lastElement;
        }

        /// <summary>
        /// Empty the deque. Removes all elements from dequeue.
        /// </summary>
        public void Clear()
        {
            this.data.Clear();
        }

        /// <summary>
        /// Determines whether [contains] [the specified element].
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified element]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(T element)
        {
            bool isElementContains = this.data.Contains(element);
            return isElementContains;
        }
    }
}
