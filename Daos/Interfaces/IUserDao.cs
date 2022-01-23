using LifeDekApi.Models;

namespace LifeDekApi.Daos.Interfaces;

public interface IUserDao
{
    User GetUser(Guid id);
    User CreateUser(User request);
    User UpdateUser(User request);
    User DeleteUser(Guid id);
}
