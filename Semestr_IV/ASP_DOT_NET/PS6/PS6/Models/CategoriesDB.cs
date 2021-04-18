using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PS6.Models
{
    public class CategoriesDB
    {
        public static List<Category> GetCategories(IConfiguration configuration)
        {
            List<Category> categories = new();

            string ConnectionString = configuration.GetConnectionString("PS5DB");

            SqlConnection con = new(ConnectionString);
            SqlCommand cmd = new("GetCategories", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Category category = new();
                category.Id = Int32.Parse(reader["Id"].ToString());
                category.ShortName = reader["ShortName"].ToString();
                category.LongName = reader["LongName"].ToString();
                categories.Add(category);
            }
            reader.Close(); con.Close();
            return categories;
        }
        public static Category GetCategory(int id, IConfiguration configuration)
        {
            Category category = new();

            string ConnectionString = configuration.GetConnectionString("PS5DB");

            SqlConnection con = new(ConnectionString);
            SqlCommand cmd = new("GetCategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                category.Id = Int32.Parse(reader["Id"].ToString());
                category.ShortName = reader["ShortName"].ToString();
                category.LongName = reader["LongName"].ToString();
            }
            reader.Close(); con.Close();
            return category;
        }
        public static void AddCategory(Category category, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("PS5DB");

            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("AddCategory", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ShortName", category.ShortName);
                cmd.Parameters.AddWithValue("@LongName", category.LongName);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
        public static void RemoveCategory(int id, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("PS5DB");

            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("RemoveCategory", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
        public static void UpdateProduct(Category category, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("PS5DB");

            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("UpdateCategory", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", category.Id);
                cmd.Parameters.AddWithValue("@ShortName", category.ShortName);
                cmd.Parameters.AddWithValue("@Description", category.LongName);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
    }
}
