//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Operator
    {
        public Operator()
        {
            this.Request = new HashSet<Request>();
        }
    
        public int UserId { get; set; }
        public string WorkShift { get; set; }
        public Nullable<bool> MayWorkOvertime { get; set; }
        public string HomePhone { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Request> Request { get; set; }
    }
}
