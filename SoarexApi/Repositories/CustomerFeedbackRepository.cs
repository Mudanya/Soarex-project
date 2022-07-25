using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace Repository
{
    public class CustomerFeedbackRepository : RepositoryBase<CustomerFeedback>, ICustomerFeedbackRepository
    {
        public CustomerFeedbackRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateCustomerFeedback(CustomerFeedback customerfeedback)
        => Create(customerfeedback);

        public async Task<IEnumerable<CustomerFeedback>> GetAllCustomerFeedbacksAsync(bool trackChanges)
        => await FindAll(trackChanges).ToListAsync();

        public async Task<CustomerFeedback> GetCustomerFeedbackAsync(Guid id,bool trackChanges)
        => await FindByCondition(c => c.Id == id,trackChanges).FirstOrDefaultAsync();

        public void UpdateteCustomerFeedback(CustomerFeedback customerfeedback)
        => Update(customerfeedback);
    }
}
