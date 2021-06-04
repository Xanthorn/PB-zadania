﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;

namespace Semester_Project.Pages.Admin_Area.Courses
{
    public class IndexModel : PageModel
    {
        private readonly EFDataAccessLibrary.DataAccess.CoursesContext _context;

        public IndexModel(EFDataAccessLibrary.DataAccess.CoursesContext context)
        {
            _context = context;
        }

        public IList<Course> Course { get;set; }

        public async Task OnGetAsync()
        {
            Course = await _context.Courses.ToListAsync();
        }
    }
}
