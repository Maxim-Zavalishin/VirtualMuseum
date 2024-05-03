using System.Security.Claims;
using VirtualMuseum.Domain.Dto.UserToken;
using VirtualMuseum.Domain.Result;

namespace VirtualMuseum.Domain.Interfaces.Services;

public interface ITokenServices
{
    string GenerateAccessToken(IEnumerable<Claim> claims);
    
    string GenerateRefreshToken();

    ClaimsPrincipal GetPrincipalFromExpiredToken(string accessToken);

    Task<BaseResult<TokenDto>> RefreshToken(TokenDto dto);
}