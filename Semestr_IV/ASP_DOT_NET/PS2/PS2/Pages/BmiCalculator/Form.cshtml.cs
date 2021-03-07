using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PS2.Models;

namespace PS2.Pages.BmiCalculator
{
    public class FormModel : PageModel
    {
        [BindProperty]
        public Person person { get; set; }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            return RedirectPreserveMethod("/BmiCalculator/Result");
        }
    }
}
