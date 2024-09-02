using Bn_API.Models;

namespace Bn_API.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
