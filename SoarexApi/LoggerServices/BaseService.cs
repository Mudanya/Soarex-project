using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.Settings;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BaseService
    {
        private readonly IMapper _mapper;
        private readonly IRepositorymanager _repository;
        public BaseService(IMapper mapper, IRepositorymanager repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<SettingsDto> AddSettings(SettingsUpsertDto upsertDto)
        {
            var isSettings = await GetSettings();
            if (isSettings != null)
                return null;
            Settings settings = _mapper.Map<Settings>(upsertDto);
            _repository.Settings.CreateSettings(settings);
            await _repository.SaveAsync();
            SettingsDto settingsDto = _mapper.Map<SettingsDto>(settings);
            return settingsDto;
        }
         public async Task<SettingsDto> UpdateSettings(SettingsUpsertDto upsertDto)
        {
            Settings set = await _repository.Settings.GetSettingsAsync(trackChanges: true);
            if (set == null)
                return null;
            Settings settings = _mapper.Map(upsertDto,set);
            _repository.Settings.UpdateSettings(settings);
            await _repository.SaveAsync();
            SettingsDto settingsDto = _mapper.Map<SettingsDto>(settings);
            return settingsDto;
        }

        public async Task<SettingsDto> GetSettings()
        {
            Settings settings = await _repository.Settings.GetSettingsAsync(trackChanges: false);
            if (settings == null)
                return null;
            SettingsDto settingsDto = _mapper.Map<SettingsDto>(settings);
            return settingsDto;
        }
    }
}
