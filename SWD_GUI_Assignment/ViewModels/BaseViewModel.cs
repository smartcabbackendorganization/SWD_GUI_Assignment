using System.Windows.Navigation;
using Prism.Mvvm;
using NavigationService = SWD_GUI_Assignment.Services.NavigationService;
// Based from SWD GUI assignment, in group work with Frank Andersen And Jesper Strøm.
namespace SWD_GUI_Assignment.ViewModels
{

    public abstract class BaseViewModel : BindableBase
    {
        protected NavigationService _navigationService;

        protected string _windowTitle;
        public string WindowTitle
        {
            get => _windowTitle;
            set => SetProperty(ref _windowTitle, value);
        }

        #region DialogResultFix
        protected bool? _dialogResult;

        public bool? DialogResult
        {
            get => _dialogResult;
            set => SetProperty(ref _dialogResult, value);
        }
        #endregion
    }
}