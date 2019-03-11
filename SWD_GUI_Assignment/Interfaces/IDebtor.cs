namespace SWD_GUI_Assignment.Interfaces
{
    interface IDebtor
    {
        double Balance { get; set; }
        void AddTransaction(ITransaction transaction);
    }
}