using Entities.DataTransferObjects.AboutUs;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace SoarexApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutUsController : ControllerBase
    {


        private readonly AboutUsService aboutUsService;

        public AboutUsController(AboutUsService aboutUsService)
        {
            this.aboutUsService = aboutUsService;
        }

        [HttpGet(Name = "GetAboutUs")]
        public async Task<IActionResult> GetAboutUs()
        {
            AboutUsDto aboutUssDto = await aboutUsService.GetAboutUsAsync();
            if (aboutUssDto == null)
                return NotFound();
            return Ok(aboutUssDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAboutUs(AboutUsUpsertDto upsertDto)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            AboutUsDto aboutUssDto = await aboutUsService.CreateAboutUsAsync(upsertDto);

            return CreatedAtAction("GetAboutUs", aboutUssDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAboutUs(Guid id, AboutUsUpsertDto aboutUssUpsertDto)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            AboutUsDto aboutUssDto = await aboutUsService.UpdateAboutUsAsync(aboutUssUpsertDto);
            if (aboutUssDto == null)
                return NotFound();
            return NoContent();
        }

    }
}
