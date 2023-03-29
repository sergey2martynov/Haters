using Haters.BlazorClient.Models;

namespace PostCreator.Client.Services
{
    public interface IUserService
    {
        Task<PostDto> GetUser();
    }
}
