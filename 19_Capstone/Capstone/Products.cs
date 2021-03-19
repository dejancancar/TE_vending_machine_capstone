using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public abstract class Products
    {
        //holds name from the input file
        public string ProductName { get; set; }

        //holds price of product from input file
        public decimal ProductPrice { get; set; }

        //holds remaining quantity, starting at 5 set in constructor
        public int ProductRemaining { get; set; }


        //holds the product slot from input file
        public string ProductSlot { get; set; }

        //holds the type of a product taken in from input file
        public string ProductType { get; set; }

        abstract public string DisplayMessage { get; }

        //contrusctor to add name, price, slot and type to create an object of product
        public Products(string productName, decimal productPrice, string productSlot, string productType)
        {
            this.ProductName = productName;
            this.ProductPrice = productPrice;
            this.ProductSlot = productSlot;
            this.ProductType = productType;
            this.ProductRemaining = 5;
        }

        
    }
}
