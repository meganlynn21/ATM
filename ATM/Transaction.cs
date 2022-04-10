using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    internal class Transaction
    {
        public double Amount { get; set; }
        public double Balance { get; set; }
        public DateTime Date { get; set; }


        internal static double Sum()
        {
            throw new NotImplementedException();
        }
    }
}
