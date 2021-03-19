using MenuFramework;
using Capstone.ProductType;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.CLI
{
    public class MainMenu : ConsoleMenu
    {
        /*******************************************************************************
         * Private data:
         * Usually, a menu has to hold a reference to some type of "business objects",
         * on which all of the actions requested by the user are performed. A common 
         * technique would be to declare those private fields here, and then pass them
         * in through the constructor of the menu.
         * ****************************************************************************/

        // NOTE: This constructor could be changed to accept arguments needed by the menu
        private VendingMachine vm;

        //pass in vending machine object
        public MainMenu(VendingMachine machine)
        {

            this.vm = machine;
            AddOption("Display Vending Machine Items", DisplayItems, "1");
            AddOption("Purchase Menu", PurchaseMenu, "2");
            AddOption("Exit", Close, "3");

            Configure(cfg =>
           {
               cfg.ItemForegroundColor = ConsoleColor.Cyan;
               cfg.MenuSelectionMode = MenuSelectionMode.KeyString; // KeyString: User types a key, Arrow: User selects with arrow
               cfg.KeyStringTextSeparator = ": ";
               cfg.Title = "Welcome to the Beared Guys Vending Machine\n";
           });
        }

        //go to purchase menu
        private MenuOptionResult PurchaseMenu()
        {

            MoneySubMenu subMenu = new MoneySubMenu(vm);
            subMenu.PurchaseMenu();

            return MenuOptionResult.WaitAfterMenuSelection;
        }

        //display all the items in the machine
        private MenuOptionResult DisplayItems()
        {
            //Console.WriteLine($"Available Items\n");
            vm.DisplayItems();
            return MenuOptionResult.WaitAfterMenuSelection;
        }
    }
}
