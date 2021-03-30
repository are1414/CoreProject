using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // CategoryTest();
            //ProductTest();

            ProductManager productManager = new ProductManager(new EfProductDal());
            var result = productManager.GetProdutDetails();
            if (result.Success == true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + " " + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine("Hata Mesajı");

            }


            //ProductManager productManager = new ProductManager(new EfProductDal());
            //foreach (var product in productManager.GetAll())
            //{
            //    Console.WriteLine(product.ProductName);
            //}
            //foreach (var product in productManager.GetAllByCategory(2))
            //{
            //    Console.WriteLine(product.ProductName);
            //}


        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            var result = productManager.GetByUnitPrice(50, 100);

            if (result.Success == true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + product.UnitPrice);
                }
            }
            else
            {
                Console.WriteLine("Hata Mesajı");

            }

        }
    }
}
