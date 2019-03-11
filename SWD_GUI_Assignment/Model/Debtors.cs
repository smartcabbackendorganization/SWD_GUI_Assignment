using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_GUI_Assignment.Model
{




    class Debtors : ObservableCollection<Debtor>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private double Balance { get; set; }
    }
}
