using Haters.PostAPI.Data;
using Haters.PostAPI.PostData;
using MediatR;

namespace Haters.PostAPI.Posts.Commands.CreatePost
{
    public class CreatePostCommandHandler
        : IRequestHandler<CreatePostCommand, Guid>
    {
        private readonly IPostDbContext _dbContext;

        public CreatePostCommandHandler(IPostDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreatePostCommand request,
            CancellationToken cancellationToken)
        {
            var post = new Post
            {
                UserName = request.UserName,
                Title = request.Title,
                Content = request.Content,
                Id = Guid.NewGuid(),
            };

            await _dbContext.Posts.AddAsync(post, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return post.Id;
        }
    }
}
