using Entities.DataTransferObjects.Enquiry;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace SoarexApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnquiryController : ControllerBase
    {

        private readonly EnquiryService enquiryService;

        public EnquiryController(EnquiryService enquiryService)
        {
            this.enquiryService = enquiryService;
        }

        [HttpGet(Name = "GetEnquiry")]
        public async Task<IActionResult> GetEnquiry()
        {
            IEnumerable<EnquiryDto> enquiriesDto = await enquiryService.GetEnquiriesAsync();
            if (enquiriesDto == null)
                return NotFound();
            return Ok(enquiriesDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEnquiry(EnquiryUpsertDto upsertDto)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            EnquiryDto enquiriesDto = await enquiryService.CreateEnquiryAsync(upsertDto);

            return CreatedAtAction("GetEnquiry", enquiriesDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEnquiry(Guid id, EnquiryUpsertDto enquiriesUpsertDto)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            EnquiryDto enquiriesDto = await enquiryService.UpdateEnquiryAsync(id, enquiriesUpsertDto);
            if (enquiriesDto == null)
                return NotFound();
            return NoContent();
        }

    }
}
