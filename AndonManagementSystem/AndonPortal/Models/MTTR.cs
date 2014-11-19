using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AndonPortal.Models
{
    public class MTTR
    {
        public String Station{ get; set; }
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
        public MTTR( String Station , int BreakDowns , int Downtime)
        {
            this.Station = Station;
            this.Value = (BreakDowns == 0 )? 0: ((double)Downtime) / BreakDowns;
        }


    }
}