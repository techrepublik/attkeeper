using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AttendanceKeeper.Data;
using Enrollee=AttendanceKeeper.Data.Enrollee;

namespace AttendanceKeeper.Classes
{
    class DataManagementClass
    {
        public static Dictionary<DateTime, string> LoadLeaveDictionary(int iEnrolleeId, int iMonth, int iYear)
        {
            string tempLeave = string.Empty;
            var dLeave = new Dictionary<DateTime, string>();

            using (var data = new DTRDataDataContext())
            {
                var q = from leave in data.Leaves
                        where (leave.EnrolleeId == iEnrolleeId)
                        select leave;

                var listLeave = q.ToList();

                foreach (var item in listLeave)
                {
                    //Leave l = listLeave.FirstOrDefault(le =>
                    //        ((le.EnrolleeId == iEnrolleeId) && (le.LeaveDateFrom.Value.Month == iMonth) &&
                    //         (le.LeaveDateFrom.Value.Year == iYear)));
                    if (item.LeaveDateFrom != null)
                        if ((item.LeaveDateFrom.Value.Month == iMonth) && (item.LeaveDateFrom.Value.Year == iYear))
                        {
                            for (int i = 0; i < item.LeaveNoDays; i++)
                            {
                                DateTime tempDt = Convert.ToDateTime(item.LeaveDateFrom);
                                DateTime tempDateTime = tempDt.AddDays(i);
                                tempLeave = item.LeaveType;
                                try
                                {
                                    dLeave.Add(tempDateTime, tempLeave);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(@"Error - " + ex.Message);
                                    //throw new Exception("Duplicate exist."); 
                                }
                            }
                        }
                }
            }
            return dLeave;
        }

        public static bool IsDTRExisting(DTR dtr)
        {
            var bResult = false;
            using (var data = new DTRDataDataContext())
            {
                bool bFlag = false;
                DTR d = data.DTRs.FirstOrDefault(dt => ((dtr.EnrolleeNo == dt.EnrolleeNo) && (dtr.DTRDate == dt.DTRDate)));
                if (d != null)
                {
                    if (dtr.TimeInAM != null)
                    {
                        if ((d.TimeInAM == null) )
                        {
                            d.TimeInAM = dtr.TimeInAM;
                            bFlag = true;
                        }
                        else if (d.TimeInAM.Trim().Length == 0)
                        {
                            d.TimeInAM = dtr.TimeInAM;
                            bFlag = true;
                        }
                    }
                    else if (dtr.TimeOutAM != null)
                    {
                        if ((d.TimeOutAM == null) )
                        {
                            d.TimeOutAM = dtr.TimeOutAM;
                            bFlag = true;
                        }
                        else if ((d.TimeOutAM.Trim().Length == 0))
                        {
                            d.TimeOutAM = dtr.TimeOutAM;
                            bFlag = true;
                        }
                    }
                    else if (dtr.TimeInPM != null)
                    {
                        if ((d.TimeInPM == null) )
                        {
                            d.TimeInPM = dtr.TimeInPM;
                            bFlag = true;
                        }
                        else if ((d.TimeInPM.Trim().Length == 0))
                        {
                            d.TimeInPM = dtr.TimeInPM;
                            bFlag = true;
                        }
                    }
                    else if (dtr.TimeOutPM != null)
                    {
                        if ((d.TimeOutPM == null) )
                        {
                            bFlag = true;
                            d.TimeOutPM = dtr.TimeOutPM;
                        }
                        else if ((d.TimeOutPM.Trim().Length == 0))
                        {
                            bFlag = true;
                            d.TimeOutPM = dtr.TimeOutPM;
                        }
                    }
                    else if (dtr.TimeInOT != null)
                    {
                        if ((d.TimeInOT == null) )
                        {
                            bFlag = true;
                            d.TimeInOT = dtr.TimeInOT;
                        }
                        else if((d.TimeInOT.Trim().Length == 0))
                        {
                            bFlag = true;
                            d.TimeInOT = dtr.TimeInOT;
                        }
                    }
                    else if (dtr.TimeOutOT != null)
                    {
                        if ((d.TimeOutOT == null) )
                        {
                            bFlag = true;
                            d.TimeOutOT = dtr.TimeOutOT;
                        }
                        else if ((d.TimeOutOT.Trim().Length == 0))
                        {
                            bFlag = true;
                            d.TimeOutOT = dtr.TimeOutOT;
                        }
                    }

                    if (bFlag == true)
                        ActionClass.SaveDTR(d);

                    bResult = true;
                }
            }
            return bResult;
        }

        public static bool IsMacDumpExisting(MacDumpLog macDumpLog)
        {
            var bResult = false;
            using (var data = new DTRDataDataContext())
            {
                MacDumpLog m = data.MacDumpLogs.FirstOrDefault( ma => ((macDumpLog.EnrolleeNo == ma.EnrolleeNo) && (macDumpLog.MacDumpDate == ma.MacDumpDate)));
                if (m != null)
                {
                    if (m.MacDumpTime != macDumpLog.MacDumpTime)
                    {
                        m.MacDumpTime = macDumpLog.MacDumpTime;

                        data.SubmitChanges();
                    }
                    bResult = true;
                }
            }
            return bResult;
        }

        #region "List<T>"

        public static List<JDTRClass> LoadDTRUpdated(int iYear, int iMonth, bool bSource)
        {
            List<JDTRClass> lJDTR = new List<JDTRClass>();
            using (var data = new DTRDataDataContext())
            {
                if ((iYear > 0) && (iMonth > 0))
                {
                    var q = from d in data.DTRs
                            where ((d.DTRDate.Value.Month == iMonth) && (d.DTRDate.Value.Year == iYear) &&
                                   (d.IsSource == bSource))
                            orderby d.DTRDate ascending
                            select new
                                       {
                                           d.EnrolleeNo,
                                           d.Enrollee.LastName,
                                           d.Enrollee.FirstName,
                                           d.Enrollee.MiddleName,
                                           d.DTRDate,
                                           d.TimeInAM,
                                           d.TimeOutAM,
                                           d.TimeInPM,
                                           d.TimeOutPM,
                                           d.TimeInOT,
                                           d.TimeOutOT,
                                           d.IsSource,
                                           d.EditedBy,
                                           d.EditedOn
                                       };

                    foreach (var list in q.ToList())
                    {
                        var j = new JDTRClass();
                        j.EnrolleeNo = list.EnrolleeNo;
                        j.LastName = list.LastName;
                        j.FirstName = list.FirstName;
                        j.MiddleName = list.MiddleName;
                        j.DTRDate = Convert.ToDateTime(list.DTRDate);
                        j.JTimeInAM = list.TimeInAM;
                        j.JTimeOutAM = list.TimeOutAM;
                        j.JTimeInPM = list.TimeInPM;
                        j.JTimeOutPM = list.TimeOutPM;
                        j.JTimeInOT = list.TimeInOT;
                        j.JTimeOutOT = list.TimeOutOT;
                        j.JIsSource = Convert.ToBoolean(list.IsSource);
                        j.JEditedBy = list.EditedBy;
                        j.JEditedOn = Convert.ToDateTime(list.EditedOn);
                        lJDTR.Add(j);
                    }
                }
            }
            return lJDTR;
        }

        public static List<JDTRClass> LoadDTROverUnder(int iYear, int iMonth)
        {
            Miscellaneous misc = GetMiscellaneous();
            var lJDtrs = new List<JDTRClass>();
            using (var data = new DTRDataDataContext())
            {
                var q = from d in data.DTRs
                        where ((d.DTRDate.Value.Year == iYear) && (d.DTRDate.Value.Month == iMonth))
                        orderby d.Enrollee.LastName ascending, d.Enrollee.FirstName ascending, d.DTRDate ascending
                        select new
                        {
                            d.DTRDate,
                            d.TotalHours,
                            d.Enrollee.FirstName,
                            d.Enrollee.LastName,
                            d.Enrollee.MiddleName,
                            d.Enrollee.EnrolleeId,
                            d.Enrollee.EnrolleeIdNo,
                            d.Enrollee.EnrolleeNo,
                            d.DTRStatus
                        };

                if (q != null)
                {
                    foreach (var dtr in q)
                    {
                        JDTRClass j = new JDTRClass();
                        j.DRegHour = Convert.ToDouble(misc.MiscRegularHours);
                        j.DTRDate = Convert.ToDateTime(dtr.DTRDate);
                        j.DTotalHour = Convert.ToDouble(dtr.TotalHours);

                        //if (j.DTotalHour == j.DRegHour)
                        //    j.SStatus = misc.MiscRegularLabel;
                        //else if (j.DTotalHour < j.DRegHour)
                        //    j.SStatus = misc.MiscUnderRegularLabel;
                        //else if (j.DTotalHour > j.DRegHour)
                        //    j.SStatus = misc.MiscOverRegularLabel;
                        j.SStatus = dtr.DTRStatus;

                        j.EnrolleeId = Convert.ToInt16(dtr.EnrolleeId);
                        j.EnrolleeNo = dtr.EnrolleeNo;
                        j.FirstName = dtr.FirstName;
                        j.LastName = dtr.LastName;
                        j.MiddleName = dtr.MiddleName;

                        lJDtrs.Add(j);
                    }
                }
            }
            return lJDtrs;
        }

