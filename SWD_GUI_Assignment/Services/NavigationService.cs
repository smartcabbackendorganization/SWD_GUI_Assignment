using SWD_GUI_Assignment.Interfaces;
using SWD_GUI_Assignment.ViewModels;
using SWD_GUI_Assignment.Views;

namespace SWD_GUI_Assignment.Services
{
    public class NavigationService : INavigationService
    {
        public bool? ShowModal(AddDebtorViewModel vm)
        {
            var window = new AddDebtorWindow();
            window.DataContext = vm;
            return window.ShowDialog();
        }

        public void ShowModeless(AddDebtorViewModel vm)
        {
            var window = new AddDebtorWindow();
            window.DataContext = vm;
            window.Show();
            vm.Close += (arg1,arg2) => {window.Close(); };
            vm.Save += (arg1, arg2) => { window.Close(); };
        }

        public bool? ShowModal(EditDebtorViewModel vm)
        {
            var window = new EditDebtorWindow();
            window.DataContext = vm;
            
            return window.ShowDialog();
        }

        public void ShowModeless(EditDebtorViewModel vm)
        {
            throw new System.NotImplementedException();
        }
    }
}