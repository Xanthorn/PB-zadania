using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        public IActionResult OnPost()
        {
            int click = Int32.Parse(Request.Form["click"]);
            if(click == 1)
            {
                Product = ProductsDB.GetProduct(Product.Id, _configuration);
                string currentShoppingCart = Request.Cookies["ShoppingCart"];
                string newShoppingCart = ShoppingCartCookie.AddProduct(Product, currentShoppingCart);
                var cookieOptions = new CookieOptions { Expires = DateTime.Now.AddDays(1) };
                Response.Cookies.Append("ShoppingCart", newShoppingCart, cookieOptions);
            }
            return RedirectToPage("/Index");
        }
    }
}
