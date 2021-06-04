using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;

namespace Semester_Project.Pages.Admin_Area.Courses
{
    public class CreateModel : PageModel
    {
        private readonly EFDataAccessLibrary.DataAccess.CoursesContext _context;

        public CreateModel(EFDataAccessLibrary.DataAccess.CoursesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Tags = _context.Tags.Where(t => t.Name != "Domyślny").ToList();
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; }

        [BindProperty]
        public List<Tag> Tags { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //Course.Tags.Add(_context.Tags.Where(t => t.Name = "Domyślny");
            _context.Courses.Add(Course);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
