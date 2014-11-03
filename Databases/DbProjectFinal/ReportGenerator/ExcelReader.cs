using System;
using System.Data.OleDb;
using System.Linq;

namespace ReportGenerator
{
    public class ExcelReader : IDisposable
    {
        public string ExcelConnectionString { get; private set; }

        private OleDbConnection dbConn;

        public ExcelReader(string filePath)
        {
            this.ExcelConnectionString =
            string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=YES\";", filePath);
            this.EstablishConnection();
        }

        private void EstablishConnection()
        {
            dbConn = new OleDbConnection(ExcelConnectionString);
            dbConn.Open();
        }

        public OleDbDataReader GetAllEntriesReader()
        {
            string getAllEntriesQuery = @"SELECT * FROM [Sales$]";
            OleDbCommand getInformation = new OleDbCommand(getAllEntriesQuery, dbConn);
            OleDbDataReader infoReader = getInformation.ExecuteReader();

            return infoReader;
        }

        //private void AppendRow(string name, double points)
        //{
        //    OleDbCommand appendLineCmd = new OleDbCommand(@"INSERT INTO [Sheet1$](Name, Score) VALUES (@Name, @Score) ", dbConn);
        //    appendLineCmd.Parameters.AddWithValue("@Name", name);
        //    appendLineCmd.Parameters.AddWithValue("@Score", points);
        //    appendLineCmd.ExecuteNonQuery();
        //}


        public void Dispose()
        {
            dbConn.Close();
        }
    }
}
