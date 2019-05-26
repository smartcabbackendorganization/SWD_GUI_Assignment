using System;
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

            WindowTitle = "Varroe Optællings System";
        }

        #region Properties

        private VarroeMides _varroeMides = new VarroeMides();
        private VarroeMide _varroeMide;

        public VarroeMides VarroeMides
        {
            get => _varroeMides;
            set => SetProperty(ref _varroeMides, value);
        }

        public VarroeMide VarroeMide
        {
            get => _varroeMide;
            set => SetProperty(ref _varroeMide, value);
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
                Console.WriteLine(vm.VarroeMide.Name);
               // vm.VarroeMide.AddTransaction(new Transaction(vm.Amount));
                VarroeMides.Add(vm.VarroeMide);
                RaisePropertyChanged(nameof(VarroeMides));
                vm = null;
            };
            vm.Close += (arg1, arg2) =>
            {
                vm = null;
            };
            _navigationService.ShowModeless(vm);
        }));



        private DelegateCommand<VarroeMide> _editDebtorCommand;

        public DelegateCommand<VarroeMide> EditDebtorCommand => _editDebtorCommand ?? (_editDebtorCommand = new DelegateCommand<VarroeMide>((debtor) =>
        {
            

            if (debtor != null)
            {
                // Work on a copy so editing wont interfere with this vm's instance
              //  var vm = new EditDebtorViewModel(_navigationService, VarroeMide.Clone(debtor));

                if (_navigationService.ShowModal(vm) == true)
                {
                    var index = VarroeMides.IndexOf(VarroeMide);
                    if (index != -1)
                    {
                        //VarroeMides[index] = vm.ActiveVarroeMide;
                        // Force update of VarroeMides property, so Window will update total balance
                        RaisePropertyChanged(nameof(VarroeMides));
                    }
                }
            }
        }));

        #endregion
    }
}