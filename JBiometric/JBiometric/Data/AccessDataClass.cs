using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JBiometric;
using JBiometric.Entities;
using zkemkeeper;

namespace JBiometric.Data
{
    public class AccessDataClass
    {
        //GetGeneralLogs (default)
        public static List<AttLog> GetAttlog(int iMachineNumber, ref string sError, int iType, string sIP, int iPort)
        {
            var con = new ConnectionClass();
            var lLogs = new List<AttLog>();
            var bConnect = false;
            switch (iType)
            {
                case 1:
                    bConnect = con.ConnectViaUSB();
                    break;
                case 2:
                    con.SIP = sIP;
                    con.IPort = iPort;
                    bConnect = con.ConnectViaNet();
                    break;
                default:
                    break;
            }
            if (bConnect == true)
            {
                int idwTMachineNumber = 0;
                int idwEnrollNumber = 0;
                string sdwEnrollNumber = string.Empty;
                int idwEMachineNumber = 0;
                int idwVerifyMode = 0;
                int idwInOutMode = 0;
                int idwYear = 0;
                int idwMonth = 0;
                int idwDay = 0;
                int idwHour = 0;
                int idwMinute = 0;
                int idwSecond = 0;
                int idwWorkCode = 0;

                int idwErrorCode = 0;
                int iGLCount = 0;
                int iIndex = 0;

                con.EnableDevice(false);//disable the device
                if (con.DDevice.ReadGeneralLogData(iMachineNumber))//read all the attendance records to the memory
                {
                    //while (con.DDevice.GetGeneralLogData(iMachineNumber, ref idwTMachineNumber, ref idwEnrollNumber,
                    //        ref idwEMachineNumber, ref idwVerifyMode, ref idwInOutMode, ref idwYear, ref idwMonth, ref idwDay, ref idwHour, ref idwMinute))//get records from the memory
                    switch (iType)
                    {
                        case 1:
                            while (con.DDevice.GetGeneralLogData(iMachineNumber, ref idwTMachineNumber, ref idwEnrollNumber,
                                ref idwEMachineNumber, ref idwVerifyMode, ref idwInOutMode, ref idwYear, ref idwMonth, ref idwDay, ref idwHour, ref idwMinute))//get records from the memory
                            {
                                var a = new AttLog();
                                iGLCount++;
                                a.EMachineNumber = idwEMachineNumber;
                                a.MachineNo = idwEMachineNumber;
                                a.EnrolleeNo = idwEnrollNumber;
                                a.GLCount = iGLCount;
                                a.EnrollNumber = idwEnrollNumber;
                                a.SEnrollNumber = idwEnrollNumber.ToString();
                                a.VerifyCode = idwVerifyMode;
                                a.InOutCode = idwInOutMode;
                                a.IYear = idwYear;
                                a.IMonth = idwMonth;
                                a.IDay = idwDay;
                                a.IHour = idwHour;
                                a.IMinute = idwMinute;
                                a.IMin = idwMinute;
                                a.Index = iIndex + 1;
                                iIndex++;
                                lLogs.Add(a);
                            }
                            break;
                        case 2:
                            while (con.DDevice.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber,
                                out idwVerifyMode, out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkCode))//get records from the memory
                            {
                                var a = new AttLog();
                                iGLCount++;
                                a.GLCount = iGLCount;
                                a.EMachineNumber = idwEMachineNumber;
                                a.MachineNo = iMachineNumber;
                                a.EnrolleeNo = Convert.ToInt16(sdwEnrollNumber);
                                a.SEnrollNumber = sdwEnrollNumber;
                                a.EnrollNumber = idwEnrollNumber;
                                a.VerifyCode = idwVerifyMode;
                                a.InOutCode = idwInOutMode;
                                a.IYear = idwYear;
                                a.IMonth = idwMonth;
                                a.IDay = idwDay;
                                a.IHour = idwHour;
                                a.IMinute = idwMinute;
                                a.IMin = idwMinute;
                                a.ISecond = idwSecond;
                                a.Index = iIndex + 1;
                                iIndex++;
                                lLogs.Add(a);
                            }
                            break;
                        default:
                            break;
                    }

                    
                }
                else
                {
                    con.DDevice.GetLastError(ref idwErrorCode);
                    if (idwErrorCode != 0)
                    {
                        sError = "Reading data from terminal failed,ErrorCode: " + idwErrorCode.ToString();
                    }
                    else
                    {
                        sError = "No data from terminal returns!";
                    }
                }
                
            }
            else
            {
                lLogs.Clear();
            }
            con.EnableDevice(true);//enable the device
            con.DDevice.Disconnect();
            return lLogs;
        }

