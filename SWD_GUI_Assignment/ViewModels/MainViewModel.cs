using SWD_GUI_Assignment.Models;
using SWD_GUI_Assignment.Services;

namespace SWD_GUI_Assignment.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private Debtors _debtors = new Debtors();

        public Debtors Debtors
        {
            get => _debtors;
            set => SetProperty(ref _debtors, value);
        }

        public MainViewModel()
        {
            _navigationService = new NavigationService();

            WindowTitle = "The Debt Book";
            _debtors.Add(new Debtor());
            _navigationService.Show(new AddDebtorViewModel(_navigationService));
        }
    }
}