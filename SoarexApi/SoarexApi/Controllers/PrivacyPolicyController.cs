using Entities.DataTransferObjects.PrivacyPolicy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace SoarexApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrivacyPolicyController : ControllerBase
    {
        private readonly PrivacyPolicyService policyService;

        public PrivacyPolicyController(PrivacyPolicyService policyService)
        {
            this.policyService = policyService;
        }

        [HttpGet(Name = "GetPrivatePolicy")]
        public async Task<IActionResult> GetPrivatePolicy()
        {
            PrivacyPolicyDto termsDto = await policyService.GetPrivacyPolicyAsync();
            if (termsDto == null)
                return NotFound();
            return Ok(termsDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePrivacyPolicy(PrivacyPolicyUpsertDto upsertDto)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            PrivacyPolicyDto termsDto = await policyService.CreatePrivacyPolicyAsync(upsertDto);

            return CreatedAtAction("GetPrivatePolicy", termsDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePrivacyPolicy(PrivacyPolicyUpsertDto termsUpsertDto)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            PrivacyPolicyDto termsDto = await policyService.UpdatePrivacyPolicyAsync(termsUpsertDto);
            if (termsDto == null)
                return NotFound();
            return NoContent();
        }

    }
}
