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
    
    public partial class tblCity
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public int StateID_Province { get; set; }
        public int CountryID { get; set; }
        public bool isActive { get; set; }
        public bool isDelete { get; set; }
    }
}
