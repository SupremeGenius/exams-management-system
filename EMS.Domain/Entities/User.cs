using System;
using System.Collections.Generic;
using System.Linq;

namespace EMS.Domain
{
    public class User : Entity, IUpdatable<User>
    {
        public string Email { get; set; }

        public string Password { get; private set; }

        public string Role { get; set; }

        public string Name { get; set; }

        public static User Create(string email, string password, string role) => new User
        {
            Email = email,
            Password = password,
            Role = role
        };

        public void Update(User updatedUser)
        {
            this.Password = updatedUser.Password == null ? this.Password: updatedUser.Password;
            this.Name = updatedUser.Name == null? this.Name : updatedUser.Name;
        }
    }
}
