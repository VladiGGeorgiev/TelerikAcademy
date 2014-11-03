using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwndAllRows
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("SERVER=.; DATABASE=Northwnd; Integrated Security=true");
            connection.Open();
            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT CategoryName, Description FROM Categories", connection);
                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string name = (string)reader["CategoryName"];
                        string description = (string)reader["Description"];
                        Console.WriteLine("Name: {0}; Description: {1}", name, description);
                    }
                }
            }
        }
    }
}
