using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Category> categories = new List<Category>
            {
                new Category{CategoryID = 1, CategoryName = "Bilgisayar"},
                new Category{CategoryID = 2, CategoryName = "Telefon"},

            };

            List<Product> products = new List<Product>
            {
                new Product{ProductID = 1, CategoryID = 1, ProductName = "Acer Laptop", QuantityPerUnit = "32 GB RAM", UnitPrice = 10000, UnitsInStock = 5},
                new Product{ProductID = 2, CategoryID = 1, ProductName = "Asus Laptop", QuantityPerUnit = "16 GB RAM", UnitPrice = 8000, UnitsInStock = 3},
                new Product{ProductID = 3, CategoryID = 1, ProductName = "HP Laptop", QuantityPerUnit = "8 GB RAM", UnitPrice = 6000, UnitsInStock = 2 },
                new Product{ProductID = 4, CategoryID = 2, ProductName = "Samsung Telefon", QuantityPerUnit = "4 GB RAM", UnitPrice = 5000, UnitsInStock = 15},
                new Product{ProductID = 5, CategoryID = 2, ProductName = "Apple Telefon", QuantityPerUnit = "4 GB RAM", UnitPrice = 8000, UnitsInStock = 0},
            };

            Console.WriteLine("Algoritmik ------------------");

            foreach (var product in products)
            {
                if (product.UnitPrice > 5000 && product.UnitsInStock > 3)
                {
                    Console.WriteLine(product.ProductName);
                }

            }

            Console.WriteLine("Linq ------------------");


            var result = products.Where(p => p.UnitPrice > 5000 && p.UnitsInStock > 3);

            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }


            GetProducts(products);
        }

        static List<Product> GetProducts(List<Product> products)
        {
            List<Product> filteredProducts = new List<Product>();
            foreach (var product in products)
            {
                if (product.UnitPrice > 5000 && product.UnitsInStock > 3)
                {
                    filteredProducts.Add(product);
                }

            }
            return filteredProducts;
        }

        static List<Product> GetProductsLinq(List<Product> products)
        {
            return products.Where(p => p.UnitPrice > 5000 && p.UnitsInStock > 3).ToList();
        }

    }
    class Product
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }

    class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
