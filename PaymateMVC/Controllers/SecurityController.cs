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
using Common;

namespace PaymateMVC.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        private readonly LoginService _loginService;
        private readonly GenderLookupService _genderLookupService;
        private readonly RegisterService _registerService;
        private readonly ResetPasswordService _resetPasswordService;

        public SecurityController(LoginService loginService, GenderLookupService genderLookupService, RegisterService registerService, ResetPasswordService resetPasswordService)
        {
            _loginService = loginService;
            _registerService = registerService;
            _genderLookupService = genderLookupService;
            _resetPasswordService = resetPasswordService;
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
                if (userBO.EmailConfirmed)
                {
                    FormsAuthentication.SetAuthCookie(userBO.CustomerEmailAddress, false);
                    FormsAuthentication.RedirectFromLoginPage(loginViewModel.CustomerEmailAddress, false);
                    if (Url.IsLocalUrl(ReturnUrl))
                        return Redirect(ReturnUrl);
                    else
                        return RedirectToAction("MainMenu", "DashBoard");
                }
                else
                    this.Flash(Toastr.ERROR, "Email Not Confirmed", "Seems like your email is not confirmed. Please check your email for a confirmation mail");
            }
            else
            {
                ModelState.Remove("CustomerPassword");
                this.Flash(Toastr.ERROR, "Login Error", "Incorrect Email Address Or Password");
            }
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
                ViewBag.UserFullName = UserBO.CustomerFullName;
                return PartialView("_ConfirmEmail");
            }
            catch
            {
                registerViewModel.Gender = await _genderLookupService.GetGenderAsync();
                this.Flash(Toastr.ERROR, "Error", "Oops!, something went wrong while processing your request");
                return View(registerViewModel);
            }
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


        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ForgotPassword(LoginViewModel loginViewModelReset)
        {
            var doesUserExist = await _registerService.GetUserEmailAsync(loginViewModelReset.CustomerEmailAddress);
            if (doesUserExist)
            {
                var ResetedPassword = RandomStringGenerator.GenerateRandomString();

                await _resetPasswordService.UpdatedResetedPasswordAsync(loginViewModelReset.CustomerEmailAddress, ResetedPassword);


                MessageBuilder messageBuilder = new MessageBuilder();


                ViewBag.EmailToReset = loginViewModelReset.CustomerEmailAddress;
                return PartialView("_PasswordReset");
            }
            else
            {
                this.Flash(Toastr.ERROR, "Error", "Invalid Email Address");
                return View("ForgotPassword");
            }
        }
    }
}