//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RepairService.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AssignProblem
    {
        public int asId { get; set; }
        public string ProblemName { get; set; }
        public string DeviceName { get; set; }
        public string BrandName { get; set; }
        public Nullable<int> techid { get; set; }
        public Nullable<int> probid { get; set; }
        public string ProblemDescription { get; set; }
    }
}