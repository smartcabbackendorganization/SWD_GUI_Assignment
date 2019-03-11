using System.Collections.Generic;
using System.ComponentModel;

namespace SWD_GUI_Assignment.Model
{
    class Debtor : IDebtor, INotifyPropertyChanged
    {
        private List<ITransaction> _transactions = new List<ITransaction>();

        public double Balance { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void AddTransaction(ITransaction transaction)
        {
            _transactions.Add(transaction);

            Balance += transaction.Amount;
            
            
        }
    }
}