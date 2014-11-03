using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategories
{
    class ProductCategories
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Server=.; Database=Northwnd; Integrated Security=true");
            connection.Open();
            using (connection)
            {
                SqlCommand command = new SqlCommand(
                    "SELECT c.CategoryName, p.ProductName " + 
                    "FROM Products p " + 
                    "JOIN Categories c ON p.CategoryId = c.CategoryId " +
                    "ORDER BY c.CategoryName", connection);
                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        var categoryName = (string)reader["CategoryName"];
                        var productName = (string)reader["ProductName"];
                        Console.WriteLine("Category: {0}; Product: {1}", categoryName, productName);
                    }
                }
            }
        }
    }
}
