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
    
    public partial class RescueEquipmentSet
    {
        public int RescueEquipmentSetId { get; set; }
        public Nullable<int> CarId { get; set; }
        public Nullable<int> RescueEquipmentCount { get; set; }
        public string RescueEquipmentCondition { get; set; }
        public string RescueEquipmentDescription { get; set; }
        public string RescueEquipmentClassification { get; set; }
    
        public virtual Car Car { get; set; }
    }
}
