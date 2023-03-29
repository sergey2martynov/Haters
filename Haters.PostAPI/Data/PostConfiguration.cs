using Haters.PostAPI.PostData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Haters.PostAPI.Data
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(post => post.Id);
            builder.HasIndex(post => post.Id).IsUnique();
            builder.Property(post => post.Title).HasMaxLength(40);
            builder.Property(post => post.Content).HasMaxLength(300);
        }
    }
}
