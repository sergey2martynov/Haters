using Microsoft.EntityFrameworkCore;

namespace Haters.PostAPI.Data
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
