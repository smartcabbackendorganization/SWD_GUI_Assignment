using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class RegistrerVarroeViewModel
    {
        [Required]
        public string LokationsId { get; set; }

        [Required]
        public string Træart { get; set; }

        [Required]
        public double Lat { get; set; }

        [Required]
        public double Lon { get; set; }
    }
}