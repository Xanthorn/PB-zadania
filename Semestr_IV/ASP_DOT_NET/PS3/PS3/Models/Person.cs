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
        [Display(Name = "Imię")]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Wprowadź adres e-mail w odpowiednim formacie")]
        [Display(Name = "Adres e-mail")]
        public string Email { get; set;}
        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        [Range(0, 250, ErrorMessage = "Wprowadź wzrost z zakresu od 0 do 250")]
        [Display(Name = "Wzrost")]
        public double Height { get; set; }
        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        [Range(0, 250, ErrorMessage = "Wprowadź wagę z zakresu od 0 do 250")]
        [Display(Name = "Waga")]
        public double Weight { get; set; }
        [Range(1, 120, ErrorMessage = "Wiek musi być z przedziału 1-120")]
        [Display(Name = "Wiek")]
        public int? Age { get; set; }
        [Display(Name = "Płeć")]
        public Gender Gender { get; set; }
    }
}
