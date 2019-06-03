using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
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


            usersCollection = new CollectionViewSource();
            usersCollection.Source = _models;
            //usersCollection.Filter += usersCollection_Filter;
            FilterText = "";

        }

        #region Properties

        private ObservableCollection<Lokation> _models = new ObservableCollection<Lokation>();

        public ObservableCollection<Lokation> Models
        {
            get => _models;
            set => SetProperty(ref _models, value);
        }


        private ObservableCollection<Job> _jobs = new ObservableCollection<Job>();

        public ObservableCollection<Job> Jobs
        {
            get => _jobs;
            set => SetProperty(ref _jobs, value);
        }

        private CollectionViewSource usersCollection;

        public ICollectionView SourceCollection
        {
            get
            {
                return this.usersCollection.View;
            }
        }

        public string FilterText
        {
            get
            {
                return filterText;
            }
            set
            {
                filterText = value;
                this.usersCollection.View.Refresh();
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

            VarroeMide usr = e.Item as VarroeMide;
            if (usr.Name.ToUpper().Contains(FilterText.ToUpper()))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
                e.Accepted = true;
            }
        }


        #endregion

        #region Commands

        private DelegateCommand _addDebtorCommand;
        private AddModelViewModel vm;
        public DelegateCommand AddDebtorCommand => _addDebtorCommand ?? (_addDebtorCommand = new DelegateCommand(() =>
        {
             vm = new AddModelViewModel(_navigationService);
            //Modeless way of doing it
            vm.Save += (arg1, arg2) =>
            {
                _models.Add(vm.Lokation);
                RaisePropertyChanged(nameof(Models));
                vm = null;
            };
            vm.Close += (arg1, arg2) =>
            {
                vm = null;
            };
            _navigationService.ShowModeless(vm);
        }));


        private DelegateCommand _addJobCommand;
        private AddJobViewModel vmJob;
        public DelegateCommand AddJobCommand => _addJobCommand ?? (_addJobCommand = new DelegateCommand(() =>
        {
            vmJob = new AddJobViewModel(_navigationService);
            if (_navigationService.ShowModal(vmJob) == true)
            {
                _jobs.Add(vmJob.Job);
            };
        }));



        private DelegateCommand<VarroeMide> _editDebtorCommand;
        private string filterText;

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
            XmlSerializer serializer = new XmlSerializer(typeof(List<Lokation>));
            StringWriter textWriter = new StringWriter();
            serializer.Serialize(textWriter,_models);


            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, textWriter.ToString());
        }



        #endregion
    }
}