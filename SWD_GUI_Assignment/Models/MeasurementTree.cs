using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_GUI_Assignment.Models
{
    public class MeasurementTree
    {
        public MeasurementTree()
        {
            Antal = 1;
            Art = "Art";
        }

        private string _art;
        private int _antal;

        public string Art
        {
            get => _art;
            set
            {
                if (value == "")
                {
                    throw new ApplicationException("Art is mandatory");
                }
                _art = value;

            }
        }

        public int Antal
        {
            get => _antal;
            set
            {
                if (value == 0)
                {
                    throw new ApplicationException("Count shuold be above zero");
                }
                _antal = value;
            } 
        }
    }
}
