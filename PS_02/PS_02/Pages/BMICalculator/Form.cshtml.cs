using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOT_NET_PS_02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace PS_02.Pages.BMICalculator
{
    public class FormModel : PageModel
    {
        [BindProperty]
        public Person Person { get; set; }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            return RedirectToPagePreserveMethod("/BMICalculator/Result", null, null, null);
        }
    }
}
