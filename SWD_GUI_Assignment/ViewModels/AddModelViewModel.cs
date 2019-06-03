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
        private Lokation _lokation;
        public Lokation Lokation
        {
            get => _lokation; 
            set  => SetProperty(ref _lokation, value); 
        }

        public AddModelViewModel(NavigationService navigationService)
        {
            Lokation = new Lokation();

            Lokation.By = "Brunt";
            Lokation.Navn = "";
            Lokation.Postnummer = "50 kg";
            Lokation.Vejnummer = 170;


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


    }
}