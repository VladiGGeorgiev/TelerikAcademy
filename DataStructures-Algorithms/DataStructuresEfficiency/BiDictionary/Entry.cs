using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiDictionary
{
    class Entry<K1, K2>
    {
        public Entry(K1 firstKey, K2 secondKey)
        {
            this.FirstKey = firstKey;
            this.SecondKey = secondKey;
        }

        public K1 FirstKey { get; set; }
        public K2 SecondKey { get; set; }
    }
}
