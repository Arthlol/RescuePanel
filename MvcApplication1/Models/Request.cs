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
    
    public partial class Request
    {
        public Request()
        {
            this.EmergencyTeamDeparture = new HashSet<EmergencyTeamDeparture>();
        }
    
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public int RequestStatusId { get; set; }
        public int RequestTypeId { get; set; }
        public string DeclarantName { get; set; }
        public string DeclarantLastName { get; set; }
        public string DeclarantMiddleName { get; set; }
        public Nullable<System.DateTime> RequestDate { get; set; }
        public string DeclarantPhone { get; set; }
        public string Address { get; set; }
        public string RequestReason { get; set; }
        public Nullable<bool> FakeRequest { get; set; }
    
        public virtual ICollection<EmergencyTeamDeparture> EmergencyTeamDeparture { get; set; }
        public virtual Operator Operator { get; set; }
        public virtual RequestStatus RequestStatus { get; set; }
        public virtual RequestType RequestType { get; set; }
    }
}
