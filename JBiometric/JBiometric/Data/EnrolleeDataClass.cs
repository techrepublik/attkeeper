using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JBiometric.Entities;

namespace JBiometric.Data
{
    public class EnrolleeDataClass
    {
        public static List<Enrollee> GetEnrollData(int iMachineNumber, int iConType)
        {
            var lEnrollee = new List<Enrollee>();
            var con = new ConnectionClass();
            var bConnect = false;
            switch (iConType)
            {
                case 1:
                    bConnect = con.ConnectViaUSB();
                    break;
                case 2:
                    bConnect = con.ConnectViaNet();
                    break;
                default:
                    break;
            }

            var iUserId = 0;
            int iBakupNo = 0;
            int iPrivilege = 0;
            int iPassword = 0;
            var sPassword = string.Empty;
            var sName = string.Empty;
            bool bEnabled = false;
            int iFingerIndex = 0;
            string sTmpData = string.Empty;
            int iTmpLength = 0;

            con.DDevice.EnableDevice(iMachineNumber, false);

            if (!bConnect)
            {
                lEnrollee.Clear();
            }
            else
            {
                //z.BeginBatchUpdate(iMachineNumber, 1);
                con.DDevice.ReadAllUserID(iMachineNumber);
                con.DDevice.ReadAllTemplate(iMachineNumber);
                while (con.DDevice.GetAllUserInfo(iMachineNumber, ref iUserId, ref sName, ref sPassword, ref iPrivilege, ref bEnabled))
                {
                    for (iFingerIndex = 0; iFingerIndex < 10; iFingerIndex++)
                    {
                        if (con.DDevice.GetUserTmpStr(iMachineNumber, iUserId, iFingerIndex, ref sTmpData, ref iTmpLength))
                        {
                            var e = new Enrollee
                            {
                                IMachineNumber = iMachineNumber,
                                IEMachineNumber = iMachineNumber,
                                IEnrollNumber = iUserId,
                                IBackupNumber = iBakupNo,
                                IMachinePrivilege = iPrivilege,
                                IFingerPrint = iFingerIndex,
                                IPassword = iPassword,
                                SName = sName,
                                STmpData = sTmpData,
                                BEnabled = bEnabled,
                            };
                            lEnrollee.Add(e);
                        }
                    }
                    
                }
                //z.BatchUpdate(iMachineNumber);
            }
            con.DDevice.EnableDevice(iMachineNumber, true);
            con.DDevice.Disconnect();

            return lEnrollee;
        }
    }
}
