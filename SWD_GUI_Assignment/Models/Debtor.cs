using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SWD_GUI_Assignment.Annotations;
using SWD_GUI_Assignment.Interfaces;

namespace SWD_GUI_Assignment.Models
{
    class Debtor : IDebtor, INotifyPropertyChanged
    {
        private ObservableCollection<ITransaction> _transactions = new ObservableCollection<ITransaction>();
        private double _balance;

        public double Balance
        {
            get => _balance;
            set
            {
                if (_balance != value)
                {
                    _balance = value;
                    OnPropertyChanged();
                }
            }
        }

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