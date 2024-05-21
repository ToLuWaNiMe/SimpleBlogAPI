using AutoMapper;
using BCrypt.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Generators;
using SimpleBlogAPI.DTOs;
using SimpleBlogAPI.Models;
using SimpleBlogAPI.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlogAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<UserDTO> RegisterUserAsync(UserForRegistrationDTO userForRegistration)
        {
            var existingUser = await _userRepository.GetUserByUsernameAsync(userForRegistration.Username);
            if (existingUser != null)
            {
                throw new Exception("User already exists");
            }

            var user = new User
            {
                Username = userForRegistration.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(userForRegistration.Password)
            };

            await _userRepository.CreateUserAsync(user);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<string> LoginUserAsync(UserForLoginDTO userForLogin)
        {
            var user = await _userRepository.GetUserByUsernameAsync(userForLogin.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(userForLogin.Password, user.PasswordHash))
            {
                throw new Exception("Invalid username or password");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.Username)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
