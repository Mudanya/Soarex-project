using Entities.DataTransferObjects.Contact;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace SoarexApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {


        private readonly ContactService contactService;

        public ContactController(ContactService contactService)
        {
            this.contactService = contactService;
        }

        [HttpGet(Name = "GetContact")]
        public async Task<IActionResult> GetContact()
        {
            ContactDto contactsDto = await contactService.GetContactAsync();
            if (contactsDto == null)
                return NotFound();
            return Ok(contactsDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(ContactUpsertDto upsertDto)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            ContactDto contactsDto = await contactService.CreateContactAsync(upsertDto);

            return CreatedAtAction("GetContact", contactsDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact(Guid id, ContactUpsertDto contactsUpsertDto)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            ContactDto contactsDto = await contactService.UpdateContactAsync(contactsUpsertDto);
            if (contactsDto == null)
                return NotFound();
            return NoContent();
        }

    }
}
