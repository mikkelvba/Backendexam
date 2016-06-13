using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eksamen.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace Eksamen.Models
{
    public class Student : User // Class student nedarver fra User - inheritance
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")] // Formater dato til dd/mm/yyyy
        public DateTime BirthDate { get; set; }

        // Oprette tom constructor.
        // MVC smider indhold gennem vores constructor til vores properties.
        public Student()
        {

        }

        // Constructor indeholder parametrene
        public Student(int ID, string name, string email, string password, DateTime birthDate)
            : base(ID, name, email, password)
        {
            // Her sættes private fields = parametre
            BirthDate = birthDate;
        }
    }

}