using TwitterCloneBackend.Dto;
using TwitterCloneBackend.Models;

namespace TwitterCloneBackend.Services.Interfaces
{
    public interface IUserService
    {
        UserDto getById(int id);
        List<UserDto> getAll(string username);
        UpdateDto updateUser(UpdateDto user);

    }
}
