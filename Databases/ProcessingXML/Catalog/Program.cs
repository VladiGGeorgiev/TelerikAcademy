using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Catalog
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateXMLCatalog();
        }

        /// <summary>
        /// Create a XML file representing catalogue. The catalogue should contain albums of different artists. 
        /// For each album you should define: name, artist, year, producer, price and a list of songs. 
        /// Each song should be described by title and duration.
        /// </summary>
        public static void CreateXMLCatalog()
        {
            XmlDocument document = new XmlDocument();
            var declaration = document.CreateXmlDeclaration("1.0", "UTF-8", "");
            document.AppendChild(declaration);
            XmlElement root = document.CreateElement("albums");
            document.AppendChild(root);

            var album = document.CreateElement("album");

            var name = document.CreateElement("name");
            name.InnerText = "Love me";
            var artist = document.CreateElement("artist");
            artist.InnerText = "Galena";
            var year = document.CreateElement("year");
            year.InnerText = "2013";
            var producer = document.CreateElement("producer");
            producer.InnerText = "Painer";
            var price = document.CreateElement("price");
            price.InnerText = "100$";

            var song1 = document.CreateElement("songs");
            var title = document.CreateElement("title");
            title.InnerText = "Dryj go!";
            var duration = document.CreateElement("duration");
            duration.InnerText = "2.5";

            var song2 = document.CreateElement("song");

            root.AppendChild(album);
            album.AppendChild(name);
            album.AppendChild(artist);
            album.AppendChild(year);
            album.AppendChild(producer);
            album.AppendChild(price);
            album.AppendChild(song1);
            song1.AppendChild(title);
            song1.AppendChild(duration);

            document.Save("../../new.xml");
        } 
    }
}
