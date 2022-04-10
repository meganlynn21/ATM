using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    internal class Program
    {
        public static List<double> transactions = new List<double>();
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
            Console.WriteLine("\nType 0 to Exit");
            Console.WriteLine("Type 1 for Cash Withdrawal");
            Console.WriteLine("Type 2 for Show previous transactions");
            Console.WriteLine("Type 3 for Balance");

            string menuSelector = Convert.ToString(Console.ReadKey(true).KeyChar);
            double myMoney = 0;

            switch (menuSelector)
            {
                case "0":
                    Environment.Exit(0);
                    break;
                // Cash Withdrawal and Availability
                case "1":
                    Console.WriteLine("Input amount you are taking out: ");
                    double cashWithdrawn = Double.Parse(Console.ReadLine());
                    myMoney += cashWithdrawn;
                    transactions.Add(cashWithdrawn);
                    Console.WriteLine($"You have {myMoney}");
                    break;
                // Show Previous Transactions
                case "2":
                    foreach (double number in transactions)
                    {
                        Console.WriteLine(number);
                    }
                    Console.ReadLine();
                    break;
                // Show Balance
                case "3":
                    CheckAccount();
                    break;


            }
          
        }
        public static void CheckAccount()
        {
            Console.WriteLine("\nEnter your debit or credit card number: ");
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

            Console.WriteLine("\nEnter your PIN number: ");
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

