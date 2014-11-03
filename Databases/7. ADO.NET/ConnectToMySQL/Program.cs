using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConnectToMySQL
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
        const string ConnectionString = "Server=localhost;Database=Books;Uid=root;Pwd=amonra;";
        static void Main(string[] args)
        {
            ListAllBooks();
            FindBookByName("Pod Igoto");
            Book book = new Book("Added book", "Minka Svircholini", "8411929473", new DateTime(2013, 01, 12));
            AddBook(book);
        }
        //Write methods for listing all books, finding a book by name and adding a book.

        static void ListAllBooks()
        {
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();
            using (connection)
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM BOOKS", connection);
                MySqlDataReader reader = command.ExecuteReader();
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
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();
            using (connection)
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM Books WHERE Title = @title", connection);
                MySqlParameter titleParameter = new MySqlParameter("@title", title);
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
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();
            using (connection)
            {
                MySqlCommand command = new MySqlCommand(
                    "INSERT INTO Books (Title, Author, PublishDate, ISBN) " +
                    "VALUES (@title, @author, @publishDate, @isbn)", connection);
                MySqlParameter titleParam = new MySqlParameter("@title", book.Title);
                MySqlParameter authorParam = new MySqlParameter("@author", book.Author);
                MySqlParameter publishDateParam = new MySqlParameter("@publishDate", book.PublishDate);
                MySqlParameter isbnParam = new MySqlParameter("@isbn", book.Isbn);
                command.Parameters.AddRange(new MySqlParameter[] { titleParam, authorParam, publishDateParam, isbnParam });
                command.ExecuteScalar();
            }
        }
    }
}