        public static List<JLeaveClass> LoadLeaves()
        {
            List<JLeaveClass> lJL = new List<JLeaveClass>();
            using (var data = new DTRDataDataContext())
            {
                var q = from l in data.Leaves
                        orderby l.LeaveDateFrom descending
                        select new
                                   {
                                       l.EnrolleeId,
                                       l.Enrollee.EnrolleeIdNo,
                                       l.Enrollee.LastName,
                                       l.Enrollee.FirstName,
                                       l.Enrollee.MiddleName,
                                       l.Enrollee.EnrolleeNo,
                                       l.LeaveNo,
                                       l.LeaveDateFrom,
                                       l.LeaveDateTo,
                                       l.LeaveNoDays,
                                       l.LeaveType,
                                       l.LeaveReason,
                                       l.LeaveId,
                                       l.EditedBy,
                                       l.EditedOn
                                   };
                if (q != null)
                {
                    foreach (var item in q)
                    {
                        JLeaveClass jl = new JLeaveClass();
                        jl.EnrolleeId = Convert.ToInt16(item.EnrolleeId);
                        jl.EnrolleeIdNo = item.EnrolleeIdNo.Trim();
                        jl.EnrolleeNo = item.EnrolleeNo;
                        jl.LastName = item.LastName;
                        jl.FirstName = item.FirstName;
                        jl.MiddleName = item.MiddleName;
                        jl.ILeaveId = item.LeaveId;
                        jl.SLeaveNo = item.LeaveNo;
                        jl.DTLeaveFrom = item.LeaveDateFrom;
                        jl.DTLeaveTo = item.LeaveDateTo;
                        jl.SLeaveType = item.LeaveType;
                        jl.SReason = item.LeaveReason;
                        jl.INoDays = item.LeaveNoDays;
                        jl.SEditedBy = item.EditedBy;
                        jl.DTEditedOn = item.EditedOn;
                        lJL.Add(jl);
                    }
                }
            }
            return lJL;
        }

        public static List<JEnrollee> LoadEnrollees()
        {
            var lEnrollees = new List<JEnrollee>();
            using (var data = new DTRDataDataContext())
            {
                var q = from e in data.Enrollees
                        orderby e.LastName ascending
                        select new
                                   {
                                       EnrolleeId = e.EnrolleeId,
                                       EnrolleeNo = e.EnrolleeNo,
                                       LastName = e.LastName,
                                       FirstName = e.FirstName,
                                       MiddleName = e.MiddleName,
                                       e.DepartmentId,
                                       e.PositionId,
                                       e.SettingId
                                   };

                if (q != null)
                {
                    foreach (var item in q)
                    {
                        JEnrollee j = new JEnrollee();
                        j.EnrolleeId = item.EnrolleeId;
                        j.EnrolleeNo = (int)item.EnrolleeNo;
                        j.LastName = item.LastName;
                        j.FirstName = item.FirstName;
                        j.MiddleName = item.MiddleName;
                        j.DepartmentId = Convert.ToInt16(item.DepartmentId);
                        j.PositionId = Convert.ToInt16(item.PositionId);
                        j.SettingId = Convert.ToInt16(item.SettingId);

                        lEnrollees.Add(j);
                    }
                }
            }
            return lEnrollees;
        }

        public static List<JEnrollee> LoadEnrollees(bool bActive, int iDepartmentId)
        {
            var lEnrollees = new List<JEnrollee>();
            using (var data = new DTRDataDataContext())
            {
                var q = from e in data.Enrollees
                        where ((e.IsActive == bActive) && (e.DepartmentId == iDepartmentId))
                        orderby e.LastName ascending, e.FirstName ascending, e.MiddleName ascending 
                        select new
                        {
                            EnrolleeId = e.EnrolleeId,
                            EnrolleeNo = e.EnrolleeNo,
                            LastName = e.LastName,
                            FirstName = e.FirstName,
                            MiddleName = e.MiddleName,
                            e.DepartmentId,
                            e.PositionId,
                            e.SettingId
                        };

                if (q != null)
                {
                    foreach (var item in q)
                    {
                        JEnrollee j = new JEnrollee();
                        j.EnrolleeId = item.EnrolleeId;
                        j.EnrolleeNo = (int)item.EnrolleeNo;
                        j.LastName = item.LastName;
                        j.FirstName = item.FirstName;
                        j.MiddleName = item.MiddleName;
                        j.DepartmentId = Convert.ToInt16(item.DepartmentId);
                        j.PositionId = Convert.ToInt16(item.PositionId);
                        j.SettingId = Convert.ToInt16(item.SettingId);

                        lEnrollees.Add(j);
                    }
                }
            }
            return lEnrollees;
        }

        public static List<JEnrollee> LoadEnrollees(string sValue)
        {
            var lEnrollees = new List<JEnrollee>();
            using (var data = new DTRDataDataContext())
            {
                var q = from e in data.Enrollees
                        where ((e.LastName.StartsWith(sValue) || (e.EnrolleeNo.Value.ToString().Trim() == sValue)
                                || (e.EnrolleeIdNo.Trim() == sValue)))
                        orderby e.LastName ascending
                        select new
                        {
                            EnrolleeId = e.EnrolleeId,
                            EnrolleeNo = e.EnrolleeNo,
                            LastName = e.LastName,
                            FirstName = e.FirstName,
                            MiddleName = e.MiddleName,
                            e.DepartmentId,
                            e.PositionId,
                            e.SettingId
                        };

                if (q != null)
                {
                    foreach (var item in q)
                    {
                        JEnrollee j = new JEnrollee();
                        j.EnrolleeId = item.EnrolleeId;
                        j.EnrolleeNo = (int)item.EnrolleeNo;
                        j.LastName = item.LastName;
                        j.FirstName = item.FirstName;
                        j.MiddleName = item.MiddleName;
                        j.DepartmentId = Convert.ToInt16(item.DepartmentId);
                        j.PositionId = Convert.ToInt16(item.PositionId);
                        j.SettingId = Convert.ToInt16(item.SettingId);

                        lEnrollees.Add(j);
                    }
                }
            }
            return lEnrollees;
        }

        public static List<JEnrollee> LoadEnrolleesAll()
        {
            var lEnrolles = new List<JEnrollee>();
            using (var data = new DTRDataDataContext())
            {
                var q = data.SPLoadEnrolleeAll();
                if (q != null)
                {
                    foreach (var item in q)
                    {
                        var j = new JEnrollee();
                        j.EnrolleeId = item.EnrolleeId;
                        j.EnrolleeIdNo = item.EnrolleeIdNo;
                        j.EnrolleeNo = item.EnrolleeNo;
                        j.LastName = item.LastName;
                        j.FirstName = item.FirstName;
                        j.MiddleName = item.MiddleName;
                        j.Sex = item.Sex;
                        j.BirthDate = item.BirthDate;
                        j.DateHired = item.DateHired;
                        j.SDepartment = item.DepartmentName.Trim();
                        j.SPosition = item.PositionName.Trim();
                        lEnrolles.Add(j);
                    }
                }
            }
            return lEnrolles;
        }

        public static List<SettingDetail> LoadSettingDetail(int? iSettengId)
        {
            var data = new DTRDataDataContext();
            var q = from sd in data.SettingDetails
                    where (sd.SettingId == iSettengId)
                    select sd;
            return q.ToList();
        }

