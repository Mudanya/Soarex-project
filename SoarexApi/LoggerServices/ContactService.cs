using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.Contact;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ContactService
    {
        private readonly IRepositorymanager repository;
        private readonly IMapper mapper;

        public ContactService(IRepositorymanager repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ContactDto> GetContactAsync()
        {
            Contact contact = await repository.Contact.GetContactAsync(trackChanges: false);
            ContactDto contactDto = mapper.Map<ContactDto>(contact);
            return contactDto;
        }

        public async Task<ContactDto> CreateContactAsync(ContactUpsertDto contactUpsertDto)
        {

            Contact contact = mapper.Map<Contact>(contactUpsertDto);
            repository.Contact.CreateContact(contact);
            await repository.SaveAsync();
            ContactDto contactDto = mapper.Map<ContactDto>(contact);
            return contactDto;
        }

        public async Task<ContactDto> UpdateContactAsync(ContactUpsertDto contactUpsertDto)
        {
            Contact contact = await repository.Contact.GetContactAsync(trackChanges: true);
            if (contact == null)
                return null;
            Contact contacts = mapper.Map(contactUpsertDto, contact);
            repository.Contact.UpdateContact(contacts);
            await repository.SaveAsync();
            ContactDto contactDto = mapper.Map<ContactDto>(contacts);
            return contactDto;
        }
    }
}
