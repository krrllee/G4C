using Microsoft.AspNetCore.Mvc;
using TwitterCloneBackend.Dto;
using TwitterCloneBackend.Models;
using TwitterCloneBackend.Repositories.Interfaces;
using TwitterCloneBackend.Services.Interfaces;

namespace TwitterCloneBackend.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var username = User.Identity.Name;
            IEnumerable<UserDto> items = _userService.getAll(username);
            return Ok(items);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetById(int id)
        {

            try
            {
                UserDto user = _userService.getById(id);
                if (user == null)
                {
                    return NotFound(); // Return a 404 response if the user is not found.
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");

            }
        }

        [HttpPost]
        [Route("UpdateUser")]
        public IActionResult updateUser(UpdateDto user)
        {
            if (user == null)
            {
                return BadRequest("Invalid user data");
            }

            var updatedUser = _userService.updateUser(user);

            if (updatedUser == null)
            {
                return NotFound("User not found");
            }

            return Ok(updatedUser);
        }
       
    }
}
