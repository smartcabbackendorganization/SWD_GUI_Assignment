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
            MeasurementTree = new MeasurementTree();
            _navigationService = navigationService;

            WindowTitle = "Add Lokation";
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

        private ICommand _confirmCommand;

        public ICommand ConfirmCommand => _confirmCommand ?? (_confirmCommand = new DelegateCommand(Confirm_Execute));

        private void Confirm_Execute()
        {
            DialogResult = true;
        }
    }
}