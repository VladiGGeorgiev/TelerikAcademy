using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Data;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;

namespace Supermarket.Client
{
    public class PdfExporter
    {
        public static void FillAndExportPdf()
        {
            using (var db = new SupermarketContext())
            {
                var test = db.DailyReports.First();
                var query = db.DailyReports.OrderBy(x => x.Date).ToList();
                string path = "../../../SalesReport.pdf";
                Document DC = new Document();
                FileStream FS = File.Create(path);
                PdfWriter.GetInstance(DC, FS);
                DC.Open();

                PdfPTable table = new PdfPTable(5);
                table.TotalWidth = 440f;
                table.LockedWidth = true;
                float[] widths = new float[] { 60f, 60f, 60f, 200f, 60f };
                table.SetWidths(widths);
                PdfPCell cell = new PdfPCell();
                bool firstDate = true;
                DateTime temp = DateTime.Now;
                decimal result = 0.00m;
                decimal grandResult = 0.00m;

                //header
                cell = new PdfPCell(new Phrase("Aggregate sales report"));
                cell.BackgroundColor = new BaseColor(189, 216, 218);
                cell.Colspan = 5;
                cell.HorizontalAlignment = 1;
                cell.PaddingTop = 10f;
                cell.PaddingBottom = 10f;
                table.AddCell(cell);

                //fonts
                BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                Font bold = new Font(bfTimes, 12, Font.BOLD);

                foreach (var item in query)
                {
                    if (firstDate)
                    {
                        temp = item.Date;
                        firstDate = false;

                        //first date
                        cell = new PdfPCell(new Phrase("Date: " + item.Date.ToString("d")));
                        cell.Colspan = 5;
                        cell.BackgroundColor = new BaseColor(223, 239, 240);
                        cell.PaddingBottom = 5f;
                        cell.PaddingLeft = 5f;
                        table.AddCell(cell);

                        //products header
                        cell = new PdfPCell(new Phrase("Product", bold));
                        cell.BackgroundColor = new BaseColor(189, 216, 218);
                        cell.PaddingBottom = 5f;
                        cell.PaddingLeft = 5f;
                        table.AddCell(cell);
                        cell = new PdfPCell(new Phrase("Quantity", bold));
                        cell.BackgroundColor = new BaseColor(189, 216, 218);
                        cell.PaddingBottom = 5f;
                        cell.PaddingLeft = 5f;
                        table.AddCell(cell);
                        cell = new PdfPCell(new Phrase("Unit Price", bold));
                        cell.BackgroundColor = new BaseColor(189, 216, 218);
                        cell.PaddingBottom = 5f;
                        cell.PaddingLeft = 5f;
                        table.AddCell(cell);
                        cell = new PdfPCell(new Phrase("Location", bold));
                        cell.BackgroundColor = new BaseColor(189, 216, 218);
                        cell.PaddingBottom = 5f;
                        cell.PaddingLeft = 5f;
                        table.AddCell(cell);
                        cell = new PdfPCell(new Phrase("Sum", bold));
                        cell.BackgroundColor = new BaseColor(189, 216, 218);
                        cell.PaddingBottom = 5f;
                        cell.PaddingLeft = 5f;
                        table.AddCell(cell);
                    }
                    if (temp == item.Date)
                    { //table data
                        table.AddCell(item.Product.ProductName);
                        table.AddCell(item.Quantity.ToString());
                        table.AddCell(item.Price.ToString());
                        table.AddCell("Supermarket " + item.MarketName);
                        decimal sum = item.Quantity * item.Price;
                        table.AddCell(sum.ToString());

                        result += sum;
                    }
                    else
                    {
                        //date
                        cell = new PdfPCell(new Phrase("Total sum for " + item.Date.ToString("d")));
                        cell.Colspan = 4;
                        cell.HorizontalAlignment = 2;
                        cell.PaddingBottom = 5f;
                        cell.PaddingLeft = 5f;
                        table.AddCell(cell);
                        temp = item.Date;

                        //sum
                        cell = new PdfPCell(new Phrase(result.ToString(), bold));
                        cell.PaddingBottom = 5f;
                        cell.PaddingLeft = 5f;
                        table.AddCell(cell);

                        temp = item.Date;
                        grandResult += result;
                        result = 0m;

                        cell = new PdfPCell(new Phrase("Date: " + item.Date.ToString("d")));
                        cell.Colspan = 5;
                        cell.BackgroundColor = new BaseColor(217, 217, 217);
                        cell.PaddingBottom = 5f;
                        cell.PaddingLeft = 5f;
                        table.AddCell(cell);
                        temp = item.Date;

                        //products header
                        cell = new PdfPCell(new Phrase("Product", bold));
                        cell.BackgroundColor = new BaseColor(189, 216, 218);
                        cell.PaddingBottom = 5f;
                        cell.PaddingLeft = 5f;
                        table.AddCell(cell);
                        cell = new PdfPCell(new Phrase("Quantity", bold));
                        cell.BackgroundColor = new BaseColor(189, 216, 218);
                        cell.PaddingBottom = 5f;
                        cell.PaddingLeft = 5f;
                        table.AddCell(cell);
                        cell = new PdfPCell(new Phrase("Unit Price", bold));
                        cell.BackgroundColor = new BaseColor(189, 216, 218);
                        cell.PaddingBottom = 5f;
                        cell.PaddingLeft = 5f;
                        table.AddCell(cell);
                        cell = new PdfPCell(new Phrase("Location", bold));
                        cell.BackgroundColor = new BaseColor(189, 216, 218);
                        cell.PaddingBottom = 5f;
                        cell.PaddingLeft = 5f;
                        table.AddCell(cell);
                        cell = new PdfPCell(new Phrase("Sum", bold));
                        cell.BackgroundColor = new BaseColor(189, 216, 218);
                        cell.PaddingBottom = 5f;
                        cell.PaddingLeft = 5f;
                        table.AddCell(cell);

                        //table data
                        table.AddCell(item.Product.ProductName);
                        table.AddCell(item.Quantity.ToString());
                        table.AddCell(item.Price.ToString());
                        table.AddCell("Supermarket " + item.MarketName);

                        decimal sum = item.Quantity * item.Price;
                        table.AddCell(sum.ToString());

                        result += sum;
                    }
                }
                //last result sum
                cell = new PdfPCell(new Phrase("Total sum for " + temp.ToString("d")));
                cell.Colspan = 4;
                cell.HorizontalAlignment = 2;
                cell.PaddingBottom = 5f;
                cell.PaddingLeft = 5f;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(result.ToString(), bold));
                cell.PaddingBottom = 5f;
                cell.PaddingLeft = 5f;
                table.AddCell(cell);

                //grand total
                grandResult += result;
                cell = new PdfPCell(new Phrase("Grand total: "));
                cell.Colspan = 4;
                cell.HorizontalAlignment = 2;
                cell.PaddingBottom = 5f;
                cell.PaddingLeft = 5f;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(grandResult.ToString(), bold));
                cell.PaddingBottom = 5f;
                cell.PaddingLeft = 5f;
                table.AddCell(cell);

                DC.Add(table);
                DC.Close();
            }

            Console.WriteLine("2. PDF was created!");
        }
    }
}
