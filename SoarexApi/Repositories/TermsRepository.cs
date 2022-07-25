using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace Repository
{
    public class TermsRepository : RepositoryBase<Terms>, ITermsRepository
    {
        public TermsRepository(RepositoryContext context):base(context)
        {
        }

        public void CreateTerm(Terms terms) => Create(terms);

        public async Task<IEnumerable<Terms>> GetAllTermsAsync(bool trackChanges)
        => await FindAll(trackChanges).ToListAsync();

        public async Task<Terms> GetTermAsync(bool trackChanges)
       => await Find(trackChanges).SingleOrDefaultAsync();

        public void UpdateTerm(Terms terms)
        => Update(terms);
    }
}
