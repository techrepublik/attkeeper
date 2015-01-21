using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBiometric.Entities
{
    public class Enrollee
    {
        public int  IMachineNumber { get; set; }
        public int  IEMachineNumber { get; set; }
        public int  IEnrollNumber { get; set; }             //B&W device
        public string SEnrollNumber { get; set; }           //Colored device
        public int  IBackupNumber { get; set; }
        public int  IMachinePrivilege { get; set; }
        public int  IFingerPrint { get; set; }
        public int  IPassword { get; set; }
        public string  SName { get; set; }
        public bool  BEnabled { get; set; }
        public string  STmpData { get; set; }
        public int  ITmpLength { get; set; }

        public string SIdNo { get; set; }
        public string SLastName { get; set; }
        public string SFirstName { get; set; }
        public string SMiddleName { get; set; }
        public string SSex { get; set; }
        public string SAddress { get; set; }
        public DateTime DTBirthDate { get; set; }
        public DateTime DTDateHired { get; set; }

        public string GetFullName()
        {
            return SLastName.Trim().ToUpper() + ", " + SFirstName.Trim() + " " + SMiddleName.Substring(0, 1) + ".";
        }
    }
}
