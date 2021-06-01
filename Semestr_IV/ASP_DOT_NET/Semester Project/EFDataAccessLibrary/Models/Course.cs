using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [Range(0, 20000)]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }

        [Required]
        [MinLength(30)]
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
