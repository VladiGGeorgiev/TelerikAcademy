using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindProducts
{
    class Program
    {
        private const string ConnetionString = "Server=.;Database=Northwnd;Integrated Security=true;";

        static void Main(string[] args)
        {
            Console.WriteLine("Find all Product contains substring.");
            Console.Write("Insert substring: ");
            string substring = Console.ReadLine();
            PrintAllProductsByPattern(substring);
        }

        private static void PrintAllProductsByPattern(string substring)
        {
            SqlConnection connection = new SqlConnection(ConnetionString);
            connection.Open();
            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Products WHERE ProductName LIKE @substring", connection);
                SqlParameter substr = new SqlParameter("@substring", "%" + substring + "%");
                command.Parameters.Add(substr);
                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string productName = (string)reader["ProductName"];
                        string quantityPerUnit = (string)reader["QuantityPerUnit"];
                        decimal unitPrice = (decimal)reader["UnitPrice"];
                        Console.WriteLine("Name: {0}, QuantityPerUnit: {1}, UnitPrice: {2}", productName, quantityPerUnit, unitPrice);
                    }                    
                }
            }
        }
    }
}
