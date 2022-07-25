using Entities.DataTransferObjects.CustomerFeedback;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace SoarexApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerFeedbackController : ControllerBase
    {


        private readonly CustomerFeedbackService customerFeedbackService;

        public CustomerFeedbackController(CustomerFeedbackService customerFeedbackService)
        {
            this.customerFeedbackService = customerFeedbackService;
        }

        [HttpGet(Name = "GetCustomerFeedback")]
        public async Task<IActionResult> GetCustomerFeedback()
        {
            IEnumerable<CustomerFeedbackDto> enquiriesDto = await customerFeedbackService.GetCustomerFeedbackAsync();
            if (enquiriesDto == null)
                return NotFound();
            return Ok(enquiriesDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomerFeedback(CustomerFeedbackUpsertDto upsertDto)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            CustomerFeedbackDto enquiriesDto = await customerFeedbackService.CreateCustomerFeedbackAsync(upsertDto);

            return CreatedAtAction("GetCustomerFeedback", enquiriesDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerFeedback(Guid id, CustomerFeedbackUpsertDto enquiriesUpsertDto)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            CustomerFeedbackDto enquiriesDto = await customerFeedbackService.UpdateCustomerFeedbackAsync(id, enquiriesUpsertDto);
            if (enquiriesDto == null)
                return NotFound();
            return NoContent();
        }

    }
}
