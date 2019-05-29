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
    public class AddJobViewModel : BaseViewModel
    {
        private Job _job;
        public Job Job
        {
            get => _job; 
            set  => SetProperty(ref _job, value); 
        }

        public AddJobViewModel(NavigationService navigationService)
        {
            Job = new Job();
            _navigationService = navigationService;

            WindowTitle = "Add Model";
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