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
    public class ListModel : PageModel
    {
        [BindProperty]
        public List<Tag> Tags { get; set; }
        private readonly ILogger<ListModel> _logger;
        private readonly CoursesContext _db;

        public ListModel(ILogger<ListModel> logger, CoursesContext db)
        {
            _logger = logger;
            _db = db;
        }
        public void OnGet()
        {
            Tags = _db.Tags.Where(tag => tag.Name != "Domyślny").ToList();
        }
    }
}
