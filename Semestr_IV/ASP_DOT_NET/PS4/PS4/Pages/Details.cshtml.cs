using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PS4.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace PS4
{
    public class DetailsModel : MyPageModel
    {
        [BindProperty]
        public Product ProductDetails { get; set; }
        [BindProperty]
        public int Id { get; set; }
        public void OnGet(int id)
        {
            LoadDB();
            Id = id;
            ProductDetails = productDB.GetElement(id);
        }
        public IActionResult OnPost()
        {
            LoadDB();
            ProductDetails = productDB.GetElement(Id);
            if (Request.Form["AddToCart"] == "Dodaj do koszyka")
            {
                string shoppingCart = Request.Cookies["ShoppingCart"];
                List<Product> productList = new List<Product>();
                var cookieOptions = new CookieOptions { Expires = DateTime.Now.AddDays(1) };
                if (shoppingCart == null)
                {
                    productList.Add(ProductDetails);
                    string cookie = JsonSerializer.Serialize(productList);
                    Response.Cookies.Append("ShoppingCart", cookie, cookieOptions);
                }
                else
                {
                    productList = JsonSerializer.Deserialize<List<Product>>(shoppingCart);
                    productList.Add(ProductDetails);
                    string cookie = JsonSerializer.Serialize(productList);
                    Response.Cookies.Append("ShoppingCart", cookie, cookieOptions);
                }
            }
            return RedirectToPage("List");
        }
    }
}
