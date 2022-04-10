using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    internal class Validate
    {
        public static bool IsCardNumberValid(string cardnum)
        {
            if (String.IsNullOrEmpty(cardnum))
            {
                return false;
            }
            if(!Double.TryParse(cardnum, out var cardNumber))
            {
                return false;
            }
            return true;
          
        }
        public static bool IsPinNumberValid(string pinNum) 
        {
            if (String.IsNullOrEmpty(pinNum))
            {
                return false;
            }
            if (!Double.TryParse(pinNum, out var pinNumber))
            {
                return false;
            }
            return true;

        }

    }
}
