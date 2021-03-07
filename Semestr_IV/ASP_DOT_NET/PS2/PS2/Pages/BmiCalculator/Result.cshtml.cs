using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PS2.Models;

namespace PS2.Pages.BmiCalculator
{
    public class ResultModel : PageModel
    {
        [BindProperty]
        Person person { get; set; }
        public void OnGet()
        {
        }
    }
}
