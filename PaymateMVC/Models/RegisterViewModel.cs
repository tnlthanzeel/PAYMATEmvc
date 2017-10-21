using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BusinessObjects;

namespace PaymateMVC.Models
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

        [Display(Name ="Email Address")]
        [Required(ErrorMessage ="Please Enter Your Email")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string CustomerEmailAddress { get; set; }


        public IEnumerable<Gender> Gender { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please Select Your Gender")]
        public int GenderID { get; set; }



        public CustomerBO Mapping (RegisterViewModel registerViewModel)
        {
            Mapper.Initialize(c => c.CreateMap<RegisterViewModel, CustomerBO>());
            var customerBo = Mapper.Map<CustomerBO>(registerViewModel);
            customerBo.CreatedOn = DateTime.Now;
            return customerBo;
        }

        
    }
}