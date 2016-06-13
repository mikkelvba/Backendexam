using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eksamen.Models;
using Eksamen.Infrastructure;
using Eksamen.Models;

namespace Eksamen.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        private Repository repository = new Repository();
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


            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection formData) // Vi henter alle data fra formen i et object
        {
            string name = formData["Name"];
            string email = formData["Email"];
            string password = formData["Password"];
            string confirmPassword = formData["ConfirmPassword"];
            DateTime birthDate = DateTime.Parse(formData["BirthDate"]); // Formater fra string (alt data vi får fra form er strings) til DateTime

            repository = (Repository)Session["repository"]; // Henter repository object ned fra session
            
            int personId = repository.Students.Max(x => x.ID) + 1;
            Student student = new Student(personId, name, email, password, birthDate);

            repository.Students.Add(student);

            Session["repository"] = repository;

            return View();
        }
    }
}