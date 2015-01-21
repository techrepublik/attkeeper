using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttendanceKeeper.Classes
{
    class SettingClass
    {
        public int ISettingId { get; set; }
        public string SSettingName { get; set; }

        public DateTime DTInAM { get; set; }
        public DateTime DTOutAM { get; set; }
        public DateTime DTInPM { get; set; }
        public DateTime DTOutPM { get; set; }
        public DateTime DTInOT { get; set; }
        public DateTime DTOutOT { get; set; }

    }
}