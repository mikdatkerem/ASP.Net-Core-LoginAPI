using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data.Common;
using WebAPI.Models;
using WebAPI.Repositories.Config;

namespace WebAPI.Repositories
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.ApplyConfiguration(new UserConfig());
        }
    }
}
