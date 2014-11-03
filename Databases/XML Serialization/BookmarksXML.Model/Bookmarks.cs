using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BookmarksXML.Model
{
    [XmlRoot("bookmarks")]
    public class Bookmarks
    {
        [XmlElement("bookmark")]
        public List<Bookmark> bookmarks { get; set; }
    }
}
