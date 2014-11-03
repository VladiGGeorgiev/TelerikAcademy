using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JSON_XML_Parser
{
    public class Parser
    {
        /// <summary>
        /// This method converts a XML Document to a string object in JSON format.
        /// </summary>
        /// <param name="xmlDocument">The document to be converted</param>
        /// <returns>String variable, containing JSON format information</returns>
        /// <remarks>A StringBuilder is used to build the JSON string</remarks>
        public static string XmlToJson(string xmlFilePath)
        {
            XmlDocument document = new XmlDocument();
            document.Load(xmlFilePath);
            XmlElement root = document.DocumentElement;

            string json = JsonConvert.SerializeXmlNode(root);
            return json;
        }

        /// <summary>
        /// This Method uses Newtonsoft.Json library for parsing JSONstring to XMLDocument
        /// </summary>
        /// <param name="jsonString">The JSONstring that to be parsed</param>
        /// <param name="xmlFilePath">The path where the XML file should be created</param>
        /// <param name="rootElementName">Root element name for the XML Document</param>
        public static void JsonToXml(string jsonString, string xmlFilePath, string rootElementName)
        {
            XmlDocument result = JsonConvert.DeserializeXmlNode(jsonString, rootElementName);

            XmlWriter writer = XmlWriter.Create(xmlFilePath);
            result.WriteContentTo(writer);
            writer.Close();
        }
    }
}