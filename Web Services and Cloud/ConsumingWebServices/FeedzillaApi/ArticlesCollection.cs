using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedzillaApi
{
    class ArticlesCollection
    {
        public ArticlesCollection()
        {
            this.Articles = new HashSet<Article>();    
        }

        public HashSet<Article> Articles { get; set; }
    }
}
