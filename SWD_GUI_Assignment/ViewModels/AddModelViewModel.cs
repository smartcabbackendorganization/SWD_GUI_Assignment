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
    public class AddModelViewModel : BaseViewModel
    {
        private Model _model;
        public Model Model
        {
            get => _model; 
            set  => SetProperty(ref _model, value); 
        }

        public AddModelViewModel(NavigationService navigationService)
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


    }
}