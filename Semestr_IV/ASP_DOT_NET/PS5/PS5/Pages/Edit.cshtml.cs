using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using PS5.Models;

namespace PS5.Pages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Product OldProduct { get; set; }
        [BindProperty]
        public string ProductDescription { get; set; }
        [BindProperty]
        public Product NewProduct { get; set; }
        private readonly IConfiguration _configuration;
        public EditModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet(int id)
        {
            OldProduct = ProductsDB.GetProduct(id, _configuration);
            ProductDescription = OldProduct.Description;
        }
        public IActionResult OnPost()
        {
            NewProduct.Description = ProductDescription;
            NewProduct.Id = OldProduct.Id;
            int click = Int32.Parse(Request.Form["click"]);
            if (click == 1)
            {
                ProductsDB.UpdateProduct(NewProduct, _configuration);
                string currentShoppingCart = Request.Cookies["ShoppingCart"];
                if(currentShoppingCart != null && currentShoppingCart != "")
                {
                    string newShoppingCart = ShoppingCartCookie.UpdateProduct(currentShoppingCart, NewProduct);
                    var cookieOptions = new CookieOptions { Expires = DateTime.Now.AddDays(1) };
                    Response.Cookies.Append("ShoppingCart", newShoppingCart, cookieOptions);
                }
                return RedirectToPage("/Index");
            }
            else
            {
                return RedirectToPage("/Index");
            }

        }
    }
}
