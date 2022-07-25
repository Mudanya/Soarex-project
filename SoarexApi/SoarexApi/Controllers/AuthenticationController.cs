using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.Authentication;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SoarexApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationManager _authentication;
        private readonly ILoggerManager logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper mapper;

        public AuthenticationController(
            IAuthenticationManager authentication, 
            ILoggerManager logger, 
            UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {
            _authentication = authentication;
            this.logger = logger;
            _userManager = userManager;
            this.mapper = mapper;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthenticationUpsertDto authenticationUpsertDto)
        {
            if(!ModelState.IsValid)
            {
                logger.LogError($"Invalid login object");
                return UnprocessableEntity(ModelState);
            }
            var isLogin =await _authentication.ValidateUser(authenticationUpsertDto);
            if (!isLogin)
                return Unauthorized();
            return Ok(new { Token = _authentication.CreateToken() });
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var user = mapper.Map<ApplicationUser>(registerDto);
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if(!result.Succeeded)
            {
                foreach(var errors in result.Errors)
                {
                    ModelState.TryAddModelError(errors.Code, errors.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }

    }
}
