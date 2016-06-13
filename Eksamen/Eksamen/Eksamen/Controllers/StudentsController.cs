using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eksamen.Infrastructure;

namespace Eksamen.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public Repository repository = new Repository(); // Laver et object af hele repository
        public ActionResult Index()
        {
            if (Session["repository"] == null) // Tjekker om Session er tom
            {
                Session["repository"] = repository; // Session = alt dummydata
            }
            else
            {
                repository = (Repository)Session["repository"]; // Ikke tom - henter det nye ned og overskriver
            }

            return View(repository.Students);
        }
    }
}