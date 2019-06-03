using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Common;
using SWD_GUI_Assignment.Models;
using SWD_GUI_Assignment.Services;


namespace SWD_GUI_Assignment.ViewModels
{
    public class AddTreeViewModel : BaseViewModel
    {
        private MeasurementTree _measurementTree;
        public MeasurementTree MeasurementTree
        {
            get => _measurementTree; 
            set  => SetProperty(ref _measurementTree, value); 
        }

        public AddTreeViewModel(NavigationService navigationService)
        {
            _measurementTree = new MeasurementTree();
            _navigationService = navigationService;

            WindowTitle = "Tilføj Sort og antal";
        }

        ICommand _confirmCommand;

        public ICommand ConfirmCommand
        {
            get { return _confirmCommand ?? (_confirmCommand = new DelegateCommand(Confirm_Execute, CanConfirmCommandExecute)); }
        }


        private bool CanConfirmCommandExecute()
        {
            return MeasurementTree.Art != "" && MeasurementTree.Antal != 0;
        }

        private void Confirm_Execute()
        {
            

            DialogResult = true;

        }
    }
}