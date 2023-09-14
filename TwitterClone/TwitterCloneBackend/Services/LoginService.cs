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
        private readonly IConfigurationSection _secretKey;

        public LoginService(ILoginRepository loginRepository,IUserRepository userRepository,IConfiguration config)
        {
            _loginRepository = loginRepository;
            _userRepository = userRepository;
            _secretKey = config.GetSection("SecretKey");
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

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Username));


            SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey.Value));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: "http://localhost:44398",
                claims: claims, //claimovi
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: signinCredentials
            );
            return new JwtSecurityTokenHandler().WriteToken(tokeOptions);
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
