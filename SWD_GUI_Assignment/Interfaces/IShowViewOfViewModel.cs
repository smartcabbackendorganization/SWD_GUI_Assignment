namespace SWD_GUI_Assignment.Interfaces
{
    public interface IShowViewOfViewModel<T>
    {
        bool? Show(T vm);
    }
}