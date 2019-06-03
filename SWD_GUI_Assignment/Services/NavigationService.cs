
using SWD_GUI_Assignment.ViewModels;
using SWD_GUI_Assignment.Views;

namespace SWD_GUI_Assignment.Services
{
    public class NavigationService
    {
        public bool? ShowModal(AddLokationViewModel vm)
        {
            var window = new AddLokationWindow();
            window.DataContext = vm;
            return window.ShowDialog();
        }


        private AddLokationWindow windowLokation = null;
        public void ShowModeless(AddLokationViewModel vm)
        {
            windowLokation = new AddLokationWindow();
            windowLokation.DataContext = vm;
            windowLokation.Show();
            vm.Close += (arg1,arg2) => { windowLokation.Close(); };
            vm.Save += (arg1, arg2) => { windowLokation.Close(); };
        }

        public void FocusLokationWindow()
        {
            if (windowLokation != null)
            {
                windowLokation.Focus();
            }
        }

        public bool? ShowModal(AddTreeViewModel vm)
        {
            var window = new AddTreeWindow();
            window.DataContext = vm;
            
            return window.ShowDialog();
        }
    }
}