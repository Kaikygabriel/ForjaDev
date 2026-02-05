using ForjaDev.Domain.BackOffice.Entities;
using ForjaDev.Domain.BackOffice.ValuesObject;
using Microsoft.EntityFrameworkCore;

namespace ForjaDev.Infra.Data.Context;

public class AppDbContext(DbContextOptions<AppDbContext>options) : DbContext(options)
{
    public DbSet<Like>Likes{ get; set; }
    public DbSet<Post>Posts { get; set; }
    public DbSet<Category>Categories { get; set; }
    public DbSet<Member>Members { get; set; }
    public DbSet<User>Users { get; set; }
    public DbSet<Comment>Comments { get; set; }
    public DbSet<Following>Followings { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}