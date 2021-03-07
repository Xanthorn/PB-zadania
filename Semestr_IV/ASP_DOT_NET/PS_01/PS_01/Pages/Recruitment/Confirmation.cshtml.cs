using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PS_01.Models;

namespace PS_01.Pages
{
    public class RecruitmentConfirmationModel : PageModel
    {
        [BindProperty]
        public Candidate Candidate { get; set; }
        [TempData]
        public string JsonCandidate { get; set; }
        public void OnGet()
        {
        }
    }
}
