using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace Repository
{
    public class PrivacyPolicyRepository : RepositoryBase<PrivacyPolicy>, IPrivacyPolicyRepository
    {
        public PrivacyPolicyRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreatePrivacyPolicy(PrivacyPolicy privacyPolicy)
        => Create(privacyPolicy);

        public async Task<PrivacyPolicy> GetPrivacyPolicyAsync(bool trackChanges)
        => await Find(trackChanges).FirstOrDefaultAsync();
        

        public void UpdatePrivacyPolicy(PrivacyPolicy privacyPolicy)
        => Update(privacyPolicy);
    }
}
