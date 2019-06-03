using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SWD_GUI_Assignment.Annotations;

/// <summary>
/// Inspiration gotten from https://stackoverflow.com/questions/9262221/c-sharp-class-auto-increment-id
/// </summary>
namespace SWD_GUI_Assignment.Models
{
   public class LokationWithSimpleTree 
    {
        public LokationWithSimpleTree()
        {
        }

        public int Id { get; set; }

        public string Navn{ get; set; }
        public string Vej { get; set; }

        public int Vejnummer { get; set; }

        public string Postnummer { get; set; }

        public string By { get; set; }

        public string MeasurementTrees { get; set; }
    }
}
