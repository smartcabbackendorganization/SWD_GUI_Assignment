using System;

namespace SWD_GUI_Assignment.Interfaces
{
    public interface ITransaction
    {
        DateTime CreatedAt { get; set; }
        double Amount { get; set; }
    }
}