using Microsoft.Extensions.Configuration;
using PS7.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PS7.DAL
{
    public class ProductSqlDB : IProductDB
    {
        private string ConnectionString;
        public ProductSqlDB(IConfiguration _configuration)
        {
            ConnectionString = _configuration.GetValue<string>("AppSettings:SqlDB");
        }
        public List<Product> List()
        {
            List<Product> products = new List<Product>();

            SqlConnection con = new(ConnectionString);
            string sql = "SELECT * FROM Products";
            SqlCommand cmd = new(sql, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Product product = new Product();
                product.id = Int32.Parse(reader["Id"].ToString());
                product.name = reader["Name"].ToString();
                product.price = Decimal.Parse(reader["Price"].ToString());
                products.Add(product);
            }
            reader.Close(); con.Close();
            return products;
        }
        public void Add(Product product)
        {
            String query = "INSERT INTO dbo.Products (Name, Price) VALUES (@Name, @Price);";

            using (SqlConnection cn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@Name", product.name);
                cmd.Parameters.AddWithValue("@Price", product.price);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
        public void Delete(int id)
        {
            String query = "DELETE FROM dbo.Products WHERE Id = @id;";

            using (SqlConnection cn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
        public Product Get(int id)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            string sql = "SELECT * FROM Products WHERE Id = @id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Product product = new Product();
            while (reader.Read())
            {
                product.id = Int32.Parse(reader["Id"].ToString());
                product.name = reader["Name"].ToString();
                product.price = Decimal.Parse(reader["Price"].ToString());
            }
            reader.Close(); con.Close();
            return product;
        }
        public void Update(Product product)
        {
            String query = "UPDATE dbo.Products SET Name = @Name, Price = @Price WHERE Id = @Id;";

            using (SqlConnection cn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@Name", product.name);
                cmd.Parameters.AddWithValue("@Price", product.price);
                cmd.Parameters.AddWithValue("@Id", product.id);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
    }
}
