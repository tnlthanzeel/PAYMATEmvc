using AutoMapper;
using BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace PaymateMVC.ViewModels
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
            loginViewModel.CustomerPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(loginViewModel.CustomerPassword,"SHA1");
            return Mapper.Map<CustomerBO>(loginViewModel);
        }
    }
}