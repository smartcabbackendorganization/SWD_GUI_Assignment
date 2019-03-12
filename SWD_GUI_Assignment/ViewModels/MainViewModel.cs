using System.Windows;
using Prism.Commands;
using SWD_GUI_Assignment.Models;
using SWD_GUI_Assignment.Services;

namespace SWD_GUI_Assignment.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private Debtors _debtors = new Debtors();

        public Debtors Debtors
        {
            get => _debtors;
            set => SetProperty(ref _debtors, value);
        }

        public MainViewModel()
        {
            _navigationService = new NavigationService();

            WindowTitle = "The Debt Book";
            var debtor = new Debtor();
            debtor.AddTransaction(new Transaction(10));
            _debtors.Add(debtor);

        }

        private DelegateCommand _addDebtorCommand;

        public DelegateCommand AddDebtorCommand => _addDebtorCommand ?? (_addDebtorCommand = new DelegateCommand(() =>
        {
            var vm = new AddDebtorViewModel(_navigationService);

            if (_navigationService.Show(vm) == true)
            {
                //Debtors.Add(vm.Debtor);
            }
        }));

        private DelegateCommand<Debtor> _editDebtorCommand;

        public DelegateCommand<Debtor> EditDebtorCommand => _editDebtorCommand ?? (_editDebtorCommand = new DelegateCommand<Debtor>((debtor) =>
        {
            var vm = new EditDebtorViewModel(_navigationService);
            MessageBox.Show("CLICKED! Balance: " + debtor.Balance.ToString());

            if (_navigationService.Show(vm) == true)
            {
                //Debtors.Add(vm.Debtor);
            }
        }));
    }
}