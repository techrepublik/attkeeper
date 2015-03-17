using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectManager
{
   public class ActionClass
    {
        # region "1. Enrollees"
        public static int SaveEnrollee(Enrollee enrollee)
        {
            int iResult = 0;
            var data = new DTRDbaseEntities();
            if (enrollee != null)
            {
                try
                {
                    var e = new Enrollee();
                    if (enrollee.EnrolleeId > 0)
                        e = data.Enrollees.FirstOrDefault(en => en.EnrolleeId == enrollee.EnrolleeId);

                    e.EnrolleeId = enrollee.EnrolleeId;
                    e.EnrolleeIdNo = enrollee.EnrolleeIdNo;
                    e.EnrolleeNo = enrollee.EnrolleeNo;
                    e.LastName = enrollee.LastName;
                    e.FirstName = enrollee.FirstName;
                    e.MiddleName = enrollee.MiddleName;
                    e.Address = enrollee.Address;
                    e.Sex = enrollee.Sex;
                    e.BirthDate = enrollee.BirthDate;
                    e.DateHired = enrollee.DateHired;
                    e.DepartmentId = enrollee.DepartmentId;
                    e.PositionId = enrollee.PositionId;
                    e.SettingId = enrollee.SettingId;
                    e.IsActive = enrollee.IsActive;
                    e.Picture = enrollee.Picture;
                    e.EditedBy = enrollee.EditedBy;
                    e.EditedOn = enrollee.EditedOn;

                    if (enrollee.EnrolleeId == 0)
                    {
                        data.Enrollees.AddObject(e);
                        data.SaveChanges();
                        iResult = e.EnrolleeId;
                    }
                    else
                    {
                        data.SaveChanges();
                        iResult = e.EnrolleeId;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(@"Error - " + ex.Message);
                    //throw;
                }
            }

            return iResult;
        }

        public static int SaveEnrollee(List<Enrollee> listEnrollee)
        {
            var iResult = 0;
            using (var data = new DTRDbaseEntities())
            {
                if (listEnrollee.Count > 0)
                {
                    foreach (var q in listEnrollee)
                    {
                        data.Enrollees.AddObject(q);
                        data.SaveChanges();
                        iResult = 1;
                    }
                    
                }
            }
            return iResult;
        }

        public static bool DeleteEnrollee(Enrollee enrollee)
        {
            bool bResult = false;
            using (var data = new DTRDbaseEntities())
            {
                if (enrollee != null)
                {
                    try
                    {
                        var e = data.Enrollees.FirstOrDefault(en => en.EnrolleeId == enrollee.EnrolleeId);
                        if (e != null)
                        {
                            data.Enrollees.DeleteObject(enrollee);
                            data.SaveChanges();
                            bResult = true;
                        }
                        else
                        {
                            bResult = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error - " + ex.Message);
                        //throw;
                    }
                }
            }
            return bResult;
        }

        public static List<Enrollee> FillEnrollees()
        {
            var data = new DTRDbaseEntities();
            var q = (from en in data.Enrollees
                     orderby en.LastName ascending, en.FirstName ascending
                     select en).AsEnumerable();


            List<Enrollee> lEnrollees = q.ToList();
            return lEnrollees;

        }

        public static List<Enrollee> FillEnrollees(bool bActive)
        {
            var data = new DTRDbaseEntities();
            var q = from en in data.Enrollees
                    where (en.IsActive == bActive)
                    orderby en.LastName ascending, en.FirstName ascending
                    select en;


            List<Enrollee> lEnrollees = q.ToList();
            return lEnrollees;

        }

        public static List<Enrollee> FillEnrollees(bool bActive, int iDepartment)
        {
            var data = new DTRDbaseEntities();
            var q = from en in data.Enrollees
                    where ((en.IsActive == bActive) && (en.DepartmentId == iDepartment))
                    orderby en.LastName ascending, en.FirstName ascending
                    select en;


            List<Enrollee> lEnrollees = q.ToList();
            return lEnrollees;

        }

        public static List<Enrollee> FillEnrollees(string sIdNo, string sLastName, string iEnrollNo)
        {
            var data = new DTRDbaseEntities();
            var q = from en in data.Enrollees
                    where ((en.EnrolleeIdNo == sIdNo) || (en.LastName.StartsWith(sLastName) || (en.EnrolleeNo.ToString() == iEnrollNo.ToString())))
                    orderby en.LastName ascending, en.FirstName ascending
                    select en;


            List<Enrollee> lEnrollees = q.ToList();
            return lEnrollees;
        }

        public static Enrollee GetEnrollee(int iEnrolleeId)
        {
            var data = new DTRDbaseEntities();
            Enrollee e = data.Enrollees.FirstOrDefault(en => en.EnrolleeId == iEnrolleeId);
            return e;
        }

        public static Enrollee GetEnrolleeViaEnrollNo(int iEnrollNo, string sIdNo, int iEnrolleeId)
        {
            Enrollee enrollee = new Enrollee();
            using (var data = new DTRDbaseEntities())
            {
                Enrollee e = data.Enrollees.FirstOrDefault(en => ((en.EnrolleeNo == iEnrollNo) || (en.EnrolleeIdNo == sIdNo)));
                if (e != null)
                {
                    enrollee = e.EnrolleeId != iEnrolleeId ? e : null;
                }
            }
            return enrollee;
        }

        # endregion

        #region "2. Departments"
        public static int SaveDepartment(Department department)
        {
            int iResult = 0;
            using (var data = new DTRDbaseEntities())
            {
                if (department != null)
                {
                    try
                    {
                        Department d = new Department();
                        if (department.DepartmentId > 0)
                            d = data.Departments.FirstOrDefault(de => de.DepartmentId == department.DepartmentId);

                        d.DepartmentId = department.DepartmentId;
                        d.DepartmentName = department.DepartmentName;
                        d.EditedBy = department.EditedBy;
                        d.EditedOn = department.EditedOn;

                        if (department.DepartmentId == 0)
                        {
                            data.Departments.AddObject(d);
                            data.SaveChanges();
                            iResult = d.DepartmentId;
                        }
                        else
                        {
                            data.SaveChanges();
                            iResult = d.DepartmentId;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error - " + ex.Message);
                        throw;
                    }
                }
            }
            return iResult;
        }

        public static bool DeleteDepartment(Department department)
        {
            bool bResult = false;
            using (var data = new DTRDbaseEntities())
            {
                try
                {
                    Department d = data.Departments.FirstOrDefault(de => de.DepartmentId == department.DepartmentId);
                    if (d != null)
                    {
                        data.Departments.DeleteObject(department);
                        data.SaveChanges();
                        bResult = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error - " + ex.Message);
                    //throw;
                }
            }
            return bResult;
        }

        public static List<Department> FillDepartments()
        {
            var data = new DTRDbaseEntities();
            var q = from d in data.Departments
                    orderby d.DepartmentName ascending
                    select d;
            return q.ToList();
        }

        public static List<Department> FillDepartments(string sDeparmentName)
        {
            var data = new DTRDbaseEntities();
            var q = from d in data.Departments
                    where (d.DepartmentName.StartsWith(sDeparmentName))
                    orderby d.DepartmentName ascending
                    select d;
            return q.ToList();
        }

        public static Department GetDepartment(int iDepartmentId)
        {
            var data = new DTRDbaseEntities();
            Department d = data.Departments.FirstOrDefault(de => de.DepartmentId == iDepartmentId);
            return d;
        }
        #endregion

        #region "3. Positions"
        public static int SavePosition(Position position)
        {
            int iResult = 0;
            using (var data = new DTRDbaseEntities())
            {
                if (position != null)
                {
                    try
                    {
                        Position p = new Position();
                        if (position.PositionId > 0)
                            p = data.Positions.FirstOrDefault(po => po.PositionId == position.PositionId);

                        p.PositionId = position.PositionId;
                        p.PositionName = position.PositionName;
                        p.DepartmentId = position.DepartmentId;
                        p.EditedBy = position.EditedBy;
                        p.EditedOn = position.EditedOn;

                        if (position.PositionId == 0)
                        {
                            data.Positions.AddObject(position);
                            data.SaveChanges();
                            iResult = p.PositionId;
                        }
                        else
                        {
                            data.SaveChanges();
                            iResult = p.PositionId;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error - " + ex.Message);
                        //throw;
                    }
                }
            }
            return iResult;
        }

        public static bool DeletePosition(Position position)
        {
            bool bResult = false;
            using (var data = new DTRDbaseEntities())
            {
                if (position != null)
                {
                    Position p = data.Positions.FirstOrDefault(po => po.PositionId == position.PositionId);
                    if (p != null)
                    {
                        data.Positions.DeleteObject(position);
                        data.SaveChanges();
                        bResult = true;
                    }
                }
            }
            return bResult;
        }

        public static List<Position> FillPostions()
        {
            var data = new DTRDbaseEntities();
            var q = from p in data.Positions
                    orderby p.PositionName ascending
                    select p;
            return q.ToList();
        }

        public static List<Position> FillPostions(int iDepartmentId)
        {
            var data = new DTRDbaseEntities();
            var q = from p in data.Positions
                    where (p.DepartmentId == iDepartmentId)
                    orderby p.PositionName ascending
                    select p;
            return q.ToList();
        }

        public static Position GetPosition(int iPositionId)
        {
            var data = new DTRDbaseEntities();
            Position p = data.Positions.FirstOrDefault(po => po.PositionId == iPositionId);
            return p;
        }
        #endregion

        #region "4. Settings"
        public static int SaveSetting(Setting setting)
        {
            int iResult = 0;
            using (var data = new DTRDbaseEntities())
            {
                if (setting != null)
                {
                    try
                    {
                        Setting s = new Setting();
                        if (setting.SettingId > 0)
                            s = data.Settings.FirstOrDefault(se => se.SettingId == setting.SettingId);

                        s.SettingId = setting.SettingId;
                        s.SettingName = setting.SettingName;
                        s.EditedBy = setting.EditedBy;
                        s.EdtiedOn = setting.EdtiedOn;

                        if (setting.SettingId == 0)
                        {
                            data.Settings.AddObject(s);
                            data.SaveChanges();
                            iResult = s.SettingId;
                        }
                        else
                        {
                            data.SaveChanges();
                            iResult = s.SettingId;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error - " + ex.Message);
                        //throw;
                    }
                }
            }
            return iResult;
        }

        public static bool DeleteSetting(Setting setting)
        {
            bool bResult = false;
            using (var data = new DTRDbaseEntities())
            {
                if (setting != null)
                {
                    Setting s = data.Settings.FirstOrDefault(se => se.SettingId == setting.SettingId);
                    if (s != null)
                    {
                        data.Settings.DeleteObject(setting);
                        data.SaveChanges();
                        bResult = true;
                    }
                }
            }
            return bResult;
        }

        public static List<Setting> FillSettings()
        {
            var data = new DTRDbaseEntities();
            var q = from s in data.Settings
                    orderby s.SettingName ascending
                    select s;
            return q.ToList();
        }

        public static Setting GetSetting(int iSettingId)
        {
            var data = new DTRDbaseEntities();
            Setting s = data.Settings.FirstOrDefault(se => se.SettingId == iSettingId);
            return s;
        }


        #endregion

        #region "5. SettingDetails"
        public static int SaveSettingDetail(SettingDetail settingDetail)
        {
            int iResult = 0;
            using (var data = new DTRDbaseEntities())
            {
                if (settingDetail != null)
                {
                    try
                    {
                        SettingDetail sd = new SettingDetail();
                        if (settingDetail.SettingDetailId > 0)
                            sd = data.SettingDetails.FirstOrDefault(sed => sed.SettingDetailId == settingDetail.SettingDetailId);

                        sd.SettingDetailId = settingDetail.SettingDetailId;
                        sd.SettingId = settingDetail.SettingId;
                        sd.SettingDetailDay = settingDetail.SettingDetailDay;
                        sd.SettingDetailINAM = settingDetail.SettingDetailINAM;
                        sd.SettingDetailOUTAM = settingDetail.SettingDetailOUTAM;
                        sd.SettingDetailINPM = settingDetail.SettingDetailINPM;
                        sd.SettingDetailOUTPM = settingDetail.SettingDetailOUTPM;
                        sd.SettingDetailINOT = settingDetail.SettingDetailINOT;
                        sd.SettingDetailOUTOT = settingDetail.SettingDetailOUTOT;
                        sd.SettingDetailAMIn01 = settingDetail.SettingDetailAMIn01;
                        sd.SettingDetailAMIn02 = settingDetail.SettingDetailAMIn02;
                        sd.SettingDetailAMOut01 = settingDetail.SettingDetailAMOut01;
                        sd.SettingDetailAMOut02 = settingDetail.SettingDetailAMOut02;
                        sd.SettingDetailPMIn01 = settingDetail.SettingDetailPMIn01;
                        sd.SettingDetailPMIn02 = settingDetail.SettingDetailPMIn02;
                        sd.SettingDetailPMOut01 = settingDetail.SettingDetailPMOut01;
                        sd.SettingDetailPMOut02 = settingDetail.SettingDetailPMOut02;
                        sd.SettingDetailOTIn01 = settingDetail.SettingDetailOTIn01;
                        sd.SettingDetailOTIn02 = settingDetail.SettingDetailOTIn02;
                        sd.SettingDetailOTOut01 = settingDetail.SettingDetailOTOut01;
                        sd.SettingDetailOTIn02 = settingDetail.SettingDetailOTOut02;
                        sd.SettingDetailActive = settingDetail.SettingDetailActive;
                        sd.EditedBy = settingDetail.EditedBy;
                        sd.EditedOn = settingDetail.EditedOn;

                        if (settingDetail.SettingDetailId == 0)
                        {
                            data.SettingDetails.AddObject(settingDetail);
                            data.SaveChanges();
                            iResult = sd.SettingDetailId;
                        }
                        else
                        {
                            data.SaveChanges();
                            iResult = sd.SettingDetailId;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error - " + ex.Message);
                        //throw;
                    }
                }
            }
            return iResult;
        }

        public static bool DeleteSettingDetail(SettingDetail settingDetail)
        {
            bool bResult = false;
            using (var data = new DTRDbaseEntities())
            {
                if (settingDetail != null)
                {
                    try
                    {
                        SettingDetail s = data.SettingDetails.FirstOrDefault(se => se.SettingDetailId == settingDetail.SettingDetailId);
                        if (s != null)
                        {
                            data.SettingDetails.DeleteObject(settingDetail);
                            data.SaveChanges();
                            bResult = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error - " + ex.Message);
                        //throw;
                    }
                }
            }
            return bResult;
        }

        public static List<SettingDetail> FillSettingDetails(int iSettingId)
        {
            var data = new DTRDbaseEntities();
            var q = from s in data.SettingDetails
                    where (s.SettingId == iSettingId)
                    select s;
            return q.ToList();
        }
        #endregion

        #region "6. Machines"
        public static int SaveMachine(List<Machine> lMachine)
        {
            int iResult = 0;
            using (var data = new DTRDbaseEntities())
            {
                if (lMachine != null)
                {
                    try
                    {
                        foreach (var q in lMachine)
                        {
                            data.Machines.AddObject(q);
                            data.SaveChanges();
                            iResult = 1;
                        }
                       
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error - " + ex.Message);
                        //throw;
                    }
                }
            }
            return iResult;
        }

        public static int SaveMachine(Machine machine)
        {
            int iResult = 0;
            using (var data = new DTRDbaseEntities())
            {
                if (machine != null)
                {
                    try
                    {
                        Machine m = new Machine();
                        if (machine.MachineId > 0)
                            m = data.Machines.FirstOrDefault(ma => ma.MachineId == machine.MachineId);

                        m.MachineInsId = machine.MachineInsId;
                        m.MachineId = machine.MachineId;
                        m.MachineNo = machine.MachineNo;
                        m.EnrolleeId = machine.EnrolleeId;
                        m.EnrolleeNo = machine.EnrolleeNo;
                        m.IYear = machine.IYear;
                        m.IMonth = machine.IMonth;
                        m.IDay = machine.IDay;
                        m.IHour = machine.IHour;
                        m.IMin = machine.IMin;
                        m.ISecond = machine.ISecond;
                        m.VerifyCode = machine.VerifyCode;
                        m.InOutCode = machine.InOutCode;

                        if (machine.MachineId == 0)
                        {
                            data.Machines.AddObject(machine);
                            data.SaveChanges();
                            iResult = m.MachineId;
                        }
                        else
                        {
                            data.SaveChanges();
                            iResult = m.MachineId;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error - " + ex.Message);
                        //throw;
                    }
                }
            }
            return iResult;
        }

        public static bool DeleteMachine(Machine machine)
        {
            bool bResult = false;
            using (var data = new DTRDbaseEntities())
            {
                if (machine != null)
                {
                    try
                    {
                        Machine m = data.Machines.FirstOrDefault(ma => ma.MachineId == machine.MachineId);

                        if (m != null)
                        {
                            data.Machines.DeleteObject(machine);
                            data.SaveChanges();
                            bResult = true;
                        }
                        else
                        {
                            data.SaveChanges();
                            bResult = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        //throw;
                    }
                }
            }
            return bResult;
        }

        public static List<Machine> FillMachinesAll()
        {
            var data = new DTRDbaseEntities();
            var q = from m in data.Machines
                    select m;
            return q.ToList();
        }

        public static List<Machine> FillMachinesViaEnrolleeId(int iEnrolleeId)
        {
            var data = new DTRDbaseEntities();
            var q = from m in data.Machines
                    where (m.EnrolleeId == iEnrolleeId)
                    select m;
            return q.ToList();
        }

        public static List<Machine> FillMachinesViaEnrollNo(int iEnrollNo)
        {
            var data = new DTRDbaseEntities();
            var q = from m in data.Machines
                    where (m.EnrolleeNo == iEnrollNo)
                    select m;
            return q.ToList();
        }

        public static List<Machine> FillMachinesViaEnrollMachineInstance(int iInstanceNo)
        {
            var data = new DTRDbaseEntities();
            var q = from m in data.Machines
                    where (m.MachineInsId == iInstanceNo)
                    select m;
            return q.ToList();
        }

        public static Machine GetMachine(int iMachineId)
        {
            var data = new DTRDbaseEntities();
            Machine m = data.Machines.FirstOrDefault(ma => ma.MachineId == iMachineId);
            return m;
        }
        #endregion

        # region "7. DTR"
        public static int SaveDTR(DTR dtr)
        {
            int iResult = 0;
            using (var data = new DTRDbaseEntities())
            {
                if (dtr != null)
                {
                    try
                    {
                        DTR d = new DTR();
                        if (dtr.DTRId > 0)
                            d = data.DTRs.FirstOrDefault(dt => dt.DTRId == dtr.DTRId);

                        d.DTRId = dtr.DTRId;
                        d.EnrolleeId = dtr.EnrolleeId;
                        d.EnrolleeNo = dtr.EnrolleeNo;
                        d.DTRDate = dtr.DTRDate;
                        d.DTRDay = dtr.DTRDay;
                        d.TimeInAM = dtr.TimeInAM;
                        d.TimeOutAM = dtr.TimeOutAM;
                        d.TimeInPM = dtr.TimeInPM;
                        d.TimeOutPM = dtr.TimeOutPM;
                        d.TimeInOT = dtr.TimeInOT;
                        d.TimeOutOT = dtr.TimeOutOT;
                        d.TotalHours = dtr.TotalHours;
                        d.TotalHour = dtr.TotalHour;
                        d.TotalMinute = dtr.TotalMinute;
                        d.DTRStatus = dtr.DTRStatus;
                        d.IsSource = dtr.IsSource;
                        d.EditedBy = dtr.EditedBy;
                        d.EditedOn = dtr.EditedOn;

                        if (dtr.DTRId == 0)
                        {
                            data.DTRs.AddObject(dtr);
                            data.SaveChanges();
                            iResult = d.DTRId;
                        }
                        else
                        {
                            data.SaveChanges();
                            iResult = d.DTRId;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error - " + ex.Message);
                        //throw;
                    }
                }
            }
            return iResult;
        }

        public static int SaveDTR(List<DTR> lDTRs)
        {
            int iResult = 0;
            using (var data = new DTRDbaseEntities())
            {
                if (lDTRs != null)
                {
                    try
                    {
                        foreach (var q in lDTRs)
                        {
                            data.DTRs.AddObject(q);
                            data.SaveChanges();
                            iResult = 1;
                        }
                       
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error - " + ex.Message);
                        //throw;
                    }
                }
            }
            return iResult;
        }

        public static bool DeleteDTR(DTR dtr)
        {
            bool bResult = false;
            using (var data = new DTRDbaseEntities())
            {
                if (dtr != null)
                {
                    DTR d = data.DTRs.FirstOrDefault(dt => dt.DTRId == dtr.DTRId);
                    if (d != null)
                    {
                        data.DTRs.DeleteObject(dtr);
                        data.SaveChanges();
                        bResult = true;
                    }
                    else
                    {
                        data.SaveChanges();
                        bResult = true;
                    }
                }
            }
            return bResult;
        }

        public static bool DeleteDTR(int iEnrolleeId, int iMonth, int iYear)
        {
            bool bResult = false;
            using (var data = new DTRDbaseEntities())
            {
                if (iEnrolleeId > 0)
                {
                    var q = from d in data.DTRs
                            where ((d.EnrolleeId == iEnrolleeId) && (d.DTRDate.Value.Month == iMonth) &&
                                   (d.DTRDate.Value.Year == iYear))
                            select d;

                    List<DTR> lDTR = q.ToList();
                    if (lDTR != null)
                    {
                        foreach (var a in lDTR)
                        {
                            data.DTRs.DeleteObject(a);
                            data.SaveChanges();
                            bResult = true;
                        }
                    }
                }
            }
            return bResult;
        }

        public static List<DTR> FillDTRs(int iEnrolleeId)
        {
            var data = new DTRDbaseEntities();
            var q = from d in data.DTRs
                    where (d.EnrolleeId == iEnrolleeId)
                    orderby d.DTRDate ascending
                    select d;
            return q.ToList();
        }

        public static List<DTR> FillDTRs(int iEnrolleeId, int iMonth, int iYear)
        {
            var data = new DTRDbaseEntities();
            var q = from d in data.DTRs
                    where ((d.EnrolleeId == iEnrolleeId) && (d.DTRDate.Value.Month == iMonth) && (d.DTRDate.Value.Year == iYear))
                    orderby d.DTRDate ascending
                    select d;
            return q.ToList();
        }

        public static DTR GetDTR(int iDTRId)
        {
            var data = new DTRDbaseEntities();
            DTR d = data.DTRs.FirstOrDefault(dt => dt.DTRId == iDTRId);
            return d;
        }
        #endregion

        #region "8. Miscellaneous"
        public static int SaveMiscellaneous(Miscellaneou misc)
        {
            int iResult = 0;
            using (var data = new DTRDbaseEntities())
            {
                if (misc != null)
                {
                    try
                    {
                        Miscellaneou m = new Miscellaneou();
                        if (misc.MiscId > 0)
                            m = data.Miscellaneous.FirstOrDefault(mi => mi.MiscId == misc.MiscId);

                        m.MiscId = misc.MiscId;
                        m.MiscGraceInAM = misc.MiscGraceInAM;
                        m.MiscGraceInPM = misc.MiscGraceInPM;
                        m.MiscGraceInOT = misc.MiscGraceInOT;
                        m.MiscRegularHours = misc.MiscRegularHours;
                        m.MiscRegularLabel = misc.MiscRegularLabel;
                        m.MiscOverRegularLabel = misc.MiscOverRegularLabel;
                        m.MiscUnderRegularLabel = misc.MiscUnderRegularLabel;
                        m.MiscActive = misc.MiscActive;
                        m.EditedOn = misc.EditedOn;
                        m.EditedBy = misc.EditedBy;

                        if (misc.MiscId == 0)
                        {
                            data.Miscellaneous.AddObject(m);
                            data.SaveChanges();
                            iResult = m.MiscId;
                        }
                        else
                        {
                            data.SaveChanges();
                            iResult = m.MiscId;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        //throw;
                    }
                }
            }
            return iResult;
        }

        public static bool DeleteMiscellaneous(Miscellaneou misc)
        {
            bool bResult = false;
            using (var data = new DTRDbaseEntities())
            {
                if (misc != null)
                {
                    try
                    {
                        Miscellaneou m = data.Miscellaneous.FirstOrDefault(mi => mi.MiscId == misc.MiscId);
                        if (m != null)
                        {
                            data.Miscellaneous.DeleteObject(misc);
                            data.SaveChanges();
                            bResult = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error - " + ex.Message);
                        //throw;
                    }
                }
            }
            return bResult;
        }

        public static List<Miscellaneou> FillMiscellaneous()
        {
            var data = new DTRDbaseEntities();
            var q = from m in data.Miscellaneous
                    select m;
            return q.ToList();
        }

        public static Miscellaneou GetMiscellaneous(int iMisId)
        {
            var data = new DTRDbaseEntities();
            Miscellaneou m = data.Miscellaneous.FirstOrDefault(mi => (mi.MiscId == iMisId));
            return m;
        }
        #endregion

        #region "9. Holidays"
        public static int SaveHoliday(Holiday holiday)
        {
            int iResult = 0;
            using (var data = new DTRDbaseEntities())
            {
                if (holiday != null)
                {
                    try
                    {
                        Holiday h = new Holiday();
                        if (holiday.HolidayId > 0)
                            h = data.Holidays.FirstOrDefault(ho => ho.HolidayId == holiday.HolidayId);

                        h.HolidayId = holiday.HolidayId;
                        h.HolidayDate = holiday.HolidayDate;
                        h.HolidayType = holiday.HolidayType;
                        h.HolidayActive = holiday.HolidayActive;
                        h.HolidayNote = holiday.HolidayNote;
                        h.EditedBy = holiday.EditedBy;
                        h.EditedOn = holiday.EditedOn;

                        if (holiday.HolidayId == 0)
                        {
                            data.Holidays.AddObject(holiday);
                            data.SaveChanges();
                            iResult = h.HolidayId;
                        }
                        else
                        {
                            data.SaveChanges();
                            iResult = h.HolidayId;
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error - " + ex.Message);
                        //throw;
                    }
                }
            }
            return iResult;
        }

        public static bool DeleteHoliday(Holiday holiday)
        {
            bool bResult = false;
            using (var data = new DTRDbaseEntities())
            {
                if (holiday != null)
                {
                    try
                    {
                        Holiday h = data.Holidays.FirstOrDefault(ho => ho.HolidayId == holiday.HolidayId);

                        if (h != null)
                        {
                            data.Holidays.DeleteObject(holiday);
                            data.SaveChanges();
                            bResult = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error - " + ex.Message);
                        //throw;
                    }
                }
            }
            return bResult;
        }

        public static List<Holiday> FillHolidays()
        {
            var data = new DTRDbaseEntities();
            var q = from h in data.Holidays
                    orderby h.HolidayDate descending
                    select h;
            return q.ToList();
        }

        public static List<Holiday> FillHolidays(int iMonth, int iYear)
        {
            var data = new DTRDbaseEntities();
            var q = from h in data.Holidays
                    where ((h.HolidayDate.Value.Month == iMonth) && (h.HolidayDate.Value.Year == iYear))
                    orderby h.HolidayDate descending
                    select h;
            return q.ToList();
        }

        public static Holiday GetHoliday(int iHolidayId)
        {
            var data = new DTRDbaseEntities();
            Holiday h = data.Holidays.FirstOrDefault(ho => ho.HolidayId == iHolidayId);
            return h;
        }
        #endregion

        #region "10. Leaves"
        public static int SaveLeave(Leaf leave)
        {
            int iResult = 0;
            using (var data = new DTRDbaseEntities())
            {
                if (leave != null)
                {
                    try
                    {
                        Leaf l = new Leaf();
                        if (leave.LeaveId > 0)
                            l = data.Leaves.FirstOrDefault(le => le.LeaveId == leave.LeaveId);

                        l.LeaveId = leave.LeaveId;
                        l.EnrolleeId = leave.EnrolleeId;
                        l.LeaveNo = leave.LeaveNo;
                        l.LeaveDateFrom = leave.LeaveDateFrom;
                        l.LeaveDateTo = leave.LeaveDateTo;
                        l.LeaveType = leave.LeaveType;
                        l.LeaveNoDays = leave.LeaveNoDays;
                        l.LeaveReason = leave.LeaveReason;
                        l.EditedOn = leave.EditedOn;
                        l.EditedBy = leave.EditedBy;

                        if (leave.LeaveId == 0)
                        {
                            data.Leaves.AddObject(leave);
                            data.SaveChanges();
                            iResult = l.LeaveId;
                        }
                        else
                        {
                            data.SaveChanges();
                            iResult = l.LeaveId;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error - " + ex.Message);
                        //throw;
                    }
                }
            }
            return iResult;
        }

        public static bool DeleteLeave(Leaf leave)
        {
            bool bResult = false;
            using (var data = new DTRDbaseEntities())
            {
                if (leave != null)
                {
                    try
                    {
                        Leaf l = data.Leaves.FirstOrDefault(le => le.LeaveId == leave.LeaveId);
                        if (l != null)
                        {
                            data.Leaves.DeleteObject(leave);
                            data.SaveChanges();
                            bResult = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error - " + ex.Message);
                        //throw;
                    }
                }
            }
            return bResult;
        }

        public static List<Leaf> FillLeaves()
        {
            var data = new DTRDbaseEntities();
            var q = from l in data.Leaves
                    orderby l.LeaveDateFrom descending
                    select l;
            return q.ToList();
        }

        public static List<Leaf> FillLeaves(int iEnrolleeId)
        {
            var data = new DTRDbaseEntities();
            var q = from l in data.Leaves
                    where (l.EnrolleeId == iEnrolleeId)
                    orderby l.LeaveDateFrom descending
                    select l;
            return q.ToList();
        }

        public static Leaf GetLeave(int iEnrolleeId)
        {
            var data = new DTRDbaseEntities();
            Leaf l = null;
            if (iEnrolleeId > 0)
            {
                l = data.Leaves.FirstOrDefault(le => le.EnrolleeId == iEnrolleeId);
            }
            return l;
        }
        #endregion

        #region "11. Users"
        public static int SaveUser(User user1)
        {
            int iResult = 0;
            using (var data = new DTRDbaseEntities())
            {
                User u = new User();
                if (user1 != null)
                {
                    try
                    {

                        if (user1.UserId > 0)
                            u = data.Users.FirstOrDefault(us => us.UserId == user1.UserId);

                        u.UserId = user1.UserId;
                        u.UserName = user1.UserName;
                        u.Password = user1.Password;
                        u.Level = user1.Level;
                        u.Active = user1.Active;
                        u.EditedOn = user1.EditedOn;
                        u.EditedBy = user1.EditedBy;

                        if (user1.UserId == 0)
                        {
                            data.Users.AddObject(user1);
                            data.SaveChanges();
                            iResult = u.UserId;
                        }
                        else
                        {
                            data.SaveChanges();
                            iResult = u.UserId;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error - " + ex.Message);
                        //throw;
                    }
                }
            }
            return iResult;
        }

        public static bool DeleteUser(User user)
        {
            bool bResult = false;
            using (var data = new DTRDbaseEntities())
            {
                if (user != null)
                {
                    User u = data.Users.FirstOrDefault(us => us.UserId == user.UserId);
                    if (u != null)
                    {
                        data.Users.DeleteObject(user);
                        data.SaveChanges();
                        bResult = true;
                    }
                }
            }
            return bResult;
        }

        public static List<User> FillUsers()
        {
            var data = new DTRDbaseEntities();
            var q = from u in data.Users
                    orderby u.UserName ascending
                    select u;
            return q.ToList();
        }

        public static User GetUser(int iUserId)
        {
            var data = new DTRDbaseEntities();
            User u = null;
            if (iUserId > 0)
                u = data.Users.FirstOrDefault(us => us.UserId == iUserId);

            return u;
        }
        #endregion

        #region "12. MachineInstances"
        public static int SaveMachineInstance(MachineInstance machineInstance)
        {
            int iResult = 0;
            using (var data = new DTRDbaseEntities())
            {
                if (machineInstance != null)
                {
                    try
                    {
                        MachineInstance m = new MachineInstance();
                        if (machineInstance.MachineInsId > 0)
                            m = data.MachineInstances.FirstOrDefault(mi => mi.MachineInsId == machineInstance.MachineInsId);

                        m.MachineInsId = machineInstance.MachineInsId;
                        m.MachineInstanceName = machineInstance.MachineInstanceName;
                        m.EditedBy = machineInstance.EditedBy;
                        m.EditedOn = machineInstance.EditedOn;

                        if (machineInstance.MachineInsId == 0)
                        {
                            data.MachineInstances.AddObject(machineInstance);
                            data.SaveChanges();
                            iResult = m.MachineInsId;
                        }
                        else
                        {
                            data.SaveChanges();
                            iResult = m.MachineInsId;
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error - " + ex.Message);
                        //throw;
                    }
                }
            }
            return iResult;
        }

        public static bool DeleteMachieneInstance(MachineInstance machineInstance)
        {
            bool bResult = false;
            using (var data = new DTRDbaseEntities())
            {
                if (machineInstance != null)
                {
                    MachineInstance m = data.MachineInstances.FirstOrDefault(mi => mi.MachineInsId == machineInstance.MachineInsId);

                    if (m != null)
                    {
                        data.MachineInstances.DeleteObject(machineInstance);
                        data.SaveChanges();
                        bResult = true;
                    }
                }
            }
            return bResult;
        }

        public static List<MachineInstance> FillMachineInstances()
        {
            var data = new DTRDbaseEntities();
            var q = from m in data.MachineInstances
                    orderby m.MachineInstanceName ascending
                    select m;
            return q.ToList();
        }

        public static MachineInstance GetMachineInstance(int iMachineInstanceId)
        {
            var data = new DTRDbaseEntities();
            MachineInstance m = null;
            if (iMachineInstanceId > 0)
            {
                m = data.MachineInstances.FirstOrDefault(mi => mi.MachineInsId == iMachineInstanceId);
            }
            return m;
        }
        #endregion

        #region "13. MachineDumpsLog"
        public static int SaveMacDumpLog(MacDumpLog macDumpLog)
        {
            int iResult = 0;
            using (var data = new DTRDbaseEntities())
            {
                if (macDumpLog != null)
                {
                    try
                    {
                        MacDumpLog m = new MacDumpLog();
                        if (macDumpLog.MacDumpId > 0)
                            m = data.MacDumpLogs.FirstOrDefault(ma => ma.MacDumpId == macDumpLog.MacDumpId);

                        m.MacDumpId = macDumpLog.MacDumpId;
                        m.EnrolleeId = macDumpLog.EnrolleeId;
                        m.MachineNo = macDumpLog.MachineNo;
                        m.EnrolleeNo = macDumpLog.EnrolleeNo;
                        m.MachineInsId = macDumpLog.MachineInsId;
                        m.MacDumpDate = macDumpLog.MacDumpDate;
                        m.MacDumpTime = macDumpLog.MacDumpTime;
                        m.EditedBy = macDumpLog.EditedBy;
                        m.EditedOn = macDumpLog.EditedOn;

                        if (macDumpLog.MacDumpId > 0)
                        {
                            data.MacDumpLogs.AddObject(macDumpLog);
                            data.SaveChanges();
                            iResult = m.MacDumpId;
                        }
                        else
                        {
                            data.SaveChanges();
                            iResult = m.MacDumpId;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error - " + ex.Message);
                        //throw;
                    }
                }
            }
            return iResult;
        }

        public static int SaveMacDumpLogAll(List<MacDumpLog> lDumpLog)
        {
            int iResult = 0;
            using (var data = new DTRDbaseEntities())
            {
                try
                {
                    if (lDumpLog != null)
                    {
                        foreach (var q in lDumpLog)
                        {
                            data.MacDumpLogs.AddObject(q);
                            data.SaveChanges();
                            iResult = 1;
                        }
                      
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //throw;
                }
            }
            return iResult;
        }

        public static bool DeleteMacDumpLog(MacDumpLog macDumpLog)
        {
            bool bResult = false;
            using (var data = new DTRDbaseEntities())
            {
                if (macDumpLog != null)
                {
                    MacDumpLog m = data.MacDumpLogs.FirstOrDefault(ma => ma.MacDumpId == macDumpLog.MacDumpId);
                    if (m != null)
                    {
                        data.MacDumpLogs.DeleteObject(macDumpLog);
                        data.SaveChanges();
                        bResult = true;
                    }
                }
            }
            return bResult;
        }

        public static List<MacDumpLog> FillMacDumpLog(int iInstanceId)
        {
            var data = new DTRDbaseEntities();
            var q = from m in data.MacDumpLogs
                    where (m.MachineInsId == iInstanceId)
                    orderby Convert.ToDateTime(m.MacDumpDate) ascending
                    select m;
            return q.ToList();
        }

        public static List<MacDumpLog> FillMacDumpLogEnrollee(int iEnrolleeId)
        {
            var data = new DTRDbaseEntities();
            var q = from m in data.MacDumpLogs
                    where (m.EnrolleeId == iEnrolleeId)
                    orderby Convert.ToDateTime(m.MacDumpDate) ascending
                    select m;
            return q.ToList();
        }

        public static List<MacDumpLog> FillMacDumpLogEnrollee(int iEnrolleeNo, string sdt)
        {
            var data = new DTRDbaseEntities();
            var q = from m in data.MacDumpLogs
                    where ((m.EnrolleeNo == iEnrolleeNo) && (m.MacDumpDate.Trim() == sdt.Trim()))
                    orderby Convert.ToDateTime(m.MacDumpDate) ascending
                    select m;
            return q.ToList();
        }

        public static List<MacDumpLog> FillMacDumpLog(int iInstanceId, int iEnrolleeNo)
        {
            var data = new DTRDbaseEntities();
            var q = from m in data.MacDumpLogs
                    where ((m.MachineInsId == iInstanceId) && (m.EnrolleeNo == iEnrolleeNo))
                    orderby Convert.ToDateTime(m.MacDumpDate) ascending
                    select m;
            return q.ToList();
        }

        public static MacDumpLog GetMacDumpLog(int iMacDumpLogId)
        {
            var data = new DTRDbaseEntities();
            MacDumpLog m = new MacDumpLog();
            if (iMacDumpLogId > 0)
            {
                m = data.MacDumpLogs.FirstOrDefault(ma => ma.MacDumpId == iMacDumpLogId);
            }
            return m;
        }
        #endregion

        #region "14. Company Information"
        public static int SaveCompany(Company company)
        {
            int iResult = 0;
            using (var data = new DTRDbaseEntities())
            {
                if (company != null)
                {
                    Company c = new Company();
                    if (company.CompanyId > 0)
                        c = data.Companies.FirstOrDefault(co => co.CompanyId == company.CompanyId);

                    c.CompanyId = company.CompanyId;
                    c.CompanyName = company.CompanyName;
                    c.CompanyAddress = company.CompanyAddress;
                    c.CompanyContact = company.CompanyContact;
                    c.CompanyActive = company.CompanyActive;

                    if (company.CompanyId == 0)
                    {
                        data.Companies.AddObject(company);
                        data.SaveChanges();
                        iResult = c.CompanyId;
                    }
                    else
                    {
                        data.SaveChanges();
                        iResult = c.CompanyId;
                    }
                }
            }
            return iResult;
        }

        public static bool DeleteCompany(Company company)
        {
            bool bResult = false;
            using (var data = new DTRDbaseEntities())
            {
                if (company != null)
                {
                    Company c = data.Companies.FirstOrDefault(co => co.CompanyId == company.CompanyId);
                    if (c != null)
                    {
                        data.Companies.DeleteObject(company);
                        data.SaveChanges();
                        bResult = true;
                    }
                }
            }
            return bResult;
        }

        public static List<Company> FillCompanies()
        {
            var data = new DTRDbaseEntities();
            var q = from c in data.Companies
                    orderby c.CompanyName ascending
                    select c;
            return q.ToList();
        }

        public static Company GetCompany(int iCompanyId)
        {
            Company tempCom = null;
            var data = new DTRDbaseEntities();
            if (iCompanyId > 0)
            {
                Company c = data.Companies.FirstOrDefault(co => co.CompanyId == iCompanyId);
                if (c != null)
                {
                    tempCom = c;
                }
            }
            return tempCom;
        }

        public static Company GetCompanyActive()
        {
            Company tempCom = null;
            var data = new DTRDbaseEntities();
            Company c = data.Companies.FirstOrDefault(co => co.CompanyActive == true);
            if (c != null)
            {
                tempCom = c;
            }
            return tempCom;
        }
        #endregion
    }
}
