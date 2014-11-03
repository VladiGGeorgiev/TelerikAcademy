using System;
using System.Collections;
using System.Collections.Generic;

namespace HashTableSample
{
    public class HashTableEnumerator<K, T> : IEnumerator
    {
        private readonly List<KeyValuePair<K, T>> hashTableEnum;

        private int position = -1;

        public HashTableEnumerator(LinkedList<KeyValuePair<K, T>>[] hashtable)
        {
            hashTableEnum = new List<KeyValuePair<K, T>>();

            for (int i = 0; i < hashtable.Length; i++)
            {
                if (hashtable[i] != null && hashtable[i].Count > 0)
                {
                    foreach (var pair in hashtable[i])
                    {
                        hashTableEnum.Add(pair);
                    }
                }
            }
        }

        public bool MoveNext()
        {
            position++;
            return (position < hashTableEnum.Count);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public KeyValuePair<K, T> Current
        {
            get
            {
                try
                {
                    return hashTableEnum[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
