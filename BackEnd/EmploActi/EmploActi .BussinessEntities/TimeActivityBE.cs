using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploActi.BussinessEntities
{
    public class TimeActivityBE
    {
        public int CodeTimeActivity { get; set; }
        public int ActivitiesCode { get; set; }
        public string NameActivities { get; set; }
        public DateTime DateActivity { get; set; }
        public int Hours { get; set; }
        public int IdUser { get; set; }
    }
}
