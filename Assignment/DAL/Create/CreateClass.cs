using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment.Models;
using Assignment.Controllers;

namespace Assignment.DAL.Create
{
    public class CreateClass
    {
        public Product addProduct(string ProdName, string ProdBrand, string ProdDescription, int ProdQuantity, int ProdPrice)
        {
            Product newProduct = new Product(ProdName, ProdBrand, ProdDescription, ProdQuantity, ProdPrice);

            if(newProduct != null){
                (new HomeController() ).AccessProductListVariable().Add(newProduct);
            }

            return newProduct;
        }

    }
}