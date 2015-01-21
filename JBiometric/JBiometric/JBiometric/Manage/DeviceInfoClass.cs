namespace JBiometric.Manage 
{
    public class DeviceInfoClass
    {
        public static zkemkeeper.CZKEMClass DDevice()
        {
            return new zkemkeeper.CZKEMClass();
        }

        //GetSerialNumber of Device
        public static string GetDeviceSN(int iMachineNumber, ref int iError, int iConType, string sIP, int iPort)
        {
            var con = new ConnectionClass();
            int iTempError = 0;
            string sSN = string.Empty;
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
                string sTempSerialNumber;
                if (con.DDevice.GetSerialNumber(iMachineNumber, out sTempSerialNumber))
                {
                    sSN = sTempSerialNumber;
                }
                else
                {
                    con.DDevice.GetLastError(ref iTempError);
                }
            }
            else
            {
                sSN = string.Empty;
            }

            con.DDevice.Disconnect();
            return sSN;
        }
    }
}
