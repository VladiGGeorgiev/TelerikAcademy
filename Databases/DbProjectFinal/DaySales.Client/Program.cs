using System;
using System.Collections.Generic;
using System.Linq;
using ReportGenerator;
using Supermarket.Data;
using Supermarket.Model;
using System.Data.Entity;
using Supermarket.Data.Migrations;
using Telerik.OpenAccess;
using System.Xml;
using System.Globalization;
using MongoDB.Driver;
using MondoDbProvider;
using System.IO;
using JSonReporter;
using System.Xml.Linq;
using SQLiteConnector;

namespace Supermarket.Client
{
    public class Program
    {
        static void Main()
        {
            //System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<SupermarketContext, Configuration>());
            System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseAlways<SupermarketContext>());

            //1 task - Load Excel Reports from ZIP File
            InitializeDataFromMySQL();
            InitializeDataFromExcel();

            //2 task - Generate PDF Aggregated Sales Reports
            PdfExporter.FillAndExportPdf();

            //3 task - Generate XML Sales Report by Vendors
            GenerateXmlReport("report.xml");

            //4 task - Product Reports
            MakeJsonReports();

            //5 task - Load Vendor Expenses from XML
            var expenses = GetVendorExpensesFromXml();
            FillExpensesInSql(expenses);
            var mongoExpenses = GetVendorMongoExpensesFromXml();
            FillExpensesInMongoDb(mongoExpenses);

            MongoDbReportReader.SetInitialData(@"mongodb://localhost", "twjsonreports", "reports");
            MongoDbReportReader.EstablishConnection();
            var cursor = MongoDbReportReader.GetReportList();

            SQLiteConnector.SQLiteConnector.MakeConnection();
        }

        private static void FillExpensesInMongoDb(ICollection<MongoExpense> expenses)
        {
            MongoClient client = new MongoClient("mongodb://localhost//");
            var server = client.GetServer();
            var db = server.GetDatabase("supermarket");
            var collection = db.GetCollection<MongoExpense>("expenses");
            
            foreach (var expense in expenses)
	        {
                collection.Insert(expense);
	        }

            //foreach (var item in collection.FindAllAs<MongoExpense>())
            //{
            //    Console.WriteLine(item);
            //} 
            Console.WriteLine("5. Expenses saved in MongoDB!");
        }

        private static void FillExpensesInSql(ICollection<Expense> expenses)
        {
            SupermarketContext context = new SupermarketContext();
            using (context)
            {
                foreach (var expense in expenses)
	            {
                    context.Expenses.Add(expense);
	            }

                context.SaveChanges();
            }

            Console.WriteLine("5. Expenses saved in SQL Server!");
        }

        private static void InitializeDataFromMySQL()
        {
            var db = new SupermarketContext();
            SupermarketModel model = new SupermarketModel();

            using (db)
            {
                foreach (var measure in model.Measures)
                {
                    db.Measurments.Add(new Measure() {
                        Id = measure.Id, 
                        MeasureName = measure.MeasureName
                    });
                }

                foreach (var vendor in model.Vendors)
                {

                    db.Vendors.Add(new Vendor() { 
                        Id = vendor.Id,
                        VendorName = vendor.VendorName
                    });
                }
                foreach (var product in model.Products)
                {
                    db.Products.Add(new Product() {
                        Id = product.Id, 
                        BasePrice = product.BasePrice,
                        MeasureId=product.MeasureId,
                        ProductName = product.ProductName, 
                        VendorId= product.VendorId
                    });
                }

                db.SaveChanges();
                Console.WriteLine("1. Data from MySQL saved in SQL Server!");
            }
        }

