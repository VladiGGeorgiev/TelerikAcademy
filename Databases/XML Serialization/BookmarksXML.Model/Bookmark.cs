using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace BookmarksXML.Model
{
    //[XmlType("bookmark")]
    public class Bookmark
    {
        [XmlElement("username")]
        public string Username { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("url")]
        public string Url { get; set; }

        [XmlElement("tags")]
        public List<string> Tags { get; set; }
    }
}
