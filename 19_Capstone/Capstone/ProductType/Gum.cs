using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.ProductType
{
    public class Gum : Products
    {
        //public const string DisplayMessage = "Chew Chew, Yum!";
        override public string DisplayMessage { get { return "Chew Chew, Yum!"; } }

        public Gum(string productName, decimal productPrice, string productSlot, string productType)
                    : base(productName, productPrice, productSlot, productType)
        {


        }

        //method to remove stock

        //need to print to log 

        //remove balance



    }
}
