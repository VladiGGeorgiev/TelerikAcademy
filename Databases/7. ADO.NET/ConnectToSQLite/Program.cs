using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace ConnectToSQLite
{
    class Book
    {
        public Book(string title, string author, string isbn, DateTime publishDate)
        {
            this.Title = title;
            this.Author = author;
            this.Isbn = isbn;
            this.PublishDate = publishDate;
        }

        public string Title { get; set; }

        public DateTime PublishDate { get; set; }

        public string Author { get; set; }

        public string Isbn { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ListBooks();
            FindBookByName("Pod Igoto");
            Book book = new Book("Added book", "Minka Svircholini", "8411929473", new DateTime(2013, 01, 12));
            AddBook(book);
        }

        static void ListBooks()
        {
            SQLiteConnection connection = new SQLiteConnection();
            connection.Open();
            using (connection)
            {
                SQLiteCommand command = new SQLiteCommand("SELECT * FROM BOOKS", connection);
                SQLiteDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string title = (string)reader["Title"];
                        string author = (string)reader["Author"];
                        string isbn = (string)reader["ISBN"];
                        DateTime publishDate = (DateTime)reader["PublishDate"];
                        Console.WriteLine("Title: {0}, Author: {1}, PublishDate: {2}, ISBN: {3}", title, author, publishDate, isbn);
                    }
                }
            }
        }

        static void FindBookByName(string title)
        {
            SQLiteConnection connection = new SQLiteConnection();
            connection.Open();
            using (connection)
            {
                SQLiteCommand command = new SQLiteCommand("SELECT * FROM Books WHERE Title = @title", connection);
                SQLiteParameter titleParameter = new SQLiteParameter("@title", title);
                command.Parameters.Add(titleParameter);
                var reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string bookTitle = (string)reader["Title"];
                        string author = (string)reader["Author"];
                        string isbn = (string)reader["ISBN"];
                        DateTime publishDate = (DateTime)reader["PublishDate"];
                        Console.WriteLine(Environment.NewLine + "Books with title {0} find:", title);
                        Console.WriteLine("Title: {0}, Author: {1}, PublishDate: {2}, ISBN: {3}", bookTitle, author, publishDate, isbn);
                    }
                }
            }
        }

        static void AddBook(Book book)
        {
            SQLiteConnection connection = new SQLiteConnection();
            connection.Open();
            using (connection)
            {
                SQLiteCommand command = new SQLiteCommand(
                    "INSERT INTO Books (Title, Author, PublishDate, ISBN) " +
                    "VALUES (@title, @author, @publishDate, @isbn)", connection);
                SQLiteParameter titleParam = new SQLiteParameter("@title", book.Title);
                SQLiteParameter authorParam = new SQLiteParameter("@author", book.Author);
                SQLiteParameter publishDateParam = new SQLiteParameter("@publishDate", book.PublishDate);
                SQLiteParameter isbnParam = new SQLiteParameter("@isbn", book.Isbn);
                command.Parameters.AddRange(new SQLiteParameter[] { titleParam, authorParam, publishDateParam, isbnParam });
                command.ExecuteScalar();
            }
        }
    }
}

