using Haters.BlazorClient.Models;
using IdentityModel.Client;
using System.Net.Http.Json;
using System.Security.Claims;

namespace Haters.BlazorClient.Services
{
    public class PostService : IPostService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PostService(IHttpClientFactory httpClientfactory)
        {
            _httpClientFactory = httpClientfactory;
        }

        public async Task<List<PostDto>> GetPosts(ClaimsPrincipal user)
        {

            var authClient = _httpClientFactory.CreateClient();
            var discoveryDocument = await authClient.GetDiscoveryDocumentAsync("https://localhost:10001");

            var tokenResponse = await authClient.RequestClientCredentialsTokenAsync(
                new ClientCredentialsTokenRequest
                {
                    Address = discoveryDocument.TokenEndpoint,
                    ClientId = "client_id",
                    ClientSecret = "client_secret",
                    Scope = "PostAPI",
                });

            var postApiClient = _httpClientFactory.CreateClient();

            postApiClient.SetBearerToken(tokenResponse.AccessToken);

            //var id = user.Identity.Name;

            var response = await postApiClient.GetAsync("https://localhost:5001/api/post/all");

            if (!response.IsSuccessStatusCode)
            {

            }

            return await response.Content.ReadFromJsonAsync<List<PostDto>>();
        }

        public async Task SendPost(PostDto post)
        {
            var postApiClient = await GetPostApiClient();

            //var response = await postApiClient.GetAsync("https://localhost:5001/api/post/all");

            await postApiClient.PostAsJsonAsync("https://localhost:5001/api/post", post);
        }

        private async Task<HttpClient> GetPostApiClient()
        {
            var authClient = _httpClientFactory.CreateClient();
            var discoveryDocument = await authClient.GetDiscoveryDocumentAsync("https://localhost:10001");

            var tokenResponse = await authClient.RequestClientCredentialsTokenAsync(
                new ClientCredentialsTokenRequest
                {
                    Address = discoveryDocument.TokenEndpoint,
                    ClientId = "client_id",
                    ClientSecret = "client_secret",
                    Scope = "PostAPI"
                });

            var postApiClient = _httpClientFactory.CreateClient();

            postApiClient.SetBearerToken(tokenResponse.AccessToken);

            return postApiClient;
        }
    }
}
