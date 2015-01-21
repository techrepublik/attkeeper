using System;

namespace AttendanceKeeper.Classes
{
    class JDTRClass : JEnrollee
    {
        public double DTotalMin { get; set; }
        public double DTotalHr { get; set; }
        public double DTotalHour { get; set; }
        public double DRegHour { get; set; }
        
        public double DUnderTime
        {
            get { return GetOverUnderTime(); }
        }
        public DateTime DTRDate { get; set; }

        public string SStatus { get; set; }

        private double GetOverUnderTime()
        {
            return DTotalHour; // -DRegHour;
        }

        public DateTime JDTDate { get; set; }
        public string JTimeInAM { get; set; }
        public string JTimeOutAM { get; set; }
        public string JTimeInPM { get; set; }
        public string JTimeOutPM { get; set; }
        public string JTimeInOT { get; set; }
        public string JTimeOutOT { get; set; }

        public bool JIsSource { get; set; }
        public string JEditedBy { get; set; }
        public DateTime JEditedOn { get; set; }
    }
}
