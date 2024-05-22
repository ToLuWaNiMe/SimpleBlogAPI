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
                // Call the AuthService to register the user
                var user = await _authService.RegisterUserAsync(userForRegistration);
                return Ok(user);  // Return the newly created user object on success
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during registration (e.g., validation errors, data access issues)
                return BadRequest(ex.Message);  // Return a BadRequest response with the exception message
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDTO userForLogin)
        {
            try
            {
                // Call the AuthService to login the user
                var token = await _authService.LoginUserAsync(userForLogin);
                return Ok(new { Token = token });  // Return an object containing the generated token
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during login (e.g., invalid credentials, authentication errors)
                return Unauthorized(ex.Message);  // Return an Unauthorized response with the exception message
            }
        }
    }
}
