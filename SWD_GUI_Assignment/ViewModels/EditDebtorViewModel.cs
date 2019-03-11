using SWD_GUI_Assignment.Interfaces;

namespace SWD_GUI_Assignment.ViewModels
{
    public class EditDebtorViewModel : BaseViewModel
    {
        public EditDebtorViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            WindowTitle = "Rediger skyldner";
        }
    }
}