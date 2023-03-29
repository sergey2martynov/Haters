using Haters.PostAPI.PostData;

namespace Haters.PostAPI.Data
{
    public interface IPostHolder
    {
        public List<Post> Posts { get; set; }
    }
}
