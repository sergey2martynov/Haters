using Haters.PostAPI.PostData;
using Microsoft.EntityFrameworkCore;

namespace Haters.PostAPI.Data
{
    public interface IPostDbContext
    {
        DbSet<Post> Posts { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
