using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBiometric.Entities
{
    public class Attendance : Enrollee
    {
        public DateTime DTAttDate { get; set; }
        
        public DateTime DTAttTimeInAM { get; set; }
        public DateTime DTAttTimeOutAM { get; set; }
        public DateTime DTAttTimeInPM { get; set; }
        public DateTime DTAttTimeOutPM { get; set; }
        public DateTime DTAttTimeInOT { get; set; }
        public DateTime DTAttTimeOutOT { get; set; }
        
        public int  IAttLocation { get; set; }
            //ILocation
            // 1 - TimeInAM, 2 - TimeOutAM, 3 - TimeInPM, 
            // 4 - TimeOutPM, 5 - TimeInOT, 6 - TimeOutOT, 7 - Delinquent
    }
}
