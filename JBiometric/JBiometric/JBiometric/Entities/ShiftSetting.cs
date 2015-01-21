using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBiometric.Entities
{
    public class ShiftSetting
    {
        public int IShiftNo { get; set; }
        public int IShiftNoHours { get; set; }
        public DateTime DTTimeInAM { get; set; }                //TimeIn in the morning
        public DateTime DTTimeOutAM { get; set; }               //TimeOut in the morning
        public DateTime DTTimeInPM { get; set; }                //TimeIn in the afternoon
        public DateTime DTTimeOutPM { get; set; }               //TimeOut in the afternoon
        public DateTime DTOverTimeIn { get; set; }              //TimeIn in the overtime
        public DateTime DTOverTimeOut { get; set; }             //TimeOut in the overtime
        public DateTime DTTimeInAM_Interval01 { get; set; }     //TimeInAM interval START
        public DateTime DTTimeInAM_Interval02 { get; set; }     //TimeInAM interval END
        public DateTime DTTimeOutAM_Interval01 { get; set; }    //TimeOutAM interval START
        public DateTime DTTimeOutAM_Interval02 { get; set; }    //TimeOutAM interval END
        public DateTime DTTimeInPM_Interval01 { get; set; }     //TimeInPM interval START
        public DateTime DTTimeInPM_Interval02 { get; set; }     //TimeInPM interval END
        public DateTime DTTimeOutPM_Interval01 { get; set; }    //TimeOutPM interval START
        public DateTime DTTimeOutPM_Interval02 { get; set; }    //TimeOutPM interval END
        public DateTime DTOverTimeIn_Interval01 { get; set; }   //TimeOverIN interval START
        public DateTime DTOverTimeIn_Interval02 { get; set; }   //TimeOverIN interval END
        public DateTime DTOverTimeOut_Interval01 { get; set; }  //TimeOverOUT interval START
        public DateTime DTOverTimeOut_Interval02 { get; set; }  //TimeOverOUT interval END

        public int ILateAM { get; set; }                        //No. of minutes to consider late in AM
        public int ILatePM { get; set; }                        //No. of minutes to consider late in PM
        public int ILateOT { get; set; }                        //No. of minutes to consider late in OT

        public bool BIsHoliday { get; set; }
        public DateTime DTHolidayDate { get; set; }
    }
}
