using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace RepairService.Models
{
    [MetadataType(typeof(ProblemMetaData))]
    public partial class Problem
    {

    }

    public class ProblemMetaData
    {
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Problem Name")]
        public string Problem_type { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Device Type")]
        public string Device { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Brand Name")]
        public string BrandName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Problem Descriptions")]
        public string ProblemDescription { get; set; }

        public string userid { get; set; }

    }
}