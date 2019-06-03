using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class RegistrerSensorViewModel
    {
        [Required]
        [Range(1,Int32.MaxValue, ErrorMessage = "LokationsId: Expected an integer value")]
        public string LokationsId { get; set; }

        [Required]
        public string Træart { get; set; }

        [Required]
        [RegularExpression("^[a-fA-F0-9]+$", ErrorMessage = "Please only write a hexidecimal number")]
        [StringLength(16, ErrorMessage = "SensorId should be 16 charactor long", MinimumLength = 16)]
        public string SensorId { get; set; }

        [Required]
        [Range(-90,90, ErrorMessage = "Lat: Expected an value between -90 and 90 degrees")]
        public double Lat { get; set; }

        [Required]
        [Range(-180, 180, ErrorMessage = "Lon: Expected an value between -90 and 90 degrees")]
        public double Lon { get; set; }
    }
}