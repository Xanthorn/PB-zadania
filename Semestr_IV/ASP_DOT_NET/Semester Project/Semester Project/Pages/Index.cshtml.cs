using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Semester_Project.Models;

namespace Semester_Project.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<Product> Products { get; set; }
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Products = new();
            Category category = new()
            {
                Id = 1,
                Name = "Produkty mleczne/nabiał"
            };
            List<Category> categories = new();
            categories.Add(category);
            Product product = new()
            {
                Id = 0,
                Name = "masło łaciate",
                Description = "Masło łaciate prosto od krowy. Polecam gorąco krowa znosząca złote jaja",
                Price = Convert.ToDecimal(3.45),
                Categories = categories
            };
            Products.Add(product);
        }
    }
}
