//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Karnameh.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class viw_Schools
    {
        public long id { get; set; }
        public string Name { get; set; }
        public Nullable<long> Manager_PersonalCode_FK { get; set; }
        public Nullable<long> MoavenEjraei_PersonalCode_FK { get; set; }
        public string MoavenFullName { get; set; }
        public string ManagerFullName { get; set; }
    }
}
