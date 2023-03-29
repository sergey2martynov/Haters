using Haters.PostAPI.PostData;

namespace Haters.PostAPI.Data
{
    public class PostHolder : IPostHolder
    {
        public List<Post> Posts { get; set; } = new List<Post>();

        public PostHolder()
        {
            var post1 = new Post
            {
                Id = Guid.NewGuid(),
                UserName = "User1",
                Title = "Big Data",
                Content = "What is it?"
            };

            var post2 = new Post
            {
                Id = Guid.NewGuid(),
                UserName = "User2",
                Title = "Machine Learning",
                Content = "I know it"
            };

            Posts.Add(post1);
            Posts.Add(post2);
        }
    }
}
