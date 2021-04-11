using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PS6.Models;
using Microsoft.Extensions.Configuration;

namespace PS6.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<Product> Products { get; set; }
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;
        public IndexModel(IConfiguration configuration, ILogger<IndexModel> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public void OnGet()
        {
            Products = ProductsDB.GetProducts(Products, _configuration);
        }
    }
}
