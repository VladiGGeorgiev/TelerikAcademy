using System;
using System.Collections.Generic;
using System.Linq;
using ContentCatalog;
using Wintellect.PowerCollections;

namespace ContentCatalog
{
    public interface ICatalog
    {
        void Add(IContent content);

        IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList);

        int UpdateContent(string oldUrl, string newUrl);
    }
}
