using System;

namespace csharp_biblioteca
{
    public class User
    {
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string TelNumber { get; set; }

        public User(string lastName, string name, string email, string password, string telNumber)
        {
            LastName = lastName;
            Name = name;
            Email = email;
            Password = password;
            TelNumber = telNumber;
        }
    }
}
