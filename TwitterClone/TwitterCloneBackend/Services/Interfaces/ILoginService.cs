using Microsoft.Exchange.WebServices.Data;
using TwitterCloneBackend.Dto;
using TwitterCloneBackend.Dtos;

namespace TwitterCloneBackend.Services.Interfaces
{
    public interface ILoginService
    {
        void Register(RegisterDto registerDto);
        string Login(LoginDto loginDto);
    }
}
