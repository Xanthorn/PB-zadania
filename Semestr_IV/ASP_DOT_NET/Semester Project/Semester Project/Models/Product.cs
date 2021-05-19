using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Semester_Project.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        [MaxLength(50, ErrorMessage = "Maksymalna długość nazwy nie powinna być dłuższa niż 50 znaków")]
        [MinLength(5, ErrorMessage = "Minimalna długość nazwy nie powinna być krótsza niż 5 znaków")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        [MaxLength(500, ErrorMessage = "Maksymalna długość opisu nie powinna być dłuższa niż 50 znaków")]
        [MinLength(20, ErrorMessage = "Minimalna długość opisu nie powinna być krótsza niż 20 znaków")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        [Range(0, 999999, ErrorMessage = "Cena powinna być z zakresu od 0 do 999 999zł")]
        public decimal Price { get; set; }
        public List<Category> Categories { get; set; }
    }
}
