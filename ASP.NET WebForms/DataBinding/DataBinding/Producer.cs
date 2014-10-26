using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBinding
{
    class Producer
    {
        public Producer(string name, ICollection<Model> models)
        {
            this.Name = name;
            this.Models = models;
        }

        public string Name { get; set; }

        public ICollection<Model> Models { get; set; }
    }
}
