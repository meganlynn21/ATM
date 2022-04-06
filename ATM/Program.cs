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
        static void Main(string[] args)
        {
            AccountHolder accountHolder = new AccountHolder(1234, 5450878657260454);
            bool shouldContinue = true;
            double bankAccount = 2000;

            // ---------- ERROR CHECKING ---------------------------------------------------
            while (shouldContinue)
            {
                try
                {
                    Console.WriteLine("Enter your debit or credit card number: ");
                    double cardnum = Double.Parse(Console.ReadLine());
                    if (cardnum != accountHolder.cardNumber)
                    {
                        Console.WriteLine("Invalid card number");
                    }

                    //Verifying the user by asking for a PIN
                    Console.WriteLine("Enter your PIN number: ");
                    int pinNum = int.Parse(Console.ReadLine());

                    //In case of negative verification, logging out the user

                    if (pinNum != accountHolder.pinNumber)
                    {
                        Console.WriteLine("Invalid PIN");
                        Console.ReadLine();
                    }
                    else
                    {
                        shouldContinue = false;
                    }
                }
                catch(FormatException)
                {
                    Console.WriteLine("Wrong Format");
                }

                // END OF ERROR CHECKING ----------------------------------------

                //In case of positive verification, showing multiple options,
                //including cash availability, the previous five transactions, and cash withdrawal

                List<double> transactions = new List<double>();
                List<double> cash = new List<double>();
                Console.WriteLine("Pick one of the following options");
                Console.WriteLine("Cash Withdrawal");
                double cashWithdrawal = Double.Parse(Console.ReadLine());
                Console.WriteLine("Show previous transactions");
                Console.WriteLine("Cash Availability");
                
                // Cash Availability
                if (cashWithdrawal < bankAccount)
                {

                }

                Console.ReadLine();
            }

        }
    }
}
