using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.Enquiry;
using Entities.Models;

namespace Services
{
    public class EnquiryService
    {
        private readonly IRepositorymanager repository;
        private readonly IMapper mapper;

        public EnquiryService(IRepositorymanager repository, IMapper mapper)
        {
            repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<EnquiryDto>> GetEnquiriesAsync()
        {
            IEnumerable<Enquiry> enquiries = await repository.Enquiry.GetAllEnquiryAsync(trackChanges: false);
            IEnumerable<EnquiryDto> enquiriesDto = mapper.Map<IEnumerable<EnquiryDto>>(enquiries);
            return enquiriesDto;
        }

        public async Task<EnquiryDto> CreateEnquiryAsync(EnquiryUpsertDto enquiriesUpsertDto)
        {

            Enquiry enquiries = mapper.Map<Enquiry>(enquiriesUpsertDto);
            repository.Enquiry.CreateEnquiry(enquiries);
            await repository.SaveAsync();
            EnquiryDto enquiriesDto = mapper.Map<EnquiryDto>(enquiries);
            return enquiriesDto;
        }

        public async Task<EnquiryDto> UpdateEnquiryAsync(Guid id, EnquiryUpsertDto enquiriesUpsertDto)
        {
            Enquiry enquiries = await repository.Enquiry.GetEnquiryAsync(id, trackChanges: true);
            if (enquiries == null)
                return null;
            Enquiry term = mapper.Map(enquiriesUpsertDto, enquiries);
            repository.Enquiry.UpdateteEnquiry(term);
            await repository.SaveAsync();
            EnquiryDto enquiriesDto = mapper.Map<EnquiryDto>(term);
            return enquiriesDto;
        }
    }
}
