using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTableExt;


namespace ATM
{
    internal class Program
    {
        public static List<Transaction> transactions = new List<Transaction>();
        public static List<double> cash = new List<double>();
        static AccountHolder accountHolder = new AccountHolder();

        static void Main(string[] args)
        {
            BankController.CreateTable();
            accountHolder.cardNumber = 5450878657260454;
            accountHolder.pinNumber = 1234;
            accountHolder.bankBalance = 2000;
       
            while (true)
            {
                CheckAccount();
            }
        }
        public static void MainMenu()
        {

            Console.Clear();

            Console.WriteLine("\n\nATM MAIN MENU");
            Console.WriteLine("Pick one of the following options");
            Console.WriteLine("\nType Enter to go back to the MAIN MENU");
            Console.WriteLine("Type 0 to Exit");
            Console.WriteLine("Type 1 for Cash Withdrawal");
            Console.WriteLine("Type 2 for Show previous Transactions and Balance");

            string menuSelector = Convert.ToString(Console.ReadKey(true).KeyChar);
 
            switch (menuSelector)
            {
                case "0":
                    Environment.Exit(0);
                    break;
                // Cash Withdrawal and Availability
                case "1":
                    WithDrawMoney();
                    break;
                // Show Previous Transactions and Show Balance of your account
                case "2":
                    ShowTransactions();
                    break;
            }
          
        }

        public static void WithDrawMoney()
        {
            Transaction trans = new Transaction();
            Console.Clear();
            Console.WriteLine("Input amount you are taking out: ");
            if (accountHolder.bankBalance > 0)
            {
                trans.Amount = Double.Parse(Console.ReadLine());
                trans.Date = DateTime.Now;
                transactions.Add(trans);
                Console.WriteLine($"You received {trans.Amount}");
                Console.WriteLine("\nPress any key to return");
                trans.Balance = accountHolder.bankBalance -= trans.Amount;
            }
            else 
            {
                Console.Clear();
                Console.Write("You have no money in your account to withdraw. Logging off...");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }
        public static void ShowTransactions()
        {
            Console.Clear();
            Console.WriteLine("\nDisplaying Transactions");
            ConsoleTableBuilder.From(transactions).ExportAndWriteLine();
            
            Console.WriteLine("Press any key to return");
            Console.ReadKey();
        }

        public static void CheckAccount()
        {
            Console.Write("\nEnter your debit or credit card number: ");
            string cardnum = Console.ReadLine();


            if (!Validate.IsCardNumberValid(cardnum))
            {
                Console.WriteLine("Invalid card number.");
                return;
            }
            else if(!BankController.CheckCardNumber(cardnum))
            {
                Console.WriteLine("Invalid card number.");
                return;
            }
          
                Console.Write("\nEnter your PIN number: ");
                string pinNum = Console.ReadLine();

                if (!Validate.IsPinNumberValid(pinNum))
                {
                    Console.WriteLine("invalid pin number.");
                    return;

                }
                else if (Double.Parse(pinNum) != accountHolder.pinNumber)
                {
                    Console.WriteLine("invalid pin number.");
                    return; 
                }
              
            

            while (true)
            {
                MainMenu();
            }
        }
    }
}

