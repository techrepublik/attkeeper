using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace AttendanceKeeper.Classes
{
    public class LeaveOb
    {
        [XmlAttribute("LeaveObName")]
        public string LeaveObName { get; set; }

        [XmlElement("LeaveDescription")]
        public string LeaveObDescription { get; set; }
    }
}
