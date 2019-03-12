using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_GUI_Assignment.Models
{
    public class Debtors : ObservableCollection<Debtor>
    {
        // Don't think databinding will work this way - but should be tested
        public double Balance
        {
            get { return this.Items.Sum(item => item.Balance); }
        }
    }
}
