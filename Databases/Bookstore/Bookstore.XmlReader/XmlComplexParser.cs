using Bookstore.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml;

namespace Bookstore.XmlReader
{
    public static class XmlComplexParser
    {
        public static void ParseXml(string filePath)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);
            string pathQuery = "/catalog/book";

            XmlNodeList xmlBookmarks = xmlDocument.SelectNodes(pathQuery);

            foreach (XmlNode book in xmlBookmarks)
            {
                using (var tran = new TransactionScope(TransactionScopeOption.Required, 
                new TransactionOptions{ IsolationLevel = IsolationLevel.RepeatableRead }))
                {
                    XmlNodeList authors = null;
                    if (book.SelectSingleNode("authors") != null)
                    {
                        authors = book.SelectSingleNode("authors").SelectNodes("author");
                    }
                

                    string title = book.GetInnerText("title");
                    if (title == null)
                    {
                        throw new ArgumentNullException("The title is null!");
                    }

                    string webSite = book.GetInnerText("web-site");
                    string isbn = book.GetInnerText("isbn");
                    string priceStr = book.GetInnerText("price");
                    XmlNodeList reviews = null;
                    if (book.SelectSingleNode("reviews") != null)
                    {
                        reviews = book.SelectSingleNode("reviews").SelectNodes("review");
                    }

                    InsertData(authors, title, webSite, isbn, priceStr, reviews);
                    tran.Complete();
                }
            }
        }

        private static void InsertData(XmlNodeList authors, string title, string webSite, string isbn, string priceStr, XmlNodeList reviews)
        {
            var context = new BookstoreEntities();
            using (context)
            {
                Book book = new Book
                {
                    Isbn = isbn,
                    Title = title,
                    Website = webSite,
                };

                if (CheckForExistingBook(context, book))
                {
                    throw new ArgumentException("The book with isbn: {0} already exist!", isbn);
                }

                if (priceStr != null)
                {
                    book.Price = decimal.Parse(priceStr);
                }

                if (authors != null)
                {
                    foreach (XmlNode authorName in authors)
                    {
                        Author author = CreateOrLoadAuthor(context, authorName.InnerText);
                        book.Authors.Add(author);
                    }
                }

                if (reviews != null)
                {
                    foreach (XmlNode reviewNode in reviews)
                    {
                        Review review = new Review();
                        review.CreationDate = DateTime.Now;
                        if (reviewNode.Attributes["date"] != null)
                        {
                            string date = reviewNode.Attributes["date"].Value;
                            review.CreationDate = DateTime.ParseExact(date, "d-MMM-yyyy", CultureInfo.InvariantCulture);
                        }
                        if (reviewNode.Attributes["author"] != null)
                        {
                            string authorStr = reviewNode.Attributes["author"].Value;
                            Author author = CreateOrLoadAuthor(context, authorStr);
                            review.AuthorId = author.AuthorId;
                        }

                        review.ReviewText = reviewNode.InnerText;
                        book.Reviews.Add(review);
                    }
                    
                }


                context.Books.Add(book);
                context.SaveChanges();
            }
        }

        //TODO: FIX
        private static bool CheckForExistingBook(BookstoreEntities context, Book book)
        {
            if (context.Books.Any(x => x.Isbn == book.Isbn))
            {
                return true;
            }

            return false;
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
    }
}
