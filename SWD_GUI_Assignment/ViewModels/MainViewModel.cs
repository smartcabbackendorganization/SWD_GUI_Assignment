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

// Based from SWD GUI assignment, in group work with Frank Andersen And Jesper Strøm.
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


            //Setup backgground thread
            bw.DoWork += new DoWorkEventHandler(BackgroundThreadOperation);

        }

        #region Properties

        private Lokation _lokation = null;
        public Lokation Lokation
        {
            get => _lokation;
            set => SetProperty(ref _lokation, value);
        }


        private ObservableCollection<Lokation> _lokations = new ObservableCollection<Lokation>();
        public ObservableCollection<Lokation> Lokations
        {
            get => _lokations;
            set => SetProperty(ref _lokations, value);
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

        private DelegateCommand _addLokationCommand;
        private AddLokationViewModel vm = null;
        public DelegateCommand AddLokationCommand => _addLokationCommand ?? (_addLokationCommand = new DelegateCommand(() =>
        {
            //If window is not opened
            if (vm == null)
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
            }
            else //Focus the window
            {
                _navigationService.FocusLokationWindow();
            }
            
        }));






        private DelegateCommand<Lokation> _editLokationCommand;
        

        public DelegateCommand<Lokation> EditLokationElement => _editLokationCommand ?? 
                                                              (_editLokationCommand = new DelegateCommand<Lokation>((lokation) =>
        {
            if (lokation != null)
            {
                // Work on a copy so editing wont interfere with this vm's instance
               var vm = new AddLokationViewModel(_navigationService, lokation.Clone() as Lokation);

               vm.Save += (arg1, arg2) =>
               {
                   //Remove the old
                   var indexOf = Lokations.IndexOf(lokation);
                   Lokations.Remove(lokation);
                   //Insert the new element
                   Lokations.Insert(indexOf, vm.Lokation);
                   //Update view
                   RaisePropertyChanged(nameof(Lokations));
               };

                _navigationService.ShowModeless(vm);
            }
        }));

        private DelegateCommand<Lokation> _deleteSelectedCommand;


        public DelegateCommand<Lokation> DeleteSelectedCommand => _deleteSelectedCommand ??
                                                                (_deleteSelectedCommand = new DelegateCommand<Lokation>((lokation) =>
            {
                if (lokation != null)
                {
                     Lokations.Remove(lokation);
                     RaisePropertyChanged(nameof(Lokations));
                }
            }));

        private DelegateCommand _deleteAllCommand;


        public DelegateCommand DeleteAllCommand => _deleteAllCommand ??
                                                                  (_deleteAllCommand = new DelegateCommand(() =>
          {
              Lokations.Clear();
              RaisePropertyChanged(nameof(Lokations));
          }));


        ICommand _SaveFile;
        public ICommand SaveFile
        {
            get { return _SaveFile ?? (_SaveFile = new DelegateCommand(SaveFile_Execute)); }
        }

        BackgroundWorker bw = new BackgroundWorker();
        private void SaveFile_Execute()
        {
            if (_lokations.Count != 0)
            {
                //Do in a background thread
                //As saving can take a LONG time if file is blocked etc. 
                bw.RunWorkerAsync();
            }
        }

        private void BackgroundThreadOperation(object sender, DoWorkEventArgs e)
        {
            //Serialiser
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Lokation>));


            //Write to file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                TextWriter textWriter = new StreamWriter(saveFileDialog.FileName);
                serializer.Serialize(textWriter, _lokations);
                textWriter.Close();
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