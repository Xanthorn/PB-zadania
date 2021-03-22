using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PS4.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace PS4.Pages
{
    public class ShoppingCartModel : MyPageModel
    {
        [BindProperty]
        public List<Product> ProductListCookie { get; set; }
        public List<Product> productList;
        [BindProperty]
        public List<Product> ProductList { get; set; }
        public void OnGet()
        {
            LoadDB();
            productList = productDB.List();
            string cookieValue = Request.Cookies["ShoppingCart"];
            ProductList = new List<Product>();
            ProductListCookie = new List<Product>();
            if (cookieValue != null)
            {
                List<Product> ProductListCookie = JsonSerializer.Deserialize<List<Product>>(cookieValue);
                if (productDB.DbSize() > 0)
                {
                    for (int i = 0; i < ProductListCookie.Count; i++)
                    {
                        for (int j = 0; j < productList.Count; j++)
                        {
                            if(ProductListCookie[i].id == productList[j].id
                                && ProductListCookie[i].name == productList[j].name
                                && ProductListCookie[i].price == productList[j].price)
                            {
                                ProductList.Add(ProductListCookie[i]);
                            }
                        }
                    }
                    var cookieOptions = new CookieOptions { Expires = DateTime.Now.AddDays(1) };
                    string cookie = JsonSerializer.Serialize(ProductList);
                    Response.Cookies.Append("ShoppingCart", cookie, cookieOptions);
                }
            }
        }
        public IActionResult OnPost()
        {
            string emptyCookie = "emptyCookie";
            var cookieOptions = new CookieOptions { Expires = DateTime.Now };
            Response.Cookies.Append("ShoppingCart", emptyCookie, cookieOptions);
            return RedirectToPage("List");
        }
    }
}
