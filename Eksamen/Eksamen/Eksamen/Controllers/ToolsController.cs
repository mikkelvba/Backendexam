using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eksamen.Controllers
{
    public class ToolsController : Controller
    {
        // GET: Tools
        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            string[] menuitems = { "Home", "Courses", "Register", "Students" }; // Laver array af strings
            //Create a partiel view, notice this is located in the Shared folder
            //so therefore the convention is to use _ in front of the view name

            return View("_MainMenu", menuitems); // Kalder partial View som bliver strongly typed, da det sender variablen med.
        }
    }
}