using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Common;
using SWD_GUI_Assignment.Models;
using SWD_GUI_Assignment.Services;


namespace SWD_GUI_Assignment.ViewModels
{
    public class AddLokationViewModel : BaseViewModel
    {
        private Lokation _lokation;
        public Lokation Lokation
        {
            get => _lokation; 
            set  => SetProperty(ref _lokation, value); 
        }

        private MeasurementTree _measurementTree = null;
        public MeasurementTree MeasurementTree
        {
            get => _measurementTree;
            set => SetProperty(ref _measurementTree, value);
        }


        public AddLokationViewModel(NavigationService navigationService)
        {
            Lokation = new Lokation();

            Lokation.By = "Aarhus V";
            Lokation.Navn = "Min Park";
            Lokation.Postnummer = "8210";
            Lokation.Vejnummer = 22;
            Lokation.Vej = "Snogebæksvej";

            _navigationService = navigationService;

            WindowTitle = "Add Lokation";
        }


        private DelegateCommand _addTreeCommand;
        public DelegateCommand AddTreeCommand => _addTreeCommand ?? (_addTreeCommand = new DelegateCommand(() =>
        {
            var vm = new AddTreeViewModel(_navigationService);
            if (_navigationService.ShowModal(vm) == true)
            {
                Lokation.MeasurementTrees.Add(vm.MeasurementTree);
                RaisePropertyChanged(nameof(Lokation.MeasurementTrees));
            };
        }));


        #region SaveAndClose

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

        #endregion
    }
}