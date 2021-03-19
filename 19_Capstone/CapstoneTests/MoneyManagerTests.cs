using Capstone;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class MoneyManagerTests
    {
        [TestMethod]
        //[DataRow(10.0, 10.0)]
        //[DataRow(0, 0)]
        //[DataRow(100, 100)]
        //[DataRow(1000, 1000)]
        //[DataRow(57, 57)]
        //[DataRow(1, 1)]
        public void FeedMoneyTest()
        {
            decimal input = 10;
            decimal expectedResult = 10;
            //arrange
            MoneyManager mm = new MoneyManager();
            //act
            decimal result = mm.FeedMoney(input);

            //assert
            Assert.AreEqual(expectedResult, result);
        }
        //[TestMethod]
        //public void RemoveMoneyTest(decimal input)
        //{
        //    //arrange
        //    MoneyManager mm = new MoneyManager();
        //    bool expectedResult = true;
        //    decimal balance = mm.Balance;
        //    //act
        //    balance -= input;
        //    bool result = mm.RemoveMoney(input);
           

        //    //assert
        //    Assert.AreEqual(expectedResult, result);

        //}


    }
}
