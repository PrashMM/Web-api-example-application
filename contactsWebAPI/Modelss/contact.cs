namespace contactsWebAPI.Modelss
{
    public class Contact
    {
        public Guid Id { get; set; } // Guid is  a global unique identifier (128 bit text string).

        public string FullName { get; set; }

        public string Email { get; set; }

        public long Phone { get; set; }

        public string Address { get; set; }
    }
}
