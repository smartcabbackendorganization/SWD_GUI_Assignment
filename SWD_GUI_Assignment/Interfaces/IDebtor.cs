namespace SWD_GUI_Assignment.Interfaces
{
    public interface IDebtor
    {
        string Name { get; set; }
        double Balance { get; set; }
        void AddTransaction(ITransaction transaction);
    }
}