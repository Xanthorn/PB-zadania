using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PS4.Models;

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
