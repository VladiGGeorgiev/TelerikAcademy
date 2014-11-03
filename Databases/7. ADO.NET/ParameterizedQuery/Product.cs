using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParameterizedQuery
{
    class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int? SupplierId { get; set; }

        public int? CategoryId { get; set; }

        public string QuantityPerUnit { get; set; }

        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }

        public short? ReorderLevel { get; set; }

        public bool Discontinued { get; set; }

        public override string ToString()
        {
            string text = String.Format(
                "Product(Id={0}, Name={1}, Discontinued={2}, SupplierId={3}, CategoryId={4}, QuantityPerUnit={5}, UnitPrice={6}, UnitsInStock={7}, UnitsOnOrder={8}, ReorderLevel={9}",
                this.ProductId, this.ProductName, this.Discontinued, this.SupplierId, this.CategoryId, this.QuantityPerUnit, this.UnitPrice,
                this.UnitsInStock, this.UnitsOnOrder, this.ReorderLevel);
            return text;
        }
    }
}
