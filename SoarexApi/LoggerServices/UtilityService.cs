using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.UtilityServices;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UtilityService
    {
        private readonly IRepositorymanager repository;
        private readonly IMapper mapper;

        public UtilityService(IRepositorymanager repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<UtilityServiceDto> CreateServiceAsync(UtilityServiceUpsertDto serviceUpsertDto)
        {
            Service service = mapper.Map<Service>(serviceUpsertDto);
            repository.Services.CreateService(service);
            await repository.SaveAsync();
            return mapper.Map<UtilityServiceDto>(service);
        }
        public async Task<UtilityServiceDto> UpdateServiceAsync(Guid id, UtilityServiceUpsertDto serviceUpsertDto)
        {
            Service service = await repository.Services.GetService(id,trackChanges: true);
            if (service == null)
                return null;
            Service  services = mapper.Map(serviceUpsertDto, service);
            repository.Services.UpdateService(services);
            await repository.SaveAsync();
            return mapper.Map<UtilityServiceDto>(services);
        }
         public async Task<IEnumerable<UtilityServiceDto>> GetServiceAsync()
        {
            IEnumerable<Service> services = await repository.Services.GetAllServices(trackChanges: false);
            if (services == null)
                return null;
            
            return mapper.Map<IEnumerable<UtilityServiceDto>>(services);
        }
        
        public async Task<bool> DeleteServiceAsync(Guid id)
        {

            Service service = await repository.Services.GetService(id, trackChanges: false);
            if(service ==  null)
                return false;
            repository.Services.DeleteService(service);
            await repository.SaveAsync();
            return true;
        }
    }
}
