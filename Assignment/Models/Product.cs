using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class Product
    {
        static int counter = 0;
        public int Id;
        public string Name;
        public string Brand;
        public string Description;
        public int Quantity;
        public int Price;

        //Constructor
        public Product(string ProdName, string ProdBrand, string ProdDescription, int ProdQuantity, int ProdPrice)
        {
            this.Id = ++counter;
            this.Name = ProdName;
            this.Brand = ProdBrand;
            this.Description = ProdDescription;
            this.Quantity = ProdQuantity;
            this.Price = ProdPrice;
        }

    }
}