using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment.Models;
using Assignment.Controllers;

namespace Assignment.DAL.Read
{
    public class ReadClass
    {
        
        public IEnumerable<Product> getAllProducts(){            
            //IEnumerable<Product> var = (new HomeController() ).AccessProductListVariable();
            return (new HomeController()).AccessProductListVariable();        
        }       

        public Product getProductById(int productId){
            IEnumerable<Product> allProducts = (new HomeController()).AccessProductListVariable();

            foreach (Product p in allProducts)
            {
                if (p.Id == productId)
                {
                    return p;
                }
            }

            return null;
        }


        
    }
}