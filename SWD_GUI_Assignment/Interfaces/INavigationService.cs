using SWD_GUI_Assignment.ViewModels;

namespace SWD_GUI_Assignment.Interfaces
{
    public interface INavigationService :
        IShowViewOfViewModel<AddModelViewModel>,
        IShowViewOfViewModel<EditDebtorViewModel>
    {

    }
}