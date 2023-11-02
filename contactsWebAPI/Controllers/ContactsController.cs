using contactsWebAPI.Data;
using contactsWebAPI.Modelss;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace contactsWebAPI.Controllers
{
    [ApiController]  // annotate using APi controller, telling that it is not MVC controller.
    [Route("api/[controller]")] // api/controllerName -> contoller name is taking from below line i.e ContactsController and injecting in this line.
    public class ContactsController : Controller
    {
        private readonly ContactsAPIDbContext dbContext;  //databse name
        
        //ctor shortcut to generate constructor
        public ContactsController(ContactsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            return Ok(await dbContext.Contacts.ToListAsync());  //dbcontext talks to contacts table and gives list.
        }



        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetContact([FromRoute] Guid id)
        {
           var contact =await  dbContext.Contacts.FindAsync(id);
            if(contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }



        [HttpPost]
        public async Task<IActionResult> AddContacts(AddContactRequests addContactRequests)
        {
            var contact = new Contact()
            {
                Id = Guid.NewGuid(),
                Address = addContactRequests.Address,
                Email = addContactRequests.Email,
                FullName = addContactRequests.FullName,
                Phone = addContactRequests.Phone,
            };
            await dbContext.Contacts.AddAsync(contact);
            await dbContext.SaveChangesAsync();
            return Ok(contact);
        }




        [HttpPut]
        [Route("{id:guid}")]   // it take id from Route,passing the id which is in the form of grid.
        public async Task<IActionResult> updateContacts([FromRoute] Guid id, UpdateContactRequests updateContactRequests)
        {
           var contact = await dbContext.Contacts.FindAsync(id);
            if(contact != null)
            {
                contact.FullName = updateContactRequests.FullName;
                contact.Phone = updateContactRequests.Phone;
                contact.Email = updateContactRequests.Email;
                contact.Address = updateContactRequests.Address;

               await  dbContext.SaveChangesAsync();
                return Ok(contact);
            }
            return NotFound();
        }


        [HttpDelete]
        [Route("{id:guid}")]  // it take id from Route,passing the id which is in the form of grid.
        public async Task<IActionResult> deleteContact([FromRoute] Guid id)
        {
            var contact = await dbContext.Contacts.FindAsync(id);
            if(contact == null)
            {
                return NotFound();
            }
            dbContext.Contacts.Remove(contact);
           await dbContext.SaveChangesAsync();
            return Ok($"{contact.FullName} got deleted");
        }
    }
}
