using Entities.DataTransferObjects.KeyAreas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace SoarexApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyAreasController : ControllerBase
    {
        private readonly KeyAreasService _service;

        public KeyAreasController(KeyAreasService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> CreateKeyAreas([FromBody] KeyAreasUpsertDto upsertDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            KeyAreasDto keyAreasDto = await _service.CreateAsync(upsertDto);
            return CreatedAtAction("GetKeyAreas", keyAreasDto);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateKeyAreas([FromBody] KeyAreasUpsertDto upsertDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            KeyAreasDto keyAreasUpsertDto = await _service.UpdateAsync(upsertDto);
            if (keyAreasUpsertDto == null)
                return NotFound();
            return NoContent();
        }
        [HttpGet(Name = "GetKeyAreas")]
        public async Task<IActionResult> GetKeyAreas()
        {
            KeyAreasDto keyAreasDto = await _service.GetKeyAreasDtoAsync();
            if (keyAreasDto == null)
                return NotFound();
            return Ok(keyAreasDto);
        }
    }
}
