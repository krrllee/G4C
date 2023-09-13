using Microsoft.IdentityModel.Tokens;
using Microsoft.SqlServer.Management.SqlParser.Metadata;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TwitterCloneBackend.Dto;
using TwitterCloneBackend.Dtos;
using TwitterCloneBackend.Models;
using TwitterCloneBackend.Repositories;
using TwitterCloneBackend.Repositories.Interfaces;
using TwitterCloneBackend.Services.Interfaces;

namespace TwitterCloneBackend.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILoginRepository _loginRepository;
        private readonly string _jwtSecret;
        private readonly int _jwtExpirationMinutes = 30;

        public LoginService(ILoginRepository loginRepository,IUserRepository userRepository)
        {
            _loginRepository = loginRepository;
            _userRepository = userRepository;
        }

        public string Login(LoginDto loginDto)
        {
            var user = _userRepository.getByUsername(loginDto.Username);
            if (user == null)
            {
                return ("User not found.");
            }
            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password,user.Password))
            {
                return("Invalid password.");
            }

            return ("Logged in.");
        }


        public void Register(RegisterDto registerDto)
        {
            try
            {
                var newUser = new User
                {
                    Username = registerDto.Username,
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    Email = registerDto.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password)
                };

                _loginRepository.Create(newUser);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
