using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PS7.DAL;
using PS7.Models;

namespace PS7.Pages
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public Product product { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost([FromServices] IProductDB XmlDB)
        {
            int choice = Int32.Parse(Request.Form["button"]);
            if (choice == 1)
            {
                XmlDB.Add(product);
            }
            return RedirectToPage("Index");
        }
    }
}
