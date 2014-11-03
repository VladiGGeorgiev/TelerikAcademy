using System;
using System.Linq;
using Supermarket.Data;
using Supermarket.Model;
using System.Text;
using System.Collections.Generic;
using System.Data.Entity;

namespace JSonReporter
{
    public class JSonReportGenerator
    {
        public static List<JSonReport> GetJsonReports()
        {
            var dbContex = new SupermarketContext();
            using (dbContex)
            {
                var jsonReports =
               from p in dbContex.Products
               join dr in dbContex.DailyReports on p.Id equals dr.ProductId
               join v in dbContex.Vendors on p.VendorId equals v.Id
               select new JSonReport
               {
                   ProductId = p.Id,
                   ProductName = p.ProductName,
                   VendorName = v.VendorName,
                   TotalQuntitySold = dr.Quantity,
                   TotalIncome = dr.Quantity * dr.Price
               };

                return jsonReports.ToList() ;
            }
        }

        public static string GetReportAsJsonArray()
        {
            var jSonReports = GetJsonReports();
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (var report in jSonReports)
            {
                sb.Append(report.ToJson() + ", ");
            }
            sb.Length -= 2;
            sb.Append("]");

            return sb.ToString();
        }

        public static void SaveToFile(string filename)
        {
            throw new NotImplementedException();
        }

        public static void UploadToMongoDb()
        {
            throw new NotImplementedException();
        }
    }
}
