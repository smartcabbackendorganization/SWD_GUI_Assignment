using System;
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
        private VarroeMide _varroeMide;
        public VarroeMide VarroeMide
        {
            get => _varroeMide; 
            set  => SetProperty(ref _varroeMide, value); 
        }

        private double _amount;

        public double Amount
        {
            get => _amount;
            set => SetProperty(ref _amount, value);
        }


        public AddDebtorViewModel(INavigationService navigationService)
        {
            VarroeMide = new VarroeMide();
            VarroeMide.Name = "";

            VarroeMide.CreatedAt = DateTime.Now;

            VarroeMide.VarroMides = 0;

            VarroeMide.Comment = "";

            _navigationService = navigationService;

            WindowTitle = "Add varroeMide";
        }

        public event EventHandler Save;
        public event EventHandler Close;

        ICommand _SaveCommand;
        public ICommand SaveCommand
        {
            get { return _SaveCommand ?? (_SaveCommand = new DelegateCommand(SaveCommand_Execute)); }
        }

        private void SaveCommand_Execute()
        {
            Save?.Invoke(null,null);
        }


        ICommand _CloseCommand;
        public ICommand CloseCommand
        {
            get { return _CloseCommand ?? (_SaveCommand = new DelegateCommand(CloseCommand_Execute)); }
        }

        private void CloseCommand_Execute()
        {
            Close?.Invoke(null, null);
            
        }

    }
}