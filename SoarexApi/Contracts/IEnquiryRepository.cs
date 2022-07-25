using Entities.Models;

namespace Contracts
{
    public interface IEnquiryRepository
    {
        void CreateEnquiry(Enquiry enquiry);
        void UpdateteEnquiry(Enquiry enquiry);
        Task<Enquiry> GetEnquiryAsync(Guid id, bool trackChanges);
        Task<IEnumerable<Enquiry>> GetAllEnquiryAsync(bool trackChanges);
    }
}
