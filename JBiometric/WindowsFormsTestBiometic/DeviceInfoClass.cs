using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBiometric
{
    public class DeviceInfoClass
    {
        public static zkemkeeper.CZKEMClass DDevice()
        {
            return new zkemkeeper.CZKEMClass();
        }

        //GetSerialNumber of Device
        public static string GetDeviceSN(int iMachineNumber, ref int iError)
        {
            var z = new zkemkeeper.CZKEMClass();
            int iTempError = 0;
            string sSN = string.Empty;

            if (z.Connect_USB(iMachineNumber))
            {
                string sTempSerialNumber;
                if (z.GetSerialNumber(iMachineNumber, out sTempSerialNumber))
                {
                    sSN = sTempSerialNumber;
                }
                else
                {
                    z.GetLastError(ref iTempError);
                }
            }
            else
            {
                sSN = string.Empty;
            }

            z.Disconnect();
            return sSN;
        }
    }
}
