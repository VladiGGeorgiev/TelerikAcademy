using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary dictionary = new Dictionary("mongodb://localhost//");

            dictionary.AddWord(new Word("JSON", "Jason Jekov"));
            foreach (var word in dictionary.ListWords())
            {
                Console.WriteLine("Word: {0}, Translation: {1}", word.Name, word.Translation);
            }
            var trans = dictionary.FindWord("Pesho");
            Console.WriteLine("Pesho: {0}", trans);


        }
    }
}
