using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBiometric.Manage
{
    public class OnlineEnrollClass
    {
        public static bool EnrollUserFinger(int iMachineNumber, int iUserId, int iFingerIndex, 
            int iFlag, ref int iError, int iConType, string sIP, int iPort)
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
                con.DDevice.CancelOperation();
                con.DDevice.DelUserTmp(iMachineNumber, iUserId, iFingerIndex);
                if (con.DDevice.StartEnrollEx(iUserId.ToString(), iFingerIndex, iFlag))
                {
                    con.DDevice.StartIdentify();
                    bResult = true;
                }
                else
                {
                    con.DDevice.GetLastError(ref iTempError);
                    iError = iTempError;
                }
            }
            else
            {
                bResult = false;
            }
            
            return bResult;
        }

        public static bool DeleteUserData(int iMachineNumber, int iUserId, int iBackupNumber, 
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
                con.DDevice.EnableDevice(iMachineNumber, false);
                //for B&W -> if (con.DDevice.DeleteEnrollData(iMachineNumber, iUserId, iMachineNumber, iBackupNumber))
                if (con.DDevice.SSR_DeleteEnrollData(iMachineNumber, iUserId.ToString(), iBackupNumber))
                {
                    bResult = con.DDevice.RefreshData(iMachineNumber);
                }
                else
                {
                    con.DDevice.GetLastError(ref iTempError);
                    bResult = false;
                }
                con.DDevice.EnableDevice(iMachineNumber, true);
            }

            con.DDevice.Disconnect();
            return bResult;
        }
    }
}
