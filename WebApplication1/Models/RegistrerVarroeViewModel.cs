using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class RegistrerVarroeViewModel
    {
        [Required]
        [StringLength(18, ErrorMessage = "Maximum length is 18")]
        public string Navn { get; set; }

        public DateTime CreatedAt { get; set; }
        [Required]
        public int Count { get; set; }

        [Required]
        public int DaysObserved { get; set; }

        [Required]
        public string Comments { get; set; }
    }
}