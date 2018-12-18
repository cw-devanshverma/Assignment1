// This assignment is one by Devansh Verma
/*
 * There are 4 pages namely front page, product listing page, product editing page and product addition page. 
 * Bootstrap, Materiaize and basic HTML and CSS is used.
 * 
 */

//Import Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment;
using Assignment.Models;
using Assignment.DAL.Read;
using Assignment.BAL;
using System.Text;
using Assignment.DAL.Update;
using System.Web.Routing;
using Assignment.DAL.Create;

namespace Assignment.Controllers
{    
    public class HomeController : Controller
    {
        //Global list of products
        private static List<Product> products = new List<Product>(){
            new Product("Activa", "Honda", "Scooty", 10, 50000),
            new Product("Activa2", "Maruiti", "Scooty", 8, 50300),
            new Product("Activa3", "BMW", "Scooty", 5, 53000)
        };

        public List<Product> AccessProductListVariable()
        {
            return products;
        }

        //Homepage
        public ActionResult Index()
        {            
            return View();
        }

        //All Products Listing
        public ActionResult List()
        {
            ViewBag.result = (StringBuilder)TempData["result"];
            ViewBag.Items = (new ReadClass() ).getAllProducts();
            return View();
        }

        //Delete a specific product
        public ActionResult DeleteL()
        {

            return RedirectToAction("List");
        }

        //Editing a list via GET method with a specific 'pid'       
        [HttpGet]
        public ActionResult EditProduct(int pid){
            ViewBag.result = (StringBuilder)TempData["result"];
            ViewBag.prod = (new ReadClass() ).getProductById(pid);
            return View();
        }

        //validation and inserting item in the list
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditProduct(int pid, string name, string description, string brand, int quantity, int price)
        {            
            Product prodDetails = (new ReadClass()).getProductById(pid);
            StringBuilder status = new StringBuilder();

            if (prodDetails != null){
                // Validate
                status = (new ValidationClass()).EditFormValidation(name, description, brand, quantity, price);

                // After Successful validation                 
                if (status.ToString() == "Record Edited Successfully!"){
                    // Update the list
                    (new EditClass()).editProduct(pid, name, description, brand, quantity, price);

                    TempData["result"] = status;
                    return RedirectToAction("List");

                }else{
                    // There are validation errors
                    TempData["result"] = status;
                    //return View("EditProduct");
                    return RedirectToAction("EditProduct", new { pid = pid });
                }
            }else {
                //ITempDataProvider has been taken care of in the views
                //status.Append("no Product found with this id");
                //ViewBag.result = status;
                //@ViewBag.Items = prodDetails;

                return View();
            }            
        }

        //Add item to the list via GET method 
        [HttpGet]
        public ActionResult AddItem()
        {
            return View();
        }

        //Add item after validation to the list
        [HttpPost]
        public ActionResult AddItem(string name, string description, string brand, int quantity, int price)
        {
            StringBuilder status = new StringBuilder();

            //Validate
            status = (new ValidationClass()).EditFormValidation(name, description, brand, quantity, price);

            // After Successful validation                 
            if (status.ToString() == "Record Edited Successfully!")
            {
                // Add the  item to list
                (new CreateClass()).addProduct(name, description, brand, quantity, price);

                ViewBag.result = "Record Inserted Successfully!";

                return RedirectToAction("List");
            }else{
                ViewBag.name = name;
                ViewBag.description = description;
                ViewBag.brand = brand;
                ViewBag.quantity = quantity;
                ViewBag.price = price;

                ViewBag.error = true;
                return View();    
            }
            
        }

    }
}