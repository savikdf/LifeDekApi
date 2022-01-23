using LifeDekApi.Dtos;

namespace LifeDekApi.Services.Interfaces;

public interface IUserService
{
    UserDto GetUser(Guid id);
    UserDto CreateUser(UserDto request);
    UserDto UpdateUser(UserDto request);
    UserDto DeleteUser(Guid id);
}
