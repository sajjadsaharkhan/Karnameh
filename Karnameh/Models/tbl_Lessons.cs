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
    
    public partial class tbl_Lessons
    {
        public tbl_Lessons()
        {
            this.tbl_Marks = new HashSet<tbl_Marks>();
        }
    
        public long id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Payeh_id_FK { get; set; }
    
        public virtual tbl_Payeh tbl_Payeh { get; set; }
        public virtual ICollection<tbl_Marks> tbl_Marks { get; set; }
    }
}
