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
        private Debtor _debtor;

        public Debtors Debtors
        {
            get => _debtors;
            set => SetProperty(ref _debtors, value);
        }

        public Debtor Debtor
        {
            get => _debtor;
            set => SetProperty(ref _debtor, value);
        }

        #endregion

        #region Commands

        private DelegateCommand _addDebtorCommand;
        private AddDebtorViewModel vm;
        public DelegateCommand AddDebtorCommand => _addDebtorCommand ?? (_addDebtorCommand = new DelegateCommand(() =>
        {
             vm = new AddDebtorViewModel(_navigationService);
            //Modeless way of doing it
            vm.Save += (arg1, arg2) =>
            {
                Debtors.Add(vm.Debtor);
                RaisePropertyChanged(nameof(Debtors));
                vm = null;
            };
            vm.Close += (arg1, arg2) =>
            {
                vm = null;
            };


            _navigationService.ShowModeless(vm);



        }));



        private DelegateCommand<Debtor> _editDebtorCommand;

        public DelegateCommand<Debtor> EditDebtorCommand => _editDebtorCommand ?? (_editDebtorCommand = new DelegateCommand<Debtor>((debtor) =>
        {
            

            if (debtor != null)
            {
                // Work on a copy so editing wont interfere with this vm's instance
                var vm = new EditDebtorViewModel(_navigationService, Debtor.Clone(debtor));

                if (_navigationService.ShowModal(vm) == true)
                {
                    var index = Debtors.IndexOf(Debtor);
                    if (index != -1)
                    {
                        Debtors[index] = vm.ActiveDebtor;
                        // Force update of Debtors property, so Window will update total balance
                        RaisePropertyChanged(nameof(Debtors));
                    }
                }
            }
        }));

        #endregion
    }
}