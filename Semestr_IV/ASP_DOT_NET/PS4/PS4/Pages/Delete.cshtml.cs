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
    public class DeleteModel : MyPageModel
    {
        [BindProperty]
        public Product DeleteProduct { get; set; }
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public string Choose { get; set; }
        public void OnGet(int id)
        {
            LoadDB();
            Id = id;
            DeleteProduct = productDB.GetElement(Id);
        }
        public IActionResult OnPost()
        {
            Choose = Request.Form["Choose"];
            if(Choose == "true")
            {
                string shoppingCart = Request.Cookies["ShoppingCart"];
                if(shoppingCart != null)
                {
                    List<Product> productList = JsonSerializer.Deserialize<List<Product>>(shoppingCart);
                    for (int i = 0; i < productList.Count; i++)
                    {
                        if (productList[i].id == Id)
                        {
                            productList.RemoveAt(i);
                        }
                    }
                    var cookieOptions = new CookieOptions { Expires = DateTime.Now.AddDays(1) };
                    string cookie = JsonSerializer.Serialize(productList);
                    Response.Cookies.Append("ShoppingCart", cookie, cookieOptions);
                }
                LoadDB();
                productDB.DeleteElement(Id);
                SaveDB();
                return RedirectToPage("List");
            }
            else
            {
                return RedirectToPage("List");
            }
        }
    }
}
