namespace Haters.PostAPI.Data
{
    public class DbInitializer
    {
        public static void Initialize(PostDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
