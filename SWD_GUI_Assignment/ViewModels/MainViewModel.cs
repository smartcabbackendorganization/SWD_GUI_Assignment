using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Win32;
using Prism.Commands;
using SWD_GUI_Assignment.Models;
using SWD_GUI_Assignment.Services;

namespace SWD_GUI_Assignment.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            _navigationService = new NavigationService();

            WindowTitle = "Lokation SW";

            //To allow search by name
            _lokationCollection = new CollectionViewSource();
            _lokationCollection.Source = _lokations;
            _lokationCollection.Filter += usersCollection_Filter;
            FilterText = "";

        }

        #region Properties

        private ObservableCollection<Lokation> _lokations = new ObservableCollection<Lokation>();
        public ObservableCollection<Lokation> Lokations
        {
            get => _lokations;
            set => SetProperty(ref _lokations, value);
        }


        private ObservableCollection<Job> _jobs = new ObservableCollection<Job>();
        public ObservableCollection<Job> Jobs
        {
            get => _jobs;
            set => SetProperty(ref _jobs, value);
        }

        private CollectionViewSource _lokationCollection;
        public ICollectionView LokationCollection
        {
            get
            {
                return this._lokationCollection.View;
            }
        }

        private string filterText;
        public string FilterText
        {
            get
            {
                return filterText;
            }
            set
            {
                filterText = value;
                this._lokationCollection.View.Refresh();
                RaisePropertyChanged("FilterText");
            }
        }

        void usersCollection_Filter(object sender, FilterEventArgs e)
        {
            if (string.IsNullOrEmpty(FilterText))
            {
                e.Accepted = true;
                return;
            }

            Lokation item = e.Item as Lokation;
            if (item.Navn.ToUpper().Contains(FilterText.ToUpper()))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }


        #endregion

        #region Commands

        private DelegateCommand _addDebtorCommand;
        private AddLokationViewModel vm;
        public DelegateCommand AddDebtorCommand => _addDebtorCommand ?? (_addDebtorCommand = new DelegateCommand(() =>
        {
             vm = new AddLokationViewModel(_navigationService);
            //Modeless way of doing it
            vm.Save += (arg1, arg2) =>
            {
                _lokations.Add(vm.Lokation);
                RaisePropertyChanged(nameof(Lokations));
                vm = null;
            };
            vm.Close += (arg1, arg2) =>
            {
                vm = null;
            };
            _navigationService.ShowModeless(vm);
        }));






        private DelegateCommand<VarroeMide> _editDebtorCommand;
        

        public DelegateCommand<VarroeMide> EditDebtorCommand => _editDebtorCommand ?? (_editDebtorCommand = new DelegateCommand<VarroeMide>((debtor) =>
        {
            

            if (debtor != null)
            {
                // Work on a copy so editing wont interfere with this vm's instance
               // var vm = new EditDebtorViewModel(_navigationService, VarroeMide.Clone(debtor));

                if (_navigationService.ShowModal(vm) == true)
                {
                    //var index = VarroeMides.IndexOf(VarroeMide);
                   // if (index != -1)
                    {
                        //VarroeMides[index] = vm.ActiveVarroeMide;
                        // Force update of VarroeMides property, so Window will update total balance
                        RaisePropertyChanged(nameof(VarroeMides));
                    }
                }
            }
        }));

        ICommand _SaveFile;
        public ICommand SaveFile
        {
            get { return _SaveFile ?? (_SaveFile = new DelegateCommand(SaveFile_Execute)); }
        }

        private void SaveFile_Execute()
        {
            if (_lokations.Count != 0)
            {
                //Serialiser
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Lokation>));
                

                //Write to file
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == true)
                {
                    TextWriter textWriter = new StreamWriter(saveFileDialog.FileName);
                    serializer.Serialize(textWriter, _lokations);
                }     
            }
        }

        ICommand _openFile;
        public ICommand OpenFile
        {
            get { return _openFile ?? (_openFile = new DelegateCommand(OpenFile_Execute)); }
        }

        private void OpenFile_Execute()
        {   
            //Serialiser
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Lokation>));

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                TextReader reader = new StreamReader(openFileDialog.FileName);
                // Deserialize all the lokations.
                var temp = (ObservableCollection<Lokation>)serializer.Deserialize(reader);

                //Add them to storage
                Lokations.AddRange(temp);
                RaisePropertyChanged(nameof(Lokations));

                //Close reader
                reader.Close();
            }
        }

        #endregion
    }
}