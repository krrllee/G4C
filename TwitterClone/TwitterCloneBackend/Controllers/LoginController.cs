using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Management.SqlParser.Metadata;
using TwitterCloneBackend.Dto;
using TwitterCloneBackend.Dtos;
using TwitterCloneBackend.Services.Interfaces;

namespace TwitterCloneBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody]RegisterDto user)
        {
            try
            {
                _loginService.Register(user);
                return NoContent();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto loginDto)
        {
            var token = _loginService.Login(loginDto);
            if (token != null)
            {
                if (token == string.Empty)
                {
                    return BadRequest("Wrong password!");

                }
                return Ok(token);
            }
            else
            {
                return BadRequest("Wrong email!");
            }
        }
    }
}
