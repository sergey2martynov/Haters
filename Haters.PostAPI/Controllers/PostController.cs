using AutoMapper;
using Haters.PostAPI.Data;
using Haters.PostAPI.PostData;
using Haters.PostAPI.Posts.Commands.CreatePost;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Haters.PostAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    [EnableCors("DefaultPolicy")]
    public class PostController : ControllerBase
    {
        private readonly IPostHolder _postHolder;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;
        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public PostController(IPostHolder postHolder, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _postHolder = postHolder;
            _contextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        [HttpGet]
        [HttpGet("all")]
        public IActionResult GetAllPosts()
        {

            var postsDto = new List<PostDto>();

            foreach (var post in _postHolder.Posts)
            {
                var postDto = new PostDto
                {
                    UserName = post.UserName,
                    Title = post.Title,
                    Content = post.Content,
                };

                postsDto.Add(postDto);
            }

            return Ok(postsDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePostAsync([FromBody] PostDto postDto)
        {
            var command = _mapper.Map<CreatePostCommand>(postDto);
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }
    }
}
