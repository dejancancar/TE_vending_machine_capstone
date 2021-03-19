using Capstone;
using Capstone.ProductType;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class InventoryManagerTests
    {
        [TestMethod]
        public void AddStartingInventoryCandyTest()
        {
            //arrange
            Candy newItem = new Candy("Cowtales", 0M, "B2", "Candy" );

            //B2 | Cowtales | 1.50 | Candy

            //act
            string name = newItem.ProductName;
            string slot = newItem.ProductSlot;
            string type = newItem.ProductType;
            decimal cost = newItem.ProductPrice;


            //assert
            Assert.AreEqual("Cowtales", name );
            Assert.AreEqual(0, cost);
            Assert.AreEqual("B2", slot);
            Assert.AreEqual("Candy", type);

        }
    }
}
