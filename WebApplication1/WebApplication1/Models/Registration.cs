using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Registration
    {
        [Required]
        [StringLength(150, ErrorMessage = "Name length must not exceed 150")]
        public string Name { get; set; }
        [Required]
        //[RegularExpression(@"^\d{2}-\d{5}-\d{1}$", ErrorMessage = "Id must follow XX-XXXXX-X")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(14, ErrorMessage = "Max Phone Number Charecters Should Be 14")]
        public string Phone { get; set; }

        [Required]
        public string Password { get; set; }

        [Required(ErrorMessage = "Retype The Password")]
        [Compare(nameof(Password), ErrorMessage = "Retyped Password Dosen't Match")]
        public string ConfirmPass { get; set; }

        [Required]
        public string Dob { get; set; }
        
    }
}