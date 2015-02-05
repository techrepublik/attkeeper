using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectManager
{
    public class JDTR
    {
        public string EmployeeName { get; set; }
        public string Duration { get; set; }
        public string NoOfHoursDuty { get; set; }
        public DateTime? DTRDate { get; set; }
        public string DTRDay { get; set; }
        public int DTRId { get; set; }
        public string DTRStatus { get; set; }
        public string EditedBy { get; set; }
        public DateTime EditedOn { get; set; }
        public string TimeInAM { get; set; }
        public string TimeInOT { get; set; }
        public string TimeInPM { get; set; }
        public string TimeOutAM { get; set; }
        public string TimeOutOT { get; set; }
        public string TimeOutPM { get; set; }
        public double? TotalHour { get; set; }
        public double? TotalHours { get; set; }
        public double? TotalMinute { get; set; }
    }
}
