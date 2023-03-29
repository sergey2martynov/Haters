using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Haters.IdentityServer.Data
{
    public static class DataBaseInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
