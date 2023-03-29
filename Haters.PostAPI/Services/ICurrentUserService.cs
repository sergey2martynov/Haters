using System;

namespace Haters.PostAPI.Services
{
    public interface ICurrentUserService
    {
        Guid UserId { get; }
    }
}
