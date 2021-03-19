using Capstone.ProductType;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    public class InventoryManager
    {

        //path to inventory
        const string path = @"..\..\..\..\vendingmachine.csv";


        //creates a new object product dictionary
        public Dictionary<string, Products> inventoryItems = new Dictionary<string, Products>();

        

        //adds items to inventoryItems from file
        public void AddStartingInventory()
        {

            try
            {
                //Read inventory file from file provided
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream) // read through input file
                    {
                        string item = sr.ReadLine();
                        string[] fields = item.Split("|");
                        decimal cost = decimal.Parse(fields[2]);
                        string slot = fields[0];
                        string name = fields[1];
                        string type = fields[3];
                        Products p = null;
                        //Creates a new object of candy, chips, drink or gum
                        if (type == ("Candy"))
                        {
                            p = new Candy(name, cost, slot, type);
                        }
                        else if (type == ("Chip"))
                        {
                            p = new Chips(name, cost, slot, type);
                        }
                        else if (type == ("Drink"))
                        {
                            p = new Drink(name, cost, slot, type);
                        }
                        else if (type == "Gum")
                        {
                            p = new Gum(name, cost, slot, type);
                        }
                        //adds object to inventory items list with key of slot and product with all information
                        inventoryItems.Add(p.ProductSlot, p);

                    }

                }
            }
            catch (Exception)
            {
                Console.WriteLine($"ERROR! Invalid {path} path.");
            }

        }


        //vending machine will call inventory manager
    }
}
