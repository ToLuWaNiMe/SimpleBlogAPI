using Microsoft.AspNetCore.Mvc;
using SimpleBlogAPI.DTOs;
using SimpleBlogAPI.Services;

namespace SimpleBlogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegistrationDTO userForRegistration)
        {
            try
            {
                var user = await _authService.RegisterUserAsync(userForRegistration);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDTO userForLogin)
        {
            try
            {
                var token = await _authService.LoginUserAsync(userForLogin);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
