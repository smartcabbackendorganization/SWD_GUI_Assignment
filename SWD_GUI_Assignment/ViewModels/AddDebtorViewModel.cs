using System.Windows;
using System.Windows.Input;
using Prism.Commands;
using Prism.Common;
using SWD_GUI_Assignment.Interfaces;
using SWD_GUI_Assignment.Models;


namespace SWD_GUI_Assignment.ViewModels
{
    public class AddDebtorViewModel : BaseViewModel
    {
        private Debtor _debtor;
        public Debtor Debtor
        {
            get => _debtor; 
            set  => SetProperty(ref _debtor, value); 
        }

        private double _amount;

        public double Amount
        {
            get => _amount;
            set => SetProperty(ref _amount, value);
        }


        public AddDebtorViewModel(INavigationService navigationService)
        {
            Debtor = new Debtor();
            Debtor.Name = "";

            _navigationService = navigationService;

            WindowTitle = "Add debtor";
        }
        


        ICommand _SaveCommand;
        public ICommand SaveCommand
        {
            get { return _SaveCommand ?? (_SaveCommand = new DelegateCommand(SaveCommand_Execute)); }
        }

        private void SaveCommand_Execute()
        {
            Debtor.AddTransaction(new Transaction(Amount));
            DialogResult = true;
        }

    }
}