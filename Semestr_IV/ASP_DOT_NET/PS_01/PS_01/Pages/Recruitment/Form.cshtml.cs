using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PS_01.Models;

namespace PS_01.Pages.Recruitment
{
    public class FormModel : PageModel
    {
        [BindProperty]
        public Candidate Candidate { get; set; }
        [BindProperty]
        public bool Cs { get; set; }
        [BindProperty]
        public bool Cpp { get; set; }
        [BindProperty]
        public bool Java { get; set; }
        [TempData]
        public string JsonCandidate { get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPost()        
        {
            if (Cpp == true)
                Candidate.ProgrammingLanguages.Add(ProgrammingLanguage.Cpp);

            if (Cs == true)
                Candidate.ProgrammingLanguages.Add(ProgrammingLanguage.Cs);

            if (Java == true)
                Candidate.ProgrammingLanguages.Add(ProgrammingLanguage.Java);

            if (Candidate.Age >= 18)
            {
                JsonCandidate = JsonConvert.SerializeObject(Candidate, Formatting.Indented);
                return RedirectToPage("/Recruitment/Confirmation");
            }
            else
                return RedirectToPage("/Recruitment/Denial");
        }
    }
}
