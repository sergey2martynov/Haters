using Applicaton.Posts.Commands.CreatePost;
using FluentValidation;

namespace Haters.PostAPI.Posts.Commands.CreatePost
{
    public class CreateNoteCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreateNoteCommandValidator()
        {
            RuleFor(createPostCommand =>
                createPostCommand.Title).NotEmpty().MaximumLength(300);
            RuleFor(createPostCommand =>
                createPostCommand.UserName).NotEmpty();
            RuleFor(createPostCommand =>
                createPostCommand.Content).NotEmpty().MaximumLength(300);
        }
    }
}
