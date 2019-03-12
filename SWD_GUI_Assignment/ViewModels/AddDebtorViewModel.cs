using System.Windows.Input;
using Prism.Commands;
using Prism.Common;
using SWD_GUI_Assignment.Interfaces;
using SWD_GUI_Assignment.Models;


namespace SWD_GUI_Assignment.ViewModels
{
    public class AddDebtorViewModel : BaseViewModel
    {
        public Debtor debtor;
        public Debtor Debtor
        {
            get { return debtor; }
            set { SetProperty(ref debtor, value); }
        }
        

        public AddDebtorViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            WindowTitle = "Tilføj skyldner";
        }
        


        ICommand _SaveCommand;
        public ICommand SaveCommand
        {
            get { return _SaveCommand ?? (_SaveCommand = new DelegateCommand(SaveCommand_Execute)); }
        }

        private void SaveCommand_Execute()
        {
            ITransaction transaction = new Transaction(InitialValue);
            DialogResult = true;
        }

    }
}