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
    
    public partial class FillStudentClasses_Result
    {
        public string CodeMelli { get; set; }
        public string Name { get; set; }
        public string Lname { get; set; }
        public string Fname { get; set; }
        public string BirthDate { get; set; }
        public Nullable<long> Class_id_FK { get; set; }
        public Nullable<long> Schools_id_FK { get; set; }
        public Nullable<int> Payeh_id_FK { get; set; }
    }
}
