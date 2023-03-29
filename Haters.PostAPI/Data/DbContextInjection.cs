using Applicaton.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class DbContextInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<PostDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IPostDbContext>(provider =>
                provider.GetService<PostDbContext>());
            return services;
        }
    }
}
