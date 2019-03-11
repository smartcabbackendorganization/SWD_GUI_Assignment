using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SWD_GUI_Assignment.Annotations;
using SWD_GUI_Assignment.Interfaces;

namespace SWD_GUI_Assignment.Models
{
    class Debtor : IDebtor, INotifyPropertyChanged
    {
        private List<ITransaction> _transactions = new List<ITransaction>();

        public double Balance { get; set; }

        public void AddTransaction(ITransaction transaction)
        {
            _transactions.Add(transaction);

            Balance += transaction.Amount;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}