using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.Terms;
using Entities.Models;

namespace Services
{
    public class TermService
    {
        private readonly IRepositorymanager _repository;
        private readonly IMapper mapper;
        private readonly ILoggerManager logger;

        public TermService(IRepositorymanager repository, IMapper mapper, ILoggerManager logger)
        {
            _repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }
        public async Task<TermsDto> GetTermsAsync()
        {
            Terms terms = await _repository.Terms.GetTermAsync(trackChanges: false);
            TermsDto termsDto = mapper.Map<TermsDto>(terms);
            return termsDto;
        }

        public async Task<TermsDto> CreateTermsAsync(TermsUpsertDto termsUpsertDto)
        {
           
            Terms terms = mapper.Map<Terms>(termsUpsertDto);
            _repository.Terms.CreateTerm(terms);
            await _repository.SaveAsync();
            TermsDto termsDto = mapper.Map<TermsDto>(terms);
            return termsDto;
        }

        public async Task<TermsDto> UpdateTermsAsync(TermsUpsertDto termsUpsertDto)
        {
            Terms terms = await _repository.Terms.GetTermAsync(trackChanges: true);
            if (terms == null)
                return null;
            Terms term = mapper.Map(termsUpsertDto, terms);
            _repository.Terms.UpdateTerm(term);
            await _repository.SaveAsync();
            TermsDto termsDto = mapper.Map<TermsDto>(term);
            return termsDto;
        }

    }
}
