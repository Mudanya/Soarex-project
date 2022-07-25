using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.AboutUs;
using Entities.Models;

namespace Services
{
    public class AboutUsService
    {

        private readonly IRepositorymanager repository;
        private readonly IMapper mapper;

        public AboutUsService(IRepositorymanager repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<AboutUsDto> GetAboutUsAsync()
        {
            AboutUs aboutUs = await repository.AboutUs.GetAboutUsAsync(trackChanges: false);
            AboutUsDto aboutUsDto = mapper.Map<AboutUsDto>(aboutUs);
            return aboutUsDto;
        }

        public async Task<AboutUsDto> CreateAboutUsAsync(AboutUsUpsertDto aboutUsUpsertDto)
        {

            AboutUs aboutUs = mapper.Map<AboutUs>(aboutUsUpsertDto);
            repository.AboutUs.CreateAboutUs(aboutUs);
            await repository.SaveAsync();
            AboutUsDto aboutUsDto = mapper.Map<AboutUsDto>(aboutUs);
            return aboutUsDto;
        }

        public async Task<AboutUsDto> UpdateAboutUsAsync(AboutUsUpsertDto aboutUsUpsertDto)
        {
            AboutUs aboutUs = await repository.AboutUs.GetAboutUsAsync(trackChanges: true);
            if (aboutUs == null)
                return null;
            AboutUs aboutUss = mapper.Map(aboutUsUpsertDto, aboutUs);
            repository.AboutUs.UpdateAboutUs(aboutUss);
            await repository.SaveAsync();
            AboutUsDto aboutUsDto = mapper.Map<AboutUsDto>(aboutUss);
            return aboutUsDto;
        }
    }
}
