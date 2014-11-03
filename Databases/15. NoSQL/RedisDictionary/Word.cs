using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisDictionary
{
    public class Word
    {
        public Word( string name, string trans)
        {
            this.Name = name;
            this.Translation = trans;
        }

        public string Name { get; set; }

        public string Translation { get; set; }
    }
}
