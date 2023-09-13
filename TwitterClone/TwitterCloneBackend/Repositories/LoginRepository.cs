using TwitterCloneBackend.Models;
using TwitterCloneBackend.Repositories.Interfaces;

namespace TwitterCloneBackend.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly TwitterDbContext _context;
        public LoginRepository(TwitterDbContext context)
        {
            _context = context;
        }
        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
