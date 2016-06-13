using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eksamen.Infrastructure;

namespace Eksamen.Controllers
{
    public class HomeController : Controller
    {
        private Repository repository = new Repository(); // Laver et object af hele repository

        public ActionResult Index()
        {

            return View(repository);
        }
    }
}