using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace PS5.Models
{
    public class ProductsDB
    {
        public static List<Product> GetProducts(List<Product> products, IConfiguration configuration)
        {
            products = new List<Product>();

            string ConnectionString = configuration.GetConnectionString("PS5DB");

            SqlConnection con = new(ConnectionString);
            string sql = "SELECT * FROM Products";
            SqlCommand cmd = new(sql, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            products = new List<Product>();
            while (reader.Read())
            {
                Product product = new()
                {
                    Id = Int32.Parse(reader["Id"].ToString()),
                    Name = reader["Name"].ToString(),
                    Price = Double.Parse(reader["Price"].ToString())
                };
                products.Add(product);
            }
            reader.Close(); con.Close();
            return products;
        }
        public static void AddProduct(Product product, IConfiguration configuration)
        {
            String query = @$"INSERT INTO dbo.Products (Name, Price, Description) VALUES (@Name, @Price, @Description);";
            string connectionString = configuration.GetConnectionString("PS5DB");

            using(SqlConnection cn = new(connectionString))
            using (SqlCommand cmd = new(query, cn))
            {
                cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = product.Name;
                cmd.Parameters.Add("@Price", SqlDbType.Decimal, 18).Value = product.Price;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar, 500).Value = product.Description;
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
        public static void DeleteProduct(int id, IConfiguration configuration)
        {
            String query = @$"DELETE FROM dbo.Products WHERE Id = @id";
            string connectionString = configuration.GetConnectionString("PS5DB");

            using (SqlConnection cn = new(connectionString))
            using (SqlCommand cmd = new(query, cn))
            {
                cmd.Parameters.Add("@Id", SqlDbType.VarChar, 50).Value = id;
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
    }
}
