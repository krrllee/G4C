using AutoMapper;
using TwitterCloneBackend.Dto;
using TwitterCloneBackend.Models;
using TwitterCloneBackend.Repositories.Interfaces;

namespace TwitterCloneBackend.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly TwitterDbContext _context;
        private readonly IMapper _mapper;
        public UserRepository(IMapper mapper,TwitterDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public UserDto getById(int id)
        {
            var userEntity = _context.Users.SingleOrDefault(u => u.Id == id);
            return _mapper.Map<UserDto>(userEntity);
        }

        public User getByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }

        public void updateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        List<UserDto> IUserRepository.getAll()
        {
            return _mapper.Map<List<UserDto>>(_context.Users.ToList());
        }
    }
}
