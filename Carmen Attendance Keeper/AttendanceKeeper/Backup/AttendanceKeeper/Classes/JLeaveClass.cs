using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttendanceKeeper.Classes
{
    public class JLeaveClass : JEnrollee
    {
        public int  ILeaveId { get; set; }
        public string  SLeaveNo { get; set; }
        public DateTime? DTLeaveFrom { get; set; }
        public DateTime? DTLeaveTo  { get; set; }
        public string SLeaveType { get; set; }
        public int?  INoDays { get; set; }
        public string SReason { get; set; }
        public string SEditedBy { get; set; }
        public DateTime?  DTEditedOn  { get; set; }

        public string SLeaveDates { get { return GetLeaveDates(); }  }

        private string GetLeaveDates()
        {
            return String.Format("{0:d} - {1:d}", DTLeaveFrom, DTLeaveTo);
        }
    }
}
