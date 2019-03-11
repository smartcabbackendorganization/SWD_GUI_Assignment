using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_GUI_Assignment.Model
{




    class Debtors : ObservableCollection<Debtor>
    {
        private double Balance { get; set; }
    }
}
