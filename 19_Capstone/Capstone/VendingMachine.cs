using Capstone.ProductType;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{

    public class VendingMachine
    {
        //new property of money manager to allow us to pass balance around
        public MoneyManager Money { get; private set; } = new MoneyManager();

        //allows us to pass in an object of inventory into our new vending machine class
        public Dictionary<string, Products> inventoryItems;

        public VendingMachine(Dictionary<string, Products> inventory)
        {
            this.inventoryItems = inventory;
        }
        public void DisplayItems()
        {
            Console.WriteLine($"| {"Slot",-4} | {"Item",-20} | {"Price",-5} | {"Stock",-5} |");
            Console.WriteLine("-----------------------------------------------");
            //loop through dictionary that was passed in
            foreach (KeyValuePair<string, Products> kvp in inventoryItems)
            {
                //set values to variables
                string productName = kvp.Value.ProductName;
                decimal cost = kvp.Value.ProductPrice;
                string productType = kvp.Value.ProductType;
                int productRemaining = kvp.Value.ProductRemaining;
                string productSlot = kvp.Key;

                //When displayitems is called, prints from dictionary the items
                Console.WriteLine($"| {productSlot,-4} | {productName,-20} | {cost,-5:c} | {productRemaining,-5} |");

            }



        }
        //method to dispense product
        public string DispenseProduct(string selection)
        {
            //set selection to uppercase
            string upperSelection = selection.ToUpper();
            if (inventoryItems.ContainsKey(upperSelection))
            {
                //variables for product in the inventory items dictionary
                int remainingProduct = inventoryItems[upperSelection].ProductRemaining;
                decimal priceOfProduct = inventoryItems[upperSelection].ProductPrice;
                string typeOfProduct = inventoryItems[upperSelection].ProductType;
                string nameOfProduct = inventoryItems[upperSelection].ProductName;
                //if not stock left, show sold out
                if (remainingProduct == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\nSOLD OUT");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Read();
                }
                //check to make sure enough money was entered into the machine
                //if product is more than balance, not enough money
                else if (priceOfProduct > this.Money.Balance)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\nINSUFFICIENT BALANCE!");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Read();

                }
                else
                {
                    //vendItem is ProductName and ProductPrice
                    //set easier variabless
                    string vendItem = ($"{nameOfProduct}, ${priceOfProduct}");
                    decimal moneySpent = this.Money.Balance - priceOfProduct;

                    //01/01/2016 12:01:25 PM Cowtales B2 $8.50 $7.50
                    //generate log
                   MoneyManager.GenerateLog($"{nameOfProduct} {upperSelection}", this.Money.Balance, moneySpent);
                    // removes 1 from stock
                    inventoryItems[upperSelection].ProductRemaining -= 1;
                    //remove cost of product from balance
                    this.Money.RemoveMoney(priceOfProduct);
                    // return item name, cost, money remaining and message 
                    //if (typeOfProduct == "Candy")
                    //{
                    //    return ($"\n\nThank You! \n{vendItem}\n\tYour remaing balance is: {moneySpent:c}\n\t\t{Candy.DisplayMessage}");
                    //}
                    //if (typeOfProduct == "Chip")
                    //{
                    //    return ($"\n\nThank You! \n{vendItem}\n\tYour remaing balance is: {moneySpent:c}\n\t\t{Chips.DisplayMessage}");
                    //}
                    //if (typeOfProduct == "Drink")
                    //{
                    //    return ($"\n\nThank You! \n{vendItem}\n\tYour remaing balance is: {moneySpent:c}\n\t\t{Drink.DisplayMessage}");
                    //}
                    //if (typeOfProduct == "Gum")
                    //{
                    //    return ($"\n\nThank You! \n{vendItem}\n\tYour remaing balance is: {moneySpent:c}\n\t\t{Gum.DisplayMessage}");
                    //}
                    return ($"\n\nThank You! \n{vendItem}\n\tYour remaing balance is: {moneySpent:c}\n\t\t{inventoryItems[upperSelection].DisplayMessage}");



                }

            }
            return "Invalid Selection";




        }

       










    }
}
