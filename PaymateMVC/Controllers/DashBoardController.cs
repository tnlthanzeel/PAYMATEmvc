using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UIServices.CustomerServices;
using System.Threading.Tasks;
using System.IO;
using RedWillow.MvcToastrFlash;
using BusinessObjects;

namespace PaymateMVC.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly UserService _userSvice;

        public DashBoardController(UserService userSvice)
        {
            _userSvice = userSvice;
        }


        [Authorize]
        public async Task<ActionResult> MainMenu()
        {
            var userDetails = await _userSvice.GetUserInfoAsync(User.Identity.Name);
            ViewBag.profilePicUrl = userDetails.ProfilePicUrl != null ? userDetails.ProfilePicUrl : "default-profilepic.png";
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> UpdateProfilePicture(HttpPostedFileBase file)
        {
            if (file != null)
            {
                var FileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Files/ProfilePics"), FileName);
                file.SaveAs(path);
                await _userSvice.UpadateUserInfoAsync(new UserBO { ProfilePicUrl = FileName }, User.Identity.Name);
                ViewBag.profilePicUrl = FileName;
                this.Flash(Toastr.SUCCESS, "Upload Complete", "Your profile picture has been uploaded successfully");
            }

            else
                this.Flash(Toastr.ERROR, "Upload Fail", "please select an image");
            return RedirectToActionPermanent("MainMenu");
        }
    }
}