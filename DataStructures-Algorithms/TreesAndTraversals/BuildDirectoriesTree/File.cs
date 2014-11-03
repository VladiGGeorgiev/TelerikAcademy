using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildDirectoriesTree
{
    class File
    {
        public File(string name, long size)
        {
            this.Name = name;
            this.Size = size;
        }

        public File(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        
        public long Size { get; set; }
    }
}
