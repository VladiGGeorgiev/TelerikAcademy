using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using BookmarksXML.Model;
using System.IO;
using System.Xml;

namespace BookmarksXMLParser
{
    public class XMLParser
    {
        public static void Main()
        {
            string filePath = "../../bookmarks.xml";
            Bookmarks x = DeserializeFromXml<Bookmarks>(filePath);

        }

        public static void SerializeToXml<T>(T obj, string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                var ser = new XmlSerializer(typeof(T));
                var xns = new XmlSerializerNamespaces();
                xns.Add(string.Empty, string.Empty);
                ser.Serialize(fileStream, obj, xns);
            }
        }

        public static T DeserializeFromXml<T>(string filePath)
        {
            T result;
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                result = (T)xmlSerializer.Deserialize(fileStream);
            }
            return result;
        }

    }
}

