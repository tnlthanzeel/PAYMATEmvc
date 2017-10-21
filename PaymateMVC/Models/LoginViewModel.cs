using AutoMapper;
using BusinessObjects;
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

        [Required(ErrorMessage = "Please enter your email address")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string CustomerEmailAddress { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        public string CustomerPassword { get; set; }


        public CustomerBO Mapping(LoginViewModel loginViewModel)
        {
            Mapper.Initialize(c => c.CreateMap<LoginViewModel, CustomerBO>());
            return Mapper.Map<CustomerBO>(loginViewModel);
        }
    }
}