        public static List<DTR> LoadDTRViaLogs(Enrollee enrollee, int iMonth, int iYear, out List<MacDumpLog> lDumpLogs)
        {
            var lDTRs = new List<DTR>();
            var lMacDumpLog = new List<MacDumpLog>();
            string sError = string.Empty;
            List<Machine> lLogs = ActionClass.FillMachinesViaEnrollNo(int.Parse(enrollee.EnrolleeNo.ToString()));
            if (sError.Length > 0)
            {
                MessageBox.Show(sError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                lDTRs = LoadEnrolleeAttendanceDTR(enrollee, lLogs.FindAll(l => ((l.EnrolleeNo == enrollee.EnrolleeNo) && (l.IMonth == iMonth) && (l.IYear == iYear))), out lMacDumpLog, true);
            }
            lDumpLogs = lMacDumpLog;
            return lDTRs;
        }

        public static List<DTR> LoadEnrolleeAttendanceDTR(AttendanceKeeper.Data.Enrollee eEnrollee, List<Machine> lAttLog, out List<MacDumpLog> lDumpLogs, string sUserName)
        {
            var lAttendance = new List<DTR>();
            var lMacDumpLog = new List<MacDumpLog>();
            foreach (var log in lAttLog)
            {
                MacDumpLog oMacDump = null;
                var dtTime = string.Format("{0}:{1}", log.IHour, log.IMin); //+ ":" + log.ISecond;
                var dtDate = string.Format("{0}/{1}/{2}", log.IMonth, log.IDay, log.IYear);

                //var dtr = lAttendance.FirstOrDefault(at => at.DTRDate == DateTime.Parse(dtDate));
                var dtr = lAttendance.FirstOrDefault(at => at.DTRDate == DateTime.Parse(dtDate));

                var iLoc = 0;
                if (dtr != null)
                {
                    dtr.DTRDate = DateTime.Parse(dtDate);
                    dtr.EnrolleeNo = eEnrollee.EnrolleeNo;
                    dtr.EnrolleeId = eEnrollee.EnrolleeId;
                    dtr.IsSource = false;
                    dtr.EditedBy = sUserName;
                    dtr.EditedOn = DateTime.Now;

                    iLoc = VerifyShiftSettingViaList(eEnrollee.EnrolleeNo.ToString(), DateTime.Parse(dtDate), DateTime.Parse(dtTime), LoadSettingDetail(eEnrollee.SettingId));
                    switch (iLoc)
                    {
                        case 1:
                            if (dtr.TimeInAM != null)
                            {
                                oMacDump = new MacDumpLog();
                                //To Delinquent table
                                Console.WriteLine(dtTime);
                                oMacDump.MacDumpDate = dtDate;
                                oMacDump.MacDumpTime = DateTimeClass.Convert24To12Format(dtTime);

                                oMacDump.EnrolleeNo = eEnrollee.EnrolleeNo;
                                oMacDump.EnrolleeId = eEnrollee.EnrolleeId;
                                oMacDump.MachineNo = log.MachineNo;
                            }
                            else
                            {
                                dtr.TimeInAM = DateTimeClass.Convert24To12Format(dtTime);
                            }
                            break;
                        case 2:
                            if (dtr.TimeOutAM != null)
                            {
                                //To Delinquent table
                                oMacDump = new MacDumpLog();
                                Console.WriteLine(dtTime.ToString());
                                oMacDump.MacDumpDate = dtDate;
                                oMacDump.MacDumpTime = DateTimeClass.Convert24To12Format(dtTime);

                                oMacDump.EnrolleeNo = eEnrollee.EnrolleeNo;
                                oMacDump.EnrolleeId = eEnrollee.EnrolleeId;
                                oMacDump.MachineNo = log.MachineNo;
                            }
                            else
                            {
                                dtr.TimeOutAM = DateTimeClass.Convert24To12Format(dtTime); ;
                            }

                            break;
                        case 3:
                            if (dtr.TimeInPM != null)
                            {
                                //To Delinquent table
                                oMacDump = new MacDumpLog();
                                Console.WriteLine(dtTime.ToString());
                                oMacDump.MacDumpDate = dtDate;
                                oMacDump.MacDumpTime = DateTimeClass.Convert24To12Format(dtTime);

                                oMacDump.EnrolleeNo = eEnrollee.EnrolleeNo;
                                oMacDump.EnrolleeId = eEnrollee.EnrolleeId;
                                oMacDump.MachineNo = log.MachineNo;
                            }
                            else
                            {
                                dtr.TimeInPM = DateTimeClass.Convert24To12Format(dtTime); ;
                            }

                            break;
                        case 4:
                            if (dtr.TimeOutPM != null)
                            {
                                //To Delinquent table
                                oMacDump = new MacDumpLog();
                                Console.WriteLine(dtTime);
                                oMacDump.MacDumpDate = dtDate;
                                oMacDump.MacDumpTime = DateTimeClass.Convert24To12Format(dtTime);

                                oMacDump.EnrolleeNo = eEnrollee.EnrolleeNo;
                                oMacDump.EnrolleeId = eEnrollee.EnrolleeId;
                                oMacDump.MachineNo = log.MachineNo;
                            }
                            else
                            {
                                dtr.TimeOutPM = DateTimeClass.Convert24To12Format(dtTime); ;
                            }

                            break;
                        case 5:
                            if (dtr.TimeInOT != null)
                            {
                                //To Delinquent table
                                oMacDump = new MacDumpLog();
                                Console.WriteLine(dtTime);
                                oMacDump.MacDumpDate = dtDate;
                                oMacDump.MacDumpTime = DateTimeClass.Convert24To12Format(dtTime);

                                oMacDump.EnrolleeNo = eEnrollee.EnrolleeNo;
                                oMacDump.EnrolleeId = eEnrollee.EnrolleeId;
                                oMacDump.MachineNo = log.MachineNo;
                            }
                            else
                            {
                                dtr.TimeInOT = DateTimeClass.Convert24To12Format(dtTime); ;
                            }


                            break;
                        case 6:
                            if (dtr.TimeOutOT != null)
                            {
                                //To Delinquent table
                                oMacDump = new MacDumpLog();
                                Console.WriteLine(DateTime.Parse(dtTime).ToString());
                                oMacDump.MacDumpDate = dtDate;
                                oMacDump.MacDumpTime = DateTimeClass.Convert24To12Format(dtTime);

                                oMacDump.EnrolleeNo = eEnrollee.EnrolleeNo;
                                oMacDump.EnrolleeId = eEnrollee.EnrolleeId;
                                oMacDump.MachineNo = log.MachineNo;
                            }
                            else
                            {
                                dtr.TimeOutOT = DateTimeClass.Convert24To12Format(dtTime); ;
                            }

                            break;
                        case 7:

                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    dtr = new DTR();
                    //iCountAtt = lAttLog.Count<AttLog>(attl => attl.GetDate() == dtDate);
                    dtr.DTRDate = DateTime.Parse(dtDate);
                    dtr.EnrolleeNo = eEnrollee.EnrolleeNo;
                    dtr.EnrolleeId = eEnrollee.EnrolleeId;

                    iLoc = VerifyShiftSettingViaList(eEnrollee.EnrolleeNo.ToString(), DateTime.Parse(dtDate), DateTime.Parse(dtTime), LoadSettingDetail(eEnrollee.SettingId));
                    switch (iLoc)
                    {
                        case 1:
                            dtr.TimeInAM = DateTimeClass.Convert24To12Format(dtTime); ;
                            break;
                        case 2:
                            dtr.TimeOutAM = DateTimeClass.Convert24To12Format(dtTime); ;
                            break;
                        case 3:
                            dtr.TimeInPM = DateTimeClass.Convert24To12Format(dtTime); ;
                            break;
                        case 4:
                            dtr.TimeOutPM = DateTimeClass.Convert24To12Format(dtTime); ;
                            break;
                        case 5:
                            dtr.TimeInOT = DateTimeClass.Convert24To12Format(dtTime); ;
                            break;
                        case 6:
                            dtr.TimeOutOT = DateTimeClass.Convert24To12Format(dtTime); ;
                            break;
                        case 7:

                            break;
                        default:
                            break;
                    }
                    if (!IsDTRExisting(dtr))
                        lAttendance.Add(dtr);
                }
                if (oMacDump != null)
                {
                    if (!IsMacDumpExisting(oMacDump))
                        lMacDumpLog.Add(oMacDump);
                }
            }
            lDumpLogs = lMacDumpLog;
            return lAttendance;
        }

        public static List<DTR> LoadEnrolleeAttendanceDTR(AttendanceKeeper.Data.Enrollee eEnrollee, List<Machine> lAttLog, 
            out List<MacDumpLog> lDumpLogs, bool bImport)
        {
            var lAttendance = new List<DTR>();
            var lMacDumpLog = new List<MacDumpLog>();
            foreach (var log in lAttLog)
            {
                MacDumpLog oMacDump = null;
                var dtTime = string.Format("{0}:{1}", log.IHour, log.IMin); //+ ":" + log.ISecond;
                var dtDate = string.Format("{0}/{1}/{2}", log.IMonth, log.IDay, log.IYear);

                var dtr = lAttendance.FirstOrDefault(at => at.DTRDate == DateTime.Parse(dtDate));

                var iLoc = 0;
                if (dtr != null)
                {
                    dtr.DTRDate = DateTime.Parse(dtDate);
                    dtr.EnrolleeNo = eEnrollee.EnrolleeNo;
                    dtr.EnrolleeId = eEnrollee.EnrolleeId;

                    iLoc = VerifyShiftSettingViaList(eEnrollee.EnrolleeNo.ToString(), DateTime.Parse(dtDate), DateTime.Parse(dtTime), LoadSettingDetail(eEnrollee.SettingId));
                    switch (iLoc)
                    {
                        case 1:
                            if (dtr.TimeInAM != null)
                            {
                                oMacDump = new MacDumpLog();
                                //To Delinquent table
                                Console.WriteLine(dtTime);
                                oMacDump.MacDumpDate = dtDate;
                                oMacDump.MacDumpTime = DateTimeClass.Convert24To12Format(dtTime);

                                oMacDump.EnrolleeNo = eEnrollee.EnrolleeNo;
                                oMacDump.EnrolleeId = eEnrollee.EnrolleeId;
                                oMacDump.MachineNo = log.MachineNo;
                            }
                            else
                            {
                                dtr.TimeInAM = DateTimeClass.Convert24To12Format(dtTime);
                            }
                            break;
                        case 2:
                            if (dtr.TimeOutAM != null)
                            {
                                //To Delinquent table
                                oMacDump = new MacDumpLog();
                                Console.WriteLine(dtTime.ToString());
                                oMacDump.MacDumpDate = dtDate;
                                oMacDump.MacDumpTime = DateTimeClass.Convert24To12Format(dtTime);

                                oMacDump.EnrolleeNo = eEnrollee.EnrolleeNo;
                                oMacDump.EnrolleeId = eEnrollee.EnrolleeId;
                                oMacDump.MachineNo = log.MachineNo;
                            }
                            else
                            {
                                dtr.TimeOutAM = DateTimeClass.Convert24To12Format(dtTime); ;
                            }

                            break;
                        case 3:
                            if (dtr.TimeInPM != null)
                            {
                                //To Delinquent table
                                oMacDump = new MacDumpLog();
                                Console.WriteLine(dtTime.ToString());
                                oMacDump.MacDumpDate = dtDate;
                                oMacDump.MacDumpTime = DateTimeClass.Convert24To12Format(dtTime);

                                oMacDump.EnrolleeNo = eEnrollee.EnrolleeNo;
                                oMacDump.EnrolleeId = eEnrollee.EnrolleeId;
                                oMacDump.MachineNo = log.MachineNo;
                            }
                            else
                            {
                                dtr.TimeInPM = DateTimeClass.Convert24To12Format(dtTime); ;
                            }

                            break;
                        case 4:
                            if (dtr.TimeOutPM != null)
                            {
                                //To Delinquent table
                                oMacDump = new MacDumpLog();
                                Console.WriteLine(dtTime);
                                oMacDump.MacDumpDate = dtDate;
                                oMacDump.MacDumpTime = DateTimeClass.Convert24To12Format(dtTime);

                                oMacDump.EnrolleeNo = eEnrollee.EnrolleeNo;
                                oMacDump.EnrolleeId = eEnrollee.EnrolleeId;
                                oMacDump.MachineNo = log.MachineNo;
                            }
                            else
                            {
                                dtr.TimeOutPM = DateTimeClass.Convert24To12Format(dtTime); ;
                            }

                            break;
                        case 5:
                            if (dtr.TimeInOT != null)
                            {
                                //To Delinquent table
                                oMacDump = new MacDumpLog();
                                Console.WriteLine(dtTime);
                                oMacDump.MacDumpDate = dtDate;
                                oMacDump.MacDumpTime = DateTimeClass.Convert24To12Format(dtTime);

                                oMacDump.EnrolleeNo = eEnrollee.EnrolleeNo;
                                oMacDump.EnrolleeId = eEnrollee.EnrolleeId;
                                oMacDump.MachineNo = log.MachineNo;
                            }
                            else
                            {
                                dtr.TimeInOT = DateTimeClass.Convert24To12Format(dtTime); ;
                            }


                            break;
                        case 6:
                            if (dtr.TimeOutOT != null)
                            {
                                //To Delinquent table
                                oMacDump = new MacDumpLog();
                                Console.WriteLine(DateTime.Parse(dtTime).ToString());
                                oMacDump.MacDumpDate = dtDate;
                                oMacDump.MacDumpTime = DateTimeClass.Convert24To12Format(dtTime);

                                oMacDump.EnrolleeNo = eEnrollee.EnrolleeNo;
                                oMacDump.EnrolleeId = eEnrollee.EnrolleeId;
                                oMacDump.MachineNo = log.MachineNo;
                            }
                            else
                            {
                                dtr.TimeOutOT = DateTimeClass.Convert24To12Format(dtTime); ;
                            }

                            break;
                        case 7:

                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    dtr = new DTR();
                    //iCountAtt = lAttLog.Count<AttLog>(attl => attl.GetDate() == dtDate);
                    dtr.DTRDate = DateTime.Parse(dtDate);
                    dtr.EnrolleeNo = eEnrollee.EnrolleeNo;
                    dtr.EnrolleeId = eEnrollee.EnrolleeId;

                    iLoc = VerifyShiftSettingViaList(eEnrollee.EnrolleeNo.ToString(), DateTime.Parse(dtDate), DateTime.Parse(dtTime), LoadSettingDetail(eEnrollee.SettingId));
                    switch (iLoc)
                    {
                        case 1:
                            dtr.TimeInAM = DateTimeClass.Convert24To12Format(dtTime); ;
                            break;
                        case 2:
                            dtr.TimeOutAM = DateTimeClass.Convert24To12Format(dtTime); ;
                            break;
                        case 3:
                            dtr.TimeInPM = DateTimeClass.Convert24To12Format(dtTime); ;
                            break;
                        case 4:
                            dtr.TimeOutPM = DateTimeClass.Convert24To12Format(dtTime); ;
                            break;
                        case 5:
                            dtr.TimeInOT = DateTimeClass.Convert24To12Format(dtTime); ;
                            break;
                        case 6:
                            dtr.TimeOutOT = DateTimeClass.Convert24To12Format(dtTime); ;
                            break;
                        case 7:

                            break;
                        default:
                            break;
                    }
                    //if (!IsDTRExisting(dtr))
                        lAttendance.Add(dtr);
                }
                if (oMacDump != null)
                {
                    //if (!IsMacDumpExisting(oMacDump))
                        lMacDumpLog.Add(oMacDump);
                }
            }
            lDumpLogs = lMacDumpLog;
            return lAttendance;
        }

        public static List<DTR> LoadEnrolleeAttendanceDTRAll(List<Enrollee> lEnrollee, out List<MacDumpLog> lMacDumpLogs, string sUserName)
        {
            var listDTR = new List<DTR>();
            var listMacDump = new List<MacDumpLog>();
            var listMc = new List<MacDumpLog>();
            foreach (var enrollee in lEnrollee)
            {
                //Load logs for the particular user
                var listLogs = ActionClass.FillMachinesViaEnrollNo(Convert.ToInt32(enrollee.EnrolleeNo));
                var tempListDTR = LoadEnrolleeAttendanceDTR(enrollee, listLogs.FindAll(l => (l.EnrolleeNo == enrollee.EnrolleeNo)), out listMacDump, sUserName);
                listDTR.AddRange(tempListDTR);
                listMc.AddRange(listMacDump);
            }

            lMacDumpLogs = listMc;
            return listDTR;
        }

        public static List<DTR> LoadDTRViaDTR(Enrollee enrollee, int iMonth, int iYear, List<DTR> lDTRs, Miscellaneous oMisc)
        {
            var lDT = new List<DTR>();
            var lSetDeatils = new List<SettingDetail>();
            var dLeave = LoadLeaveDictionary(enrollee.EnrolleeId, iMonth, iYear);
            var Misc = oMisc;
            lSetDeatils = ActionClass.FillSettingDetails(Convert.ToInt16(enrollee.SettingId));
            int iDaysMonth = DateTimeClass.GetDaysInMonth(iYear, iMonth);
            for (int i = 1; i <= iDaysMonth; i++)
            {
                DTR dtrTemp01 = new DTR();
                DateTime dtTemp = Convert.ToDateTime(iMonth.ToString() + "/" + i.ToString() + "/" + iYear.ToString());
                DTR dtrTemp = lDTRs.FirstOrDefault(d => d.DTRDate == dtTemp);
                string sDay = DateTimeClass.VerifyDay(dtTemp);
                string sHolidayTemp = string.Empty;
                TimeSpan? iTimeAM = new TimeSpan();
                TimeSpan? iTimePM = new TimeSpan();
                TimeSpan? iTimeOT = new TimeSpan();
                double? iTotalTime;

                if (dtrTemp != null)
                {
                    double? iTotalTimeAM = 0;
                    double? iTotalTimePM = 0;
                    double? iTotalTimeOT = 0;
                    
                    dtrTemp01 = dtrTemp;
                    dtrTemp01.DTRDay = sDay;
                    foreach (var detail in lSetDeatils)
                    {
                        if (detail.SettingDetailDay.Trim() == sDay.Trim())
                        {
                            DateTime? dtTimeInAM = null;
                            DateTime? dtTimeOutAM = null;
                            DateTime? dtTimeInPM = null;
                            DateTime? dtTimeOutPM = null;
                            DateTime? dtTimeInOT = null;
                            DateTime? dtTimeOutOT = null;
                            
                            if (dtrTemp.TimeInAM != null)
                            {
                                DateTime tempTimeInAM;
                                if (DateTime.TryParse(dtrTemp.TimeInAM, out tempTimeInAM))
                                {
                                    //dtTimeInAM = Convert.ToDateTime(dtrTemp.TimeInAM);
                                    dtTimeInAM = tempTimeInAM;
                                    if (Misc.MiscActive == true)
                                    {
                                        string shortTimeString = detail.SettingDetailINAM.Value.ToShortTimeString();
                                        DateTime tempSetTime = Convert.ToDateTime(shortTimeString);

                                        //dtTimeInAM = DateTimeClass.IsCompareTime(dtTimeInAM, Convert.ToDateTime(detail.SettingDetailINAM), 0) ? dtTimeInAM : Convert.ToDateTime(detail.SettingDetailINAM);
                                        if (DateTimeClass.IsCompareTime((DateTime) dtTimeInAM, tempSetTime, 0))
                                        {
                                            DateTime tempTime =
                                                dtTimeInAM.Value.AddMinutes(-Convert.ToDouble(Misc.MiscGraceInAM));
                                            if (DateTimeClass.IsCompareTime(tempTime, tempSetTime, 0))
                                            {
                                                dtTimeInAM = (Misc.MiscGraceInAM <= tempTime.Minute)
                                                                 ? tempTime
                                                                 : tempSetTime;
                                            }
                                        }
                                        else
                                        {
                                            dtTimeInAM = tempSetTime;
                                        }
                                    }
                                    else
                                    {
                                        string shortTimeString = detail.SettingDetailINAM.Value.ToShortTimeString();
                                        DateTime tempSetTime = Convert.ToDateTime(shortTimeString);
                                        dtTimeInAM = DateTimeClass.IsCompareTime(dtTimeInAM.Value, tempSetTime, 0) ? dtTimeInAM : tempSetTime;
                                    }
                                }
                                else
                                {
                                    dtTimeInAM = null;
                                }
                            }

                            if (dtrTemp.TimeOutAM != null)
                            {
                                DateTime tempTimeOutAM;
                                if (DateTime.TryParse(dtrTemp.TimeOutAM, out tempTimeOutAM))
                                {
                                    //dtTimeOutAM = Convert.ToDateTime(dtrTemp.TimeOutAM);
                                    dtTimeOutAM = tempTimeOutAM;
                                    string shortTimeString = detail.SettingDetailOUTAM.Value.ToShortTimeString();
                                    DateTime dtShort = Convert.ToDateTime(shortTimeString);
                                    dtTimeOutAM = DateTimeClass.IsCompareTime((DateTime) dtTimeOutAM, dtShort, 1)
                                                      ? dtTimeOutAM
                                                      : dtShort;
                                }
                            }

                            if (dtrTemp.TimeInPM != null)
                            {
                                DateTime tempTimeInPM;
                                if (DateTime.TryParse(dtrTemp.TimeInPM, out tempTimeInPM))
                                {
                                    //dtTimeInPM = Convert.ToDateTime(dtrTemp.TimeInPM);
                                    dtTimeInPM = tempTimeInPM;
                                    if (Misc.MiscActive == true)
                                    {
                                        string shortTimeString = detail.SettingDetailINPM.Value.ToShortTimeString();
                                        DateTime tempSetTime = Convert.ToDateTime(shortTimeString);
                                        //dtTimeInAM = DateTimeClass.IsCompareTime(dtTimeInAM, Convert.ToDateTime(detail.SettingDetailINAM), 0) ? dtTimeInAM : Convert.ToDateTime(detail.SettingDetailINAM);
                                        if (DateTimeClass.IsCompareTime((DateTime) dtTimeInPM, tempSetTime, 0))
                                        {
                                            DateTime tempTime =
                                                dtTimeInPM.Value.AddMinutes(-Convert.ToDouble(Misc.MiscGraceInPM));
                                            if (DateTimeClass.IsCompareTime(tempTime, tempSetTime, 0))
                                            {
                                                dtTimeInPM = (Misc.MiscGraceInPM <= tempTime.Minute)
                                                                 ? tempTime
                                                                 : tempSetTime;
                                            }
                                        }
                                        else
                                        {
                                            dtTimeInPM = tempSetTime;
                                        }
                                    }
                                    else
                                    {
                                        string shortTimeString = detail.SettingDetailINPM.Value.ToShortTimeString();
                                        DateTime tempSetTime = Convert.ToDateTime(shortTimeString);
                                        dtTimeInPM = DateTimeClass.IsCompareTime(dtTimeInPM.Value, tempSetTime, 0)
                                                         ? dtTimeInPM
                                                         : tempSetTime;
                                    }
                                }
                                else
                                {
                                    dtTimeInPM = null;
                                }
                            }
                            if (dtrTemp.TimeOutPM != null)
                            {
                                DateTime tempTimeOutPM;
                                if (DateTime.TryParse(dtrTemp.TimeOutPM, out tempTimeOutPM))
                                {
                                    //dtTimeOutPM = Convert.ToDateTime(dtrTemp.TimeOutPM);
                                    dtTimeOutPM = tempTimeOutPM;
                                    string shortTimeString = detail.SettingDetailOUTPM.Value.ToShortTimeString();
                                    DateTime dtShort = Convert.ToDateTime(shortTimeString);
                                    dtTimeOutPM = DateTimeClass.IsCompareTime((DateTime) dtTimeOutPM, dtShort, 1)
                                                      ? dtTimeOutPM
                                                      : dtShort;
                                }
                            }

                            if (dtrTemp.TimeInOT != null)
                            {
                                DateTime tempTimeInOT;
                                if (DateTime.TryParse(dtrTemp.TimeInOT, out tempTimeInOT))
                                {
                                    //dtTimeInOT = Convert.ToDateTime(dtrTemp.TimeInOT);
                                    dtTimeInOT = tempTimeInOT;
                                    if (Misc.MiscActive == true)
                                    {
                                        string shortTimeString = detail.SettingDetailINOT.Value.ToShortTimeString();
                                        DateTime tempSetTime = Convert.ToDateTime(shortTimeString);
                                        //dtTimeInAM = DateTimeClass.IsCompareTime(dtTimeInAM, Convert.ToDateTime(detail.SettingDetailINAM), 0) ? dtTimeInAM : Convert.ToDateTime(detail.SettingDetailINAM);
                                        if (DateTimeClass.IsCompareTime((DateTime) dtTimeInOT, tempSetTime, 0))
                                        {
                                            DateTime tempTime =
                                                dtTimeInOT.Value.AddMinutes(-Convert.ToDouble(Misc.MiscGraceInOT));
                                            if (DateTimeClass.IsCompareTime(tempTime, tempSetTime, 0))
                                            {
                                                dtTimeInOT = (Misc.MiscGraceInOT <= tempTime.Minute)
                                                                 ? tempTime
                                                                 : tempSetTime;
                                            }
                                        }
                                        else
                                        {
                                            dtTimeInOT = tempSetTime;
                                        }
                                    }
                                    else
                                    {
                                        string shortTimeString = detail.SettingDetailINOT.Value.ToShortTimeString();
                                        DateTime tempSetTime = Convert.ToDateTime(shortTimeString);
                                        dtTimeInOT = DateTimeClass.IsCompareTime(dtTimeInOT.Value, tempSetTime, 0)
                                                         ? dtTimeInPM
                                                         : tempSetTime;
                                    }
                                }
                                else
                                {
                                    dtTimeInOT = null;
                                }
                            }
                            if (dtrTemp.TimeOutOT != null)
                            {
                                DateTime tempTimeOutOT;
                                if (DateTime.TryParse(dtrTemp.TimeOutOT, out tempTimeOutOT))
                                {
                                    //dtTimeOutOT = Convert.ToDateTime(dtrTemp.TimeOutOT);
                                    dtTimeOutOT = tempTimeOutOT;
                                    string shortTimeString = detail.SettingDetailOUTPM.Value.ToShortTimeString();
                                    DateTime dtShort = Convert.ToDateTime(shortTimeString);
                                    dtTimeOutOT = DateTimeClass.IsCompareTime((DateTime) dtTimeOutOT, dtShort, 1)
                                                      ? dtTimeOutOT
                                                      : dtShort;
                                }
                            }

                            DateTime? tempDtInAM = null;
                            if (dtTimeInAM != null)
                                tempDtInAM = Convert.ToDateTime(dtTimeInAM.Value.ToString("HH:mm"));

                            DateTime? tempDtOutAM = null;
                            if (dtTimeOutAM != null)
                                tempDtOutAM = Convert.ToDateTime(dtTimeOutAM.Value.ToString("HH:mm"));

                            DateTime? tempDtInOT = null;
                            if (dtTimeInOT != null)
                                Convert.ToDateTime(dtTimeInOT.Value.ToString("HH:mm"));

                            DateTime? tempDtOutOT = null;
                            if (dtTimeOutOT != null)
                                Convert.ToDateTime(dtTimeOutOT.Value.ToString("HH:mm"));

                            iTimeAM = tempDtOutAM - tempDtInAM; // dtTimeOutAM.Subtract(dtTimeInAM);
                            iTimePM = dtTimeOutPM - dtTimeInPM;
                            iTimeOT = tempDtOutOT - tempDtInOT;
                        }
                    }

                    double? iHourAM = null;
                    if (iTimeAM != null)
                        iHourAM = iTimeAM.Value.Hours;

                    double? iMinAM = null;
                    if (iTimeAM != null)
                        iMinAM = iTimeAM.Value.Minutes;

                    iTotalTimeAM = (iHourAM + (iMinAM/60));

                    double? iHourPM = null;
                    if (iTimePM != null)
                        iHourPM = iTimePM.Value.Hours;

                    double? iMinPM = null;
                    if (iTimePM != null)
                        iMinPM = iTimePM.Value.Minutes;

                    iTotalTimePM = (iHourPM + (iMinPM/60));

                    double? iHourOT = 0;
                    if (iTimeOT != null) 
                        iHourOT = iTimeOT.Value.Hours;

                    double? iMinOT = 0;
                    if (iMinOT != 0)
                        iMinOT = iTimeOT.Value.Minutes;

                    iTotalTimeOT = (iHourOT + (iMinOT/60));

                    if (Misc.MiscActive == true)
                    {
                        double dHour = Convert.ToDouble(Misc.MiscRegularHours);
                        iTotalTime = iTotalTimeAM + iTotalTimePM + iTotalTimeOT;

                        dtrTemp01.TotalHour = iTotalTime;

                        //Computer for hour
                        dtrTemp01.TotalHour = (dtrTemp.TimeInAM != null) && (dtrTemp.TimeOutAM != null) &&
                                              (dtrTemp.TimeInPM != null) && (dtrTemp.TimeOutPM != null)
                                                  ? ((iHourAM + iHourPM))
                                                  : 0;

                        dtrTemp01.TotalHour = (dtrTemp.TimeInAM != null) && (dtrTemp.TimeOutAM != null)
                                                  ? ((dtrTemp01.TotalHour + iHourOT))
                                                  : (dtrTemp01.TotalHour);


                        //Compute for minutes
                        dtrTemp01.TotalMinute = (dtrTemp.TimeInAM != null) && (dtrTemp.TimeOutAM != null) &&
                                                (dtrTemp.TimeInPM != null) && (dtrTemp.TimeOutPM != null)
                                                    ? (iMinAM + iMinPM)
                                                    : 0;

                        dtrTemp01.TotalMinute = (dtrTemp.TimeInAM != null) && (dtrTemp.TimeOutAM != null)
                                                    ? (dtrTemp01.TotalMinute + iMinOT)
                                                    : dtrTemp01.TotalMinute;


                        if (dtrTemp01.TotalMinute > 0)
                        {
                            if (dtrTemp01.TotalMinute >= 60)
                            {
                                int tempToHour = Convert.ToInt32(Convert.ToDouble(dtrTemp01.TotalMinute) / 60);
                                int tempToMin = Convert.ToInt32((Convert.ToDouble(dtrTemp01.TotalMinute) % 60));
                                dtrTemp01.TotalHour = (dtrTemp01.TotalHour + tempToHour) - dHour;
                                dtrTemp01.TotalMinute = tempToMin;
                            }
                            else
                            {
                                dtrTemp01.TotalHour = (dtrTemp01.TotalHour + 1) - dHour;
                                dtrTemp01.TotalMinute = 60 - dtrTemp01.TotalMinute;
                            }
                        }
                        
                        //Compute for total hours
                        double? tempITotaltime = iTotalTime - dHour;
                        dtrTemp01.TotalHours = (dtrTemp.TimeInAM != null) && (dtrTemp.TimeOutAM != null) &&
                                               (dtrTemp.TimeInPM != null) && (dtrTemp.TimeOutPM != null) 
                                                   ? tempITotaltime 
                                                   : 0;
                        dtrTemp01.TotalHours = (dtrTemp.TimeInAM != null) && (dtrTemp.TimeOutAM != null)
                                                   ? (dtrTemp01.TotalHours + iTotalTimeOT)
                                                   : dtrTemp01.TotalHours;

                        if (dtrTemp01.TotalHours == 0)
                        {
                            dtrTemp01.DTRStatus = (dtrTemp.TimeInAM != null) && (dtrTemp.TimeOutAM != null) &&
                                                  (dtrTemp.TimeInPM != null) && (dtrTemp.TimeOutPM != null)
                                                   ? Misc.MiscRegularLabel
                                                   : "-"; 
                        }
                        else if (dtrTemp01.TotalHours > 0)
                        {
                            dtrTemp01.DTRStatus = Misc.MiscOverRegularLabel;
                        }
                        else if (dtrTemp01.TotalHours < 0)
                        {
                            dtrTemp01.DTRStatus = Misc.MiscUnderRegularLabel;
                        }
                        else
                        {
                            dtrTemp01.DTRStatus = "-";
                        }
                    }
                    else
                    {
                        iTotalTime = iTotalTimeAM + iTotalTimePM + iTotalTimeOT;
                        dtrTemp01.TotalHours = iTotalTime;
                    }

                    if (IsHoliday(dtTemp, out sHolidayTemp))
                        dtrTemp01.DTRStatus = "(h)" + sHolidayTemp;

                    if (dLeave.ContainsKey(dtTemp))
                    {
                        //A.M.
                        if (dtrTemp01.TimeInAM == null)
                            dtrTemp01.TimeInAM = "L/O.B.";
                        else if (dtrTemp01.TimeInAM.Trim().Length == 0)
                            dtrTemp01.TimeInAM = "L/O.B.";

                        if (dtrTemp01.TimeOutAM == null)
                            dtrTemp01.TimeOutAM = "L/O.B.";
                        else if (dtrTemp01.TimeOutAM.Trim().Length == 0)
                            dtrTemp01.TimeOutAM = "L/O.B";

                        //P.M.
                        if (dtrTemp01.TimeInPM == null)
                            dtrTemp01.TimeInPM = "L/O.B.";
                        else if (dtrTemp01.TimeInPM.Trim().Length == 0)
                            dtrTemp01.TimeInPM = "L/O.B";

                        if (dtrTemp01.TimeOutPM == null)
                            dtrTemp01.TimeOutPM = "L/O.B.";
                        else if (dtrTemp01.TimeOutPM.Trim().Length == 0)
                            dtrTemp01.TimeOutPM = "L/O.B";

                        //O.T.
                        //if (dtrTemp01.TimeInOT == null)
                        //    dtrTemp01.TimeInOT = "L/O.B.";
                        //else if (dtrTemp01.TimeInOT.Trim().Length == 0)
                        //    dtrTemp01.TimeInOT = "L/O.B";

                        //if (dtrTemp01.TimeOutOT == null)
                        //    dtrTemp01.TimeOutOT = "L/O.B.";
                        //else if (dtrTemp01.TimeOutOT.Trim().Length == 0)
                        //    dtrTemp01.TimeOutOT = "L/O.B";
    
                        dtrTemp01.DTRStatus = dLeave[dtTemp];
                    }
                }
                else
                {
                    if ((sDay == "Sunday") || (sDay == "Saturday"))
                    {
                        dtrTemp01.TimeInAM = sDay;
                        dtrTemp01.TimeOutAM = "-----";
                        dtrTemp01.TimeInPM = sDay;
                        dtrTemp01.TimeOutPM = "-----";
                        dtrTemp01.TimeInOT = sDay;
                        dtrTemp01.TimeOutOT = "-----";
                    }
                    //else
                    //{
                    //    dtrTemp01.TimeInAM = "-";
                    //    dtrTemp01.TimeOutAM = "-";
                    //    dtrTemp01.TimeInPM = "-";
                    //    dtrTemp01.TimeOutPM = "-";
                    //    dtrTemp01.TimeInOT = "-";
                    //    dtrTemp01.TimeOutOT = "-";
                    //}
                    dtrTemp01.DTRDate = dtTemp;
                    dtrTemp01.DTRDay = sDay;
                    //dtrTemp01.TotalHours = Convert.ToDouble(iTotalTime);

                    if (IsHoliday(dtTemp, out sHolidayTemp))
                    {
                        dtrTemp01.DTRStatus = sHolidayTemp + " (h)";
                        dtrTemp01.TimeInAM = "Holid";
                        dtrTemp01.TimeOutAM = "-----";
                        dtrTemp01.TimeInPM = "Holid";
                        dtrTemp01.TimeOutPM = "-----";
                        dtrTemp01.TimeInOT = "Holid";
                        dtrTemp01.TimeOutOT = "-----";
                    }

                    if (dLeave.ContainsKey(dtTemp))
                    {
                        dtrTemp01.DTRStatus = dLeave[dtTemp];
                        dtrTemp01.TimeInAM = "L/O.B.";
                        dtrTemp01.TimeOutAM = "-----";
                        dtrTemp01.TimeInPM = "L/O.B.";
                        dtrTemp01.TimeOutPM = "-----";
                        dtrTemp01.TimeInOT = "L/O.B.";
                        dtrTemp01.TimeOutOT = "-----";
                    }
                }
                lDT.Add(dtrTemp01);
            }
            return lDT;
        }

        public static List<DTR> LoadDTRViaDTR(Enrollee enrollee, int iMonth, int iYear, int iFrom, int iTo, List<DTR> lDTRs)
        {
            var lDT = new List<DTR>();
            var lSetDeatils = new List<SettingDetail>();
            var dLeave = LoadLeaveDictionary(enrollee.EnrolleeId, iMonth, iYear);
            var Misc = ActionClass.FillMiscellaneous().FirstOrDefault(mi => mi.MiscActive == true);
            lSetDeatils = ActionClass.FillSettingDetails(Convert.ToInt16(enrollee.SettingId));
            int iDaysMonth = DateTimeClass.GetDaysInMonth(iYear, iMonth);
            for (int i = 1; i <= iDaysMonth; i++)
            {
                DTR dtrTemp01 = new DTR();

                DateTime dtTemp = Convert.ToDateTime(iMonth.ToString() + "/" + i.ToString() + "/" + iYear.ToString());

                DTR dtrTemp = lDTRs.FirstOrDefault(d => d.DTRDate == dtTemp);
                string sDay = DateTimeClass.VerifyDay(dtTemp);
                string sHolidayTemp = string.Empty;
                TimeSpan? iTimeAM = new TimeSpan();
                TimeSpan? iTimePM = new TimeSpan();
                TimeSpan? iTimeOT = new TimeSpan();
                double? iTotalTime;

                #region "Start"

                if ((i >= iFrom) && (i <= iTo))
                {

                    if (dtrTemp != null)
                    {
                        double? iTotalTimeAM = 0;
                        double? iTotalTimePM = 0;
                        double? iTotalTimeOT = 0;

                        dtrTemp01 = dtrTemp;
                        dtrTemp01.DTRDay = sDay;

                        foreach (var detail in lSetDeatils)
                        {
                            if (detail.SettingDetailDay.Trim() == sDay.Trim())
                            {
                                DateTime? dtTimeInAM = null;
                                DateTime? dtTimeOutAM = null;
                                DateTime? dtTimeInPM = null;
                                DateTime? dtTimeOutPM = null;
                                DateTime? dtTimeInOT = null;
                                DateTime? dtTimeOutOT = null;

                                #region "TimeInAM"

                                if (dtrTemp.TimeInAM != null)
                                {
                                    DateTime tempTimeInAM;
                                    if (DateTime.TryParse(dtrTemp.TimeInAM, out tempTimeInAM))
                                    {
                                        //dtTimeInAM = Convert.ToDateTime(dtrTemp.TimeInAM);
                                        dtTimeInAM = tempTimeInAM;
                                        if (Misc.MiscActive == true)
                                        {
                                            string shortTimeString = detail.SettingDetailINAM.Value.ToShortTimeString();
                                            DateTime tempSetTime = Convert.ToDateTime(shortTimeString);

                                            //dtTimeInAM = DateTimeClass.IsCompareTime(dtTimeInAM, Convert.ToDateTime(detail.SettingDetailINAM), 0) ? dtTimeInAM : Convert.ToDateTime(detail.SettingDetailINAM);
                                            if (DateTimeClass.IsCompareTime((DateTime) dtTimeInAM, tempSetTime, 0))
                                            {
                                                DateTime tempTime =
                                                    dtTimeInAM.Value.AddMinutes(-Convert.ToDouble(Misc.MiscGraceInAM));
                                                if (DateTimeClass.IsCompareTime(tempTime, tempSetTime, 0))
                                                {
                                                    dtTimeInAM = (Misc.MiscGraceInAM <= tempTime.Minute)
                                                                     ? tempTime
                                                                     : tempSetTime;
                                                }
                                            }
                                            else
                                            {
                                                dtTimeInAM = tempSetTime;
                                            }
                                        }
                                        else
                                        {
                                            string shortTimeString = detail.SettingDetailINAM.Value.ToShortTimeString();
                                            DateTime tempSetTime = Convert.ToDateTime(shortTimeString);
                                            dtTimeInAM = DateTimeClass.IsCompareTime(dtTimeInAM.Value, tempSetTime, 0)
                                                             ? dtTimeInAM
                                                             : tempSetTime;
                                        }
                                    }
                                    else
                                    {
                                        dtTimeInAM = null;
                                    }
                                }

                                #endregion

                                #region "TimeOutAM"

                                if (dtrTemp.TimeOutAM != null)
                                {
                                    DateTime tempTimeOutAM;
                                    if (DateTime.TryParse(dtrTemp.TimeOutAM, out tempTimeOutAM))
                                    {
                                        //dtTimeOutAM = Convert.ToDateTime(dtrTemp.TimeOutAM);
                                        dtTimeOutAM = tempTimeOutAM;
                                        string shortTimeString = detail.SettingDetailOUTAM.Value.ToShortTimeString();
                                        DateTime dtShort = Convert.ToDateTime(shortTimeString);
                                        dtTimeOutAM = DateTimeClass.IsCompareTime((DateTime) dtTimeOutAM, dtShort, 1)
                                                          ? dtTimeOutAM
                                                          : dtShort;
                                    }
                                }

                                #endregion

                                #region "TimeInPM"

                                if (dtrTemp.TimeInPM != null)
                                {
                                    DateTime tempTimeInPM;
                                    if (DateTime.TryParse(dtrTemp.TimeInPM, out tempTimeInPM))
                                    {
                                        //dtTimeInPM = Convert.ToDateTime(dtrTemp.TimeInPM);
                                        dtTimeInPM = tempTimeInPM;
                                        if (Misc.MiscActive == true)
                                        {
                                            string shortTimeString = detail.SettingDetailINPM.Value.ToShortTimeString();
                                            DateTime tempSetTime = Convert.ToDateTime(shortTimeString);
                                            //dtTimeInAM = DateTimeClass.IsCompareTime(dtTimeInAM, Convert.ToDateTime(detail.SettingDetailINAM), 0) ? dtTimeInAM : Convert.ToDateTime(detail.SettingDetailINAM);
                                            if (DateTimeClass.IsCompareTime((DateTime) dtTimeInPM, tempSetTime, 0))
                                            {
                                                DateTime tempTime =
                                                    dtTimeInPM.Value.AddMinutes(-Convert.ToDouble(Misc.MiscGraceInPM));
                                                if (DateTimeClass.IsCompareTime(tempTime, tempSetTime, 0))
                                                {
                                                    dtTimeInPM = (Misc.MiscGraceInPM <= tempTime.Minute)
                                                                     ? tempTime
                                                                     : tempSetTime;
                                                }
                                            }
                                            else
                                            {
                                                dtTimeInPM = tempSetTime;
                                            }
                                        }
                                        else
                                        {
                                            string shortTimeString = detail.SettingDetailINPM.Value.ToShortTimeString();
                                            DateTime tempSetTime = Convert.ToDateTime(shortTimeString);
                                            dtTimeInPM = DateTimeClass.IsCompareTime(dtTimeInPM.Value, tempSetTime, 0)
                                                             ? dtTimeInPM
                                                             : tempSetTime;
                                        }
                                    }
                                    else
                                    {
                                        dtTimeInPM = null;
                                    }
                                }

                                #endregion

                                #region "TimeOutPM"

                                if (dtrTemp.TimeOutPM != null)
                                {
                                    DateTime tempTimeOutPM;
                                    if (DateTime.TryParse(dtrTemp.TimeOutPM, out tempTimeOutPM))
                                    {
                                        //dtTimeOutPM = Convert.ToDateTime(dtrTemp.TimeOutPM);
                                        dtTimeOutPM = tempTimeOutPM;
                                        string shortTimeString = detail.SettingDetailOUTPM.Value.ToShortTimeString();
                                        DateTime dtShort = Convert.ToDateTime(shortTimeString);
                                        dtTimeOutPM = DateTimeClass.IsCompareTime((DateTime) dtTimeOutPM, dtShort, 1)
                                                          ? dtTimeOutPM
                                                          : dtShort;
                                    }
                                }

                                #endregion

                                #region "TimeInOT"

                                if (dtrTemp.TimeInOT != null)
                                {
                                    DateTime tempTimeInOT;
                                    if (DateTime.TryParse(dtrTemp.TimeInOT, out tempTimeInOT))
                                    {
                                        //dtTimeInOT = Convert.ToDateTime(dtrTemp.TimeInOT);
                                        dtTimeInOT = tempTimeInOT;
                                        if (Misc.MiscActive == true)
                                        {
                                            string shortTimeString = detail.SettingDetailINOT.Value.ToShortTimeString();
                                            DateTime tempSetTime = Convert.ToDateTime(shortTimeString);
                                            //dtTimeInAM = DateTimeClass.IsCompareTime(dtTimeInAM, Convert.ToDateTime(detail.SettingDetailINAM), 0) ? dtTimeInAM : Convert.ToDateTime(detail.SettingDetailINAM);
                                            if (DateTimeClass.IsCompareTime((DateTime) dtTimeInOT, tempSetTime, 0))
                                            {
                                                DateTime tempTime =
                                                    dtTimeInOT.Value.AddMinutes(-Convert.ToDouble(Misc.MiscGraceInOT));
                                                if (DateTimeClass.IsCompareTime(tempTime, tempSetTime, 0))
                                                {
                                                    dtTimeInOT = (Misc.MiscGraceInOT <= tempTime.Minute)
                                                                     ? tempTime
                                                                     : tempSetTime;
                                                }
                                            }
                                            else
                                            {
                                                dtTimeInOT = tempSetTime;
                                            }
                                        }
                                        else
                                        {
                                            string shortTimeString = detail.SettingDetailINOT.Value.ToShortTimeString();
                                            DateTime tempSetTime = Convert.ToDateTime(shortTimeString);
                                            dtTimeInOT = DateTimeClass.IsCompareTime(dtTimeInOT.Value, tempSetTime, 0)
                                                             ? dtTimeInPM
                                                             : tempSetTime;
                                        }
                                    }
                                    else
                                    {
                                        dtTimeInOT = null;
                                    }
                                }

                                #endregion

                                #region "TimeOutOT"

                                if (dtrTemp.TimeOutOT != null)
                                {
                                    DateTime tempTimeOutOT;
                                    if (DateTime.TryParse(dtrTemp.TimeOutOT, out tempTimeOutOT))
                                    {
                                        //dtTimeOutOT = Convert.ToDateTime(dtrTemp.TimeOutOT);
                                        dtTimeOutOT = tempTimeOutOT;
                                        string shortTimeString = detail.SettingDetailOUTPM.Value.ToShortTimeString();
                                        DateTime dtShort = Convert.ToDateTime(shortTimeString);
                                        dtTimeOutOT = DateTimeClass.IsCompareTime((DateTime) dtTimeOutOT, dtShort, 1)
                                                          ? dtTimeOutOT
                                                          : dtShort;
                                    }
                                }

                                #endregion

                                #region "Conversion"

                                DateTime? tempDtInAM = null;
                                if (dtTimeInAM != null)
                                    tempDtInAM = Convert.ToDateTime(dtTimeInAM.Value.ToString("HH:mm"));

                                DateTime? tempDtOutAM = null;
                                if (dtTimeOutAM != null)
                                    tempDtOutAM = Convert.ToDateTime(dtTimeOutAM.Value.ToString("HH:mm"));

                                DateTime? tempDtInOT = null;
                                if (dtTimeInOT != null)
                                    Convert.ToDateTime(dtTimeInOT.Value.ToString("HH:mm"));

                                DateTime? tempDtOutOT = null;
                                if (dtTimeOutOT != null)
                                    Convert.ToDateTime(dtTimeOutOT.Value.ToString("HH:mm"));

                                iTimeAM = tempDtOutAM - tempDtInAM; // dtTimeOutAM.Subtract(dtTimeInAM);
                                iTimePM = dtTimeOutPM - dtTimeInPM;
                                iTimeOT = tempDtOutOT - tempDtInOT;

                                #endregion
                            }
                        }

                        #region "Computation"

                        double? iHourAM = null;
                        if (iTimeAM != null)
                            iHourAM = iTimeAM.Value.Hours;

                        double? iMinAM = null;
                        if (iTimeAM != null)
                            iMinAM = iTimeAM.Value.Minutes;

                        iTotalTimeAM = (iHourAM + (iMinAM/60));

                        double? iHourPM = null;
                        if (iTimePM != null)
                            iHourPM = iTimePM.Value.Hours;

                        double? iMinPM = null;
                        if (iTimePM != null)
                            iMinPM = iTimePM.Value.Minutes;

                        iTotalTimePM = (iHourPM + (iMinPM/60));

                        double? iHourOT = 0;
                        if (iTimeOT != null)
                            iHourOT = iTimeOT.Value.Hours;

                        double? iMinOT = 0;
                        if (iMinOT != 0)
                            iMinOT = iTimeOT.Value.Minutes;

                        iTotalTimeOT = (iHourOT + (iMinOT/60));

                        #endregion

                        #region "Miscellaneous"

                        if (Misc.MiscActive == true)
                        {
                            iTotalTime = iTotalTimeAM + iTotalTimePM + iTotalTimeOT;
                            dtrTemp01.TotalHour = iTotalTime;

                            double dHour = Convert.ToDouble(Misc.MiscRegularHours);

                            //Computer for hour
                            dtrTemp01.TotalHour = (dtrTemp.TimeInAM != null) && (dtrTemp.TimeOutAM != null) &&
                                                  (dtrTemp.TimeInPM != null) && (dtrTemp.TimeOutPM != null)
                                                      ? (dHour - (iHourAM + iHourPM))
                                                      : 0;

                            dtrTemp01.TotalHour = (dtrTemp.TimeInAM != null) && (dtrTemp.TimeOutAM != null)
                                                      ? ((dHour) - (dtrTemp01.TotalHour + iHourOT))
                                                      : (dHour - dtrTemp01.TotalHour);


                            //Compute for minutes
                            dtrTemp01.TotalMinute = (dtrTemp.TimeInAM != null) && (dtrTemp.TimeOutAM != null) &&
                                                    (dtrTemp.TimeInPM != null) && (dtrTemp.TimeOutPM != null)
                                                        ? (iMinAM + iMinPM)
                                                        : 0;

                            dtrTemp01.TotalMinute = (dtrTemp.TimeInAM != null) && (dtrTemp.TimeOutAM != null)
                                                        ? (dtrTemp01.TotalMinute + iMinOT)
                                                        : dtrTemp01.TotalMinute;


                            if (dtrTemp01.TotalMinute > 0)
                            {
                                if (dtrTemp01.TotalMinute >= 60)
                                {
                                    int tempToHour = Convert.ToInt32(Convert.ToDouble(dtrTemp01.TotalMinute)/60);
                                    int tempToMin = Convert.ToInt32((Convert.ToDouble(dtrTemp01.TotalMinute)%60));
                                    dtrTemp01.TotalHour = Convert.ToDouble(Misc.MiscRegularHours) -
                                                          (dtrTemp01.TotalHour + tempToHour);
                                    dtrTemp01.TotalMinute = tempToMin;
                                }
                            }

                            //Compute for total hours
                            dtrTemp01.TotalHours = (dtrTemp.TimeInAM != null) && (dtrTemp.TimeOutAM != null) &&
                                                   (dtrTemp.TimeInPM != null) && (dtrTemp.TimeOutPM != null)
                                                       ? iTotalTime
                                                       : 0;
                            dtrTemp01.TotalHours = (dtrTemp.TimeInAM != null) && (dtrTemp.TimeOutAM != null)
                                                       ? (dtrTemp01.TotalHours + iTotalTimeOT)
                                                       : dtrTemp01.TotalHours;

                            if (iTotalTime == Misc.MiscRegularHours)
                            {
                                dtrTemp01.DTRStatus = Misc.MiscRegularLabel;
                            }
                            else if (iTotalTime > Misc.MiscRegularHours)
                            {
                                dtrTemp01.DTRStatus = Misc.MiscOverRegularLabel;
                            }
                            else if (iTotalTime < Misc.MiscRegularHours)
                            {
                                dtrTemp01.DTRStatus = Misc.MiscUnderRegularLabel;
                            }
                            else
                            {
                                dtrTemp01.DTRStatus = "-";
                            }
                        }
                        else
                        {
                            iTotalTime = iTotalTimeAM + iTotalTimePM + iTotalTimeOT;
                            dtrTemp01.TotalHours = iTotalTime;
                        }

                        #endregion

                        if (IsHoliday(dtTemp, out sHolidayTemp))
                            dtrTemp01.DTRStatus = "(h)" + sHolidayTemp;

                        #region "Leave"

                        if (dLeave.ContainsKey(dtTemp))
                        {
                            //A.M.
                            if (dtrTemp01.TimeInAM == null)
                                dtrTemp01.TimeInAM = "L/O.B.";
                            else if (dtrTemp01.TimeInAM.Trim().Length == 0)
                                dtrTemp01.TimeInAM = "L/O.B.";

                            if (dtrTemp01.TimeOutAM == null)
                                dtrTemp01.TimeOutAM = "L/O.B.";
                            else if (dtrTemp01.TimeOutAM.Trim().Length == 0)
                                dtrTemp01.TimeOutAM = "L/O.B";

                            //P.M.
                            if (dtrTemp01.TimeInPM == null)
                                dtrTemp01.TimeInPM = "L/O.B.";
                            else if (dtrTemp01.TimeInPM.Trim().Length == 0)
                                dtrTemp01.TimeInPM = "L/O.B";

                            if (dtrTemp01.TimeOutPM == null)
                                dtrTemp01.TimeOutPM = "L/O.B.";
                            else if (dtrTemp01.TimeOutPM.Trim().Length == 0)
                                dtrTemp01.TimeOutPM = "L/O.B";

                            //O.T.
                            //if (dtrTemp01.TimeInOT == null)
                            //    dtrTemp01.TimeInOT = "L/O.B.";
                            //else if (dtrTemp01.TimeInOT.Trim().Length == 0)
                            //    dtrTemp01.TimeInOT = "L/O.B";

                            //if (dtrTemp01.TimeOutOT == null)
                            //    dtrTemp01.TimeOutOT = "L/O.B.";
                            //else if (dtrTemp01.TimeOutOT.Trim().Length == 0)
                            //    dtrTemp01.TimeOutOT = "L/O.B";

                            dtrTemp01.DTRStatus = dLeave[dtTemp];
                        }

                        #endregion
                    }
                    else
                    {
                        if ((sDay == "Sunday") || (sDay == "Saturday"))
                        {
                            dtrTemp01.TimeInAM = sDay;
                            dtrTemp01.TimeOutAM = "-----";
                            dtrTemp01.TimeInPM = sDay;
                            dtrTemp01.TimeOutPM = "-----";
                            dtrTemp01.TimeInOT = sDay;
                            dtrTemp01.TimeOutOT = "-----";
                        }
                        //else
                        //{
                        //    dtrTemp01.TimeInAM = "-";
                        //    dtrTemp01.TimeOutAM = "-";
                        //    dtrTemp01.TimeInPM = "-";
                        //    dtrTemp01.TimeOutPM = "-";
                        //    dtrTemp01.TimeInOT = "-";
                        //    dtrTemp01.TimeOutOT = "-";
                        //}
                        dtrTemp01.DTRDate = dtTemp;
                        dtrTemp01.DTRDay = sDay;
                        //dtrTemp01.TotalHours = Convert.ToDouble(iTotalTime);

                        #region "Holidays"

                        if (IsHoliday(dtTemp, out sHolidayTemp))
                        {
                            dtrTemp01.DTRStatus = sHolidayTemp + " (h)";
                            dtrTemp01.TimeInAM = "Holid";
                            dtrTemp01.TimeOutAM = "-----";
                            dtrTemp01.TimeInPM = "Holid";
                            dtrTemp01.TimeOutPM = "-----";
                            dtrTemp01.TimeInOT = "Holid";
                            dtrTemp01.TimeOutOT = "-----";
                        }

                        #endregion

                        #region "Leave"

                        if (dLeave.ContainsKey(dtTemp))
                        {
                            dtrTemp01.DTRStatus = dLeave[dtTemp];
                            dtrTemp01.TimeInAM = "L/O.B.";
                            dtrTemp01.TimeOutAM = "-----";
                            dtrTemp01.TimeInPM = "L/O.B.";
                            dtrTemp01.TimeOutPM = "-----";
                            dtrTemp01.TimeInOT = "L/O.B.";
                            dtrTemp01.TimeOutOT = "-----";
                        }

                        #endregion
                    }
                }

                #endregion

                lDT.Add(dtrTemp01);
            }
            return lDT;
        }


        #endregion

        public static int VerifyShiftSettingViaList(string sEnrollNumber,
            DateTime dtDate, DateTime dtTime, List<SettingDetail> lSettings)
        {
            int iSet = 0;



            foreach (var settings in lSettings)
            {
                if (settings.SettingDetailActive == true)
                {
                    if (settings.SettingDetailDay.Trim() == DateTimeClass.VerifyDay(dtDate))
                    {

                        if (((dtTime.Hour > Convert.ToDateTime(settings.SettingDetailAMIn01).Hour) || ((dtTime.Hour == Convert.ToDateTime(settings.SettingDetailAMIn01).Hour) && (dtTime.Minute >= Convert.ToDateTime(settings.SettingDetailAMIn01).Minute))) &&
                            ((dtTime.Hour < Convert.ToDateTime(settings.SettingDetailAMIn02).Hour) || ((dtTime.Hour == Convert.ToDateTime(settings.SettingDetailAMIn02).Hour) && (dtTime.Minute <= Convert.ToDateTime(settings.SettingDetailAMIn02).Minute))))
                        {
                            iSet = 1;
                        }
                        else if (((dtTime.Hour > Convert.ToDateTime(settings.SettingDetailAMOut01).Hour) || ((dtTime.Hour == Convert.ToDateTime(settings.SettingDetailAMOut01).Hour) && (dtTime.Minute >= Convert.ToDateTime(settings.SettingDetailAMOut01).Minute))) &&
                            ((dtTime.Hour < Convert.ToDateTime(settings.SettingDetailAMOut02).Hour) || ((dtTime.Hour == Convert.ToDateTime(settings.SettingDetailAMOut02).Hour) && (dtTime.Minute <= Convert.ToDateTime(settings.SettingDetailAMOut02).Minute))))
                        {
                            iSet = 2;
                        }
                        else if (((dtTime.Hour > Convert.ToDateTime(settings.SettingDetailPMIn01).Hour) || ((dtTime.Hour == Convert.ToDateTime(settings.SettingDetailPMIn01).Hour) && (dtTime.Minute >= Convert.ToDateTime(settings.SettingDetailPMIn01).Minute))) &&
                            ((dtTime.Hour < Convert.ToDateTime(settings.SettingDetailPMIn02).Hour) || ((dtTime.Hour == Convert.ToDateTime(settings.SettingDetailPMIn02).Hour) && (dtTime.Minute <= Convert.ToDateTime(settings.SettingDetailPMIn02).Minute))))
                        {
                            iSet = 3;
                        }
                        else if (((dtTime.Hour > Convert.ToDateTime(settings.SettingDetailPMOut01).Hour) || ((dtTime.Hour == Convert.ToDateTime(settings.SettingDetailPMOut01).Hour) && (dtTime.Minute >= Convert.ToDateTime(settings.SettingDetailPMOut01).Minute))) &&
                            ((dtTime.Hour < Convert.ToDateTime(settings.SettingDetailPMOut02).Hour) || ((dtTime.Hour == Convert.ToDateTime(settings.SettingDetailPMOut02).Hour) && (dtTime.Minute <= Convert.ToDateTime(settings.SettingDetailPMOut02).Minute))))
                        {
                            iSet = 4;
                        }
                        else if (((dtTime.Hour > Convert.ToDateTime(settings.SettingDetailOTIn01).Hour) || ((dtTime.Hour == Convert.ToDateTime(settings.SettingDetailOTIn01).Hour) && (dtTime.Minute >= Convert.ToDateTime(settings.SettingDetailOTIn01).Minute))) &&
                            ((dtTime.Hour < Convert.ToDateTime(settings.SettingDetailOTIn02).Hour) || ((dtTime.Hour == Convert.ToDateTime(settings.SettingDetailOTIn02).Hour) && (dtTime.Minute <= Convert.ToDateTime(settings.SettingDetailOTIn02).Minute))))
                        {
                            iSet = 5;
                        }
                        else if (((dtTime.Hour > Convert.ToDateTime(settings.SettingDetailOTOut01).Hour) || ((dtTime.Hour == Convert.ToDateTime(settings.SettingDetailOTOut01).Hour) && (dtTime.Minute >= Convert.ToDateTime(settings.SettingDetailOTOut01).Minute))) &&
                            ((dtTime.Hour < Convert.ToDateTime(settings.SettingDetailOTOut02).Hour) || ((dtTime.Hour == Convert.ToDateTime(settings.SettingDetailOTOut02).Hour) && (dtTime.Minute <= Convert.ToDateTime(settings.SettingDetailOTOut02).Minute))))
                        {
                            iSet = 6;
                        }
                        else
                        {
                            iSet = 7;
                        }
                    }
                }
            }

            //}

            return iSet;
        }

        public static int CompareDTRDate(DTR dt1, DTR dt2)
        {
            return dt1.DTRDate.Value.CompareTo(dt2.DTRDate.Value);
        }

        public static bool IsActiveMisc()
        {
            bool bResult = false;
            using (var data = new DTRDataDataContext())
            {
                Miscellaneous m = data.Miscellaneous.FirstOrDefault(mi => mi.MiscActive == true);
                bResult = (m != null);
            }
            return bResult;
        }

        public static Enrollee GetEnrollNoDuplicate(int iEnrollNo)
        {
            using (var data = new DTRDataDataContext())
            {
                Enrollee e = null;
                if (iEnrollNo > 0)
                {
                    e = data.Enrollees.FirstOrDefault(en => en.EnrolleeNo == iEnrollNo);

                }
                return e;
            }
        }

        public static Enrollee GetEnrollNoDuplicate(string sEnrollIdNo)
        {
            using (var data = new DTRDataDataContext())
            {
                Enrollee e = null;
                if (sEnrollIdNo.Length > 0)
                {
                    e = data.Enrollees.FirstOrDefault(en => en.EnrolleeIdNo == sEnrollIdNo);

                }
                return e;
            }
        }

        public static Miscellaneous GetMiscellaneous()
        {
            using (var data = new DTRDataDataContext())
            {
                Miscellaneous m = data.Miscellaneous.FirstOrDefault(mi => mi.MiscActive == true);
                return m;
            }
        }

        public static bool IsHoliday(DateTime dt, out string holiday)
        {
            bool bResult = false;
            string sHday = string.Empty;
            using (var data = new DTRDataDataContext())
            {
                Holiday h = data.Holidays.FirstOrDefault(ho => ho.HolidayDate == dt);
                if (h != null)
                {
                    bResult = true;
                    sHday = h.HolidayType;
                }
            }
            holiday = sHday;
            return bResult;
        }

        public static bool IsUserAdmin(int iUserId)
        {
            bool bResult = false;
            using (var data = new DTRDataDataContext())
            {
                User u = data.Users.FirstOrDefault(us => ((us.UserId == iUserId) && (us.Level.Trim() == "Admin")));
                bResult = u != null;
            }
            return bResult;
        }

        public static User GetUserViaUserNamePass(string sUserName, string sPassword)
        {
            User u = null;
            if ((sUserName.Length > 0) && (sPassword.Length > 0))
            {
                using (var data = new DTRDataDataContext())
                {
                    u = data.Users.FirstOrDefault(us => ((us.UserName.Trim() == sUserName) && (us.Password.Trim() == sPassword)));
                }
            }
            return u;
        }
    }
}
