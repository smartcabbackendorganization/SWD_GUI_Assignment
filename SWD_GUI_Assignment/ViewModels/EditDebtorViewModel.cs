using System;
using System.Windows;
using System.Windows.Input;
using Prism.Commands;
using SWD_GUI_Assignment.Models;
using SWD_GUI_Assignment.Services;

namespace SWD_GUI_Assignment.ViewModels
{
    public class EditDebtorViewModel : BaseViewModel
    {
        private VarroeMide _activeVarroeMide;

        public VarroeMide ActiveVarroeMide
        {
            get => _activeVarroeMide;
            set => SetProperty(ref _activeVarroeMide, value);
        }

        private double _newTransaction;

        public double NewTransaction
        {
            get => _newTransaction;
            set => SetProperty(ref _newTransaction, value);
        }

        public EditDebtorViewModel(NavigationService navigationService, VarroeMide varroeMide)
        {
            _navigationService = navigationService;

            ActiveVarroeMide = varroeMide;

            WindowTitle = "Edit VarroeMide - " + ActiveVarroeMide.Name;
        }

        private ICommand _addValueCommand;

        public ICommand AddValueCommand => _addValueCommand ?? (_addValueCommand = new DelegateCommand(AddValue_Execute));

        private void AddValue_Execute()
        {
            if (ActiveVarroeMide == null) throw new ArgumentNullException();
            //ActiveVarroeMide.Transactions.Add(new Transaction(NewTransaction));
        }


    }
}