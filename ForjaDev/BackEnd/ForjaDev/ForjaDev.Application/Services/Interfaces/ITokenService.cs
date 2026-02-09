using System.Security.Claims;

namespace ForjaDev.Application.Services.Interfaces;

public interface ITokenService
{
    string GenerateAccessToken(IEnumerable<Claim>claims);
    IEnumerable<Claim> GetClaimsByMember(Domain.BackOffice.Entities.Member member);
}