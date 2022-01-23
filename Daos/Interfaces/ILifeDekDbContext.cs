using LifeDekApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeDekApi.Daos.Interfaces;

public interface ILifeDekDbContext
{
    DbSet<Card> Cards { get; set; }
    DbSet<User> Users { get; set; }

    int SaveChanges();
}

