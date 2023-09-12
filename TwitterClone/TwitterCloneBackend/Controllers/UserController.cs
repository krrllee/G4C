using Microsoft.AspNetCore.Mvc;
using TwitterCloneBackend.Models;
using TwitterCloneBackend.Repositories;

namespace TwitterCloneBackend.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<User> GetAll()
        {
            var users = _userRepository.getAll();
            return users.ToList();
        }

        [HttpGet]
        [Route("GetById")]
        public User GetById(int id)
        {
            var user = _userRepository.getById(id);
            return user;
        }

        [HttpPost]
        [Route("AddUser")]
        public bool AddUser(User user)
        {

            return false;
        }
       
    }
}
