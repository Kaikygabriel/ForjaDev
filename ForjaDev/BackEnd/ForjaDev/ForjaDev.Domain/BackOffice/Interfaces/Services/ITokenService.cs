using System.Security.Claims;
using ForjaDev.Domain.BackOffice.Entities;

namespace ForjaDev.Domain.BackOffice.Interfaces.Services;

public interface ITokenService
{
    string GenerateAccessToken(IEnumerable<Claim>claims);
    IEnumerable<Claim> GetClaimsByMember(Member member);
}