using AutoMapper;
using Entities.DataTransferObjects.AboutUs;
using Entities.DataTransferObjects.Authentication;
using Entities.DataTransferObjects.Contact;
using Entities.DataTransferObjects.CustomerFeedback;
using Entities.DataTransferObjects.Enquiry;
using Entities.DataTransferObjects.KeyAreas;
using Entities.DataTransferObjects.PrivacyPolicy;
using Entities.DataTransferObjects.Settings;
using Entities.DataTransferObjects.Terms;
using Entities.DataTransferObjects.UtilityServices;
using Entities.Models;

namespace SoarexApi.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SettingsUpsertDto, Settings>();
            CreateMap<Settings, SettingsDto>();
            CreateMap<TermsUpsertDto, Terms>();
            CreateMap<Terms, TermsDto>();
            CreateMap<UtilityServiceUpsertDto, Service>();
            CreateMap<Service, UtilityServiceDto>();
            CreateMap<PrivacyPolicy, PrivacyPolicyDto>();
            CreateMap<PrivacyPolicyUpsertDto, PrivacyPolicy>();
            CreateMap<EnquiryUpsertDto, Enquiry>();
            CreateMap<Enquiry, EnquiryDto>();
            CreateMap<CustomerFeedbackUpsertDto, CustomerFeedback>().
                ForMember(c=>c.Customer, opt=>opt.MapFrom(a=>a.Name));
            CreateMap<CustomerFeedback, CustomerFeedbackDto>();
            CreateMap<ContactUpsertDto, Contact>();
            CreateMap<Contact, ContactDto>();
            CreateMap<AboutUsUpsertDto, AboutUs>();
            CreateMap<AboutUs, AboutUsDto>();
            CreateMap<RegisterDto, ApplicationUser>();
            CreateMap<KeyAreasUpsertDto, KeyAreas>();
            CreateMap<KeyAreas, KeyAreasDto>();
        }
    }
}
