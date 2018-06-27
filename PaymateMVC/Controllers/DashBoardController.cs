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
    [Authorize]
    public class DashBoardController : Controller
    {
        private readonly string[] _imageFileExtensions = { ".jpg", ".png", ".gif", ".jpeg" };
        private readonly UserService _userService;

        public DashBoardController(UserService userSvice)
        {
            _userService = userSvice;
        }



        public async Task<ActionResult> MainMenu()
        {
            var userDetails = await _userService.GetUserInfoAsync(User.Identity.Name);
            ViewBag.profilePicUrl = userDetails.ProfilePicUrl ?? "default-profilepic.png";
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> UpdateProfilePicture(HttpPostedFileBase file)
        {
            if (file != null)
            {
                if (!_imageFileExtensions.Any(item => file.FileName.EndsWith(item, StringComparison.OrdinalIgnoreCase))) { this.Flash(Toastr.ERROR, "Invlaid File", "Please upload an image file"); return RedirectToActionPermanent("MainMenu"); }


                var FileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Files/ProfilePics"), FileName);
                file.SaveAs(path);
                await _userService.UpadateUserInfoAsync(new UserBO { ProfilePicUrl = FileName }, User.Identity.Name);
                ViewBag.profilePicUrl = FileName;
                this.Flash(Toastr.SUCCESS, "Upload Complete", "Your profile picture has been uploaded successfully");
            }

            else
                this.Flash(Toastr.ERROR, "Upload Fail", "please select an image");
            return RedirectToActionPermanent("MainMenu");
        }
    }
}