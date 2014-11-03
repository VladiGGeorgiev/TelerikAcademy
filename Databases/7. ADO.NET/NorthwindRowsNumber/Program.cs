using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindRowsNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Server=.; " +
            "Database=Northwnd; Integrated Security=true");
            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT COUNT(*) as Count FROM Categories", connection);
                int count = (int)command.ExecuteScalar();
                Console.WriteLine("The count of Categories is: {0}", count);
            }
        }
    }
}
