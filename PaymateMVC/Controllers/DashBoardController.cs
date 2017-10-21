using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaymateMVC.Controllers
{
    public class DashBoardController : Controller
    {
        // GET: DashBoard
        public ActionResult MainMenu()
        {
            return Content("DashBoard running");
        }
    }
}