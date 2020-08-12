namespace DuplicateFinder
{
    class Contact
    {
        public string Name { get; }
        public string Email { get; }
        public string Number { get; }

        public Contact(string name, string email, string num)
        {
            Name = name;
            Email = email;
            Number = num;
        }
    }
}
