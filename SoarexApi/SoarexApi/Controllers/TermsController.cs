using Entities.DataTransferObjects.Terms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace SoarexApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermsController : ControllerBase
    {
        private readonly TermService termService;

        public TermsController(TermService termService)
        {
            this.termService = termService;
        }
        [HttpGet(Name = "GetTerms")]
        public async Task<IActionResult> GetTerms()
        {
            TermsDto termsDto = await termService.GetTermsAsync();
            if(termsDto == null)
                return NotFound();
            return Ok(termsDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTerms(TermsUpsertDto upsertDto)
        {
            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            TermsDto termsDto = await termService.CreateTermsAsync(upsertDto);
            
            return CreatedAtAction("GetTerms", termsDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTerms(TermsUpsertDto termsUpsertDto)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            TermsDto termsDto = await termService.UpdateTermsAsync(termsUpsertDto);
            if (termsDto == null)
                return NotFound();
            return NoContent();
        }

    }
}
