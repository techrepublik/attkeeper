using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBiometric.Entities
{
    public class AttLog
    {
        public int  TMachineNumnber { get; set; }
        public int  EnrollNumber { get; set; }
        public int  EnrolleeNo { get; set; }
        public int  MachineNo { get; set; }
        public string SEnrollNumber { get; set; }
        public int  EMachineNumber { get; set; }
        public int  VerifyCode { get; set; }
        public int  InOutCode { get; set; }
        public int  IYear { get; set; }
        public int  IMonth { get; set; }
        public int  IDay { get; set; }
        public int  IHour { get; set; }
        public int  IMinute { get; set; }
        public int  IMin { get; set; }
        public int  ISecond { get; set; }
        public string STime { get; set; } //for long time
        public int  IWorkCode { get; set; }
        public int  IReserved { get; set; }

        public int  ErrorCode { get; set; }
        public int  GLCount { get; set; }
        public int  Index { get; set; }

        public string GetDate()
        {
            return IMonth.ToString() + "/" + IDay.ToString() + "/" + IYear.ToString();
        }

        public string GetTime(int iType)
        {
            if (iType == 1)
                return IHour.ToString() + ":" + IMinute.ToString() + ":" + ISecond.ToString();
            else 
                return IHour.ToString() + ":" + IMinute.ToString();
        }
    }
}
