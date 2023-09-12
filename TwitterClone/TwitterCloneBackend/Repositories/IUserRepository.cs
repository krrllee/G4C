using TwitterCloneBackend.Models;

namespace TwitterCloneBackend.Repositories
{
    public interface IUserRepository
    {
        User getById(int id);
        List<User> getAll();
        bool addUser(User user);
        bool removeUser(int id);
        bool updateUser(User user);

    }
}
