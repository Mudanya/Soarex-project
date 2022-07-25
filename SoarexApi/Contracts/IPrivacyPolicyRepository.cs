using Entities.Models;

namespace Contracts
{
    public interface IPrivacyPolicyRepository
    {
        void CreatePrivacyPolicy(PrivacyPolicy privacyPolicy);
        void UpdatePrivacyPolicy(PrivacyPolicy privacyPolicy);
        Task<PrivacyPolicy> GetPrivacyPolicyAsync(bool trackChanges);

    }
}
