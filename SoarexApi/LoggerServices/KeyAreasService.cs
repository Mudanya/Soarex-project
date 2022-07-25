using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.KeyAreas;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class KeyAreasService
    {
        private readonly IRepositorymanager _repository;
        private readonly IMapper mapper;

        public KeyAreasService(IRepositorymanager repository, IMapper mapper)
        {
            _repository = repository;
            this.mapper = mapper;
        }
        public async Task<KeyAreasDto> CreateAsync(KeyAreasUpsertDto upsertDto)
        {
            KeyAreas keyAreas = mapper.Map<KeyAreas>(upsertDto);
            _repository.KeyAreas.CreateKeyAreas(keyAreas);
            await _repository.SaveAsync();
            KeyAreasDto keyAreasDto = mapper.Map<KeyAreasDto>(keyAreas);
            return keyAreasDto;
        }
        public async Task<KeyAreasDto> UpdateAsync(KeyAreasUpsertDto upsertDto)
        {
            KeyAreas keyAreas = await _repository.KeyAreas.GetKeyAreasAsync(trackChanges: true);
            if (keyAreas == null)
                return null;
            KeyAreas keyAreasForUpdate = mapper.Map(upsertDto,keyAreas);
            _repository.KeyAreas.UpdateKeyAreas(keyAreasForUpdate);
            await _repository.SaveAsync();
            KeyAreasDto keyAreasDto = mapper.Map<KeyAreasDto>(keyAreasForUpdate);
            return keyAreasDto;
        }

        public async Task<KeyAreasDto> GetKeyAreasDtoAsync()
        {
            KeyAreas keyAreas = await _repository.KeyAreas.GetKeyAreasAsync(trackChanges:false);
            KeyAreasDto keyAreasDto = mapper.Map<KeyAreasDto>(keyAreas);
            return keyAreasDto;
        }
    }
}
