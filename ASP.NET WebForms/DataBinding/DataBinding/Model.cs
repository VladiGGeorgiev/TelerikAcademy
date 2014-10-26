using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBinding
{
    class Model
    {
        public Model(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
