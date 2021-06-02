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
    public class ModifyTagModel : PageModel
    {
        private readonly CoursesContext _db;
        private readonly ILogger<AddTagModel> _logger;

        [BindProperty]
        public Tag Tag { get; set; }
        [BindProperty]
        public int Id { get; set; }

        public ModifyTagModel(ILogger<AddTagModel> logger, CoursesContext db)
        {
            _db = db;
            _logger = logger;
        }
        public void OnGet(int id)
        {
            Id = id;
            Tag = _db.Tags.Find(Id);
        }
        public IActionResult OnPost()
        {
            Tag.Id = Id;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                var tag = _db.Tags.First(i => i.Id == Tag.Id);
                tag.Name = Tag.Name;
                _db.SaveChanges();
                return RedirectToPage("/Admin-Area/Tags/List");
            }
        }
    }
}
