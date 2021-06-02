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
    public class DeleteTagModel : PageModel
    {
        private readonly CoursesContext _db;
        private readonly ILogger<AddTagModel> _logger;

        [BindProperty]
        public Tag Tag { get; set; }
        [BindProperty]
        public int Id { get; set; }

        public DeleteTagModel(ILogger<AddTagModel> logger, CoursesContext db)
        {
            _db = db;
            _logger = logger;
        }
        public void OnGet(int id)
        {
            Tag = _db.Tags.Find(id);
        }
        public IActionResult OnPost()
        {
            int choice = Int32.Parse(Request.Form["IsToBeDeleted"]);
            if(choice == 1)
            {
                _db.Tags.Remove(Tag);
                _db.SaveChanges();
            }
            return RedirectToPage("/Admin-Area/Tags/List");
        }
    }
}
