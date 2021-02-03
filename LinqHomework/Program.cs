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
            //Test(products);

            //GetProducts(products);

            //AnyTest(products);

            //FindTest(products);

            //FindAllTest(products);

            //AscDescTest(products);

            //ClassicLinqTest(products);


            var result = from p in products       // productlarda olan her bir p'yi categorilerde olan her bir c'yi CategoryId'ye göre yanyana getir.
                         join c in categories
                         on p.CategoryID equals c.CategoryID
                         where p.UnitPrice > 5000          // UnitPrice'ı 5000 den büyük olanları getir.
                         orderby p.UnitPrice descending   // Fiyat azalarak olacak şekilde. 
                         select new ProductDto {ProductID = p.ProductID, CategoryName = c.CategoryName, ProductName = p.ProductName, UnitPrice = p.UnitPrice };

            foreach (var productDto in result)
            {
                Console.WriteLine("{0} --- {1}", productDto.ProductName, productDto.CategoryName);
            }



        }

        private static void ClassicLinqTest(List<Product> products)
        {
            var result = from p in products   // Linq'in 2. kullanımı. Product'dan her p için unitprice'ı 6000 den yüksek olanları yüksek fiyattan düşük fiyata göre, isimlerini de z den a ya sırala demek.
                         where p.UnitPrice > 5000
                         orderby p.UnitPrice descending, p.ProductName ascending
                         select new ProductDto { ProductID = p.ProductID, ProductName = p.ProductName, UnitPrice = p.UnitPrice };

            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void AscDescTest(List<Product> products)
        {
            //Single Line Query
            var result = products.Where(p => p.ProductName.Contains("top")).OrderByDescending(p => p.UnitPrice).ThenByDescending(p => p.ProductName); // İçerisinde "top" olan ürünleri getir. OrderBy yükselen, Descending azaland demek.

            // Üstte yazan kod; Listenin içinde "top" kelimesini içeren ürünleri
            // yüksekten aza şekilde z den a ya sırala demek.

            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void FindAllTest(List<Product> products)
        {
            var result = products.FindAll(p => p.ProductName.Contains("top")); // FindAll, listede şartlara uyan şeyleri getirir. Contains "içeriyorsa" demek.

            Console.WriteLine(result);
        }

        private static void FindTest(List<Product> products)
        {
            var result = products.Find(p => p.ProductID == 3); // Find, bir ürünün detaylarını göstermek için kullanılır.

            Console.WriteLine(result.ProductName);
        }

        private static void AnyTest(List<Product> products)
        {
            var result = products.Any(p => p.ProductName == "Acer Laptop"); // Any, bir listede bir eleman var mı, yok mu onu aratır. Sonuç olarak; True,False döndürür.

            Console.WriteLine(result);
        }

        private static void Test(List<Product> products)
        {
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

    class ProductDto
    {
        public int ProductID { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }

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
