using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Inspiration gotten from https://stackoverflow.com/questions/9262221/c-sharp-class-auto-increment-id
/// </summary>
namespace SWD_GUI_Assignment.Models
{
   public class Lokation  :ICloneable
    {
        static int nextId;
        public Lokation()
        {
            MeasurementTrees = new ObservableCollection<MeasurementTree>();
            Id = Interlocked.Increment(ref nextId);
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

        public object Clone() { return this.MemberwiseClone(); }
    }
}
