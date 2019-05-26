using System;
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

            WindowTitle = "Varroe Optællings System";


            usersCollection = new CollectionViewSource();
            usersCollection.Source = _varroeMides;
            usersCollection.Filter += usersCollection_Filter;
            FilterText = "";

        }

        #region Properties

        private VarroeMides _varroeMides = new VarroeMides();

        private CollectionViewSource usersCollection;

        public ICollectionView SourceCollection
        {
            get
            {
                return this.usersCollection.View;
            }
        }


        public VarroeMides VarroeMides
        {
            get => _varroeMides;
            set => SetProperty(ref _varroeMides, value);
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
            }
        }


        #endregion

        #region Commands

        private DelegateCommand _addDebtorCommand;
        private AddDebtorViewModel vm;
        public DelegateCommand AddDebtorCommand => _addDebtorCommand ?? (_addDebtorCommand = new DelegateCommand(() =>
        {
             vm = new AddDebtorViewModel(_navigationService);
            //Modeless way of doing it
            vm.Save += (arg1, arg2) =>
            {
                Console.WriteLine(vm.VarroeMide.Name);
               // vm.VarroeMide.AddTransaction(new Transaction(vm.Amount));
                VarroeMides.Add(vm.VarroeMide);
                RaisePropertyChanged(nameof(VarroeMides));
                vm = null;
            };
            vm.Close += (arg1, arg2) =>
            {
                vm = null;
            };
            _navigationService.ShowModeless(vm);
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
            XmlSerializer serializer = new XmlSerializer(typeof(VarroeMides));
            StringWriter textWriter = new StringWriter();
            serializer.Serialize(textWriter,_varroeMides);


            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, textWriter.ToString());
        }



        #endregion
    }
}