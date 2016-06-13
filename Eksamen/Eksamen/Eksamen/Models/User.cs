using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Eksamen.Infrastructure;

namespace Eksamen.Models
{
    public class User
    {
        /*
        private int iD;
        public int ID
        {
            get { return id; } // henter fields værdi ud
            set { id = value } // overskriver fields værdi med ny værdi
        }
        */

        public int ID { get; set; } // auto-generated property

        [Required(ErrorMessage = "Angiv venligst et navn")] // Built-in property validation
        public string Name { get; set; }

        [RegularExpression(@"\S+@\S+\.\S{2,3}", ErrorMessage = "Problem med email")]
        // /S - Matcher alle non-white-space characters
        // + - Betyder at der kan være 1 til uendelig antal non-white-space characters - Meta characters
        // @ - skal indeholde "@" - ordinary characters. Samme med "."
        // {2,3} - der skal være 2-3 non-space-characters - meta character
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Angiv venligst en email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Angiv venligst et password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        [Required(ErrorMessage = "Bekræft venligst dit password")]
        public string ConfirmPassword { get; set; }
        public List<Course> Courses { get; set; }

        // Oprette tom constructor.
        // MVC smider indhold gennem vores constructor til vores properties.
        public User()
        {

        }

        // Constructor indeholder parametrene
        public User(int ID, string name, string email, string password)
        {
            // Her sættes private fields = parametre
            this.ID = ID;
            Name = name;
            Email = email;
            Password = password;

            // Dette er en liste over courses en person er tilmeldt. Den er tom.
            Courses = new List<Course>();
        }

        // Tager mod course som parameter og tilføjer course ind i vores liste øverst med courses.
        // List er en class i MVC, som har en Method der hedder "Add"
        public void AddCourse(Course course)
        {
            Courses.Add(course);
        }
    }
}