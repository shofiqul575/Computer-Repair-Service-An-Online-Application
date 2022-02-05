using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RepairService.Models
{
    [MetadataType(typeof(AssignProblemMeta))]
    public partial class AssignProblem
    {

    }

    public class AssignProblemMeta
    {
       
        [DisplayName("Problem Name")]
        public string ProblemName { get; set; }

        [DisplayName("Device Name")]
        public string DeviceName { get; set; }

        [DisplayName("Brand Name")]
        public string BrandName { get; set; }
        public Nullable<int> techid { get; set; }

        [DisplayName("Problem Id")]
        public Nullable<int> probid { get; set; }

        [DisplayName("Problem Description")]
        public string ProblemDescription { get; set; }
    }
}