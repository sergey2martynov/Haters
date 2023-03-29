using Domain;
using Microsoft.EntityFrameworkCore;

namespace Applicaton.Interfaces
{
    public interface IPostDbContext
    {
        DbSet<Post> Posts { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
