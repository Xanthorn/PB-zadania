using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Semester_Project.Pages.Admin_Area.Courses
{
    public class IndexModel : PageModel
    {
        private readonly EFDataAccessLibrary.DataAccess.CoursesContext _context;

        public IndexModel(EFDataAccessLibrary.DataAccess.CoursesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int SelectedTag { get; set; }
        public IList<Course> Course { get;set; }
        public SelectList TagOptions { get; set; }

        public async Task OnGetAsync()
        {
            Course = await _context.Courses.ToListAsync();
            TagOptions = new SelectList (_context.Tags.ToList(), nameof(Tag.Id), nameof(Tag.Name));
            SelectedTag = 0;
        }

        public IActionResult OnPostFilters(int SelectedTag)
        {
            var tag = _context.Tags.Find(SelectedTag);

            Course = _context.Courses
                .Include(c => c.Tags)
                .Where(x => x.Tags.Any(y => y.Id == tag.Id))
                .ToList();

            TagOptions = new SelectList(_context.Tags.ToList(), nameof(Tag.Id), nameof(Tag.Name));
            SelectedTag = 0;

            return Page();
        }
    }
}
