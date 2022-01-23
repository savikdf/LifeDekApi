using System;
using System.Collections.Generic;
using LifeDekApi.Daos.Interfaces;
using LifeDekApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LifeDekApi.Daos;

public partial class LifeDekDbContext : DbContext, ILifeDekDbContext
{
    public LifeDekDbContext()
    {
    }

    public LifeDekDbContext(DbContextOptions<LifeDekDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Card> Cards { get; set; } = null!;
    public virtual DbSet<User> Users { get; set; } = null!;

    public override int SaveChanges()
    {
        int result = base.SaveChanges();
        System.Console.WriteLine($"LifeDekDbContext: Saved changes to LifeDekDb. Result of {result}");
        return result;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=LifeDekDb;Trusted_Connection=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Card>(entity =>
        {
            entity.HasKey(e => e.Guid)
                .HasName("PK__Cards__A2B5777C97B2D23C");

            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Description).IsUnicode(false);

            entity.Property(e => e.Name).IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Guid)
                .HasName("PK__Users__A2B5777CB3AD3589");

            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.FirstName).IsUnicode(false);

            entity.Property(e => e.LastName).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);    
}

