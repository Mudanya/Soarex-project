using Entities.Models;

namespace Contracts
{
    public interface IContactRepository
    {
        void CreateContact(Contact contact);
        void UpdateContact(Contact contact);
        Task<Contact> GetContactAsync(bool trackChanges);
    }
}
