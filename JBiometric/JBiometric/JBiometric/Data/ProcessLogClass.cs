using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JBiometric.Entities;

namespace JBiometric.Data
{
    public class ProcessLogClass
    {
        //single enrollee Attendance Log information
        public static List<Attendance> LoadEnrolleeAttendance(Enrollee eEnrollee, List<AttLog> lAttLog)
        {
            var lAttendance = new List<Attendance>();
            int iLoc = 1;
            foreach (var log in lAttLog)
            {
                string dtTime = log.IHour + ":" + log.IMinute + ":" + log.ISecond;
                string dtDate = log.IMonth + "/" + log.IDay + "/" + log.IYear;

                Attendance att = lAttendance.FirstOrDefault(at => at.DTAttDate == DateTime.Parse(dtDate));
                
                if (att != null)
                {
                    att.DTAttDate = DateTime.Parse(dtDate);
                    att.IEnrollNumber = eEnrollee.IEnrollNumber;
                    att.SEnrollNumber = eEnrollee.SEnrollNumber;
                    
                    //iLoc = VerifyShiftSetting(eEnrollee.IEnrollNumber.ToString(), DateTime.Parse(dtDate), DateTime.Parse(dtTime));
                    switch (iLoc)
                    {
                        case 1:
                            att.DTAttTimeInAM = DateTime.Parse(dtTime);
                            break;
                        case 2:
                            att.DTAttTimeOutAM = DateTime.Parse(dtTime);
                            break;
                        case 3:
                            att.DTAttTimeInPM = DateTime.Parse(dtTime);
                            break;
                        case 4:
                            att.DTAttTimeOutPM = DateTime.Parse(dtTime);
                            break;
                        case 5:
                            att.DTAttTimeInOT = DateTime.Parse(dtTime);
                            break;
                        case 6:
                            att.DTAttTimeOutOT = DateTime.Parse(dtTime);
                            break;
                        case 7:

                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    att = new Attendance();
                    //iCountAtt = lAttLog.Count<AttLog>(attl => attl.GetDate() == dtDate);
                    att.DTAttDate = DateTime.Parse(dtDate);
                    att.IEnrollNumber = eEnrollee.IEnrollNumber;
                    att.SEnrollNumber = eEnrollee.SEnrollNumber;
                    //iLoc = VerifyShiftSetting(eEnrollee.IEnrollNumber.ToString(), DateTime.Parse(dtDate), DateTime.Parse(dtTime));
                    switch (iLoc)
                    {
                        case 1:
                            att.DTAttTimeInAM = DateTime.Parse(dtTime);
                            break;
                        case 2:
                            att.DTAttTimeOutAM = DateTime.Parse(dtTime);
                            break;
                        case 3:
                            att.DTAttTimeInPM = DateTime.Parse(dtTime);
                            break;
                        case 4:
                            att.DTAttTimeOutPM = DateTime.Parse(dtTime);
                            break;
                        case 5:
                            att.DTAttTimeInOT = DateTime.Parse(dtTime);
                            break;
                        case 6:
                            att.DTAttTimeOutOT = DateTime.Parse(dtTime);
                            break;
                        case 7:

                            break;
                        default:
                            break;
                    }
                    lAttendance.Add(att);
                }
                iLoc += 1;
            }
            
            return lAttendance;
        }

        public static List<Attendance> LoadEnrolleeAttendanceAll(List<Enrollee> lEnrollee, List<AttLog> lAttLog)
        {
            var lAttendance = new List<Attendance>();

            foreach (var enr in lEnrollee)
            {
                int iLoc = 1;
                Enrollee enrollee = enr;
                foreach (var log in lAttLog.FindAll(a => a.SEnrollNumber == enrollee.SEnrollNumber) )
                {
                    string dtTime = log.IHour + ":" + log.IMinute + ":" + log.ISecond;
                    string dtDate = log.IMonth + "/" + log.IDay + "/" + log.IYear;

                    Attendance att = lAttendance.FirstOrDefault(at => at.DTAttDate == DateTime.Parse(dtDate));

                    if (att != null)
                    {
                        att.DTAttDate = DateTime.Parse(dtDate);
                        att.IEnrollNumber = enrollee.IEnrollNumber;
                        att.SEnrollNumber = enrollee.SEnrollNumber;
                        //iLoc = VerifyShiftSetting(eEnrollee.IEnrollNumber.ToString(), DateTime.Parse(dtDate), DateTime.Parse(dtTime));

                        switch (iLoc)
                        {
                            case 1:
                                att.DTAttTimeInAM = DateTime.Parse(dtTime);
                                break;
                            case 2:
                                att.DTAttTimeOutAM = DateTime.Parse(dtTime);
                                break;
                            case 3:
                                att.DTAttTimeInPM = DateTime.Parse(dtTime);
                                break;
                            case 4:
                                att.DTAttTimeOutPM = DateTime.Parse(dtTime);
                                break;
                            case 5:
                                att.DTAttTimeInOT = DateTime.Parse(dtTime);
                                break;
                            case 6:
                                att.DTAttTimeOutOT = DateTime.Parse(dtTime);
                                break;
                            case 7:

                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        att = new Attendance();
                        //iCountAtt = lAttLog.Count<AttLog>(attl => attl.GetDate() == dtDate);
                        att.DTAttDate = DateTime.Parse(dtDate);
                        att.IEnrollNumber = enrollee.IEnrollNumber;
                        att.SEnrollNumber = enrollee.SEnrollNumber;
                        //iLoc = VerifyShiftSetting(eEnrollee.IEnrollNumber.ToString(), DateTime.Parse(dtDate), DateTime.Parse(dtTime));
                        switch (iLoc)
                        {
                            case 1:
                                att.DTAttTimeInAM = DateTime.Parse(dtTime);
                                break;
                            case 2:
                                att.DTAttTimeOutAM = DateTime.Parse(dtTime);
                                break;
                            case 3:
                                att.DTAttTimeInPM = DateTime.Parse(dtTime);
                                break;
                            case 4:
                                att.DTAttTimeOutPM = DateTime.Parse(dtTime);
                                break;
                            case 5:
                                att.DTAttTimeInOT = DateTime.Parse(dtTime);
                                break;
                            case 6:
                                att.DTAttTimeOutOT = DateTime.Parse(dtTime);
                                break;
                            case 7:

                                break;
                            default:
                                break;
                        }
                        lAttendance.Add(att);
                    }
                    iLoc += 1;
                }
            }
            return lAttendance;
        }

        public static int VerifyShiftSetting(string sEnrollNumber, 
            DateTime dtDate, DateTime dtTime, ShiftSetting shiftSetting )
        {
            int iSet = 0;

            //if (!dtDate.Equals(shiftSetting.DTHolidayDate))
            //{
                if ((dtTime >= shiftSetting.DTTimeInAM_Interval01) && (dtTime <= shiftSetting.DTTimeInAM_Interval02))
                {
                    //TO DO -> put in the TimeInAM
                    iSet = 1;
                }
                else if ((dtTime >= shiftSetting.DTTimeOutAM_Interval01) && (dtTime <= shiftSetting.DTTimeOutAM_Interval02))
                {
                    //TO DO -> put in the TimeOutAM
                    iSet = 2;
                }
                else if ((dtTime >= shiftSetting.DTTimeInPM_Interval01) && (dtTime <= shiftSetting.DTTimeInPM_Interval02))
                {
                    //TO DO -> put in the TimeInPM   
                    iSet = 3;
                } 
                else if ((dtTime >= shiftSetting.DTTimeOutPM_Interval01) && (dtTime <= shiftSetting.DTTimeOutPM_Interval02))
                {
                    //TO DO -> put in the TimeOutPM
                    iSet = 4;
                }
                else if ((dtTime >= shiftSetting.DTOverTimeIn_Interval01) && (dtTime <= shiftSetting.DTOverTimeIn_Interval02))
                {
                    //TO DO -> put in the OverTimeIn
                    iSet = 5;
                }
                else if ((dtTime >= shiftSetting.DTOverTimeOut_Interval01) && (dtTime <= shiftSetting.DTOverTimeOut_Interval02))
                {
                    //TO DO -> put in the OverTimeOut
                    iSet = 6;
                }
                else
                {
                    iSet = 7;
                }
            //}

            return iSet;
        }
    }
}
