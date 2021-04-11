using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace PS5.Models
{
    public class ShoppingCartCookie
    {
        public static string AddProduct(Product product, string currentShoppingCart)
        {
            List<Product> shoppingCart = new();
            if(currentShoppingCart != "" && currentShoppingCart != null)
                shoppingCart = JsonSerializer.Deserialize<List<Product>>(currentShoppingCart);
            shoppingCart.Add(product);
            shoppingCart = shoppingCart.OrderBy(p => p.Id).ToList();
            string newShoppingCart = JsonSerializer.Serialize(shoppingCart);
            return newShoppingCart;
        }
        public static List<Product> GetProducts(string currentShoppingCart)
        {
            if (currentShoppingCart == "" || currentShoppingCart == null)
                return new List<Product>();
            else
            {
                List<Product> shoppingCart = JsonSerializer.Deserialize<List<Product>>(currentShoppingCart);
                return shoppingCart;
            }
        }
        public static string RemoveProduct(string currentShoppingCart, Product productToRemove)
        {
            if (currentShoppingCart == "" || currentShoppingCart == null)
                return currentShoppingCart;
            else
            {
                List<Product> shoppingCart = JsonSerializer.Deserialize<List<Product>>(currentShoppingCart);
                for(int i = shoppingCart.Count - 1; i > -1; i--)
                {
                    if(shoppingCart[i].Id == productToRemove.Id)
                    {
                        shoppingCart.RemoveAt(i);
                    }
                }
                string newShoppingCart = JsonSerializer.Serialize(shoppingCart);
                return newShoppingCart;
            }
        }
        public static string UpdateProduct(string currentShoppingCart, Product upToDateProduct)
        {
            if (currentShoppingCart == "" || currentShoppingCart == null)
                return currentShoppingCart;
            else
            {
                List<Product> shoppingCart = JsonSerializer.Deserialize<List<Product>>(currentShoppingCart);
                for (int i = shoppingCart.Count - 1; i > -1; i--)
                {
                    if (shoppingCart[i].Id == upToDateProduct.Id)
                    {
                        shoppingCart[i] = upToDateProduct;
                    }
                }
                string newShoppingCart = JsonSerializer.Serialize(shoppingCart);
                return newShoppingCart;
            }
        }
    }
}
