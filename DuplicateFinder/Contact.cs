using System;
using System.Collections.Generic;
using System.Text;

namespace DuplicateFinder
{
    class Contact
    {
        public string Name { get; }
        public string Email { get; }
        public string Number { get; }

        public Contact(string name, string email, string num)
        {
            this.Name = name;
            this.Email = email;
            this.Number = num;
        }
    }
}
