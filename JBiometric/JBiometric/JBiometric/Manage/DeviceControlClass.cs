using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zkemkeeper;

namespace JBiometric.Manage 
{
    public class DeviceControlClass
    {

        //PowerOffDevice
        public static bool TurnOffDevice(int iMachineNumber, ref string sError, int iConType, string sIP, int iPort)
        {
            var con = new ConnectionClass();
            bool bResult = false;
            int iError = 0;

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

            if (bConnect)
            {
                if (con.DDevice.PowerOffDevice(iMachineNumber))
                {
                    bResult = true;
                }
                else
                {
                    con.DDevice.GetLastError(ref iError);
                }
            }
           
            return bResult;
        }

        //RetartDevice
        public static bool RestartDevice(int iMachineNumber, ref string sError, int iConType, string sIP, int iPort)
        {
            var con = new ConnectionClass();
            bool bResult = false;
            int iError = 0;

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

            if (bConnect)
            {
                if (con.DDevice.RestartDevice(iMachineNumber))
                {
                    bResult = true;
                }
                else
                {
                    con.DDevice.GetLastError(ref iError);
                }
            }
            
            return bResult;
        }

        //DisableDeviceWithTimeOut
        public static bool DisableDeviceTimeOut(int iMachineNumber, int iDuration, 
            ref int iError, int iConType, string sIP, int iPort)
        {
            var con = new ConnectionClass();
            bool bResult = false;
            int iTempError = 0;

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

            if (bConnect)
            {
                if (con.DDevice.DisableDeviceWithTimeOut(iMachineNumber, iDuration))
                {
                    con.DDevice.RefreshData(iMachineNumber);
                    bResult = true;
                }
                else
                {
                    con.DDevice.GetLastError(ref iTempError);
                }
            }
           
            con.DDevice.Disconnect();
            return bResult;
        }

        public static bool SetDeviceTime(int iMachineNumber, int iConType, string sIP, int iPort)
        {
            var con = new ConnectionClass();
            bool bResult = false;
            int iError = 0;

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

            if (bConnect)
            {
                if (con.DDevice.SetDeviceTime(iMachineNumber))
                {
                    bResult = true;
                }
                else
                {
                    con.DDevice.GetLastError(ref iError);
                }
            }
           
            return bResult;
        }

        public static bool SetDeviceTime(int iMachineNumber, int iConType, int iYear, int iMonth, int iDay,
                                        int iHour, int iMin, int iSec, string sIP, int iPort)
        {
            var con = new ConnectionClass();
            bool bResult = false;
            int iError = 0;

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

            if (bConnect)
            {
                if (con.DDevice.SetDeviceTime2(iMachineNumber, iYear, iMonth, iDay, iHour, iMin, iSec))
                {
                    bResult = true;
                }
                else
                {
                    con.DDevice.GetLastError(ref iError);
                }
            }
            
            return bResult;
        }

        public static bool GetDeviceTime(int iMachineNumber, int iConType, out string sDTime, string sIP, int iPort)
        {
            var con = new ConnectionClass();
            bool bResult = false;

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

            int idwErrorCode = 0;

            int idwYear = 0;
            int idwMonth = 0;
            int idwDay = 0;
            int idwHour = 0;
            int idwMinute = 0;
            int idwSecond = 0;

            string tempDTime = string.Empty;

            if (bConnect)
            {
                if (con.DDevice.GetDeviceTime(iMachineNumber, ref idwYear, ref idwMonth, ref idwDay, ref idwHour,
                                           ref idwMinute, ref idwSecond))
                {
                    tempDTime = idwYear.ToString() + "-" + idwMonth.ToString() + "-" + idwDay.ToString() +
                                            " @ " + idwHour.ToString() + ":" + idwMinute.ToString() + ":" +
                                            idwSecond.ToString();
                    bResult = true;
                }
                else
                {
                    con.DDevice.GetLastError(ref idwErrorCode);
                }
            }
            sDTime = tempDTime;
            return bResult;
        }
    }
}
