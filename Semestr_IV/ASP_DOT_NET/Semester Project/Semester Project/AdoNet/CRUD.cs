using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Semester_Project.AdoNet
{
    public static class CRUD
    {
        public static string GetPasswordHash(string username, IConfiguration configuration)
        {
            string passwordHash = null;
            string connectionString = configuration.GetConnectionString("AdoNet");

            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("GetHash", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", username);
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    passwordHash = reader["PasswordHash"].ToString();
                }
                cn.Close();
                return passwordHash;
            }
        }
    }
}
