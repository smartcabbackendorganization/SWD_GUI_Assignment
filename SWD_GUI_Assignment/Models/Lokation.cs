using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_GUI_Assignment.Models
{
   public class Lokation
    {
        public Lokation()
        {
            MeasurementTrees = new ObservableCollection<MeasurementTree>();
        }

        public int Id { get; set; }

        public string Navn{ get; set; }
        public string Vej { get; set; }

        public int Vejnummer { get; set; }

        public string Postnummer { get; set; }

        public string By { get; set; }

        public ObservableCollection<MeasurementTree> MeasurementTrees { get; set; }

        public int SamletAntal
        {
            get => MeasurementTrees.Sum(x => x.Antal);
        } 
    }
}
