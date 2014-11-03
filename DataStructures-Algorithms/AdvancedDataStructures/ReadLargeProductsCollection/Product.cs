using System;
namespace ReadLargeProductsCollection
{
    class Product : IComparable
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Product))
            {
                throw new ArgumentException("Argument is not a Product!");
            }

            Product otherProduct = obj as Product;
            if (this.Price > otherProduct.Price)
            {
                return 1;
            }
            else if (this.Price < otherProduct.Price)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1:f2}", this.Name, this.Price);    
        }
    }
}
