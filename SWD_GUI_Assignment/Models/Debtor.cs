using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using SWD_GUI_Assignment.Annotations;
using SWD_GUI_Assignment.Interfaces;

namespace SWD_GUI_Assignment.Models
{
    public class Debtor : IDebtor, INotifyPropertyChanged
    {
        private ObservableCollection<ITransaction> _transactions = new ObservableCollection<ITransaction>();
        private string _name;

        public ObservableCollection<ITransaction> Transactions
        {
            get => _transactions;
            set
            {
                if (_transactions != value)
                {
                    _transactions = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public double Balance
        {
            get { return this.Transactions.Sum(item => item.Amount); }
        }

        public void AddTransaction(ITransaction transaction)
        {
            _transactions.Add(transaction);
        }

        public static Debtor Clone(IDebtor original)
        {
            Debtor newInstance = new Debtor();
            newInstance.Name = original.Name;
            foreach (var transaction in original.Transactions)
            {
                var newTransaction = new Transaction(transaction.Amount);
                newTransaction.CreatedAt = transaction.CreatedAt;
                newInstance.AddTransaction(newTransaction);
            }

            return newInstance;
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