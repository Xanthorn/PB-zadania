using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using PS5.Models;

namespace PS5.Pages
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public Product NewProduct { get; set; }
        private readonly IConfiguration _configuration;
        public AddModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                ProductsDB.AddProduct(NewProduct, _configuration);
                return RedirectToPage("/Index");
            }
        }
    }
}
