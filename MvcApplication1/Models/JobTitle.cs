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
    
    public partial class JobTitle
    {
        public JobTitle()
        {
            this.Employee = new HashSet<Employee>();
        }
    
        public int JobTitleId { get; set; }
        public string JobTitleName { get; set; }
        public Nullable<decimal> Salary { get; set; }
    
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
