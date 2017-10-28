﻿using AutoMapper;
using BusinessObjects;
using System.Web.Security;
using PaymateMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UIServices.CustomerServices;
using UIServices.LookupServices;
using System.Security.Policy;
using Message;



namespace PaymateMVC.Controllers
{

    [AllowAnonymous]
    public class SecurityController : Controller
    {

        private readonly LoginService _LoginService;
        private readonly GenderLookupService _GenderLookupService;
        private readonly RegisterService _RegisterService;
        //private readonly IMapper _mapper;


        public SecurityController(/*IMapper mapper*/)
        {
            _LoginService = new LoginService();
            _RegisterService = new RegisterService();
            _GenderLookupService = new GenderLookupService();
            //_mapper = mapper;

        }

        //  GET: Security
        [HttpGet]
        public ActionResult Login(string ReturnUrl)
        {
            ViewBag.returnURL = ReturnUrl;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginViewModel, string ReturnUrl)
        {

            var userBO = loginViewModel.Mapping(loginViewModel);
            userBO = _LoginService.Login(userBO.CustomerEmailAddress, userBO.CustomerPassword);
            if (userBO != null)
            {
                FormsAuthentication.SetAuthCookie(userBO.CustomerEmailAddress, false);
                FormsAuthentication.RedirectFromLoginPage(loginViewModel.CustomerEmailAddress, false);

                if (Url.IsLocalUrl(ReturnUrl))
                    return Redirect(ReturnUrl);
                else
                    return RedirectToAction("MainMenu", "DashBoard");
            }
            ModelState.Remove("CustomerPassword");
            TempData["LoginError"] = "LoginError";
            return View("Login", loginViewModel);
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult Register()
        {
            var registerViewModel = new RegisterViewModel()
            {
                Gender = _GenderLookupService.GetGender()
            };
            return View(registerViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            try
            {
                var UserBO = registerViewModel.Mapping(registerViewModel);
                _RegisterService.RegisterCustomer(UserBO);
                MessageBuilder.SendEmail(UserBO.CustomerEmailAddress,UserBO.CustomerFirstName, UserBO.CustomerLastName);
                return Redirect("Login");
            }

            catch(Exception ex)
            {
                return Content(ex.ToString());
            }
        }


        public ActionResult Confirmation(string id)
        {
            _RegisterService.ConfirmEmail(id);
            return RedirectToAction("MainMenu", "DashBoard");
        }
    }
}