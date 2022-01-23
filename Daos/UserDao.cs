using LifeDekApi.Daos.Interfaces;
using LifeDekApi.Models;

namespace LifeDekApi.Daos;

public class UserDao : IUserDao
{
    //temp in memory repo
    private List<Card> cards = new List<Card>();

    private ILifeDekDbContext context;

    public UserDao() : this(new LifeDekDbContext()) { }
    public UserDao(ILifeDekDbContext context)
    {
        this.context = context;
        for (int i = 0; i < 10; i++)
        {
            cards.Add(new Card()
            {
                Guid = Guid.NewGuid(),
                Name = $"Card Name {i}",
                Description = $"Card Description {i}"
            });
        }
    }


    public User GetUser(Guid id)
    {
        return context.Users.SingleOrDefault(u => u.Guid == id);
    }

    public User CreateUser(User request)
    {
        context.Users.Add(request);

        if (context.SaveChanges() == 0)
        {
            throw new Microsoft.EntityFrameworkCore.DbUpdateException();
        }

        return request;
    }

    public User UpdateUser(User request)
    {
        User userToUpdate = GetUser(request.Guid);
        if (userToUpdate == null)
        {
            return null;
        }

        userToUpdate.FirstName = request.FirstName;
        userToUpdate.LastName = request.LastName;

        if (context.SaveChanges() == 0)
        {
            throw new Microsoft.EntityFrameworkCore.DbUpdateException();
        }

        return userToUpdate;
    }

    public User DeleteUser(Guid id)
    {
        User userToDelete = GetUser(id);
        if (userToDelete == null)
        {
            return null;
        }
        context.Users.Remove(userToDelete);

        if (context.SaveChanges() == 0)
        {
            throw new Microsoft.EntityFrameworkCore.DbUpdateException();
        }
        return userToDelete;
    }
}
