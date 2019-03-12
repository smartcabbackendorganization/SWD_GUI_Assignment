using System.Windows;
using Prism.Commands;
using SWD_GUI_Assignment.Models;
using SWD_GUI_Assignment.Services;

namespace SWD_GUI_Assignment.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            _navigationService = new NavigationService();

            WindowTitle = "The Debt Book";
        }

        #region Properties

        private Debtors _debtors = new Debtors();
        private Debtor _currentDebtor;

        public Debtors Debtors
        {
            get => _debtors;
            set => SetProperty(ref _debtors, value);
        }

        public Debtor Debtor
        {
            get => _currentDebtor;
            set => SetProperty(ref _currentDebtor, value);
        }

        #endregion

        #region Commands

        private DelegateCommand _addDebtorCommand;

        public DelegateCommand AddDebtorCommand => _addDebtorCommand ?? (_addDebtorCommand = new DelegateCommand(() =>
        {
            var vm = new AddDebtorViewModel(_navigationService);

            if (_navigationService.Show(vm) == true)
            {
                Debtors.Add(vm.Debtor);
                // Force update of Debtors property, so Window will update total balance
                RaisePropertyChanged(nameof(Debtors));
            }
        }));

        private DelegateCommand<Debtor> _editDebtorCommand;

        public DelegateCommand<Debtor> EditDebtorCommand => _editDebtorCommand ?? (_editDebtorCommand = new DelegateCommand<Debtor>((debtor) =>
        {
            var vm = new EditDebtorViewModel(_navigationService);

            if (_navigationService.Show(vm) == true)
            {
                MessageBox.Show("Uddate the existing Debtor in Debtors with the newly edited one.");
            }
        }));

        #endregion
    }
}