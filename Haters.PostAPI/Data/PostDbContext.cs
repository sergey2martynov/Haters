using Haters.PostAPI.PostData;
using Microsoft.EntityFrameworkCore;

namespace Haters.PostAPI.Data
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
