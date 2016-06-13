using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eksamen.Infrastructure;
using Eksamen.Models;

namespace Eksamen.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
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

            return View(repository.Courses);
        }

        public PartialViewResult GetStudentsPartial(int id) // Modtager data med GET i url. PartialViewResult - arbejder med partialview
        {
            repository = (Repository)Session["repository"]; // Henter repository ned fra session

            List<Student> studentList = new List<Student>(); // Instansierer en liste

            foreach(Student student in repository.Students){ // Looper gennem alle elever

                if(student.Courses.Exists(c => c.ID == id)) // spørger om det id (courseId) matcher er et af courses i listen.
                {
                    studentList.Add(student); // Finder match, så tilføj student til listen
                }

            }
            return PartialView("_Students", studentList); // Sender studentlist med over til partial view.
        }
    }
}