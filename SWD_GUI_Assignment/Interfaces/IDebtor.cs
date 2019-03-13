using System.Collections.ObjectModel;

namespace SWD_GUI_Assignment.Interfaces
{
    public interface IDebtor
    {
        string Name { get; set; }
        double Balance { get; }
        ObservableCollection<ITransaction> Transactions { get; set; }
        void AddTransaction(ITransaction transaction);
    }
}