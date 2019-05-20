namespace SWD_GUI_Assignment.Interfaces
{
    public interface IShowViewOfViewModel<T>
    {
        bool? ShowModal(T vm);

        void ShowModeless(T vm);
    }
}