using SWD_GUI_Assignment.Interfaces;
using SWD_GUI_Assignment.ViewModels;
using SWD_GUI_Assignment.Views;

namespace SWD_GUI_Assignment.Services
{
    public class NavigationService : IShowViewOfViewModel<AddModelViewModel>, IShowViewOfViewModel<EditDebtorViewModel>
    {
        public bool? ShowModal(AddModelViewModel vm)
        {
            var window = new AddModelWindow();
            window.DataContext = vm;
            return window.ShowDialog();
        }

        public void ShowModeless(AddModelViewModel vm)
        {
            var window = new AddModelWindow();
            window.DataContext = vm;
            window.Show();
            vm.Close += (arg1,arg2) => {window.Close(); };
            vm.Save += (arg1, arg2) => { window.Close(); };
        }

        public bool? ShowModal(AddJobViewModel vm)
        {
            var window = new AddJobWindow();
            window.DataContext = vm;
            return window.ShowDialog();
        }

        public void ShowModeless(AddJobViewModel vm)
        {
            var window = new AddJobWindow();
            window.DataContext = vm;
            window.Show();
            vm.Close += (arg1, arg2) => { window.Close(); };
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