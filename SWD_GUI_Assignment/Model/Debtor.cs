using System.Collections.Generic;

namespace SWD_GUI_Assignment.Model
{
    class Debtor : IDebtor
    {
        private List<ITransaction> _transactions = new List<ITransaction>();

        public double Balance { get; set; }

        public void AddTransaction(ITransaction transaction)
        {
            _transactions.Add(transaction);

            Balance += transaction.Amount;
        }
    }
}