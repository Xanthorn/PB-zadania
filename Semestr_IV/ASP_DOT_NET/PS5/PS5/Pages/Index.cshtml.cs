using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace PS5.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IConfiguration Configuration { get; }
        public string lblInfoText;
        public IndexModel(IConfiguration configuration, ILogger<IndexModel> logger)
        {
            _logger = logger;
            Configuration = configuration;
        }

        public void OnGet()
        {
            string Products = Configuration.GetConnectionString("PS5DB");

            SqlConnection con = new SqlConnection(Products);
            string sql = "SELECT * FROM Products";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            StringBuilder htmlStr = new StringBuilder("");
            while (reader.Read())
            {
                htmlStr.Append("<li>");
                htmlStr.Append(reader["Id"].ToString() + " ");
                htmlStr.Append(reader.GetString(1) + " ");
                htmlStr.Append(String.Format("{0:0.00}",
               Decimal.Parse(reader["Price"].ToString())));
                htmlStr.Append("</li>");
            }
            reader.Close(); con.Close();
            lblInfoText = htmlStr.ToString();
        }
    }
}
