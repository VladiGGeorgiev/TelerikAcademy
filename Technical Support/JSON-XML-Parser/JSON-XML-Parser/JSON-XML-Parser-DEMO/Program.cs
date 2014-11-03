using JSON_XML_Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JSON_XML_Parser_DEMO
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = Parser.XmlToJson("../../../Catalogue.xml");
            Console.WriteLine(json);

            Parser.JsonToXml(json, "../../../result.xml", "catalogue");
        }
    }
}
