using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eksamen.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            if (Session["admin"] != null) // Er man logget ind, sendes man til panelet
            {
                return RedirectToAction("Index", "AdminPanel");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Index(FormCollection formData)
        {
            string username = formData["Username"];
            string password = formData["Password"];

            if(username == "admin" && password == "pass1234")
            {
                Session["admin"] = true;
                return RedirectToAction("Index", "AdminPanel"); // Ved korekt login sendes man til AdminPanel
            }
            else
            {
                return View();
            }
        }
    }

}