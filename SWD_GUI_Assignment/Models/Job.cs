using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_GUI_Assignment.Models
{
    public class Job
    {
        public string Kunde { get; set; }
        public string StartDato { get; set; }

        public int AntalDage { get; set; }

        public string Adresse { get; set; }

        public int AntalModeller { get; set; }

        public string Kommentarer { get; set; }
    }
}
