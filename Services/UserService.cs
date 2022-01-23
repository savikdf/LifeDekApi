using LifeDekApi.Daos;
using LifeDekApi.Daos.Interfaces;
using LifeDekApi.Dtos;
using LifeDekApi.Models;
using LifeDekApi.Services.Interfaces;

namespace LifeDekApi.Services;

public class UserService : IUserService
{
    private readonly IUserDao userDao;

    public UserService() : this(new UserDao()) { }
    public UserService(IUserDao userDao)
    {
        this.userDao = userDao;
    }

    public UserDto GetUser(Guid id)
    {
        User model = userDao.GetUser(id);
        return (UserDto)model;
    }

    public UserDto CreateUser(UserDto request)
    {
        User model = (User)request;
        return (UserDto)userDao.CreateUser(model);
    }

    public UserDto UpdateUser(UserDto request)
    {
        User model = (User)request;
        return (UserDto)userDao.UpdateUser(model);
    }

    public UserDto DeleteUser(Guid id)
    {
        User model = userDao.DeleteUser(id);
        return (UserDto)model;
    }
}

