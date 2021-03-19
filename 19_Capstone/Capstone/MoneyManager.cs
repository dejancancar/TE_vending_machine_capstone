using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class MoneyManager
    {


        //balance of our machine
        public decimal Balance { get; private set; } = 0;



        //feed money, adds money to the machine total
        public decimal FeedMoney(decimal deposit)
        {
            //01/01/2016 12:00:00 PM FEED MONEY: $5.00 $5.00
            GenerateLog("FEED MONEY", Balance, Balance + deposit);
            this.Balance += deposit;
            return this.Balance;
        }

        // if balance is smaller then 0, can't purchase
        //if balance is bigger than 0, remove amount of purchase price
        public bool RemoveMoney(decimal toRemoveAmount)
        {
            
            if(this.Balance <= 0)
            {
                return false;
            }
            else 
            { 
            this.Balance -= toRemoveAmount;
            return true;
            }

        }

        //finish transaction, calculates the change while balance is bigger than 0
        public string FinishTransaction()
        {
            
            decimal quarter = .25m;
            decimal dime = .10m;
            decimal nickel = .05m;
            //looks at balance
            // gives out .25 first
            while(this.Balance > 0)
            {
                //holder for balance to be able to do calculations
                decimal endBalance = this.Balance;
                //resets vending machine balance to 0 
                this.Balance = 0;

                //Run GenerateLog Method to log the transaction
                //01/01/2016 12:01:35 PM GIVE CHANGE: $7.50 $0.00
                GenerateLog("GIVE CHANGE", endBalance, 0M);
                if (endBalance % quarter > 0 || endBalance % dime > 0 || endBalance % nickel == 0)
                {
                     //if number divisible by .25, .10, and .05
                    int numberOfQuarters = 0;
                    int numberOfDimes = 0;
                    int numberOfNickels = 0;
                    decimal remainingBalance = 0;
                    //multiply by 100 to be able to use integer and automatically round down, otherwise .25 would be 0
                    numberOfQuarters = (int)(endBalance * 100) / (int)(quarter * 100);
                    //remaining balance is the balance once quarters are given out
                    remainingBalance = endBalance - (numberOfQuarters * quarter);
                    //remaining balance is divided by .10s to give change of dimes
                    numberOfDimes = (int)(remainingBalance * 100) / (int)(dime*100);
                    //remaining balance once .25 and .10 are taken out
                    remainingBalance = remainingBalance - (dime * numberOfDimes);
                    //remaining balance and nickel is multiplied by 100 to use integer math
                    numberOfNickels = (int)(remainingBalance * 100) / (int)(nickel*100);
                    //if there and no quarters and no dimes, print out only nickels
                    if(numberOfQuarters == 0 && numberOfDimes == 0)
                    {
                        return ($"Your change is {numberOfNickels} nickel(s)."); 
                    }
                    //if there are no quarters return dimes and nickels
                    else if(numberOfQuarters == 0)
                    {
                        return ($"Your change is {numberOfDimes} dime(s) and {numberOfNickels} nickel(s).");
                    }
                    else if (numberOfDimes == 0 && numberOfNickels == 0)
                    {
                        return ($"Your change is {numberOfQuarters} quarter(s).");
                    }
                    else if (numberOfNickels == 0)
                    {
                        return ($"Your change is {numberOfQuarters} quarter(s), {numberOfDimes} dime(s).");
                    }
                    else
                    // returns change with quarters, dimes and nickels
                    {
                    return ($"Your change is {numberOfQuarters} quarter(s), {numberOfDimes} dime(s), and {numberOfNickels} nickel(s).");
                    }
                }

            }
            return "";
        }

        // generate log, takes the name of the transaction, the starting balance and balance once transaction is complete and logs them
        public static void GenerateLog(string transactionName, decimal balance, decimal balanceAfterTransaction)
        {
            string path = @"..\..\..\Log.txt";
            /*01/01/2016 12:00:00 PM FEED MONEY: $5.00 $5.00
              01/01/2016 12:00:15 PM FEED MONEY: $5.00 $10.00
              01/01/2016 12:00:20 PM Crunchie B4 $10.00 $8.50
              01/01/2016 12:01:25 PM Cowtales B2 $8.50 $7.50
              01/01/2016 12:01:35 PM GIVE CHANGE: $7.50 $0.00
            */

            using (StreamWriter logFile = new StreamWriter(path, true))
            {
                logFile.WriteLine($"{DateTime.Now} {transactionName} {balance:c} {balanceAfterTransaction:c}");
            }
        }
    }
}
