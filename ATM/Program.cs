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
            accountHolder.cardNumber = 5450878657260454;
            accountHolder.pinNumber = 1234;
            accountHolder.bankAccount = 2000;
       
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
            Console.WriteLine("Type 2 for Show previous transactions");
            Console.WriteLine("Type 3 for Balance");

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
            double money = 0;
            Transaction trans = new Transaction();
            Console.Clear();
            Console.WriteLine("Input amount you are taking out: ");
             trans.Amount = Double.Parse(Console.ReadLine());
             trans.Date = DateTime.Now;
             money += trans.Amount;
             transactions.Add(trans);
             Console.WriteLine($"You received {money}");
             Console.WriteLine("\nPress any key to return");
             trans.Balance = accountHolder.bankAccount -= trans.Amount;
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
                Console.WriteLine("invalid card number.");
                return;
            }
            else if(Double.Parse(cardnum) != accountHolder.cardNumber)
            {
                Console.WriteLine("invalid card number.");
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
            }

            while (true)
            {
                MainMenu();
            }
        }
    }
}

