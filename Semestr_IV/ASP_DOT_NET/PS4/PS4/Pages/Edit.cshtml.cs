using Microsoft.AspNetCore.Mvc;
using PS4.Models;
using System;

namespace PS4
{
    public class EditModel : MyPageModel
    {
        [BindProperty]
        public Product EditProduct { get; set; }
        [BindProperty]
        public int id { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            LoadDB();
            EditProduct.id = id;
            productDB.Edit(id, EditProduct);
            SaveDB();
            return RedirectToPage("List");
        }
    }
}
