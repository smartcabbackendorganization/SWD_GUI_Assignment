using System;
using System.Data;

namespace WebApplication1.Models
{
    public class Sensor
    {
        public Sensor()
        {
        }
        public int Id { get; set; }

        public string LokationsId { get; set; }

        public string CreatedBy { get; set; }

        public string Træart { get; set; }

        public string Sensorid { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
}