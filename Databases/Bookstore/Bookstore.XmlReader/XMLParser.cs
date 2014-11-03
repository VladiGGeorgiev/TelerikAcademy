using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml;
using Bookstore.Model;

namespace Bookstore.XmlReader
{
    public static class XmlParser
    {
        public static void ParseXml(string filePath)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);
            string pathQuery = "/catalog/book";

            XmlNodeList xmlBookmarks = xmlDocument.SelectNodes(pathQuery);

            foreach (XmlNode book in xmlBookmarks)
            {
                string author = book.GetInnerText("author");
                if (author == null)
                {
                    throw new ArgumentNullException("The author is null!");
                }

                string title = book.GetInnerText("title");
                if (title == null)
                {
                    throw new ArgumentNullException("The title is null!");
                }

                string webSite = book.GetInnerText("web-site");
                string isbn = book.GetInnerText("isbn");
                string priceStr = book.GetInnerText("price");

                InsertData(author, title, webSite, isbn, priceStr);
            }
        }

        private static void InsertData(string authorName, string title, string webSite, string isbn, string priceStr)
        {
            var context = new BookstoreEntities();
            Author author = CreateOrLoadAuthor(context, authorName);

            Book book;
            book = new Book
            {
                Isbn = isbn,
                Title = title,
                Website = webSite,
            };

            if (priceStr != null )
            {
                book.Price = decimal.Parse(priceStr);
            }

            
            book.Authors.Add(author);

            context.Books.Add(book);
            context.SaveChanges();
        }

        private static Author CreateOrLoadAuthor(BookstoreEntities context, string authorName)
        {
            var user = context.Authors.FirstOrDefault(x => x.Name == authorName);
            if (user != null)
            {
                return user;
            }

            var newAuthor = new Author
            {
                Name = authorName
            };

            context.Authors.Add(newAuthor);
            context.SaveChanges();
            return newAuthor;
        }

        public static string GetInnerText(this XmlNode node, string tagName)
        {
            var childNode = node.SelectSingleNode(tagName);
            if (childNode == null)
            {
                return null;
            }

            return childNode.InnerText;
        }
    }
}
