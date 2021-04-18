using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using PS6.Models;

namespace PS6.Pages
{
    public class CategoriesModel : PageModel
    {
        [BindProperty]
        public List<Category> Categories { get; set; }
        private readonly IConfiguration _configuration;
        public CategoriesModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet()
        {
            Categories = CategoriesDB.GetCategories(_configuration);
        }
    }
}
