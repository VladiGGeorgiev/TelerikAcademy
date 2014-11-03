using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Model
{
    public class MongoExpense
    {
        public BsonObjectId Id { get; set; }

        public DateTime Month { get; set; }

        public decimal Value { get; set; }

        public int VendorId { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Value: {1}, Month: {2}, VendorId: {3}", this.Id, this.Value, this.Month, this.VendorId);
        }
    }
}
