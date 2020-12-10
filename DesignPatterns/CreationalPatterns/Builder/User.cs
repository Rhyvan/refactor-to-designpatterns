using System;

namespace DesignPatterns.Builder
{
    public class User
    {

        public string Email { get; private set; }
        public int? Age { get; private set; }
        public string? Name { get; private set; }
        public double? Height { get; private set; }

        public User() : this(null)
        {
        }

        public User(string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("Email should not be empty");
            }

            Email = email;
        }

        public User(string email, int age) : this(email)
        {
            Age = age;
        }

        public User(string email, string name) : this(email)
        {
            Name = name;
        }

        public User(string email, double height) : this(email)
        {
            Height = height;
        }

        public User(string email, String name, int age, double height) : this(email)
        {
            Name = name;
            Age = age;
            Height = height;
        }
    }
}
