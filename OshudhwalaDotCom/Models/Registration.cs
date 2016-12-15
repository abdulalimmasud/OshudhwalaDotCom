using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OshudhwalaDotCom.Models
{
    public class Registration
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Password { set; get; }
        [Compare("Password")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { set; get; }
        public string Address { set; get; }
        public int UserType { set; get; }
        [DisplayName("Date of Birth")]
        public string DateOfBirth { set; get; }

    }
}