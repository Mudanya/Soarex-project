using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace Repository
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(RepositoryContext context):base(context)
        {

        }

        public void CreateContact(Contact contact)
        => Create(contact);

        public async Task<Contact> GetContactAsync(bool trackChanges)
        => await Find(trackChanges).FirstOrDefaultAsync();

        public void UpdateContact(Contact contact)
        => Update(contact);
    }
}
