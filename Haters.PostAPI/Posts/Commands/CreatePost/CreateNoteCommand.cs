using MediatR;

namespace Haters.PostAPI.Posts.Commands.CreatePost
{
    public class CreatePostCommand : IRequest<Guid>
    {
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
