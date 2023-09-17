using System.Reflection.Metadata.Ecma335;
using TwitterCloneBackend.Dto;
using TwitterCloneBackend.Models;
using TwitterCloneBackend.Repositories.Interfaces;
using TwitterCloneBackend.Services.Interfaces;
using Microsoft.SqlServer.Management;
using Microsoft.SqlServer.Management.SqlParser.Metadata;


namespace TwitterCloneBackend.Services
{
    public class UserService : IUserService
    {
       private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public List<UserDto> getAll()
        {
            return _userRepository.getAll();
        }

        public UserDto getById(int id)
        {
            try
            {
                UserDto user = _userRepository.getById(id);

                // Handle the case where the user with the specified ID is not found.
                if (user == null)
                {
                    // You can throw an exception, return null, or handle it as you see fit.
                    throw new Exception($"User with ID {id} not found.");
                }

                return user;
            }
            catch (Exception ex)
            {
                // Handle exceptions and possibly log them.
                throw new Exception($"Error while fetching user with ID {id}: {ex.Message}", ex);
            }
        }

        public UpdateDto updateUser(UpdateDto user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            var existingUser = _userRepository.getByUsername(user.Username);
            if (existingUser == null)
            {
                return null;
            }

            existingUser.Username = user.Username;
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.Bio = user.Bio;
            existingUser.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            _userRepository.updateUser(existingUser);

            return user;
        }

    }
}
