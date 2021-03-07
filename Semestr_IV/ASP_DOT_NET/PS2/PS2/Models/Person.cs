using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PS2.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        [RegularExpression(@"^[A-ZŁŻ]{1}[a-z]+$", ErrorMessage = "Imię może składać się jedynie z liter i powinno zaczynać się z wielkiej litery")]
        [MaxLength(15, ErrorMessage = "Imię jest za długie, ogranicz się do 15 znaków")]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Wprowadź adres e-mail w odpowiednim formacie")]
        public string Email { get; set;}
        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        [Range(0, 250.99)]
        public double? Height { get; set; }
        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        [Range(0, 250.99)]
        public double? Weight { get; set; }
        [Range(1, 120, ErrorMessage = "Wiek musi być z przedziału 1-120")]
        public int? Age { get; set; }
        public Gender Gender { get; set; }
    }
}
