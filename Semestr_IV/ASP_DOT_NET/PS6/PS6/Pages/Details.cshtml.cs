using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using PS6.Models;

namespace PS6.Pages
{
    public class DetailsModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; }
        private readonly IConfiguration _configuration;
        [BindProperty]
        public Category Category { get; set; }
        public DetailsModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet(int id)
        {
            Product = ProductsDB.GetProduct(id, _configuration);
            Category = CategoriesDB.GetCategory(Product.IdCategory, _configuration);
        }
        public IActionResult OnPost()
        {
            int click = Int32.Parse(Request.Form["click"]);
            if (click == 1)
            {
                Product = ProductsDB.GetProduct(Product.Id, _configuration);
                string currentShoppingCart = Request.Cookies["ShoppingCart"];
                string newShoppingCart = ProductsCookies.AddProduct(Product, currentShoppingCart);
                var cookieOptions = new CookieOptions { Expires = DateTime.Now.AddDays(1) };
                Response.Cookies.Append("ShoppingCart", newShoppingCart, cookieOptions);
            }
            return RedirectToPage("/Index");
        }
    }
}
