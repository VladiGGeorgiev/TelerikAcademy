using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sider.Executors;
using Sider.Serialization;
using Sider;

namespace RedisDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary dictionary = new Dictionary();
            dictionary.AddWord(new Word("PC", "Computer"));
            dictionary.FindWord("PC");
        }
    }
}
