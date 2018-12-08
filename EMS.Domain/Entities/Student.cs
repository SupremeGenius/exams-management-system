using System;
using System.Collections.Generic;
using System.Linq;

namespace EMS.Domain
{
    public class Student : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public static Student Create(string firstName, string lastName, string email) => new Student
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email
        };
    }
}
