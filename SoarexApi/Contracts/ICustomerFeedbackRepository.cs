using Entities.Models;

namespace Contracts
{
    public interface ICustomerFeedbackRepository
    {
        void CreateCustomerFeedback(CustomerFeedback customerfeedback);
        void UpdateteCustomerFeedback(CustomerFeedback customerfeedback);
        Task<CustomerFeedback> GetCustomerFeedbackAsync(Guid id,bool trackChanges);
        Task<IEnumerable<CustomerFeedback>> GetAllCustomerFeedbacksAsync(bool trackChanges);
    }
}
