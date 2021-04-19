using System;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PS7.DAL;
using PS7.Models;

namespace PS7.Pages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Product product { get; set; }
        public void OnGet(int id, [FromServices] IProductDB XmlDB)
        {
            product = XmlDB.Get(id);
            product.id = id;
        }
        public IActionResult OnPost(int id, [FromServices] IProductDB XmlDB)
        {
            int choice = Int32.Parse(Request.Form["button"]);
            if (choice == 1)
            {
                product.id = id;
                XmlDB.Update(product);
            }
            return RedirectToPage("Index");
        }
    }
}

