using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AttendanceKeeper.Data;

namespace AttendanceKeeper.Classes
{
    public class JEnrollee : Enrollee
    {
        public new int EnrolleeId { get; set; }
        public new int?  EnrolleeNo { get; set; }
        public new string EnrolleeIdNo { get; set; }
        public new string LastName { get; set; }
        public new string FirstName { get; set; }
        public new string MiddleName { get; set; }
        public new int DepartmentId { get; set; }
        public new int PositionId { get; set; }
        public new int SettingId { get; set; }

        public string  SDepartment { get; set; }
        public string  SPosition { get; set; }

        public string GetFullName
        {
            get
            {
                return FullName();
            }
        }

        public string FullName()
        {
            return LastName.Trim().ToUpper() + ", " + FirstName.Trim() + " " + MiddleName.Substring(0, 1) + ".";
        }
    }
}
