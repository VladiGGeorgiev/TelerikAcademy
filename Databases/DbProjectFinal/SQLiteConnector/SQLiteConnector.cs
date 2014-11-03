using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace SQLiteConnector
{
    public class SQLiteConnector
    {
        static string connectionString = @"Data Source=..\..\VendorReports.db";

        public static void MakeConnection()
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            string query = @"INSERT INTO Products(ProductId, Tax) VALUES (1, 10)";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
