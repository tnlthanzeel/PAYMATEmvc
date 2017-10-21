using AutoMapper;
using BusinessObjects;
using PaymateMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UIServices.CustomerServices;
using UIServices.LookupServices;

namespace PaymateMVC.Controllers
{


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
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginViewModel)
        {


            var isLoginValid = _LoginService.Login(loginViewModel.UserName, loginViewModel.Password);
            if (isLoginValid != null)
                return RedirectToAction("MainMenu", "DashBoard");

            TempData["LoginError"] = "LoginError";
            return View("Login", loginViewModel);

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
            var customerBo = registerViewModel.Mapping(registerViewModel);
            _RegisterService.RegisterCustomer(customerBo);
            return Content("oki");
        }
    }



}