using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eksamen.Areas.Admin.Controllers
{
    public class AdminPanelController : Controller
    {
        // GET: Admin/AdminPanel
        public ActionResult Index()
        {
            if (Session["admin"] == null) // Er man logget ind, sendes man til panelet
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }
    }
}