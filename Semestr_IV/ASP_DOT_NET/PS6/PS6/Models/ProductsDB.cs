using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace PS6.Models
{
    public class ProductsDB
    {
        public static List<Product> GetProducts(List<Product> products, IConfiguration configuration)
        {
            products = new List<Product>();

            string ConnectionString = configuration.GetConnectionString("PS5DB");

            SqlConnection con = new(ConnectionString);
            SqlCommand cmd = new("GetProducts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Product product = new Product();
                product.Id = Int32.Parse(reader["Id"].ToString());
                product.Name = reader["Name"].ToString();
                product.Price = Double.Parse(reader["Price"].ToString());
                product.Description = reader["Description"].ToString();
                products.Add(product);
            }
            reader.Close(); con.Close();
            return products;
        }
        public static void AddProduct(Product product, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("PS5DB");

            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("AddProduct", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
        public static void RemoveProduct(int id, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("PS5DB");

            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("DeleteProduct", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
        public static Product GetProduct(int id, IConfiguration configuration)
        {
            string ConnectionString = configuration.GetConnectionString("PS5DB");

            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("GetProduct", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Product product = new Product();
            while (reader.Read())
            {
                product.Id = Int32.Parse(reader["Id"].ToString());
                product.Name = reader["Name"].ToString();
                product.Price = Double.Parse(reader["Price"].ToString());
                product.Description = reader["Description"].ToString();
            }
            reader.Close(); con.Close();
            return product;
        }
        public static void UpdateProduct(Product product, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("PS5DB");

            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("UpdateProduct", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@Id", product.Id);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
    }
}
