using SWD_GUI_Assignment.Interfaces;
using SWD_GUI_Assignment.Models;

namespace SWD_GUI_Assignment.ViewModels
{
    public class EditDebtorViewModel : BaseViewModel
    {
        private Debtor _activeDebtor;

        public Debtor ActiveDebtor
        {
            get { return _activeDebtor; }
            set { _activeDebtor = value; }
        }

        public EditDebtorViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            ActiveDebtor=new Debtor();
            ActiveDebtor.AddTransaction(new Transaction(10.5));
            ActiveDebtor.AddTransaction(new Transaction(15.4));

            WindowTitle = "Rediger skyldner";
        }
    }
}