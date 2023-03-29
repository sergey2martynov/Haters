using Haters.BlazorClient.Models;
using System.Security.Claims;

namespace Haters.BlazorClient.Services
{
    public interface IPostService
    {
        Task<List<PostDto>> GetPosts(ClaimsPrincipal user);
        Task SendPost(PostDto postDto);
    }
}
