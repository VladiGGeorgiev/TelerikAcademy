using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectToExcel
{
    class Data
    {
        public Data(int id, string name, double score)
        {
            this.Name = name;
            this.Score = score;
            this.Id = id;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public double Score { get; set; }
    }

    class ConnectToExcel
    {
        static void Main(string[] args)
        {
            DataTable dt = new DataTable("newtable");
            OleDbConnectionStringBuilder csbuilder = new OleDbConnectionStringBuilder();
            csbuilder.Provider = "Microsoft.ACE.OLEDB.12.0";
            csbuilder.DataSource = @"..\..\Excel.xlsx";
            csbuilder.Add("Extended Properties", "Excel 12.0");

            ReadDataFromExcel(csbuilder);
            InsertDataToExcel(csbuilder, new Data(16, "New Name", 999));
        }
  
        private static void ReadDataFromExcel(OleDbConnectionStringBuilder csbuilder)
        {
            OleDbConnection connection = new OleDbConnection(csbuilder.ConnectionString);
            connection.Open();

            using (connection)
            {
                OleDbCommand command = new OleDbCommand("SELECT Name, Score FROM [Sheet1$]", connection);
                var reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        var name = (string)reader["Name"];
                        var score = (double)reader["Score"];
                        Console.WriteLine("Name: {0}, Score: {1}", name, score);
                    }
                }
            }
        }

        private static void InsertDataToExcel(OleDbConnectionStringBuilder csbuilder, Data data)
        {
            OleDbConnection connection = new OleDbConnection(csbuilder.ConnectionString);
            connection.Open();

            using (connection)
            {
                OleDbCommand command = new OleDbCommand("INSERT INTO [Sheet1$] (Id, Name, Score) " + 
                    "VALUES (@id, @name, @score)", connection);

                OleDbParameter id = new OleDbParameter("@id", data.Id);
                OleDbParameter name = new OleDbParameter("@name", data.Name);
                OleDbParameter score = new OleDbParameter("@score", data.Score);
                command.Parameters.AddRange(new OleDbParameter[] { id, name, score });

                try
                {
                    command.ExecuteNonQuery();

                    Console.WriteLine("Row inserted successfully.");
                }
                catch (OleDbException exception)
                {
                    Console.WriteLine("SQL Error occured: " + exception);
                }
            }
        }
    }
}
