using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Common;
using SWD_GUI_Assignment.Interfaces;
using SWD_GUI_Assignment.Models;


namespace SWD_GUI_Assignment.ViewModels
{
    public class AddJobViewModel : BaseViewModel
    {
        private Model _model;
        public Model Model
        {
            get => _model; 
            set  => SetProperty(ref _model, value); 
        }

        public AddJobViewModel(INavigationService navigationService)
        {
            Model = new Model();

            Model.Hårfarve = "Brunt";
            Model.Navn = "";
            Model.Kommentarer = "Ingen kommentar";
            Model.Vægt = "50 kg";
            Model.Højde = 170;


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