using System;
using System.Collections.Generic;

namespace Bookmarks.Client
{
    class Program
    {
        static void Main()
        {
            XmlParser.ParseXml();

            XmlParser.ExecureQueriesFromXml("../../query.xml");
        }
    }
}
