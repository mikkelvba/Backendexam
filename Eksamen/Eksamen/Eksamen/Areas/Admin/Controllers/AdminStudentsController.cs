using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eksamen.Infrastructure;

namespace Eksamen.Areas.Admin.Controllers
{
    public class AdminStudentsController : Controller
    {
        Repository repository = new Repository(); // Instansiereer repository

        // GET: Admin/AdminStudents
        public ActionResult Index()
        {
            if (Session["admin"] == null) // Er man logget ind, sendes man til panelet
            {
                return RedirectToAction("Index", "Login");
            }
            if(Session["repository"] == null){ // Hvis den ikke er gemt i session, så ligger vi den med dummydata op.
                Session["repository"] = repository;
            }
            else
            {
                repository = (Repository)Session["repository"]; // Hvis session er gemt, overskrives den med dummydata.
            }

            return View(repository.Students);
        }

        [HttpPost]
        public ActionResult Index(FormCollection formData)
        {
            string name = formData["student.Name"]; // Laver variabel og sætter = det ny-opdateret felt.
            string email = formData["student.Email"];
            string password = formData["student.Password"];
            int id = Int32.Parse(formData["student.ID"]);

            repository = (Repository)Session["repository"]; // Antager at sessionen er sat, da vi har sat den i GET øverst.
            // Når vi benytter POST, skal vi sætte repository igen for at få det nyeste fra Session.

            // Her overskrives det data som var gemt i sessionen før med de nyeste ændringer.
            (repository.Students).Where(d => d.ID == id).First().Name = name; // LINQ = Where id fra students er = id fra hidden input
            (repository.Students).Where(d => d.ID == id).First().Email = email;
            (repository.Students).Where(d => d.ID == id).First().Password = password;

            Session["repository"] = repository; // Ligger Session op igen.

            return View(repository.Students);
        }
    }
}