using ImplementHashTable;
using System;
using System.Linq;

namespace ImplementHashSet
{
    class HashSet<T>
    {
        private HashTable<int, T> container;

        public HashSet()
        {
            this.container = new HashTable<int, T>();
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get
            {
                return this.container.Count;
            }
        }

        public void Add(T value)
        {
            int key = value.GetHashCode();
            this.container.Add(key, value);
        }

        public T Find(T value)
        {
            int key = value.GetHashCode();
            T result = this.container.Find(key);
            return result;
        }

        public void Remove(T value)
        {
            int key = value.GetHashCode();
            this.container.Remove(key);
        }

        public void Clear()
        {
            this.container.Clear();
        }

        public HashSet<T> Union(HashSet<T> otherSet)
        {
            var union = this.container.Values.Union(otherSet.container.Values);
            HashSet<T> tempSet = new HashSet<T>();

            foreach (var item in union)
            {
                tempSet.Add(item);
            }

            return tempSet;
        }

        public HashSet<T> Intersect(HashSet<T> otherSet)
        {
            var intersect = this.container.Values.Intersect(otherSet.container.Values);
            HashSet<T> tempSet = new HashSet<T>();

            foreach (var item in intersect)
            {
                tempSet.Add(item);
            }

            return tempSet;
        }
    }
}
