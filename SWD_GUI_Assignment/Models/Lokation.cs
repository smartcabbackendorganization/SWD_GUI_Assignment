using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_GUI_Assignment.Models
{
   public class Lokation
    {
        public int Id { get; set; }

        public string Navn{ get; set; }
        public string Vej { get; set; }

        public int Vejnummer { get; set; }

        public string Postnummer { get; set; }

        public string By { get; set; }

        public List<MeasurementTree> MeasurementTrees { get; set; }

        public int SamletAntal
        {
            get => MeasurementTrees.Sum(x => x.Antal);
        } 
    }
}
