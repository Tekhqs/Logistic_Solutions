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
    
    public partial class tblWarehouseMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblWarehouseMaster()
        {
            this.tblItemInventory_Customer = new HashSet<tblItemInventory_Customer>();
            this.tblStorageLocations = new HashSet<tblStorageLocation>();
        }
    
        public int WarehouseID { get; set; }
        public string WareHouseCode { get; set; }
        public string WareHouseDescription { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string CityID { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Remarks { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblItemInventory_Customer> tblItemInventory_Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblStorageLocation> tblStorageLocations { get; set; }
    }
}
