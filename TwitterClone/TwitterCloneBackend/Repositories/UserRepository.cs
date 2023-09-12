using TwitterCloneBackend.Models;

namespace TwitterCloneBackend.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly TwitterDbContext _context;
        public UserRepository(TwitterDbContext context)
        {
            _context = context;
        }
        public bool addUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }

        public List<User> getAll()
        {
            return _context.Users.ToList();
        }

        public User getById(int id)
        {
            var result = _context.Users.FirstOrDefault(x => x.Id == id);
            if (result == null) {
                return null;
            }
            return result;
        }

        public bool removeUser(int id)
        {
            try
            {
                var res = _context.Users.FirstOrDefault(u => u.Id == id);
                if(res != null)
                {
                    _context.Users.Remove(res);
                    _context.SaveChanges();
                    return true;

                }
                return false;
            }
            catch(Exception ex)
            {
                return false; 
            }
        }

        public bool updateUser(User user)
        {
            try
            {
                var res = _context.Users.Update(user);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
