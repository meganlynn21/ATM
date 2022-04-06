using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class AccountHolder
    {
        public int pinNumber;
        public double cardNumber;

        public AccountHolder(int aPinNumber, double aCardNumber)
        {
        
            pinNumber = aPinNumber;
            cardNumber = aCardNumber;
        }

    }
}
