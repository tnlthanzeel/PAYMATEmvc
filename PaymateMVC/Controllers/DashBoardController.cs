using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UIServices.CustomerServices;
using System.Threading.Tasks;

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
    }
}