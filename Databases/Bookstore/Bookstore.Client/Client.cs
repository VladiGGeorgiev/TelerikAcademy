using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Client
{
    public class Client
    {
        public static void Main()
        {
            //Don't call XmlParser and XmlComplexParser together!!!!!!!!!!!
            //Before call clear the database!!!!!

            //Problem 3. Simple Books Import from XML File
            //XmlReader.XmlParser.ParseXml("../../../Tests/Problem 3. Simple Books Import from XML File/test5.xml");

            //Problem 4. Complex Books Import from XML File
            XmlReader.XmlComplexParser.ParseXml("../../../Tests/Problem 4. Complex Books Import from XML File/test3.xml");

            //Problem 5. Simple Search for Books
            //QueryExecutor.Searcher.ExecureQuery("../../simple-query.xml");

            //QueryExecutor.Searcher.ExecureQuery("../../simple-query2.xml");

            //Problem 6. Search for Reviews
            //Problem 7. Search Logs (Code First)
            //QueryExecutor.SearchForReviews.ExecureQuery("../../reviews-queries.xml");
        }
    }
}
