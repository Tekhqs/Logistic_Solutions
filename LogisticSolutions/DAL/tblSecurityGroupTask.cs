//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblSecurityGroupTask
    {
        public int SecurityGroupTasksID { get; set; }
        public int SecurityGroupID { get; set; }
        public int SecurityTaskID { get; set; }
        public int CustomerID { get; set; }
        public bool CanSearch { get; set; }
        public bool CanView { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public bool CanPrint { get; set; }
        public bool CanFullControl { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    
        public virtual tblSecurityGroup tblSecurityGroup { get; set; }
        public virtual tblSecurityTask tblSecurityTask { get; set; }
    }
}
