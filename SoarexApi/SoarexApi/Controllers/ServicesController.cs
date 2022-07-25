using Entities.DataTransferObjects.UtilityServices;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace SoarexApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly UtilityService service;

        public ServicesController(UtilityService service)
        {
            this.service = service;
        }
        [HttpGet(Name = "GetService")]
        public async Task<IActionResult> GetServices()
        {
            return Ok(await service.GetServiceAsync());
        }
        [HttpPost]
        public async Task<IActionResult> CreateServices(UtilityServiceUpsertDto serviceUpsertDto)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            var services = await service.CreateServiceAsync(serviceUpsertDto);
            return CreatedAtAction("GetService", services);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateServices(Guid id, UtilityServiceUpsertDto serviceUpsertDto)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            var services = await service.UpdateServiceAsync(id,serviceUpsertDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(Guid id)
        {
            if (id == null)
                return NotFound();
            bool isDeleted = await service.DeleteServiceAsync(id);
            if(!isDeleted)
                return NotFound();
            return NoContent();
        }
    }
}
