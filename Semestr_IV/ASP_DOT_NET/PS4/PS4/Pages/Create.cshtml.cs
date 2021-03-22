using Microsoft.AspNetCore.Mvc;
using PS4.Models;
namespace PS4
{
    public class CreateModel : MyPageModel
    {
        [BindProperty]
        public Product newProduct { get; set; }
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
            productDB.Create(newProduct);
            SaveDB();
            return RedirectToPage("List");
        }
    }
}