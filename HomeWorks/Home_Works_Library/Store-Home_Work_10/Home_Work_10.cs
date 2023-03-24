using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Works_Library.Store_Home_Work_10
{
    public class Home_Work_10
    {
        public static void Run()
        {
            IProductsService productServise = ProductsService.GetInstance();

            productServise.AddNewCategory("Electronics", 0);
            productServise.AddNewCategory("Sports", 0);
            productServise.AddNewCategory("Books", 0);

            productServise.AddNewCategory("Computers", productServise.FindCategoryByName("Electronics").Id);
            productServise.AddNewCategory("Gadgets", productServise.FindCategoryByName("Electronics").Id);
            productServise.AddNewCategory("Balls", productServise.FindCategoryByName("Sports").Id);
            productServise.AddNewCategory("Ping Pong", productServise.FindCategoryByName("Sports").Id);
            productServise.AddNewCategory("Harry Potter", productServise.FindCategoryByName("Books").Id);
            productServise.AddNewCategory("Eragon", productServise.FindCategoryByName("Books").Id);

            productServise.AddNewProduct("Dell Vostro", 2500, true, productServise.FindCategoryByName("Computers").Id);
            productServise.AddNewProduct("Dell Inspirion", 3000, false, productServise.FindCategoryByName("Computers").Id);
            productServise.AddNewProduct("MacBook", 7000, true, productServise.FindCategoryByName("Computers").Id);

            productServise.AddNewProduct("Ipad Pro", 2000, true, productServise.FindCategoryByName("Gadgets").Id);
            productServise.AddNewProduct("Smart watch", 1500, false, productServise.FindCategoryByName("Gadgets").Id);
            productServise.AddNewProduct("Galaxi S20", 2150, true, productServise.FindCategoryByName("Gadgets").Id);

            productServise.AddNewProduct("Basketball", 250, true, productServise.FindCategoryByName("Balls").Id);
            productServise.AddNewProduct("Football", 100, true, productServise.FindCategoryByName("Balls").Id);
            productServise.AddNewProduct("Baseball", 10, true, productServise.FindCategoryByName("Balls").Id);

            productServise.AddNewProduct("Ping pong ball", 10, true, productServise.FindCategoryByName("Ping Pong").Id);
            productServise.AddNewProduct("Ping pong table", 3000, false, productServise.FindCategoryByName("Ping Pong").Id);
            productServise.AddNewProduct("Ping pong racket", 120, true, productServise.FindCategoryByName("Ping Pong").Id);

            productServise.AddNewProduct("Harry Potter and the philosoper stone", 100, true, productServise.FindCategoryByName("Harry Potter").Id);
            productServise.AddNewProduct("Harry Potter and the chamber of secrets", 100, true, productServise.FindCategoryByName("Harry Potter").Id);
            productServise.AddNewProduct("Harry Potter and the prisoner from askaban", 100, false, productServise.FindCategoryByName("Harry Potter").Id);

            productServise.AddNewProduct("Eragon1", 120, true, productServise.FindCategoryByName("Eragon").Id);
            productServise.AddNewProduct("Eldest", 120, true, productServise.FindCategoryByName("Eragon").Id);
            productServise.AddNewProduct("Brisingr", 120, true, productServise.FindCategoryByName("Eragon").Id);

            Console.WriteLine("All the hardcoded data is: ");
            productServise.PrintAllData();

            bool toExit = false;

            while (toExit == false)
            {
                Console.WriteLine();
                PrintMenu();
                int action = int.Parse(Console.ReadLine());

                switch (action)
                {
                    case 1:
                        AddNewCategoryInfo(productServise);
                        break;
                    case 2:
                        AddNewProductInfo(productServise);
                        break;
                    case 3:
                        AddNewProductsInfo(productServise);
                        break;
                    case 4:
                        RemoveProductInfo(productServise);
                        break;
                    case 5:
                        UpdateProducttInfo(productServise);
                        break;
                    case 6:
                        GetProductsByCategoryInfo(productServise);
                        break;
                    case 7:
                        GetAllProductsByPriceInfo(productServise);
                        break;
                    case 8:
                        GetAllProductsByIdAndPriceInfo(productServise);
                        break;
                    case 9:
                        GetAllProductsInfo(productServise);
                        break;
                    case 10:
                        FindProductByNameInfo(productServise);
                        break;
                    case 11:
                        RemoveAllProductsOfCategoryInfo(productServise);
                        break;
                    case 12:
                        SaveAllProductsByCategoryInfo(productServise);
                        break;
                    case 13:
                        productServise.PrintAllData();
                        break;
                    case 14:
                        toExit = true;
                        break;
                    default:
                        Console.WriteLine("You enter wrong input");
                        break;
                }
            }
        }

        public static void PrintMenu()
        {
            Console.WriteLine("Please choose action from the list:");
            Console.WriteLine("1 - Add new category");
            Console.WriteLine("2 - Add new product");
            Console.WriteLine("3 - Add new products");
            Console.WriteLine("4 - Remove product");
            Console.WriteLine("5 - Update product");
            Console.WriteLine("6 - Get products by category id");
            Console.WriteLine("7 - Get all products by price");
            Console.WriteLine("8 - Get all products by id and price");
            Console.WriteLine("9 - GetAllProducts");
            Console.WriteLine("10 - Find product by name");
            Console.WriteLine("11 - Remove all products of category");
            Console.WriteLine("12 - Save all products of category id to file");
            Console.WriteLine("13 - Print all data");
            Console.WriteLine("14 - Exit");
        }

        // 1
        public static void AddNewCategoryInfo(IProductsService productServise)
        {
            Console.WriteLine("please enter category name, and category parent id:");
            string categoryName = Console.ReadLine();
            int categoryParentId = int.Parse(Console.ReadLine());
            productServise.AddNewCategory(categoryName, categoryParentId);
            Console.WriteLine("Done");
        }
        // 2
        public static void AddNewProductInfo(IProductsService productServise)
        {
            Console.WriteLine("please enter product name, price, is in stock(true/false), category id:");
            string name = Console.ReadLine();
            decimal price = decimal.Parse(Console.ReadLine());
            bool isinstock = bool.Parse(Console.ReadLine());
            int categoryId = int.Parse(Console.ReadLine());
            productServise.AddNewProduct(name, price, isinstock, categoryId);
            Console.WriteLine("Done");
        }
        // 3
        public static void AddNewProductsInfo(IProductsService productServise)
        {
            Console.WriteLine("please enter amount of products to add:");
            int amount = int.Parse(Console.ReadLine());

            StoreProduct[] products = new StoreProduct[amount];

            for (int i = 0; i < amount; i++)
            {
                Console.WriteLine("please enter product name, price, is in stock(true/false), category id:");
                string name = Console.ReadLine();
                decimal price = decimal.Parse(Console.ReadLine());
                bool isinstock = bool.Parse(Console.ReadLine());
                int categoryId = int.Parse(Console.ReadLine());
                products[i] = new StoreProduct(categoryId, name, price, isinstock);
            }

            productServise.AddNewProducts(products);
            Console.WriteLine("Done");
        }
        // 4
        public static void RemoveProductInfo(IProductsService productServise)
        {
            Console.WriteLine("Please enter product id to remove");
            string productId = Console.ReadLine();

            productServise.RemoveProduct(productId);
            Console.WriteLine("Done");
        }
        // 5
        public static void UpdateProducttInfo(IProductsService productServise)
        {

            Console.WriteLine("Please enter product id to update");
            string productId = Console.ReadLine();

            Console.WriteLine("please enter product name, price, is in stock(true/false), category id:");
            string name = Console.ReadLine();
            decimal price = decimal.Parse(Console.ReadLine());
            bool isinstock = bool.Parse(Console.ReadLine());
            int categoryId = int.Parse(Console.ReadLine());
            StoreProduct newProductInfo = new StoreProduct(categoryId, name, price, isinstock);

            productServise.UpdateProduct(productId, newProductInfo);
            Console.WriteLine("Done");
        }
        // 6
        public static void GetProductsByCategoryInfo(IProductsService productServise)
        {
            Console.WriteLine("Please enter category id:");
            int categoryId = int.Parse(Console.ReadLine());

            List<StoreProduct> products = productServise.GetProductsByCategory(categoryId);

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine(products[i].ToString());
            }
        }
        // 7
        public static void GetAllProductsByPriceInfo(IProductsService productServise)
        {
            Console.WriteLine("Please enter lower price, higher price:");
            int lowerPrice = int.Parse(Console.ReadLine());
            int higherPrice = int.Parse(Console.ReadLine());

            List<StoreProduct> products = productServise.GetAllProductsByPrice(lowerPrice, higherPrice);

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine(products[i].ToString());
            }
        }
        // 8
        public static void GetAllProductsByIdAndPriceInfo(IProductsService productServise)
        {
            Console.WriteLine("Please enter category id, lower price, higher price:");
            int inCategoryId = int.Parse(Console.ReadLine());
            int lowerPrice = int.Parse(Console.ReadLine());
            int higherPrice = int.Parse(Console.ReadLine());

            List<StoreProduct> products = productServise.GetAllProductsByPrice(inCategoryId, lowerPrice, higherPrice);

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine(products[i].ToString());
            }
        }
        // 9
        public static void GetAllProductsInfo(IProductsService productServise)
        {
            List<StoreProduct> products = productServise.GetAllProducts();

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine(products[i].ToString());
            }
        }
        // 10
        public static void FindProductByNameInfo(IProductsService productServise)
        {
            Console.WriteLine("Please enter product name:");
            string productName = Console.ReadLine();

            StoreProduct product = productServise.FindProductByName(productName);
            Console.WriteLine(product.ToString());
        }
        // 11
        public static void RemoveAllProductsOfCategoryInfo(IProductsService productServise)
        {
            Console.WriteLine("Please enter category id:");
            int categoryId = int.Parse(Console.ReadLine());

            productServise.RemoveAllProductsOfCategory(categoryId);
            Console.WriteLine("Done");
        }
        // 12
        public static void SaveAllProductsByCategoryInfo(IProductsService productServise)
        {
            Console.WriteLine("Please enter category id:");
            int categoryId = int.Parse(Console.ReadLine());

            productServise.SaveAllProductsByCategory(categoryId);
            Console.WriteLine("Done");
        }

    }
}
