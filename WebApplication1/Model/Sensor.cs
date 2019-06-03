using System;

namespace WebApplication1.Models
{
    public class Sensor
    {
        public Sensor()
        {
        }
        public string LokationsId { get; set; }

        public string CreatedBy { get; set; }

        public string Træart { get; set; }
        public string Sensorid { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
}