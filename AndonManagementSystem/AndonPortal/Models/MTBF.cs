using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AndonPortal.Models
{
    public class MTBF
    {
        public String  Station{ get; set; }

        double value;
        public double Value
        {

            get
            {
                return Math.Round(value, 2);
            }
            set
            {
                this.value = value;
            }
        }

        public MTBF(String station, int breakdowns, int shifts)
        {
            this.Station = station;
            Value = (breakdowns == 0) ? 0 : shifts * 7.16 / breakdowns;
        }
    }
}