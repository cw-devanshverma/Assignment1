using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment.Models;
using Assignment.Controllers;
using Assignment.DAL.Read;

namespace Assignment.DAL.Update
{
    public class EditClass
    {
        public void editProduct(int pid, string name, string description, string brand, int quantity, int price){
            Product productDetails = (new ReadClass()).getProductById(pid);

            productDetails.Name = name;
            productDetails.Description = description;
            productDetails.Brand = brand;
            productDetails.Quantity = quantity;
            productDetails.Price = price;

        }



    }
}