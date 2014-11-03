using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;

namespace MongoDbDictionary
{
    class Dictionary
    {
        MongoCollection<Word> collection;
            
        public Dictionary(string connectionString)
        {
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var db = server.GetDatabase("dictionary");
            collection = db.GetCollection<Word>("words");
        }

        public void AddWord(Word word) 
        {
            collection.Insert(word);
            Console.WriteLine("Word: {0} - Inserted!", word.Name);
        }

        public ICollection<Word> ListWords() 
        {
            var words = collection.FindAll();

            return words.ToList();
        }

        public string FindWord(string name) 
        {
            var words = collection.AsQueryable<Word>().Where(x => x.Name == name);

            return words.First().Translation;
        }
    }
}