        public static List<AttLog> GetAttlog(int iMachineNumber, ref string sError, int iType, bool bColor, string sIP, int iPort)
        {
            var con = new ConnectionClass();
            var lLogs = new List<AttLog>();
            var bConnect = false;
            switch (iType)
            {
                case 1:
                    
                    bConnect = con.ConnectViaUSB();
                    break;
                case 2:
                    con.SIP = sIP;
                    con.IPort = iPort;
                    bConnect = con.ConnectViaNet();
                    break;
                default:
                    break;
            }
            if (bConnect)
            {
                int idwTMachineNumber = 0;
                int idwEnrollNumber = 0;
                string sdwEnrollNumber = string.Empty;
                int idwEMachineNumber = 0;
                int idwVerifyMode = 0;
                int idwInOutMode = 0;
                int idwYear = 0;
                int idwMonth = 0;
                int idwDay = 0;
                int idwHour = 0;
                int idwMinute = 0;
                int idwSecond = 0;
                int idwWorkCode = 0;

                int idwErrorCode = 0;
                int iGLCount = 0;
                int iIndex = 0;

                con.EnableDevice(false);//disable the device
                if (con.DDevice.ReadGeneralLogData(iMachineNumber))//read all the attendance records to the memory
                {
                    //while (con.DDevice.GetGeneralLogData(iMachineNumber, ref idwTMachineNumber, ref idwEnrollNumber,
                    //        ref idwEMachineNumber, ref idwVerifyMode, ref idwInOutMode, ref idwYear, ref idwMonth, ref idwDay, ref idwHour, ref idwMinute))//get records from the memory
                    if (bColor == false)
                    {
                        while (con.DDevice.GetGeneralLogData(iMachineNumber, ref idwTMachineNumber, ref idwEnrollNumber,
                                                             ref idwEMachineNumber, ref idwVerifyMode, ref idwInOutMode,
                                                             ref idwYear, ref idwMonth, ref idwDay, ref idwHour,
                                                             ref idwMinute)) //get records from the memory
                        {
                            var a = new AttLog();
                            iGLCount++;
                            a.EMachineNumber = idwEMachineNumber;
                            a.MachineNo = idwEMachineNumber;
                            a.EnrolleeNo = idwEnrollNumber;
                            a.GLCount = iGLCount;
                            a.EnrollNumber = idwEnrollNumber;
                            a.SEnrollNumber = idwEnrollNumber.ToString();
                            a.VerifyCode = idwVerifyMode;
                            a.InOutCode = idwInOutMode;
                            a.IYear = idwYear;
                            a.IMonth = idwMonth;
                            a.IDay = idwDay;
                            a.IHour = idwHour;
                            a.IMinute = idwMinute;
                            a.IMin = idwMinute;
                            a.Index = iIndex + 1;
                            iIndex++;
                            lLogs.Add(a);
                        }
                    }
                    else
                    {
                        while (con.DDevice.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber,
                                out idwVerifyMode, out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkCode))//get records from the memory
                            {
                                var a = new AttLog();
                                iGLCount++;
                                a.GLCount = iGLCount;
                                a.EMachineNumber = idwEMachineNumber;
                                a.MachineNo = iMachineNumber;
                                a.EnrolleeNo = Convert.ToInt16(sdwEnrollNumber);
                                a.SEnrollNumber = sdwEnrollNumber;
                                a.EnrollNumber = idwEnrollNumber;
                                a.VerifyCode = idwVerifyMode;
                                a.InOutCode = idwInOutMode;
                                a.IYear = idwYear;
                                a.IMonth = idwMonth;
                                a.IDay = idwDay;
                                a.IHour = idwHour;
                                a.IMinute = idwMinute;
                                a.IMin = idwMinute;
                                a.ISecond = idwSecond;
                                a.Index = iIndex + 1;
                                iIndex++;
                                lLogs.Add(a);
                            }
                    }

                }
                else
                {
                    con.DDevice.GetLastError(ref idwErrorCode);
                    if (idwErrorCode != 0)
                    {
                        sError = "Reading data from terminal failed,ErrorCode: " + idwErrorCode.ToString();
                    }
                    else
                    {
                        sError = "No data from terminal returns!";
                    }
                }

            }
            else
            {
                lLogs.Clear();
            }
            con.EnableDevice(true);//enable the device
            con.DDevice.Disconnect();
            return lLogs;
        }

        //GetGeneralLogs From Device (string type and extended type)
        public static List<AttLog> GetAttlog(int iMachineNumber, ref string sError, int iDisplay, int iType, string sIP, int iPort)
        {
            var con = new ConnectionClass();
            var lLogs = new List<AttLog>();
            var bConnect = false;
            switch (iType)
            {
                case 1:
                    bConnect = con.ConnectViaUSB();
                    break;
                case 2:
                    con.SIP = sIP;
                    con.IPort = iPort;
                    bConnect = con.ConnectViaNet();
                    break;
                default:
                    break;
            }
            if (bConnect == true)
            {
                int idwEnrollNumber = 0;
                int idwVerifyMode = 0;
                int idwInOutMode = 0;
                int idwYear = 0;
                int idwMonth = 0;
                int idwDay = 0;
                int idwHour = 0;
                int idwMinute = 0;
                int idwSecond = 0;
                int idwWorkCode = 0;
                int idwReserved = 0;

                string sdwTime = string.Empty;

                int idwErrorCode = 0;
                int iGLCount = 0;
                int iIndex = 0;

                con.EnableDevice(false) ;//disable the device
                if (con.DDevice.ReadGeneralLogData(iMachineNumber))//read all the attendance records to the memory
                {
                    if (iDisplay == 1)
                    {
                        while (con.DDevice.GetGeneralLogDataStr(iMachineNumber, ref idwEnrollNumber, ref idwVerifyMode,
                                                            ref idwInOutMode, ref sdwTime))
                            //get the records from memory
                        {
                            var a = new AttLog();
                            iGLCount++;
                            a.EMachineNumber = iMachineNumber;
                            a.MachineNo = iMachineNumber;
                            a.EnrolleeNo = idwEnrollNumber;
                            a.GLCount = iGLCount;
                            a.EnrollNumber = idwEnrollNumber;
                            a.VerifyCode = idwVerifyMode;
                            a.InOutCode = idwInOutMode;
                            a.STime = sdwTime;
                            iIndex++;
                            lLogs.Add(a);
                        }
                    }
                    else if (iDisplay == 2)
                    {
                        while (con.DDevice.GetGeneralExtLogData(iMachineNumber, ref idwEnrollNumber, ref idwVerifyMode, ref idwInOutMode,
                            ref idwYear, ref idwMonth, ref idwDay, ref idwHour, ref idwMinute, ref idwSecond, ref idwWorkCode, ref idwReserved))//get records from the memory
                        {
                            var a = new AttLog();
                            iGLCount++;
                            a.GLCount = iGLCount;
                            a.EMachineNumber = iMachineNumber;
                            a.MachineNo = iMachineNumber;
                            a.EnrolleeNo = idwEnrollNumber;
                            a.EnrollNumber = idwEnrollNumber;
                            a.VerifyCode = idwVerifyMode;
                            a.InOutCode = idwInOutMode;
                            a.IYear = idwYear;
                            a.IMonth = idwMonth;
                            a.IDay = idwDay;
                            a.IHour = idwHour;
                            a.IMinute = idwMinute;
                            a.ISecond = idwSecond;
                            a.IWorkCode = idwWorkCode;
                            a.IReserved = idwReserved;
                            iIndex++;
                            lLogs.Add(a);
                        }
                    }
                }
                else
                {
                    con.DDevice.GetLastError(ref idwErrorCode);
                    if (idwErrorCode != 0)
                    {
                        sError = "Reading data from terminal failed,ErrorCode: " + idwErrorCode.ToString();
                    }
                    else
                    {
                        sError = "No data from terminal returns!";
                    }
                }
            }
            else
            {
                lLogs.Clear();
            }
            con.DDevice.EnableDevice(iMachineNumber, true);//enable the device
            con.DDevice.Disconnect();
            return lLogs;
        }

        //GetDeviceStatus or GetDeviceRecord(s)
        public static int GetRecordOnDevice(int iMachineNumber, int iStatus, ref int iError, int iType, string sIP, int iPort)
        {
            var con = new ConnectionClass();
            int iValue = 0;
            int iTempValue = 0;
            var bConnect = false;
            switch (iType)
            {
                case 1:
                    bConnect = con.ConnectViaUSB();
                    break;
                case 2:
                    con.SIP = sIP;
                    con.IPort = iPort;
                    bConnect = con.ConnectViaNet();
                    break;
                default:
                    break;
            }
            if (bConnect)
            {
                con.EnableDevice(false);
                if (con.DDevice.GetDeviceStatus(iMachineNumber, iStatus, ref iTempValue))
                {
                    iValue = iTempValue;
                }
                else
                {
                    con.DDevice.GetLastError(ref iError);
                    iValue = 0;
                }
                con.EnableDevice(true);
            }
            else
            {
                iValue = 0;
            }
            con.Disconnect();
            return iValue;
        }

        //ClearLogsInDevice
        public static bool ClearDeviceLogs(int iMachineNumber, ref int iError, int iConType, string sIP, int iPort )
        {
            var con = new ConnectionClass();
            var bConnect = false;
            switch (iConType)
            {
                case 1:
                    bConnect = con.ConnectViaUSB();
                    break;
                case 2:
                    con.SIP = sIP;
                    con.IPort = iPort;
                    bConnect = con.ConnectViaNet();
                    break;
                default:
                    break;
            }

            int iTempError = 0;
            bool bResult = false;

            con.DDevice.EnableDevice(iMachineNumber, false);
            if (bConnect)
            {
                if (con.DDevice.ClearGLog(iMachineNumber))
                {
                    con.DDevice.RefreshData(iMachineNumber);
                    bResult = true;
                }
                else
                {
                    con.DDevice.GetLastError(ref iTempError);
                    iError = iTempError;
                }
            }
            con.DDevice.EnableDevice(iMachineNumber, true);
            con.DDevice.Disconnect();
            return bResult;
        }
    }
}
