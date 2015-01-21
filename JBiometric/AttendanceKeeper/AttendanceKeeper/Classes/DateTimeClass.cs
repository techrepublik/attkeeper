using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttendanceKeeper.Classes
{
    public class DateTimeClass
    {
        public static string VerifyDay(DateTime dt)
        {
            DayOfWeek day = dt.DayOfWeek;
            return day.ToString();
        }

        public static int GetDaysInMonth(int iYear, int iMonth)
        {
            return DateTime.DaysInMonth(iYear, iMonth);
        }

        public static bool IsCompareTime(DateTime timeTo, DateTime timeBase1, int iCompareType)
        {
            bool bResult = false;
            if (iCompareType == 0)
            {
                if (((timeTo.Hour > timeBase1.Hour) ||
                     ((timeTo.Hour == timeBase1.Hour) && (timeTo.Minute >= timeBase1.Minute))))
                {
                    bResult = true;
                }
            }
            else
            {
                if (((timeTo.Hour < timeBase1.Hour) ||
                     ((timeTo.Hour == timeBase1.Hour) && (timeTo.Minute <= timeBase1.Minute))))
                {
                    bResult = true;
                }
            }
            return bResult;
        }

        public static string Convert24To12Format(string tTime)
        {
            DateTime dt = Convert.ToDateTime(tTime);
            return dt.ToString("hh:mm tt");
        }

        
    }
}
