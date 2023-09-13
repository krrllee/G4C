using TwitterCloneBackend.Dto;
using TwitterCloneBackend.Models;

namespace TwitterCloneBackend.Repositories.Interfaces
{
    public interface IUserRepository
    {
        UserDto getById(int id);
        List<UserDto> getAll();
        void updateUser(User user);
        User getByUsername(string username);

    }
}
