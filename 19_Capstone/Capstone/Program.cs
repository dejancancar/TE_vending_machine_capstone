using Capstone.CLI;
using System;

namespace Capstone
{
    class Program
    {
        /****************************************************************************************
         * Notes on this Capstone solution:
         *      This solution contains both a project for the Vending Machine program (Capstone)
         *      and a project for tests (CapstoneTests). The Test project already references the
         *      Capstone project, so all you need to do is add Test Classes and Test Methods.
         *      
         *      ConsoleMenuFramework has been added via Nuget, so the project is ready to derive
         *      new menus. There is already a sample menu in the CLI folder. You can rename this 
         *      one, or create a new one to get started.
         * 
         * *************************************************************************************/
        static void Main(string[] args)
        {
            // You may want to create some objects to get the whole process started here...


            // Some objects could be passed into the menu constructor, so that the menu has something to 
            // perform its actions against....
            

            //creates an object of inventory manager
            InventoryManager im = new InventoryManager();
            //invoke method from inventory manager page
            im.AddStartingInventory();

            //create a new vending machine
            //and add the starting items from the dictionary in inventory items to a new vending machine
            VendingMachine vm = new VendingMachine(im.inventoryItems);

            //create a new object mainmenu
            MainMenu mainMenu = new MainMenu(vm);
            mainMenu.Show();
        }
    }
}


//if(you_got_a_problem)
//{
//    problem.vanillaIce = YO_Ill_solve_it;
//}
