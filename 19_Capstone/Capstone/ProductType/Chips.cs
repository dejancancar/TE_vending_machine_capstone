using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.ProductType
{
    public class Chips : Products
    {
        //public const string DisplayMessage = "Crunch Crunch, Yum!";
        override public string DisplayMessage { get { return "Crunch Crunch, Yum!"; } }

        public Chips(string productName, decimal productPrice, string productSlot, string productType)
                    : base(productName, productPrice, productSlot, productType)
        {


        }

        //method to remove stock

        //need to print to log 

        //remove balance

    }
}
