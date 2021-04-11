using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PS5.Models;

namespace PS5.Pages
{
    public class ShoppingCartModel : PageModel
    {
        [BindProperty]
        public List<Product> ShoppingCart { get; set; }
        public void OnGet()
        {
            string currentShoppingCart = Request.Cookies["ShoppingCart"];
            ShoppingCart = ShoppingCartCookie.GetProducts(currentShoppingCart);
        }
        public IActionResult OnPost()
        {
            string emptyShoppingCart = "";
            var cookieOptions = new CookieOptions { Expires = DateTime.Now.AddDays(1) };
            Response.Cookies.Append("ShoppingCart", emptyShoppingCart, cookieOptions);
            return RedirectToPage();
        }
    }
}
