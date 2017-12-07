using AutoMapper;
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
using Common.Enumarations;
using RedWillow.MvcToastrFlash;
using System.Threading.Tasks;

namespace PaymateMVC.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        private readonly LoginService _loginService;
        private readonly GenderLookupService _genderLookupService;
        private readonly RegisterService _registerService;

        public SecurityController(LoginService loginService, GenderLookupService genderLookupService, RegisterService registerService)
        {
            _loginService = loginService;
            _registerService = registerService;
            _genderLookupService = genderLookupService;
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
        public async Task<ActionResult> Login(LoginViewModel loginViewModel, string ReturnUrl)
        {
            var userBO = loginViewModel.Mapping(loginViewModel);
            userBO = await _loginService.GetUserAsync(userBO.CustomerEmailAddress, userBO.CustomerPassword);
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
            this.Flash(Toastr.ERROR, "Login Error", "Incorrect Email Address Or Password");
            return View("Login", loginViewModel);
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<ActionResult> Register()
        {
            var registerViewModel = new RegisterViewModel()
            {
                Gender = await _genderLookupService.GetGenderAsync()
            };
            return View(registerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel registerViewModel)
        {
            try
            {
                var UserBO = registerViewModel.Mapping(registerViewModel);
                await _registerService.RegisterCustomerAsync(UserBO);

                MessageBuilder messageBuilder = new MessageBuilder()
                {
                    To = UserBO.CustomerEmailAddress,
                    Subject = "PAYmate Confirmation Email",
                    Body = "Hi " + UserBO.CustomerFullName + ",\nClick on the link below to confirm your email address.\n\n" + "http://paymatelk.azurewebsites.net/Security/Confirmation?id=",
                    IsNewCustomer = true
                };
                await MessageBuilder.SendEmailAsync(messageBuilder);
                ViewBag.ModelIsValid = true;
                Dispose();
                return RedirectToAction("ConfirmationMessage", "Security", new { UserBO.CustomerFullName });
            }
            catch
            {
                registerViewModel.Gender = await _genderLookupService.GetGenderAsync();
                this.Flash(Toastr.ERROR, "Error", "Oops!, something went wrong while processing your request");
                return View(registerViewModel);
            }
        }


        [HttpGet]
        public ActionResult ConfirmationMessage(string CustomerFullName)
        {
            ViewBag.UserFullName = CustomerFullName;
            return PartialView("_ConfirmEmail");
        }

        [HttpPost]
        public async Task<JsonResult> DoesUserEmailExist(string CustomerEmailAddress)
        {
            var doesUserExist = await _registerService.GetUserEmailAsync(CustomerEmailAddress);
            return Json(!doesUserExist);
        }

        public async Task<ActionResult> Confirmation(string id)
        {
            await _registerService.ConfirmEmailAsync(id);
            return RedirectToAction("MainMenu", "DashBoard");
        }
    }
}