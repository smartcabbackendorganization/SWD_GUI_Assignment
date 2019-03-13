using System;
using System.Windows.Input;
using Prism.Commands;
using SWD_GUI_Assignment.Interfaces;
using SWD_GUI_Assignment.Models;

namespace SWD_GUI_Assignment.ViewModels
{
    public class EditDebtorViewModel : BaseViewModel
    {
        private Debtor _activeDebtor;

        public Debtor ActiveDebtor
        {
            get => _activeDebtor;
            set => SetProperty(ref _activeDebtor, value);
        }

        private double _newTransaction;

        public double NewTransaction
        {
            get => _newTransaction;
            set => SetProperty(ref _newTransaction, value);
        }

        public EditDebtorViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            WindowTitle = "Rediger skyldner";

        }

        private ICommand _addValueCommand;

        public ICommand AddValueCommand
        {
            get
            {
                return _addValueCommand ?? (_addValueCommand = new DelegateCommand(AddValue_Execute));
            }
        }

        private void AddValue_Execute()
        {
            if (ActiveDebtor == null) throw new ArgumentNullException();
            ActiveDebtor.Transactions.Add(new Transaction(NewTransaction));
        }
    }
}