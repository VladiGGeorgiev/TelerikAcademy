using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbDictionary
{
    public class Word
    {
        public Word( string name, string trans)
        {
            this.Name = name;
            this.Translation = trans;
        }

        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public string Translation { get; set; }
    }
}
