using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Semester_Project.Pages.Admin_Area.Tags
{
    public class AddTagModel : PageModel
    {
        private readonly CoursesContext _db;
        private readonly ILogger<AddTagModel> _logger;

        [BindProperty]
        public Tag Tag { get; set; }

        public AddTagModel(ILogger<AddTagModel> logger, CoursesContext db)
        {
            _db = db;
            _logger = logger;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                _db.Tags.Add(Tag);
                _db.SaveChanges();
                return RedirectToPage("/Admin-Area/Tags/List");
            }
        }
    }
}
