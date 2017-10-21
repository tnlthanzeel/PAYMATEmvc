using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PaymateMVC.Models
{
    public class LoginViewModel
    {
        public int CustomerID { get; set; }

        [Required(ErrorMessage ="Please enter your username")]
        [Display(Name ="Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Please enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}