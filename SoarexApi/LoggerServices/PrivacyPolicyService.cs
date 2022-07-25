using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.PrivacyPolicy;
using Entities.Models;

namespace Services
{
    public class PrivacyPolicyService
    {
        private readonly IRepositorymanager repository;
        private readonly IMapper mapper;

        public PrivacyPolicyService(IRepositorymanager repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<PrivacyPolicyDto> GetPrivacyPolicyAsync()
        {
            PrivacyPolicy privacyPolicy = await repository.PrivacyPolicy.GetPrivacyPolicyAsync(trackChanges: false);
            PrivacyPolicyDto privacyPolicyDto = mapper.Map<PrivacyPolicyDto>(privacyPolicy);
            return privacyPolicyDto;
        }

        public async Task<PrivacyPolicyDto> CreatePrivacyPolicyAsync(PrivacyPolicyUpsertDto privacyPolicyUpsertDto)
        {

            PrivacyPolicy privacyPolicy = mapper.Map<PrivacyPolicy>(privacyPolicyUpsertDto);
            repository.PrivacyPolicy.CreatePrivacyPolicy(privacyPolicy);
            await repository.SaveAsync();
            PrivacyPolicyDto privacyPolicyDto = mapper.Map<PrivacyPolicyDto>(privacyPolicy);
            return privacyPolicyDto;
        }

        public async Task<PrivacyPolicyDto> UpdatePrivacyPolicyAsync(PrivacyPolicyUpsertDto privacyPolicyUpsertDto)
        {
            PrivacyPolicy privacyPolicy = await repository.PrivacyPolicy.GetPrivacyPolicyAsync(trackChanges: true);
            if (privacyPolicy == null)
                return null;
            PrivacyPolicy privacyPolic = mapper.Map(privacyPolicyUpsertDto, privacyPolicy);
            repository.PrivacyPolicy.UpdatePrivacyPolicy(privacyPolic);
            await repository.SaveAsync();
            PrivacyPolicyDto privacyPolicyDto = mapper.Map<PrivacyPolicyDto>(privacyPolic);
            return privacyPolicyDto;
        }
    }
}
