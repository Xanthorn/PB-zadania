using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DOT_NET_PS_02.Models
{
    public class Person
    {
        [Display(Name = "Imię")]
        [Required(ErrorMessage = "Pole 'Imię' jest obowiązkowe")]
        public string Name;
        [Display(Name = "E-mail")]
        public string Email;
        [Display(Name = "Wzrost")]
        [Required(ErrorMessage = "Pole 'Wzrost' jest obowiązkowe")]
        public double Height;
        [Display(Name = "Waga")]
        [Required(ErrorMessage = "Pole 'Waga' jest obowiązkowe")]
        public double Weight;
        [Display(Name = "Wiek")]
        public double Age;
        [Display(Name = "Płeć")]
        [Required(ErrorMessage = "Pole 'Płeć' jest obowiązkowe")]
        public Gender Gender;
    }
}
