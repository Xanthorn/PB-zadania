using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PS4.Models
{
    public class Product
    {
        [Display(Name = "Id")] 
        public int id { get; set; }
        [Display(Name = "Nazwa")] 
        public string name { get; set; }
        [Display(Name = "Cena")] 
        public decimal price { get; set; }
        public static List<Product> GetProducts() 
        { 
            Product pilka = new Product { id = 1, name = "Piłka nożna", price = 25.30M }; 
            Product narty = new Product { id = 2, name = "Narty", price = 150.39M }; 
            Product rakieta = new Product { id = 3,name = "Rakieta ", price = 111.10M}; 
            return new List<Product> { pilka, narty, rakieta }; }
        }
}
