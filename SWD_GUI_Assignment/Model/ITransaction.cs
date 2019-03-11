using System;

namespace SWD_GUI_Assignment.Model
{
    interface ITransaction
    {
        DateTime CreatedAt { get; set; }
        double Amount { get; set; }
    }
}