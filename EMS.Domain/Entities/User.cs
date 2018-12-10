using System;
using System.Collections.Generic;
using System.Linq;

namespace EMS.Domain
{
    public class User : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public static User Create(string email, string password, string role) => new User
        {
            Email = email,
            Password = password,
            Role = role
        };
    }
}
