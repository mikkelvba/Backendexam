using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Eksamen.Models
{
    public class Course
    {
        // blue = simple types
        // green = complex types
        public int ID { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")] // Formater dato til dd/mm/yyyy
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }
        public Teacher Teacher { get; set; }

        // Opretter en liste med students tilhørende det specifikke course
        public List<Student> Students { get; set; }
        // List er en class i MVC

        // Oprette tom constructor pga. modelbinding.
        // MVC smider indhold gennem vores constructor til vores properties.
        public Course()
        {

        }

        // Constructor indeholder parametrene
        public Course(int ID, string name, DateTime startDate, DateTime endDate, Teacher teacher)
        {
            // Her sættes private fields = parametre
            this.ID = ID;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            Teacher = teacher;

            // Det er en complex type, så derfor skal den instansieres. Den er tom fra start.
            Students = new List<Student>();
        }

        // Tager mod student som parameter og tilføjer studenten ind i vores liste øverst med studenter.
        // List er en class i MVC, som har en Method der hedder "Add"
        public void AddStudent(Student student)
        {
            Students.Add(student);
        }
    }
}