using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Works_Library.Store_Home_Work_10
{
    public class ProductsService : IProductsService
    {
        private static ProductsService singeltonService = null;
        private readonly List<StoreCategory> _categories;
        private readonly List<StoreProduct> _products;

        private ProductsService()
        {
            _categories = new List<StoreCategory>();
            _products = new List<StoreProduct>();
        }

        public static IProductsService GetInstance()
        {
            if (singeltonService == null)
            {
                singeltonService = new ProductsService();
                return singeltonService;
            }
            else
            {
                return singeltonService;
            }
        }

        public void AddNewCategory(string categoryName, int categoryParentId)
        {
            StoreCategory newCategory = new StoreCategory(categoryName, categoryParentId);
            _categories.Add(newCategory);
        }

        public void AddNewProduct(string name, decimal price, bool isinstock, int categoryId)
        {
            StoreProduct newProduct = new StoreProduct(categoryId, name, price, isinstock);
            _products.Add(newProduct);
        }

        public void AddNewProducts(StoreProduct[] products)
        {
            for (int i = 0; i < products.Length; i++)
            {
                _products.Add(products[i]);
            }
        } 

        public void RemoveProduct(string productId)
        {
            for(int i = 0; i < _products.Count; i++)
            {
                if (_products[i].Id == productId)
                        _products.RemoveAt(i);
            }
        } 

        public void UpdateProduct(string productId, StoreProduct newProductInfo)
        {
            for (int i = 0; i < _products.Count; i++)
            {
                if (_products[i].Id == productId)
                {
                    _products[i] = newProductInfo;
                }
            }
        }

        public List<StoreCategory> GetAllTopLevelCategories()
        {
            List<StoreCategory> topLevelCategories = new List<StoreCategory>();

            for (int i = 0; i < _categories.Count; i++)
            {
                if (_categories[i].ParentCatogoryId == 0)
                {
                    topLevelCategories.Add(_categories[i]);
                }
            }

            return topLevelCategories;
        }

        public List<StoreCategory> GetSubCategories(int parentCategoryID)
        {
            List<StoreCategory> subCategories = new List<StoreCategory>();

            for (int i = 0; i < _categories.Count; i++)
            {
                if (_categories[i].ParentCatogoryId == parentCategoryID)
                {
                    subCategories.Add(_categories[i]);
                }
            }

            return subCategories;
        }

        public List<StoreProduct> GetProductsByCategory(int categoryId)
        {
            List<StoreProduct> productsCategory = new List<StoreProduct>();

            for (int i = 0; i < _products.Count; i++)
            {
                if (_products[i].StoreCategoryId == categoryId)
                {
                    productsCategory.Add(_products[i]);
                }
            }

            return productsCategory;
        }

        public List<StoreProduct> GetAllProductsByPrice(int lowPrice, int highPrice)
        {
            List<StoreProduct> productsByPrice = new List<StoreProduct>();

            _products.Sort(ComparisonByPrice);

            for (int i = 0; i < _products.Count; i++)
            {
                if (_products[i].Price >= lowPrice && _products[i].Price <= highPrice)
                {
                    productsByPrice.Add(_products[i]);
                }
            }

            return productsByPrice;
        } 

        public List<StoreProduct> GetAllProductsByPrice(int inCategoryId, int lowPrice, int highPrice)
        {
            List<StoreProduct> productsByPrice = new List<StoreProduct>();

            _products.Sort(ComparisonByPrice);

            for (int i = 0; i < _products.Count; i++)
            {
                if (_products[i].StoreCategoryId == inCategoryId && _products[i].Price >= lowPrice && _products[i].Price <= highPrice)
                {
                    productsByPrice.Add(_products[i]);
                }
            }

            return productsByPrice;
        } 

        public List<StoreProduct> GetAllProducts() // Sort By Price
        {
            _products.Sort(ComparisonByPrice);
            return _products;
        }

        // Helper function for sorting.
        public int ComparisonByPrice(object obj1, object obj2)
        {
            if (obj1 is StoreProduct product1 && obj2 is StoreProduct product2)
            {
                if (product1.Price == product2.Price)
                    return 0;
                else if (product1.Price > product2.Price)
                    return 1;
                else
                    return -1;
            }
            return 1;
        }

        public StoreProduct FindProductByName(string productName)
        {
            StoreProduct productByName = null;

            for (int i = 0; i < _products.Count; i++)
            {
                if (_products[i].Name == productName)
                    productByName = _products[i];
            }

            return productByName;
        }

        public StoreCategory FindCategoryByName(string categoryName)
        {
            StoreCategory categorytByName = null;

            for (int i = 0; i < _categories.Count; i++)
            {
                if (_categories[i].Name == categoryName)
                    categorytByName = _categories[i];
            }

            return categorytByName;
        } // I added

        /*public StoreCategory FindCategoryById(int categoryId)
        {
            StoreCategory categorytById = null;

            for (int i = 0; i < _categories.Count; i++)
            {
                if (_categories[i].Id == categoryId)
                    categorytById = _categories[i];
            }

            return categorytById;

        } // + I added
        */

        public void RemoveAllProductsOfCategory(int categoryId)
        {
            for (int i = 0; i < _products.Count; i++)
            {
                if (_products[i].StoreCategoryId == categoryId)
                {
                    _products.RemoveAt(i);
                    i--;
                }
            }
        }

        public void SaveAllProductsByCategory(int categoryId) //file name will be the according to the value of of the Category Name property 
        {
            string categoryName = "";

            for (int i = 0; i < _categories.Count; i++)
            {
                if (_categories[i].Id == categoryId)
                    categoryName = _categories[i].Name;
            }

            for (int i = 0; i < _products.Count; i++)
            {
                if (_products[i].StoreCategoryId == categoryId)
                    File.AppendAllText(categoryName, _products[i].ToString());
            }
        }

        public void PrintAllData() // + I added
        {
            Console.WriteLine("\nCATEGORIES AS LIST:");
            Console.WriteLine("ID  NAME           PARENT_CATEGORY");

            for (int i = 0; i < _categories.Count; i++)
            {
                int numOfSpaces = 15 - _categories[i].Name.Length;
                Console.WriteLine($" {_categories[i].Id}  {_categories[i].Name}{new string(' ', numOfSpaces)}" +
                                  $"{_categories[i].ParentCatogoryId}");
            }


            Console.WriteLine("\nCATEGORIES AS TREE:");
            List<StoreCategory> topLevelCategories = GetAllTopLevelCategories();

            for (int i = 0; i < topLevelCategories.Count; i++)
            {
                Console.WriteLine(topLevelCategories[i].Name);
                List<StoreCategory> subCategories = GetSubCategories(topLevelCategories[i].Id);

                for (int j = 0; j < subCategories.Count; j++)
                {
                    Console.WriteLine("  -" + subCategories[j].Name);
                }

            }

            Console.WriteLine("\nPRODUCTS AS LIST:");
            Console.WriteLine($"ID     NAME   {new string(' ', 40)}   PRICE     ISINSTOCK     STORECATEGORYID ");

            for (int i = 0; i < _products.Count; i++)
            {
                int spacesName = 7 - _products[i].Id.Length;
                int spacesPrice = 50 - _products[i].Name.Length;
                int Isinstock = 10 - _products[i].Price.ToString().Length;
                Console.WriteLine(_products[i].Id + new string(' ', spacesName > 0 ? spacesName : 5) + _products[i].Name + 
                                  new string(' ', spacesPrice > 0 ? spacesPrice : 5) + _products[i].Price +
                                  new string(' ', Isinstock > 0 ? Isinstock : 5) + _products[i].Isinstock +
                                  new string(' ', _products[i].Isinstock ? 10 : 9) + _products[i].StoreCategoryId);
            }

        }

        /*public int ComparisonByCategoryId(object obj1, object obj2)
        {
            if (obj1 is StoreProduct product1 && obj2 is StoreProduct product2)
            {
                if (product1.StoreCategoryId == product2.StoreCategoryId)
                    return 0;
                else if (product1.StoreCategoryId > product2.StoreCategoryId)
                    return 1;
                else
                    return -1;
            }
            return 1;
        }
        */

    }
}
