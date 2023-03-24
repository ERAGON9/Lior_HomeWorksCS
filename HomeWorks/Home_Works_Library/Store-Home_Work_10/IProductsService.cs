using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Works_Library.Store_Home_Work_10
{
    public interface IProductsService
    {
        public void AddNewCategory(string categoryName, int categoryParentId);
        public void AddNewProduct(string name, decimal price, bool isinstock, int categoryId);
        public void AddNewProducts(StoreProduct[] products);
        public void RemoveProduct(string productId);
        public void UpdateProduct(string productId, StoreProduct newProductInfo);
        public List<StoreCategory> GetAllTopLevelCategories();
        public  List<StoreCategory> GetSubCategories(int parentCategoryID);
        public List<StoreProduct> GetProductsByCategory(int categoryId);
        public List<StoreProduct> GetAllProductsByPrice(int lowPrice, int highPrice);
        public List<StoreProduct> GetAllProductsByPrice(int inCategoryId, int lowPrice, int highPrice);
        public List<StoreProduct> GetAllProducts(); //Sort By Price
        public StoreProduct FindProductByName(string productName);
        public StoreCategory FindCategoryByName(string categoryName); // + I added
        public void RemoveAllProductsOfCategory(int categoryId);
        public void SaveAllProductsByCategory(int categoryId); //file name will be the according to the value of of the Category Name property 
        public void PrintAllData(); // + I added
    }
}
