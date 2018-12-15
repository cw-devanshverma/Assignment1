//Import Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment;

namespace Assignment.Controllers
{

    //class for all the products present
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
        public Product(string n, string b, string d, int q, int p)
        {
            this.Id = ++counter;
            this.Name = n;
            this.Brand = b;
            this.Description = d;
            this.Quantity = q;
            this.Price = p;
        }
    };

    public class HomeController : Controller
    {
        //static int var = 1;

        //Global list of products
        public static List<Product> products = new List<Product>(){
            new Product("Activa", "Honda", "Scooty", 10, 50000),
            new Product("Activa2", "Maruiti", "Scooty", 8, 50300),
            new Product("Activa3", "BMW", "Scooty", 5, 53000)
        };

        //public void once()
        //{
        //    if (var == 1)
        //    {
        //        Product p1 = new Product("Activa", "Honda", "Scooty", 10, 50000);
        //        Product p2 = new Product("Activa2", "Maruiti", "Scooty", 8, 50300);
        //        Product p3 = new Product("Activa3", "BMW", "Scooty", 5, 53000);

        //        products.Add(p1);
        //        products.Add(p2);
        //        products.Add(p3);

        //        var++;
        //    }

        //    Console.Write(products.Count);
        //}           


        //Homepage
        public ActionResult Index()
        {
            //once();

            //Console.Write(products.Count);

            //products.Add(p1);
            //products.Add(p2);
            //products.Add(p3);

            return View();
        }


        //All Products Listing
        public ActionResult List()
        {

            //Console.Write(products.Count);

            //Product p1 = new Product("Activa", "Honda", "Scooty", 10, 50000);
            //Product p2 = new Product("Activa2", "Maruiti", "Scooty", 8, 50300);
            //Product p3 = new Product("Activa3", "BMW", "Scooty", 5, 53000);

            //products.Add(p1);
            //products.Add(p2);
            //products.Add(p3);            

            //@ViewBag.Items = products;
            @ViewBag.Items = products;

            return View();
        }

        //Delete a specific product
        public ActionResult DeleteL()
        {

            return RedirectToAction("List");
        }

        //Editing a list via GET method with a specific 'pid'       
        [HttpGet]
        public ActionResult Edit(int pid)
        {
            foreach (Product p in products)
            {
                if (p.Id == pid)
                {
                    @ViewBag.prod = p;
                }
            }

            return View();
        }

        //validation and inserting item in the list
        [HttpPost]
        public ActionResult Edit(int pid, string name, string description, string brand, int quantity, int price)
        {
            foreach (Product p in products)
            {
                if (p.Id == pid)
                {
                    p.Name = name;
                    p.Description = description;
                    p.Brand = brand;
                    p.Quantity = quantity;
                    p.Price = price;
                }
            }

            return RedirectToAction("List");
        }

        //Add item to the list via GET method 
        [HttpGet]
        public ActionResult AddItems()
        {

            return View();
        }

        //Add item after validation to the list
        [HttpPost]
        public ActionResult AddItems(string name, string description, string brand, int quantity, int price)
        {
            //Validate
            if (quantity < 0 || price < 0)
            {
                @ViewBag.Restore1 = name;
                @ViewBag.Restore2 = description;
                @ViewBag.Restore3 = brand;
                @ViewBag.Restore4 = quantity;
                @ViewBag.Restore5 = price;

                @ViewBag.error = true;
                return View();
            }


            Product p = new Product(name, brand, description, quantity, price);
            products.Add(p);

            return RedirectToAction("List");
        }

    }
}