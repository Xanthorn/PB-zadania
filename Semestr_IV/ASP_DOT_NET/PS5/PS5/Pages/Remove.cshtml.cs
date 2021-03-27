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
    public class RemoveModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; }
        private readonly IConfiguration _configuration;
        public RemoveModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet(int id)
        {
            Product = ProductsDB.GetProduct(id, _configuration);
        }
        public IActionResult OnPost()
        {
            int click = Int32.Parse(Request.Form["click"]);
            if (click == 1)
            {
                ProductsDB.RemoveProduct(Product.Id, _configuration);
                return RedirectToPage("/Index");
            }
            else
            {
                return RedirectToPage("/Index");
            }
        }
    }
}
