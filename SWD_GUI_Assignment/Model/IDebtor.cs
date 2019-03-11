namespace SWD_GUI_Assignment.Model
{
    interface IDebtor
    {
        double Balance { get; set; }
        void AddTransaction(ITransaction transaction);
    }
}