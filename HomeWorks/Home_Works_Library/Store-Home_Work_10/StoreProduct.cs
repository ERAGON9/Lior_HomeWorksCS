﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Home_Works_Library.Store_Home_Work_10
{
    public class StoreProduct
    {
        private static int counter = 1;
        private readonly string prefixId;

        public string Id { get;}
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Isinstock { get; set; }
        public int StoreCategoryId { get; set; }


        public StoreProduct(string prefixId, int categoryId, string name, decimal price, bool isInStock)
        {
            Id = $"{prefixId}#{counter}";
            counter++;
            this.prefixId = prefixId;
            Name = name;
            Price = price;
            Isinstock = isInStock;
            StoreCategoryId = categoryId;
        }

        public StoreProduct(int categoryId, string name, decimal price, bool isInStock)
        {
            Id = $"{categoryId}#{counter}";
            counter++;
            Name = name;
            Price = price;
            Isinstock = isInStock;
            StoreCategoryId = categoryId;
        }

        public StoreProduct() //Empty Ctor
        {
            Id = $"{0}#{counter}";
            counter++;
            Name = "";
            Price = 0;
            Isinstock = true;
            StoreCategoryId = 0;
        }


        public static StoreProduct CopyProductWithNewId(StoreProduct exsistingProduct) //Id Generated by the same as in constractor
        {
            string[] seperateStrings = exsistingProduct.Id.Split('#');
            string newId= $"{seperateStrings[0]}#{counter}";
            counter++;
            StoreProduct copiedProduct = new StoreProduct(newId, exsistingProduct.StoreCategoryId, exsistingProduct.Name, exsistingProduct.Price, exsistingProduct.Isinstock);
            return copiedProduct;
        }

        public override string ToString() //return object info properties data
        {
            return $"Id = {Id} , Name = {Name} , Price = {Price} , Isinstock = {Isinstock} , StoreCategoryId = {StoreCategoryId} ";
        }

    }
}
