using contactsWebAPI.Modelss;
using Microsoft.EntityFrameworkCore;

namespace contactsWebAPI.Data
{
    public class ContactsAPIDbContext : DbContext // inherits from DbContext, DbContext talks to database.
    {          
        //ctor to generate constructor
        public ContactsAPIDbContext(DbContextOptions options) : base(options)  // generate constructors and Options are passed to base class.
        {
        }

        public DbSet<Contact> Contacts { get; set; } // Here we create one table to read, update the data. 
    }
}
