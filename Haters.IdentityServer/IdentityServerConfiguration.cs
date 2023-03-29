using IdentityServer4.Models;
using IdentityServer4;
using IdentityModel;

internal class IdentityServerConfiguration
{
    public static List<Client> GetClients()
    {
        return new List<Client>
        {
            new Client{
                ClientId = "client_blazor",
                ClientSecrets = { new Secret("client_secret_blazor".ToSha256()) },
            RequireClientSecret = false,
            RequireConsent = false,
            RequirePkce = true,
            AllowedGrantTypes = GrantTypes.Code,
            AllowedScopes =
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                "blazor",
                "PostAPI"
            },
            AllowedCorsOrigins = { "https://localhost:7294" },
            RedirectUris = {"https://localhost:7294/authentication/login-callback"},
            PostLogoutRedirectUris = { "https://localhost:7294/authentication/logout-callback" }
            },
        new Client
        {
            ClientId = "client_id",
            ClientSecrets = { new Secret("client_secret".ToSha256()) },
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            AllowedScopes =
                {
                    "PostAPI",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                },
        }
        };
    }


    public static IEnumerable<ApiResource> GetApiResources()
    {
        yield return new ApiResource("PostAPI")
        {
            Scopes = { "PostAPI" }
        };
    }

    public static IEnumerable<IdentityResource> GetIdentityResources()
    {
        yield return new IdentityResources.OpenId();
        yield return new IdentityResources.Profile();
    }

    /// <summary>
    /// IdentityServer4 version 4.x.x changes
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<ApiScope> GetApiScopes()
    {
        yield return new ApiScope("blazor");
        yield return new ApiScope("PostAPI");
    }
}