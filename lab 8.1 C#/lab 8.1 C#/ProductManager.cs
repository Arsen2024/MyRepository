using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_8._1_C_
{
    public class ProductManager
    {
        private List<(string Name, decimal Price, string Category, bool InStock)> products
           = new List<(string Name, decimal Price, string Category, bool InStock)>();

        public void AddProduct(string name, decimal price, string category, bool inStock)
        {
            products.Add((name, price, category, inStock));
        }

        public List<(string, decimal, string, bool)> GetAllProducts()
        {
            return products;
        }

        public (string, decimal, string, bool)? GetProduct(int index)
        {
            if (index >= 0 && index < products.Count)
                return products[index];
            return null;
        }

        public decimal GetAveragePrice()
        {
            if (products.Count == 0) return 0;
            return products.Average(p => p.Price);
        }

        public List<(string, decimal, string, bool)> GetSocialProducts()
        {
            decimal avg = GetAveragePrice();
            return products.Where(p => p.Price < avg).ToList();
        }
    }
}

