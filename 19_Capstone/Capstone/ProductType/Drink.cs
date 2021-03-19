using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.ProductType
{
    public class Drink : Products
    {
        //public const string DisplayMessage = "Glug Glug, Yum!";
        override public string DisplayMessage { get { return "Glug Glug, Yum!"; } }

        public Drink(string productName, decimal productPrice, string productSlot, string productType)
                    : base(productName, productPrice, productSlot, productType)
        {


        }

        //method to remove stock

        //need to print to log 

        //remove balance



    }
}
