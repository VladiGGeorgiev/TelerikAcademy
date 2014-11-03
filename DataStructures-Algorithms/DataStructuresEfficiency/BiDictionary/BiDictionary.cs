using System;
using System.Collections;
using System.Collections.Generic;
using Wintellect.PowerCollections;

namespace BiDictionary
{
    /*
     * Implement a class BiDictionary<K1,K2,T> that allows adding triples
     * {key1, key2, value}
     * and fast search by key1, key2 or by both key1 and key2. 
     * Note: multiple values can be stored for given key.
     */
    class BiDictionary<K1, K2, T>
    {
        private MultiDictionary<K1, T> containerKey1;
        private MultiDictionary<K2, T> containerKey2;
        private MultiDictionary<Entry<K1, K2>, T> containerKeys;

        public BiDictionary()
        {
            this.containerKey1 = new MultiDictionary<K1, T>(true);
            this.containerKey2 = new MultiDictionary<K2, T>(true);
            this.containerKeys = new MultiDictionary<Entry<K1, K2>, T>(true);
        }

        public void Add(K1 firstKey, K2 secondKey, T value)
        {
            this.containerKey1.Add(firstKey, value);
            this.containerKey2.Add(secondKey, value);
            this.containerKeys.Add(new Entry<K1, K2>(firstKey, secondKey), value);
        }

        public ICollection<T> FindByFirstKey(K1 key1)
        {
            if (this.containerKey1.ContainsKey(key1))
            {
                return this.containerKey1[key1];   
            }
            else
            {
                throw new ArgumentException("There is not element with this value!");
            }
        }

        public ICollection<T> FindBySecondKey(K2 key2)
        {
            if (this.containerKey2.ContainsKey(key2))
            {
                return this.containerKey2[key2];
            }
            else
            {
                throw new ArgumentException("There is not element with this value!");
            }
        }

        public ICollection<T> FindByAllKeys(K1 key1, K2 key2)
        {
            Entry<K1, K2> entry = new Entry<K1, K2>(key1, key2);
            if (this.containerKeys.ContainsKey(entry))
            {
                return this.containerKeys[entry];
            }
            else
            {
                throw new ArgumentException("There is not element with this value!");
            }
        }
    }
}
