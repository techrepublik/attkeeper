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
    
    public partial class Leaf
    {
        public int LeaveId { get; set; }
        public Nullable<int> EnrolleeId { get; set; }
        public string LeaveNo { get; set; }
        public Nullable<System.DateTime> LeaveDateFrom { get; set; }
        public Nullable<System.DateTime> LeaveDateTo { get; set; }
        public string LeaveType { get; set; }
        public Nullable<int> LeaveNoDays { get; set; }
        public string LeaveReason { get; set; }
        public string EditedBy { get; set; }
        public Nullable<System.DateTime> EditedOn { get; set; }
    
        public virtual Enrollee Enrollee { get; set; }
    }
}