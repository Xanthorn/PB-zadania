using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Semester_Project.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        [MaxLength(50, ErrorMessage = "Maksymalna długość nazwy nie powinna być dłuższa niż 50 znaków")]
        [MinLength(5, ErrorMessage = "Minimalna długość nazwy nie powinna być krótsza niż 5 znaków")]
        public string Name { get; set; }
    }
}
