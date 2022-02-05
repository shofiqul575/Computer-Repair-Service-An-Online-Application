using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RepairService.Models
{
    [MetadataType(typeof(TechnicianMedaData))]
    public partial class Technician
    {
        public string ConfirmPassword { get; set; }
    }
    public partial class TechnicianMedaData
    {
        [DisplayName("Technician Name")]
        [Required(ErrorMessage = "This field is required")]
        public string TechnicianName { get; set; }

        [DisplayName("Shop Name")]
        [Required(ErrorMessage = "This field is required")]
        public string ShopName { get; set; }

        [DisplayName("Shop Address")]
        [Required(ErrorMessage = "This field is required")]
        public string ShopAddress { get; set; }

        [DisplayName("Contact Number")]
        [Required(ErrorMessage = "This field is required")]
        public string Phone { get; set; }

        [DisplayName("Expertise On")]
        [Required(ErrorMessage = "This field is required")]
        public string Expertise { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 Characters is required")]
        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password dont match")]
        [MinLength(6, ErrorMessage = "Minimum 6 Characters is required")]
        public string ConfirmPassword { get; set; }
    }
}