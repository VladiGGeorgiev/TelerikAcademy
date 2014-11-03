
using Sider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisDictionary
{
    class Dictionary
    {
        RedisClient client;
            
        public Dictionary()
        {
            client = new RedisClient();
        }

        public void AddWord(Word word) 
        {
            client.HSet("dictionary", word.Name, word.Translation);
            Console.WriteLine("{0} - Inserted!", word.Name);
        }

        public ICollection<Word> ListWords() 
        {
            var words = client.HGetAll("dictionary");

            return words.Select(x => new Word(x.Key, x.Value)).ToList();
        }

        public string FindWord(string name) 
        {
            var translation = client.HGet("dictionary", name);

            return translation;
        }
    }
}
