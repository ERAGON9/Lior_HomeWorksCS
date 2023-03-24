using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Works_Library.Store_Home_Work_10
{
    public class StoreCategory
    {
        private static int counter = 1;
        public int Id { get;}
        public string Name { get; set; }
        public int ParentCatogoryId { get; set; }

        public StoreCategory(string name, int parentcategoryId)
        {
            Id = counter;
            counter++;
            Name = name;
            ParentCatogoryId = parentcategoryId;
        }

        public StoreCategory(string name) // set parentcategoryId = 0
        {
            Id = counter;
            counter++;
            Name = name;
            ParentCatogoryId = 0;
        }

        public StoreCategory()  //Default Ctor
        {
            Id = counter;
            counter++;
            Name = "";
            ParentCatogoryId = 0;
        }

        public override string ToString() //return Category properties Data
        {
            return $"Id = {Id} , Name = {Name} , ParentCatogoryId = {ParentCatogoryId} ";
        }

    }
}
