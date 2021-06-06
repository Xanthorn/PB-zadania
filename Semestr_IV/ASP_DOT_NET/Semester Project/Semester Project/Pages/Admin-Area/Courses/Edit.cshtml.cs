using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Semester_Project.Models;

namespace Semester_Project.Pages.Admin_Area.Courses
{
    public class EditModel : PageModel
    {
        private readonly EFDataAccessLibrary.DataAccess.CoursesContext _context;

        public EditModel(EFDataAccessLibrary.DataAccess.CoursesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FormCourse FormCourse { get; set; }
        public SelectList TagOptions { get; set; }
        public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course = await _context.Courses.FirstOrDefaultAsync(m => m.Id == id);

            FormCourse = new()
            {
                Name = Course.Name,
                Price = Course.Price,
                Id = Course.Id,
                Description = Course.Description
            };
            TagOptions = new SelectList(_context.Tags.Where(x => x.Name != "Default"), nameof(Tag.Id), nameof(Tag.Name));

            if (Course == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Course = await _context.Courses.Include(x => x.Tags).FirstOrDefaultAsync(m => m.Id == FormCourse.Id);

            Course.Name = FormCourse.Name;
            Course.Price = FormCourse.Price;
            Course.Description = FormCourse.Description;

            Course.Tags.Clear();

            Course.Tags.Add(_context.Tags.Where(x => x.Name == "Default").First());
            foreach(int id in FormCourse.SelectedTags)
            {
                var tag = _context.Tags.Find(id);
                Course.Tags.Add(tag);
            }

            _context.Attach(Course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(Course.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Index");
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
    }
}
