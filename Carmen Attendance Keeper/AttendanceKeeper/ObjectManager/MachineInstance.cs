//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ObjectManager
{
    using System;
    using System.Collections.Generic;
    
    public partial class MachineInstance
    {
        public MachineInstance()
        {
            this.MacDumpLogs = new HashSet<MacDumpLog>();
            this.Machines = new HashSet<Machine>();
        }
    
        public int MachineInsId { get; set; }
        public string MachineInstanceName { get; set; }
        public string EditedBy { get; set; }
        public Nullable<System.DateTime> EditedOn { get; set; }
    
        public virtual ICollection<MacDumpLog> MacDumpLogs { get; set; }
        public virtual ICollection<Machine> Machines { get; set; }
    }
}