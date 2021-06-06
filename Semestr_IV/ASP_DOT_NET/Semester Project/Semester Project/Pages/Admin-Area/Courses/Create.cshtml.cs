using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Semester_Project.Models;

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
            TagOptions = new SelectList(_context.Tags.Where(x => x.Name != "Default"), nameof(Tag.Id), nameof(Tag.Name));
            return Page();
        }

        [BindProperty]
        public FormCourse Course { get; set; }
        public SelectList TagOptions { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Course course = new()
            {
                Id = Course.Id,
                Name = Course.Name,
                Price = Course.Price,
                Description = Course.Description
            };

            course.Tags.Add(_context.Tags.Where(x => x.Name == "Default").First());
            foreach(int id in Course.SelectedTags)
            {
                var tag = _context.Tags.Find(id);
                course.Tags.Add(tag);
            }

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
