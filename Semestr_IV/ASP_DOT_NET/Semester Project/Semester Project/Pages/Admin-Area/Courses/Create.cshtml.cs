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
            TagOptions = new SelectList(Tags, nameof(Tag.Id), nameof(Tag.Name));
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; }

        [BindProperty]
        public int[] TagsSelected { get; set; }

        public List<Tag> Tags { get; set; }

        public MultiSelectList TagOptions { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Course.Tags.Add(_context.Tags.Where(t => t.Name == "Domyślny").ToList().First());
            foreach(int id in TagsSelected)
            {
                var tag = _context.Tags.Find(id);
                Course.Tags.Add(tag);
                tag.Courses.Add(Course);
            }

            _context.Courses.Add(Course);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
