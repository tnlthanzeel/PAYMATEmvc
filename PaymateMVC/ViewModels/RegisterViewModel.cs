using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BusinessObjects;
using Common.Enumarations;
using System.Web.Security;

namespace PaymateMVC.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please Enter Your First Name")]
        public string CustomerFirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please Enter Your Last Name")]
        public string CustomerLastName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        public string CustomerPassword { get; set; }


        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Enter Your Password Again")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("CustomerPassword", ErrorMessage = "Passwords Does Not Match")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Card Number")]
        [Required(ErrorMessage = "Please enter your Card Number")]
        [DataType(DataType.CreditCard)]
        public long? CustomerCardNo { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Please Enter Your Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Remote("DoesUserEmailExist", "Security", HttpMethod = "POST", ErrorMessage = "This Email Address is already taken.")]
        public string CustomerEmailAddress { get; set; }

        public IEnumerable<Gender> Gender { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please Select Your Gender")]
        public int GenderID { get; set; }


        [Display(Name = "Date Of Birth")]
        [Required(ErrorMessage = "Select your date of birth")]
        public DateTime? DateOfBirth { get; set; }

        public UserBO Mapping(RegisterViewModel registerViewModel)
        {
            var UserBO = Mapper.Map<UserBO>(registerViewModel);
            UserBO.CustomerGuid = Guid.NewGuid();
            UserBO.Status = (int)CustomerStatusEnum.Active;
            UserBO.CreatedOn = DateTime.Now.AddHours(5).AddMinutes(30);
            UserBO.EmailConfirmed = false;
            UserBO.CustomerPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(registerViewModel.CustomerPassword, "SHA1");
            return UserBO;
        }
    }
}