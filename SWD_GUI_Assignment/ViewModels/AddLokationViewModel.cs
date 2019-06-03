using System;
using System.Linq;
using System.Windows.Input;
using Prism.Commands;
using SWD_GUI_Assignment.Models;
using SWD_GUI_Assignment.Services;

namespace SWD_GUI_Assignment.ViewModels
{
    public class AddLokationViewModel : BaseViewModel
    {
        private DelegateCommand _addTreeCommand;
        private Lokation _lokation;

        private MeasurementTree _measurementTree;


        public AddLokationViewModel(NavigationService navigationService)
        {
            Lokation = new Lokation();

            Lokation.By = "Aarhus V";
            Lokation.Navn = "Min Park";
            Lokation.Postnummer = "8210";
            Lokation.Vejnummer = 22;
            Lokation.Vej = "Snogebæksvej";

            _navigationService = navigationService;

            WindowTitle = "Tilføj Lokation";
        }

        public AddLokationViewModel(NavigationService navigationService, Lokation lokation)
        {
            Lokation = lokation;

            _navigationService = navigationService;

            WindowTitle = "Tilføj Lokation";
        }

        public Lokation Lokation
        {
            get => _lokation;
            set => SetProperty(ref _lokation, value);
        }

        public MeasurementTree MeasurementTree
        {
            get => _measurementTree;
            set => SetProperty(ref _measurementTree, value);
        }

        public DelegateCommand AddTreeCommand => _addTreeCommand ?? (_addTreeCommand = new DelegateCommand(() =>
        {
            var vm = new AddTreeViewModel(_navigationService);
            if (_navigationService.ShowModal(vm) == true)
            {
                //Detect if already added, and then add to that.
                if (Lokation.MeasurementTrees.Count(x => x.Sort == vm.MeasurementTree.Sort) != 0)
                {
                    var tree = Lokation.MeasurementTrees.First(x => x.Sort == vm.MeasurementTree.Sort);
                    var indexOf = Lokation.MeasurementTrees.IndexOf(tree);
                    vm.MeasurementTree.Antal += tree.Antal;
                    Lokation.MeasurementTrees.Remove(tree);
                    Lokation.MeasurementTrees.Insert(indexOf,vm.MeasurementTree);
                }
                else
                {
                    Lokation.MeasurementTrees.Add(vm.MeasurementTree);
                }

                RaisePropertyChanged(nameof(Lokation.MeasurementTrees));
            }

            ;
        }));


        #region SaveAndClose

        public event EventHandler Save;
        public event EventHandler Close;

        private ICommand _SaveCommand;

        public ICommand SaveCommand => _SaveCommand ?? (_SaveCommand = new DelegateCommand(SaveCommand_Execute));

        private void SaveCommand_Execute()
        {
            Save?.Invoke(null, null);
        }


        private ICommand _CloseCommand;

        public ICommand CloseCommand => _CloseCommand ?? (_SaveCommand = new DelegateCommand(CloseCommand_Execute));


        private void CloseCommand_Execute()
        {
            Close?.Invoke(null, null);
        }

        #endregion
    }
}