using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Assignment
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //list<product> products = new list<product>();
            //product p1 = new product("activa", "honda", "scooty", 10, 50000);
            //product p2 = new product("activa2", "maruiti", "scooty", 8, 50300);
            //product p3 = new product("activa3", "bmw", "scooty", 5, 53000);

            //products.Add(p1);
            //products.Add(p2);
            //products.Add(p3);       

        }
    }  
        
    //public class Product{
    //    static int counter = 0;
    //    public int Id;
    //    public string Name;
    //    public string Brand;
    //    public string Description;
    //    public int Quantity;
    //    public int Price;
                
    //    public Product(string n, string b, string d, int q, int p){
    //        this.Id = ++counter;
    //        this.Name = n;
    //        this.Brand = b;
    //        this.Description = d;
    //        this.Quantity = q;
    //        this.Price = p;
    //    }
    //}



}
