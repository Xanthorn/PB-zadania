using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PS5.Models
{
    public class Product
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Wprowadź Id")]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Wprowadź nazwę")]
        [DataType(DataType.Text)]
        [MaxLength(50, ErrorMessage = "Nazwa nie może być dłuższa niż 50 znaków")]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Wprowadź cenę")]
        [DataType(DataType.Currency)]
        [Range(0, 99999999, ErrorMessage = "Wprowadź cenę z zakresu 0 - 99 999 999")]
        [RegularExpression(@"^([0-9]{1},[0-9]{1,2})|([1-9]{1}\d*,\d{1,2})|([1-9]\d*)$")]
        public double Price { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Wprowadź opis")]
        [DataType(DataType.Text)]
        [MaxLength(500, ErrorMessage = "Opis nie może być dłuższy niż 500 znaków")]
        public string Description { get; set; }

    }
}
