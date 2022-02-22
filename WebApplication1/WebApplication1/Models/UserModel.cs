using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UserModel
    {
        public long UserID { get; set; }
        public string Name { get; set; }
        [Required]
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
        public string Dob { get; set; }
        public string Gender { get; set; }
    }
}