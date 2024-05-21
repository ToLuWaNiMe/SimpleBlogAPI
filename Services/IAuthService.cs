using SimpleBlogAPI.DTOs;

namespace SimpleBlogAPI.Services
{
    public interface IAuthService
    {
        Task<UserDTO> RegisterUserAsync(UserForRegistrationDTO userForRegistration);
        Task<string> LoginUserAsync(UserForLoginDTO userForLogin);
    }
}
