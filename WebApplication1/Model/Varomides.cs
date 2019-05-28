using System;

namespace WebApplication1.Models
{
    public class Varomides
    {
        public Varomides()
        {
            CreatedAt = DateTime.Now;
        }
        public int Id { get; set; }

        public string Navn { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Count { get; set; }
        public int DaysObserved { get; set; }
        public string Comments { get; set; }
    }
}