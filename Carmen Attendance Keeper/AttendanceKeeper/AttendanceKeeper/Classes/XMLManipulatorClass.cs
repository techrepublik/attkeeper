using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace AttendanceKeeper.Classes
{
    public class XmlManipulatorClass
    {
        public static void SerializeToXml(List<LeaveOb> leaveObs)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<LeaveOb>));
            TextWriter textWriter = new StreamWriter(Application.StartupPath + @"LeaveOB.xml");
            xmlSerializer.Serialize(textWriter, leaveObs);
            textWriter.Close();
        }

        public static void SerializeToXml(LeaveOb leaveOb)
        {
            var xmlSerializer = new XmlSerializer(typeof (List<LeaveOb>));
            TextWriter textWriter = new StreamWriter(Application.StartupPath + @"LeaveOB.xml");
            xmlSerializer.Serialize(textWriter, leaveOb);
            textWriter.Close();
        }

        public static List<LeaveOb> DeSerializeFromXml()
        {
            List<LeaveOb> listLeaveOb;
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(List<LeaveOb>));
                TextReader textReader = new StreamReader(Application.StartupPath + @"LeaveOB.xml");
                listLeaveOb = (List<LeaveOb>)xmlSerializer.Deserialize(textReader);
                textReader.Close();
            }
            catch (Exception)
            {
                listLeaveOb = null;
                //throw;
            }
            
            return listLeaveOb;
        }
    }
}