        private static void InitializeDataFromExcel()
        {
            var db = new SupermarketContext();

            var generator = new Generator(@"..\..\Sample-Sales-Reports.zip", @"..\..\");
            var reportList = generator.Generate();
            
            using (db)
            {
                
                foreach (var item in reportList)
                {
                    db.DailyReports.Add(item);
                }

                db.SaveChanges();
                Console.WriteLine("1. Data from Excel saved in SQL Server!");
            }
        }

        private static ICollection<MongoExpense> GetVendorMongoExpensesFromXml()
        {
            XmlDocument document = new XmlDocument();
            document.Load(@"..\..\Vendor.xml");

            List<MongoExpense> expenses = new List<MongoExpense>();
            using (var db = new SupermarketContext())
            {
                XmlNode sales = document.DocumentElement;
                foreach (XmlNode sale in sales.ChildNodes)
                {
                    foreach (XmlNode expense in sale.ChildNodes)
                    {
                        DateTime date = DateTime.ParseExact(expense.Attributes[0].Value, "MMM-yyyy", CultureInfo.InvariantCulture);
                        string vendorName = sale.Attributes[0].Value;
                        int currentVendorId = 
                            (from v in db.Vendors
                             where v.VendorName == vendorName
                             select v.Id).First();

                        var currentExpense = new MongoExpense
                        {
                            Month = date,
                            Value = decimal.Parse(expense.InnerText),
                            VendorId = currentVendorId
                        };

                        expenses.Add(currentExpense);
                    }
                }
            }

            return expenses;
        }

        private static ICollection<Expense> GetVendorExpensesFromXml()
        {
            XmlDocument document = new XmlDocument();
            document.Load(@"..\..\Vendor.xml");

            List<Expense> expenses = new List<Expense>();
            using (var db = new SupermarketContext())
            {
                XmlNode sales = document.DocumentElement;
                foreach (XmlNode sale in sales.ChildNodes)
                {
                    foreach (XmlNode expense in sale.ChildNodes)
                    {
                        DateTime date = DateTime.ParseExact(expense.Attributes[0].Value, "MMM-yyyy", CultureInfo.InvariantCulture);
                        string vendorName = sale.Attributes[0].Value;
                        int currentVendorId = //db.Vendors.Where(x => x.VendorName == sale.Attributes[0].Value).Select(x => x.Id).ToList();
                            (from v in db.Vendors
                             where v.VendorName == vendorName
                            select v.Id).First();
                        
                        var currentExpense = new Expense
                        {
                            Month = date,
                            Value = decimal.Parse(expense.InnerText),
                            VendorId = currentVendorId
                        };

                        expenses.Add(currentExpense);
                    }
                }
            }
            
            return expenses;
        }

        private static void MakeJsonReports()
        {
            MongoJsonWriter.SetInitialData(@"mongodb://localhost", "twjsonreports", "reports");
            MongoJsonWriter.EstablishConnection();

            Directory.CreateDirectory(@"..\..\Product-Reports");
            var jsonReports = JSonReportGenerator.GetJsonReports();
            foreach (var item in jsonReports)
            {
                MongoJsonWriter.SaveJson(item.ToJson());
                var strWriter = File.AppendText(@"..\..\Product-Reports\" + item.ProductId + ".json");
                using (strWriter)
                {
                    strWriter.WriteLine(item.ToJson());
                }
            }
            Console.WriteLine("4. JSON Product reports save in MongoDB and in new file!");
        }

        private static void GenerateXmlReport(string name)
        {
             var db = new SupermarketContext();

            using (db)
            {
                XDocument salestest = new XDocument(
                    new XDeclaration("1.0", "utf-8", "no"),
                    new XProcessingInstruction("xml-stylesheet", @"type=""text/xsl"" href=""SalesStyle.xslt"""));

                var byVendor =
                    from vendor in db.DailyReports
                    select vendor;

                var grouped = byVendor.GroupBy(x => x.MarketName);

                var sale = new XElement("Sales");
                salestest.Add(sale);

                foreach (var item in grouped)
                {
                    var secondSale = new XElement("sale");
                    sale.Add(secondSale);
                    var vendor = new XAttribute("vendor", item.Key);
                    secondSale.Add(vendor);

                    foreach (var date in item)
                    {
                        secondSale.Add(
                            new XElement("summary",
                            new XAttribute("date", date.Date),
                            new XAttribute("total-sum", date.Price))
                        );
                    }
                }
                salestest.Save(name);
            }

            Console.WriteLine("3. XML sales report is generated!");
        }
    }
}
