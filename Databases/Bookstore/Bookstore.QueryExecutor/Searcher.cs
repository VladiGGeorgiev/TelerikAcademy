using System.Xml;
using Bookstore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.XmlReader;

namespace Bookstore.QueryExecutor
{
    public class Searcher
    {
        public static void ExecureQuery(string filePath)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);
            string pathQuery = "/query";

            XmlNode xmlQuery = xmlDocument.SelectSingleNode(pathQuery);


            string title = xmlQuery.GetInnerText("title");
            string author = xmlQuery.GetInnerText("author");
            string isbn = xmlQuery.GetInnerText("isbn");

            BookstoreEntities context = new BookstoreEntities();
            var booksQuery =
                from b in context.Books
                select b;

            if (title != null)
            {
                booksQuery = context.Books.Where(x => x.Title == title);
            }

            if (author != null)
            {
                booksQuery = booksQuery.Where(x => x.Authors.Any(y => y.Name.ToLower() == author.ToLower()));
            }

            if (isbn != null)
            {
                booksQuery = booksQuery.Where(x => x.Isbn == isbn);
            }

            booksQuery = booksQuery.OrderBy(x => x.Title);

            PrintBooksOnConsole(booksQuery.ToList());
        }

        private static void PrintBooksOnConsole(List<Book> list)
        {
            int booksCount = list.Count;
            if (booksCount > 0)
            {
                Console.WriteLine("{0} books found:", booksCount);
                foreach (var book in list)
                {
                    int reviewsCount = book.Reviews.Count;
                    if (reviewsCount > 0)
                    {
                        Console.WriteLine("{0} --> {1} reviews", book.Title, reviewsCount);
                    }
                    else
                    {
                        Console.WriteLine("{0} --> no reviews", book.Title);
                    }
                }
            }
            else
            {
                Console.WriteLine("Nothing found");
            }
        }
    }
}
