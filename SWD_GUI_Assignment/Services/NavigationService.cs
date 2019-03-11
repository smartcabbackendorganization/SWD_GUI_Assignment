using SWD_GUI_Assignment.Interfaces;
using SWD_GUI_Assignment.ViewModels;
using SWD_GUI_Assignment.Views;

namespace SWD_GUI_Assignment.Services
{
    public class NavigationService : INavigationService
    {
        public bool? Show(AddDebtorViewModel vm)
        {
            var window = new AddDebtorWindow();
            window.DataContext = vm;
            return window.ShowDialog();
        }

        public bool? Show(EditDebtorViewModel vm)
        {
            var window = new EditDebtorWindow();
            window.DataContext = vm;
            return window.ShowDialog();
        }
    }
}