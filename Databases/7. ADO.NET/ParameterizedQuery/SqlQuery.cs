using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParameterizedQuery
{
    class SqlQuery
    {
        static SqlConnection connection;

        static void Main(string[] args)
        {
            SqlQuery query = new SqlQuery();
            
            try
            {
                query.ConnectToDatabase(Settings.Default.DBConnectionString);
                Product product = new Product();
                product.ProductName = "PeshoFood";
                product.QuantityPerUnit = "12 - 12 oz jars";
                product.Discontinued = true;
                product.SupplierId = 2;
                product.CategoryId = 1;

                int insertedProductId = query.InsertProduct(product);

                Console.WriteLine("Inserted new Product with id: {0}", insertedProductId);
            }
            finally
            {
                query.DisconnectFromDatabase();
            }
        }

        private void ConnectToDatabase(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        private void DisconnectFromDatabase()
        {
            if (connection != null)
            {
                connection.Close();
            }
        }

        private int InsertProduct(Product product)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Products " +
            "(ProductName, SupplierId, CategoryId, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) " +
            "VALUES (@ProductName, @SupplierId, @CategoryId, @QuantityPerUnit, @UnitPrice, @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued)", connection);

            command.Parameters.AddWithValue("@ProductName", product.ProductName);
            command.Parameters.AddWithValue("@QuantityPerUnit", product.QuantityPerUnit);
            command.Parameters.AddWithValue("@Discontinued", product.Discontinued);

            SqlParameter supplierId = new SqlParameter("@SupplierId", product.SupplierId);
            if (product.SupplierId == null)
            {
                supplierId.Value = DBNull.Value;
            }
            command.Parameters.Add(supplierId);

            SqlParameter categoryId = new SqlParameter("@CategoryId", product.CategoryId);
            if (product.CategoryId == null)
            {
                categoryId.Value = DBNull.Value;
            }
            command.Parameters.Add(categoryId);

            SqlParameter unitPrice = new SqlParameter("@UnitPrice", product.UnitPrice);
            if (product.UnitPrice == null)
            {
                unitPrice.Value = DBNull.Value;
            }
            command.Parameters.Add(unitPrice);
            
            SqlParameter unitsInStock = new SqlParameter("@UnitsInStock", product.UnitsInStock);
            if (product.UnitsInStock == null)
            {
                unitsInStock.Value = DBNull.Value;
            }
            command.Parameters.Add(unitsInStock);
            
            SqlParameter unitsOnOrder = new SqlParameter("@UnitsOnOrder", product.UnitsOnOrder);
            if (product.UnitsOnOrder == null)
            {
                unitsOnOrder.Value = DBNull.Value;
            }
            command.Parameters.Add(unitsOnOrder);
            
            SqlParameter reorderLevel = new SqlParameter("@ReorderLevel", product.ReorderLevel);
            if (product.ReorderLevel == null)
            {
                reorderLevel.Value = DBNull.Value;
            }
            command.Parameters.Add(reorderLevel);

            command.ExecuteNonQuery();

            SqlCommand selectIdentity = new SqlCommand("SELECT @@Identity", connection);
            int insertedProductId = (int)(decimal)selectIdentity.ExecuteScalar();
            return insertedProductId;
        }
    }
}