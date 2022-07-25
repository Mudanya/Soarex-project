using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace Repository
{
    public class EnquiryRepository : RepositoryBase<Enquiry>, IEnquiryRepository
    {
        public EnquiryRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateEnquiry(Enquiry enquiry)
        => Create(enquiry);

        public async Task<IEnumerable<Enquiry>> GetAllEnquiryAsync(bool trackChanges)
        => await FindAll(trackChanges).ToListAsync();

        public async Task<Enquiry> GetEnquiryAsync(Guid id, bool trackChanges)
        => await FindByCondition(e => e.Id == id, trackChanges).FirstOrDefaultAsync();

        public void UpdateteEnquiry(Enquiry enquiry)
        => Update(enquiry);
    }
}
