using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.CLI
{
    public class MoneySubMenu
    {
        private VendingMachine vm;
        

        //pass in vending machine
        public MoneySubMenu(VendingMachine machine)
        {
           this.vm = machine;
        }


        //feed money menu
        public string PurchaseMenu()
        {


            while (true)
            {
                Console.Clear();
                Console.WriteLine("Purchasing Menu\n");
                Console.WriteLine("1: Feed Money");
                Console.WriteLine("2: Select Product");
                Console.WriteLine("3: Finish Transaction");
                Console.WriteLine("");
                Console.WriteLine($"Current Balance: {vm.Money.Balance:c}");
                //ask user to select from menu
                Console.Write("\nSelect an option: ");
                //save user selection to input variable
                string input = Console.ReadLine();
                //if feed money is selected
                if (input == "1")
                {
                    while (true)
                    {
                        Console.Clear();
                        //ask user to insert money
                        Console.Write ("Please insert $1, $2, $5, or $10: ");

                        //save user input to amountToFeed
                        string amountToFeed = Console.ReadLine();
                        //adds amountToFeed to balance by invoking feedMoney method
                        if (amountToFeed == "1")
                        {
                            vm.Money.FeedMoney(1);
                            Console.WriteLine("\n\nYou've added $1 to your total!");
                            Console.Read();

                        }
                        else if (amountToFeed == "2")
                        {
                            vm.Money.FeedMoney(2);
                            Console.WriteLine("\n\nYou've added $2 to your total!");
                            Console.Read();
                        }
                        else if (amountToFeed == "5")
                        {
                            vm.Money.FeedMoney(5);
                            Console.WriteLine("\n\nYou've added $5 to your total!");
                            Console.Read();
                        }
                        else if (amountToFeed == "10")
                        {
                            vm.Money.FeedMoney(10);
                            Console.WriteLine("\n\nYou've added $10 to your total!");
                            Console.Read();
                        }
                        //if anything other than 1 2 5 or 10 is input
                        else
                        {
                            Console.WriteLine("Invalid Dollar Amount");
                            Console.Read();
                        }

                        break;
                    }

                }
                //if select product is selected
                //invokes method to go to menu
                if(input == "2")
                {

                    GoToProductSelectionMenu();

                }
                //if finish transtaction is selected
                //invokes finish transaction method
                if(input == "3")
                {
                    if(vm.Money.Balance == 0)
                    {

                        Console.Clear();
                        Console.WriteLine($"Balance is already {0:c}");
                        string placeHolder = Console.ReadLine();
                        //GoBackToMainMenu();
                        return null;

                    }
                    else
                    {
                        GoToFinishTransaction();
                        return null;

                    }

                }




            }




        }
        private void GoToProductSelectionMenu()
        {
            Console.Clear();
            //create new menu and pass in vending machine
            ProductSelectionMenu selectionMenu = new ProductSelectionMenu(vm);
            //call on method to select your product
            selectionMenu.SelectYourProduct();
        }
        private void GoToFinishTransaction()
        {

            Console.Clear();
            //hold finishtransaction in a variable
            string result = vm.Money.FinishTransaction();
            Console.WriteLine("Please collect your change!\n");
            //write the result of finishtransaction method
            Console.WriteLine(result);
            //blank variable, holds input so it doesn't get used in the mainmenu
            string placeHolder = Console.ReadLine();
            //GoBackToMainMenu();
        }
        //returns to main menu
        //private void GoBackToMainMenu()
        //{
        //    MainMenu mm = new MainMenu(vm);
        //    Console.Clear();
        //    mm.Show();
            
        //}
    }
}
