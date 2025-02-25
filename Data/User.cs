using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Task2.Data;

namespace Task2.Data
{
    public class User
    {
        public User(string firstName = "", string lastName = "", string email = "", string password = "", string confirmPassword = "", string phone = "", string birthDate = "", Gender? gender = null)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
            Phone = phone;
            BirthDate = birthDate;
            Gender = gender;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Phone { get; set; }
        public string BirthDate { get; set; }
        public Gender? Gender { get; set; }
        public string image { get; set; }
    }
}
