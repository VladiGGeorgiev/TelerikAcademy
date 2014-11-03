using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class Article : IComparable
    {
        public Article(string title, string barcode, string vendor, decimal price)
        {
            this.Title = title;
            this.Barcode = barcode;
            this.Vendor = vendor;
            this.Price = price;
        }
        
        public string Barcode { get; set; }

        public string Title { get; set; }

        public string Vendor { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return "Title: " + this.Title + ", Barcode: " + this.Barcode + ", Vendor: " + this.Vendor + ", Price: " + this.Price;
        }

        public int CompareTo(object obj)
        {
            return this.Price.CompareTo((obj as Article).Price);
        }
    }
}
