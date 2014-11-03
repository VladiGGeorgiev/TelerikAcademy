using Bookstore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Bookstore.XmlReader;
using System.Globalization;
using SearchLogs.Data;
using SearchLogs;

namespace Bookstore.QueryExecutor
{
    public class SearchForReviews
    {
        public static void ExecureQuery(string filePath)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);
            string pathQuery = "/review-queries/query";

            XmlNodeList xmlQuery = xmlDocument.SelectNodes(pathQuery);


            string fileName = "../../search-results.xml";
            using (var writer = new XmlTextWriter(fileName, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("search-results");
                writer.WriteStartElement("result-set");

                BookstoreEntities context = new BookstoreEntities();
                foreach (XmlNode query in xmlQuery)
                {
                    if (query.Attributes["type"].Value == "by-period")
                    {
                        string startDateStr = query["start-date"].InnerText;
                        string endDateStr = query["end-date"].InnerText;

                        DateTime startDate = DateTime.ParseExact(startDateStr, "d-MMM-yyyy", CultureInfo.InvariantCulture);
                        DateTime endDate = DateTime.ParseExact(endDateStr, "d-MMM-yyyy", CultureInfo.InvariantCulture);


                        var searchQuery =
                            from r in context.Reviews
                            where r.CreationDate >= startDate && r.CreationDate <= endDate
                            select r;

                        searchQuery = searchQuery.OrderByDescending(x => x.CreationDate);
                        searchQuery = searchQuery.OrderByDescending(x => x.ReviewText);

                        WriteBookmarks(writer, searchQuery.ToList());
                    }
                    else
                    {
                        string authorName = query["author-name"].InnerText;

                        var searchQuery =
                            from r in context.Reviews
                            join a in context.Authors on r.AuthorId equals a.AuthorId
                            where a.Name == authorName
                            select r;

                        searchQuery = searchQuery.OrderByDescending(x => x.CreationDate);
                        searchQuery = searchQuery.OrderByDescending(x => x.ReviewText);

                        WriteBookmarks(writer, searchQuery.ToList());
                    }

                    //Create log
                    var logsContext = new LogsContext();
                    Log log = new Log
                        {
                            Date = DateTime.Now,
                            QueryXml = CreateQueryXml(query)
                        };
                    logsContext.Logs.Add(log);
                    logsContext.SaveChanges();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private static string CreateQueryXml(XmlNode query)
        {
            StringBuilder result = new StringBuilder();
            result.Append("<query type=\"" + query.Attributes[0].Value + "\">");
            result.Append(query.InnerXml);
            result.Append("</query>");
            return result.ToString();
        }

        private static void WriteBookmarks(XmlTextWriter writer, IList<Review> reviews)
        {
            foreach (var review in reviews)
            {
                //<review>
                writer.WriteStartElement("review");

                if (review.CreationDate != null)
                {
                    writer.WriteElementString("date", review.CreationDate.ToString("d-MMM-yyyy"));
                }
                if (review.ReviewText != null)
                {
                    writer.WriteElementString("content", review.ReviewText);
                }

                //<BOOK>
                writer.WriteStartElement("book");
                writer.WriteElementString("title", review.Book.Title);

                if (review.Book.Authors.Count > 0)
                {
                    StringBuilder str = new StringBuilder();
                    var authors = review.Book.Authors.OrderBy(x => x.Name);
                    foreach (var author in authors)
                    {
                        str.Append(author.Name + ", ");
                    }
                    str.Length -= 2;
                    writer.WriteElementString("authors", str.ToString());
                }

                if (review.Book.Isbn != null)
                {
                    writer.WriteElementString("isbn", review.Book.Isbn);
                }

                if (review.Book.Website != null)
                {
                    writer.WriteElementString("url", review.Book.Website);
                }
                
                writer.WriteEndElement();
                //</BOOK>

                writer.WriteEndElement();
                //</review>
            }
        }
    }
}
