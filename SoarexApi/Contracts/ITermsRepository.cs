using Entities.Models;

namespace Contracts
{
    public interface ITermsRepository
    {
        Task<Terms> GetTermAsync(bool trackChanges);
        void UpdateTerm(Terms terms);
        void CreateTerm(Terms terms);
    }
}
