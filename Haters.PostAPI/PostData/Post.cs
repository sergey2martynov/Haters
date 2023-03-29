namespace Haters.PostAPI.PostData
{
    public class Post
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
