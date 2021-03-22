using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PS4.Models;
using System.Text.Json;

namespace PS4.DAL
{
    public class ProductDB
    {
        private List<Product> products;
        public void Load(string jsonProducts)
        {
            if (jsonProducts == null)
            {
                products = Product.GetProducts();
            }
            else
            {
                // products = JsonConvert.DeserializeObject<List<Product>>(jsonProducts);
                products = JsonSerializer.Deserialize<List<Product>>(jsonProducts);
            }
        }
        private int GetNextId()
        {
            int lastID = products[products.Count - 1].id;
            int newID = ++lastID;
            return newID;
        }
        public void Create(Product p)
        {
            p.id = GetNextId();
            products.Add(p);
        }
        public string Save()
        {

            //return JsonConvert.SerializeObject(products);
            return JsonSerializer.Serialize(products);
        }
        public void Edit(int id, Product modifiedProduct)
        {
            products[id - 1] = modifiedProduct;
        }
        public List<Product> List()
        {
            return products;
        }
        public Product GetElement(int id)
        {
            return (products[id - 1]);
        }
        public void DeleteElement(int id)
        {
            products.RemoveAt(id - 1);
            AssignNewId(id);
        }
        private void AssignNewId(int id)
        {
            for(int i = id - 1; i < products.Count - id + 1; i++) 
            {
                products[i].id = i + 1;
            }
        }
    }
}

