namespace SWD_GUI_Assignment.Interfaces
{
    public interface IDebtor
    {
        double Balance { get; set; }
        void AddTransaction(ITransaction transaction);
    }
}