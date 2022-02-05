﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RepairService.Models
{
    [MetadataType(typeof(tbl_adminMetaData))]
    public partial class tbl_Admin
    {
        public string ConfirmPassword { get; set; }
    }

    public class tbl_adminMetaData
    {
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }

        
        [DisplayName("Contact Number")]
        [Required(ErrorMessage = "This field is required")]
        public string Phone { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Address { get; set; }

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