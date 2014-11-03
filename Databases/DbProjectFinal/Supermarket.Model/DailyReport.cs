using Supermarket.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Supermarket.Model
{
    public class DailyReport
    {
        public DailyReport()
        {

        }

        public int Id { get; set; }

        public string MarketName { get; set; }

        public DateTime Date { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public DailyReport(string marketName, int productId, int quantity, decimal price, DateTime date)
        {
            this.MarketName = marketName;
            this.ProductId = productId;
            this.Quantity = quantity;
            this.Price = price;
            this.Date = date;
        }

        public static DailyReport TryParse(string marketName, string productIdStr, string quantityStr, string priceStr, string dateStr)
        {
            DailyReport newDaySale = null;
            int id = 0;
            int quantity = 0;
            decimal price = 0m;
            DateTime date = DateTime.Now;
            bool dateParsed = DateTime.TryParseExact(dateStr, "dd-MMM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            bool idParsed = int.TryParse(productIdStr, out id);
            bool quantityParsed = int.TryParse(quantityStr, out quantity);
            bool priceParsed = decimal.TryParse(priceStr, out price);

            if (idParsed && quantityParsed && priceParsed && dateParsed)
            {
                newDaySale = new DailyReport(marketName, id, quantity, price, date);
            }

            return newDaySale;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1} {2} {3} {4}", this.MarketName, this.ProductId, this.Quantity, this.Price, this.Date);
        }
    }
}
