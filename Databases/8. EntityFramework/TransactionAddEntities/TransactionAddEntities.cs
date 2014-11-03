using System.Transactions;
using NorthwindEntity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionAddEntities
{
    class TransactionAddEntities
    {
        static void Main(string[] args)
        {
            Order order = new Order
            {
                CustomerID = "BLONP",
                OrderDate = DateTime.Now,
                ShipCountry = "Bulgaria",
                ShipName = "Last ship"
            };
            
            Order_Detail orderDetail = new Order_Detail
            {
                ProductID = 5,
                Quantity = 10,
                Discount = 0
            };

            AddOrder(order, orderDetail);
        }
  
        private static void AddOrder(Order order, Order_Detail orderDetail)
        {
            using (NorthwndEntities context = new NorthwndEntities())
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    context.Orders.Add(order);
                    context.SaveChanges();
                    orderDetail.OrderID = context.Orders.Where(x => x.ShipName == "Last ship").First().OrderID;
                    context.Order_Details.Add(orderDetail);
                    context.SaveChanges();

                    transaction.Complete();
                }
            }
        }
    }
}
