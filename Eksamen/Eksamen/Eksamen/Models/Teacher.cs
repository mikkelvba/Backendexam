using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Eksamen.Models
{
    public class Teacher : User // Class teacher nedarver fra User - inheritance
    {
        [Display(Name = "Weekly Hours")]
        public int WeeklyHours { get; set; }
        public float Salary { get; set; }

        // Oprette tom constructor pga. modelbinding.
        // MVC smider indhold gennem vores constructor til vores properties.
        public Teacher()
        {

        }

        // Constructor indeholder parametrene
        public Teacher(int ID, string name, string email, string password, int weeklyHours, float salary)
            :base(ID, name, email, password)
        {

            // Her sættes private fields = parametre
            WeeklyHours = weeklyHours;
            Salary = salary;
        }
    }
}