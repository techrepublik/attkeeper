using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JBiometric.Manage;
using zkemkeeper;

namespace JBiometric
{
    public class ConnectionClass
    {
        public string SIP { get; set; }
        public int IPort { get; set; }
        public int IMachineNo { get; set; }
        public zkemkeeper.CZKEMClass DDevice { get; set; }

        public ConnectionClass()
        {
            SIP = "192.168.1.201";
            IPort = 4370;
            DDevice = new CZKEMClass();
        }

        public ConnectionClass(string sIP, int iPort)
        {
            SIP = sIP;
            IPort = iPort;
            DDevice = new CZKEMClass();
        }

        public bool ConnectViaUSB()
        {
            return DDevice.Connect_USB(IMachineNo);
        }

        public bool ConnectViaNet()
        {
            return DDevice.Connect_Net(SIP, IPort);
        }

        public bool EnableDevice(bool bEnable)
        {
            return DDevice.EnableDevice(IMachineNo, bEnable);
        }

        public void Disconnect()
        {
            DDevice.Disconnect();
        }

        #region "Connection"

        
        
        #endregion
    }
}
