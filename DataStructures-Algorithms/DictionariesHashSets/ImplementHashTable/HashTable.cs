using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ImplementHashTable
{
    public class HashTable<K, T> : IEnumerable<KeyValuePair<K, T>>
    {
        LinkedList<KeyValuePair<K, T>>[] list;
        private int count;
        private int capacity;

        public HashTable(int capacity = 16)
        {
            this.list = new LinkedList<KeyValuePair<K, T>>[capacity];
            this.count = 0;
            this.capacity = capacity;
        }

        public IEnumerable<T> Values
        {
            get
            {
                foreach (var node in this.list)
                {
                    if (node != null)
                    {
                        while (node.First != null)
                        {
                            yield return node.First.Value.Value;
                        }
                    }
                }
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public T this[K key]
        {
            get
            {
                T value = this.Find(key);
                return value;
            }

            set
            {
                var index = key.GetHashCode() % this.list.Length;
                if (list[index] != null)
                {
                    var next = this.list[index].First;
                    while (next != null)
                    {
                        if (next.Value.Key.Equals(key))
                        {
                            next.Value = new KeyValuePair<K, T>(key, value);
                            break;
                        }

                        next = next.Next;
                    }
                }
                else
                {
                    list[index] = new LinkedList<KeyValuePair<K, T>>();
                    list[index].AddFirst(new LinkedListNode<KeyValuePair<K, T>>(new KeyValuePair<K, T>(key, value)));
                }

                this.count++;
            }
        }

        public void Add(K key, T value)
        {
            if (this.count > this.capacity * 0.75)
            {
                this.EnlargeCapacity();
            }

            int index = key.GetHashCode() % this.list.Length;
            if (this.list[index] == null)
            {
                this.list[index] = new LinkedList<KeyValuePair<K, T>>();
            }

            var next = this.list[index].First;
            while (next != null)
            {
                if (next.Value.Key.Equals(key))
                {
                    throw new ArgumentException("There is already that key!");
                }

                next = next.Next;
            }

            this.list[index].AddLast(new KeyValuePair<K, T>(key, value));
            this.count++;
        }

        public T Find(K key)
        {
            int index = key.GetHashCode() % this.list.Length;
            if (list[index] != null)
            {
                var next = this.list[index].First;
                while (next != null)
                {
                    if (next.Value.Key.Equals(key))
                    {
                        return next.Value.Value;
                    }

                    next = next.Next;
                }
            }

            throw new ArgumentException("There isn't element with this key!");
        }

        public void Remove(K key)
        {
            int index = key.GetHashCode() % this.list.Length;
            if (this.list[index] == null)
            {
                throw new ArgumentException("There isn't element with that key!");
            }

            bool isRemoved = false;
            var next = this.list[index].First;
            while (next != null)
            {
                if (next.Value.Key.Equals(key))
                {
                    this.list[index].Remove(next);
                    isRemoved = true;
                    break;
                }

                next = next.Next;
            }

            if (!isRemoved)
            {
                throw new ArgumentException("There isn't element with that key!");
            }

            this.count--;
        }

        public void Clear()
        {
            this.list = new LinkedList<KeyValuePair<K, T>>[16];
            this.count = 0;
            this.capacity = list.Length;
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            foreach (var item in this.list)
            {
                if (item != null)
                {
                    var next = item.First;
                    while (next != null)
                    {
                        yield return next.Value;
                        next = next.Next;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void EnlargeCapacity()
        {
            LinkedList<KeyValuePair<K, T>>[] temp =
                new LinkedList<KeyValuePair<K, T>>[capacity * 2];

            for (int i = 0; i < this.list.Length; i++)
            {
                temp[i] = this.list[i];
            }

            this.list = temp;
            this.capacity = temp.Length;
        }

    }
}
