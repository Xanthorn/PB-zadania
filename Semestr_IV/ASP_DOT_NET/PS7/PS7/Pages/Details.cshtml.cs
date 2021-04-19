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
    public class DetailsModel : PageModel
    {
        [BindProperty]
        public Product product { get; set; }
        public void OnGet(int id, [FromServices] IProductDB XmlDB)
        {
            product = XmlDB.Get(id);
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("/Index");
        }
    }
}
