using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_GUI_Assignment.Model
{
    class Transaction : ITransaction
    {
        public Transaction(double amount)
        {
            CreatedAt = DateTime.Now;

            Amount = amount;
        }

        public DateTime CreatedAt { get; set; }

        public double Amount { get; set; }

    }
}
