using Contracts;
using Entities.DataTransferObjects.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Newtonsoft.Json;

namespace SoarexApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly BaseService _service;
        private readonly GlobalService _globalService;

        public SettingsController(
            ILoggerManager logger, 
            BaseService service,
            GlobalService globalService)
        {
            _logger = logger;
            _service = service;
            _globalService = globalService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateSettings(IFormCollection data)
        {
            var utility = data["utility"];
            SettingsUpsertDto settingsDto = JsonConvert.DeserializeObject<SettingsUpsertDto>(utility);
            await TryUpdateModelAsync(settingsDto);
            if(!ModelState.IsValid)
            {
                _logger.LogError("SettingsUpsertDto model is invalid for post");
                return UnprocessableEntity(ModelState);
            }
            var logo = data.Files["logo"];
            var heroImage = data.Files["heroImage"];
            settingsDto.Logo = _globalService.UploadFile(logo);
            settingsDto.HeroImage = _globalService.UploadFile(heroImage);
            var settingDto = await _service.AddSettings(settingsDto);
            if (settingDto == null)
                return UnprocessableEntity("Settings are created only once");
            return CreatedAtRoute("SettingsGet", settingsDto);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateteSettings(IFormCollection data)
        {
            var utility = data["utility"];
            SettingsUpsertDto settingsDto = JsonConvert.DeserializeObject<SettingsUpsertDto>(utility);
            await TryUpdateModelAsync(settingsDto);
           
            if (!ModelState.IsValid)
            {
                _logger.LogError("SettingsUpsertDto model is invalid for post");
                return UnprocessableEntity(ModelState);
            }
            var logo = data.Files["logo"];
            var heroImage = data.Files["heroImage"];
            settingsDto.Logo = _globalService.UploadFile(logo);
            settingsDto.HeroImage = _globalService.UploadFile(heroImage);
            var settingDto = await _service.UpdateSettings(settingsDto);
            if(settingDto == null)
            {
                _logger.LogError("The SettingsUpdateDto returned null");
                return NotFound();
            }
            return NoContent();
        }
        [HttpGet(Name = "SettingsGet")]
        public async Task<IActionResult> GetSettings()
        {
            var settingDto = await _service.GetSettings();
            if(settingDto == null)
            {
                _logger.LogWarn("Settings not found at GetSettings");
                return NotFound();
            }
            return Ok(settingDto);
        }
    }
}
