using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Xml.Model
{
    [Serializable()]
    [XmlRoot("bookmarks")]
    public class BookmarkCollection
    {
        [XmlArray("bookmarks")]
        [XmlArrayItem("bookmark", typeof(Bookmark))]
        public List<Bookmark> Bookmarks = new List<Bookmark>();
    }
}
