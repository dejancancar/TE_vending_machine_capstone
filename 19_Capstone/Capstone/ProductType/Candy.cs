using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.ProductType
{
    public class Candy : Products
    {
        override public string DisplayMessage { get { return "Munch Munch, Yum!"; } }


        public Candy(string productName, decimal productPrice, string productSlot, string productType)
                    : base(productName, productPrice, productSlot, productType)
        {
        

        }

        //method to remove stock

        //need to print to log 

        //remove balance



    }

}
