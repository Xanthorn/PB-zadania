using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PS2.Models;
using Newtonsoft.Json;

namespace PS2.Pages.BmiCalculator
{
    public class FormModel : PageModel
    {
        [BindProperty]
        public Person person { get; set; }
        [TempData]
        public string tempPerson { get; set; }
        [TempData]
        public string tempHeightUnit { get; set; }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            tempHeightUnit = Request.Form["HeightUnit"];
            tempPerson = JsonConvert.SerializeObject(person);
            return RedirectToPage("/BmiCalculator/Result");
        }
    }
}
