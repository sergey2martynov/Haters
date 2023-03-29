using Applicaton.Interfaces;
using Data.EntityTypeConfiguration;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class PostDbContext : DbContext, IPostDbContext
    {
        public DbSet<Post> Posts { get; set; }

        public PostDbContext(DbContextOptions<PostDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PostConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
