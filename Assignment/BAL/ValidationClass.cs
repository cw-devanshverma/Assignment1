using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Assignment.BAL
{
    public class ValidationClass
    {
        // Edit Form Validation
        public StringBuilder EditFormValidation(string name, string description, string brand, int quantity, int price){
            StringBuilder err = new StringBuilder(); 

            if (quantity < 0){
                err.Append("quantity should be greater than 0\n");
            }
            if (price < 0){
                err.Append("price should be greater than 0\n");
            }
            if (quantity > 0 && price >0 ){
                err.Append("Record Edited Successfully!");
            }

            return err;
        }


    }
}