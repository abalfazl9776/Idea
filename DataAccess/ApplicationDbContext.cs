using DataAccess.Entities;
using DataContract.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
        
    }
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Idea> Idea { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Comment> Comment { get; set; }
    public DbSet<CommentsOnIdeas>CommentsOnIdeas { get; set; }

}