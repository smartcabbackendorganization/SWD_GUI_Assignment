using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using SWD_GUI_Assignment.Annotations;
using SWD_GUI_Assignment.Interfaces;

namespace SWD_GUI_Assignment.Models
{
    public class VarroeMide : INotifyPropertyChanged
    {
        private string _name;
        private int _varroMides;
        private string _comment;

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime CreatedAt { get; set; }

        public int VarroMides
        {
            get => _varroMides;
            set
            {
                if (value == _varroMides) return;
                _varroMides = value;
                OnPropertyChanged();
            }
        }

        public string Comment
        {
            get => _comment;
            set
            {
                if (value == _comment) return;
                _comment = value;
                OnPropertyChanged();
            }
        }

        public double Balance
        {
            get => 0;
        }



        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}