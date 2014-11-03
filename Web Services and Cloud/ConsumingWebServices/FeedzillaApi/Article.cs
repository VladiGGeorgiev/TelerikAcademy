using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedzillaApi
{
    class Article
    {
        public string Title { get; set; }

        public string Url { get; set; }

        public override string ToString()
        {
            return string.Format("Title: {0}, \r\n Url: {1}", this.Title, this.Url);
        }
    }
}
