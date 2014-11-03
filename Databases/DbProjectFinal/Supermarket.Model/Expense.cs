using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Supermarket.Model
{
    public class Expense
    {
        public int Id { get; set; }
        
        public DateTime Month { get; set; }

        public decimal Value { get; set; }

        public int VendorId { get; set; }

        public Vendor Vendor { get; set; }
    }
}
