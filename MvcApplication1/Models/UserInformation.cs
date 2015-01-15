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
    
    public partial class UserInformation
    {
        public int UserId { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string PersonalPhone { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
    
        public virtual Administrator Administrator { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}