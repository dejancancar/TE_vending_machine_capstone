using MenuFramework;
using Capstone.ProductType;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.CLI
{
    public class ProductSelectionMenu : ConsoleMenu
    {
        /*******************************************************************************
         * Private data:
         * Usually, a menu has to hold a reference to some type of "business objects",
         * on which all of the actions requested by the user are performed. A common 
         * technique would be to declare those private fields here, and then pass them
         * in through the constructor of the menu.
         * ****************************************************************************/

        // NOTE: This constructor could be changed to accept arguments needed by the menu


        VendingMachine vm;
        //pass in vending machine
        public ProductSelectionMenu(VendingMachine vm)
        {

            this.vm = vm;




            Configure(cfg =>
           {
               cfg.ItemForegroundColor = ConsoleColor.Cyan;
               cfg.MenuSelectionMode = MenuSelectionMode.KeyString; // KeyString: User types a key, Arrow: User selects with arrow
               //cfg.KeyStringTextSeparator = ": ";
               //cfg.Title = "Product Select Menu";
           });
        }
        public MenuOptionResult SelectYourProduct()
        {
            //shows items you can choose from
            vm.DisplayItems();
            Console.WriteLine("\n\n");


            Console.WriteLine($"Current Balance: ${vm.Money.Balance}\n");
            Console.Write("Please enter your selection: ");
            string selection = Console.ReadLine();
            string youGetThis = vm.DispenseProduct(selection);
            Console.WriteLine($"{youGetThis}");
            Console.Read();
            return MenuOptionResult.WaitAfterMenuSelection;
        }





    }
}
