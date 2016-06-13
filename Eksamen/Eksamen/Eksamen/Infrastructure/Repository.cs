using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eksamen.Models;

// Jeg bruger repository til mit dummy data til Models.

namespace Eksamen.Infrastructure
{
    public class Repository
    {

        // Laver en liste over studenter, courses og teachers
        // Ved complex types skal det instansieres med "new"
        private List<Student> students = new List<Student>(); 
        public List<Student> Students { get { return students; } }

        private List<Course> courses = new List<Course>();
        public List<Course> Courses { get { return courses; } }

        private List<User> users = new List<User>();
        public List<User> Users { get { return users; } }

        private List<Teacher> teachers = new List<Teacher>();
        public List<Teacher> Teachers { get { return teachers; } }


        // Constructor indeholder parametrene
        public Repository()
        {
            Teacher t1 = new Teacher(1, "Lone Sørensen", "lone@eaa.com", "jflkwjkw23", 33, 145f);
            Teacher t2 = new Teacher(1, "Knud Johansen", "knud@eaa.com", "hweuidh123", 38, 165f);
            Teacher t3 = new Teacher(3, "Poul Andersen", "poul@eaaa.com", "fwihioh2hi", 33, 165f);

            Student s1 = new Student(4, "Stefan Jensen", "stefan@gmail.com", "pass123", new DateTime(1990, 09, 21));
            Student s2 = new Student(5, "Michael Poulsen", "michael@gmail.com", "sdfg32sdg", new DateTime(1991, 12, 11));
            Student s3 = new Student(6, "Karsten Kristensen", "karsten@gmail.com", "werwert32", new DateTime(1990, 02, 07));
            Student s4 = new Student(7, "Alex Hansen", "alex@gmail.com", "dfgoupu23", new DateTime(1990, 01, 30));
            Student s5 = new Student(8, "Gunnar Thomsen", "gunnar@gmail.com", "dpfgejporgj65", new DateTime(1990, 07, 20));
            Student s6 = new Student(9, "Nanna Olsen", "nanna@gmail.com", "oregpojr09", new DateTime(1990, 11, 20));
            Student s7 = new Student(10, "Tove Trollsen", "tove@gmail.com", "ehi23hioh", new DateTime(1990, 03, 10));
            Student s8 = new Student(11, "Marie Kasttrup", "marie@gmail.com", "kp12kkppb", new DateTime(1990, 01, 19));
            Student s9 = new Student(12, "Hanne Holst Jensen", "hanne@gmail.com", "fehwiohq11", new DateTime(1990, 03, 04));
            Student s10 = new Student(13, "Line Yding Poulsen", "line@gmail.com", "dw12dwwda", new DateTime(1990, 10, 03));

            Course c1 = new Course(1, "Matematik", new DateTime(2016, 08, 20), new DateTime(2017, 06, 26), t1);
            Course c2 = new Course(2, "Engelsk", new DateTime(2016, 08, 22), new DateTime(2017, 06, 24), t2);
            Course c3 = new Course(3, "Kemi", new DateTime(2015, 08, 14), new DateTime(2016, 06, 08), t3);
            Course c4 = new Course(4, "Idræt", new DateTime(2016, 08, 22), new DateTime(2017, 06, 26), t2);

            // Tilføjer alle teachers til liste
            Teachers.Add(t1);
            Teachers.Add(t2);
            Teachers.Add(t3);

            // Lave courses for teachers
            t1.AddCourse(c1);
            t2.AddCourse(c2);
            t2.AddCourse(c4);
            t3.AddCourse(c3);
                // t1.Courses.Add(c1)  -Tilføje uden Method i Course

            // Tilføjer alle courses til liste
            Courses.Add(c1);
            Courses.Add(c2);
            Courses.Add(c3);
            Courses.Add(c4);

            // Tilføjer alle studenter til liste
            Students.Add(s1);
            Students.Add(s2);
            Students.Add(s3);
            Students.Add(s4);
            Students.Add(s5);
            Students.Add(s6);
            Students.Add(s7);
            Students.Add(s8);
            Students.Add(s9);
            Students.Add(s10);

            // For hver student i vores list tilføjer vi et course. Alternativt er 3*10 for at tilføje hver enkelt. DRY
            foreach(Student student in Students)
            {
                student.AddCourse(c1); // Tilføjer course til student
                c1.AddStudent(student); // Tilføjer student til course

                student.AddCourse(c2);
                c2.AddStudent(student);

                student.AddCourse(c3);
                c3.AddStudent(student);

                Users.Add(student);
            }

            // For loop. Laver variabel "i" og sætter til 0. Så længe "i" er mindre end Students.Count(som er 10)
            // Første gang er i = 0. Anden gang ligges der 2 til osv. Hermed hver anden student tilføjes til idræt.
            for(int i = 0; i < Students.Count; i += 2) 
            {
                Students[i].AddCourse(c4); // tilføjer idræt til hver 2. student
                c4.AddStudent(Students[i]); // tilføjer hver 2. student til idræt
            }
            
            foreach (Teacher teacher in Teachers)
            {
                Users.Add(teacher);
            }


        }
        
    }
}