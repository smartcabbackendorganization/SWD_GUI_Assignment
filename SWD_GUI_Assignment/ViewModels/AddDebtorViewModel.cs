using SWD_GUI_Assignment.Interfaces;

namespace SWD_GUI_Assignment.ViewModels
{
    public class AddDebtorViewModel : BaseViewModel
    {
        public AddDebtorViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            WindowTitle = "Tilføj skyldner";
        }
    }
}