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
        public int Id { get; set; }
        public void OnGet(int id)
        {
            LoadDB();
            Id = id;
            EditProduct = productDB.GetElement(Id);
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            LoadDB();
            productDB.Edit(Id, EditProduct);
            SaveDB();
            return RedirectToPage("List");
        }
    }
}
