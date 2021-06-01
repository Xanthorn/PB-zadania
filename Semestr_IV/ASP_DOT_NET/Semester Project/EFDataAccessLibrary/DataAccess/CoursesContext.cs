using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.DataAccess
{
    public class CoursesContext : DbContext
    {
        public CoursesContext(DbContextOptions options) : base(options) { }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
