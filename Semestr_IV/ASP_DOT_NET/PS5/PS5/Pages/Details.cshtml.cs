using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using PS5.Models;

namespace PS5.Pages.Shared
{
    public class DetailsModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; }
        private readonly IConfiguration _configuration;
        public DetailsModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet(int id)
        {
            Product = ProductsDB.GetProduct(id, _configuration);
        }
    }
}
