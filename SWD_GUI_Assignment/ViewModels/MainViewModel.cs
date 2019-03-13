using SWD_GUI_Assignment.Services;

namespace SWD_GUI_Assignment.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            _navigationService = new NavigationService();

            WindowTitle = "Skyldnerlisten";

            //skal fjernes, kun for test
            _navigationService.Show(new EditDebtorViewModel(_navigationService));
        }
    }
}