using System.Security.Claims;
using ForjaDev.Domain.BackOffice.Entities;
using ForjaDev.Domain.BackOffice.Interfaces.Services;

namespace ForjaDev.Test.Mock;

public class FakeTokenService : ITokenService
{
    public string GenerateAccessToken(IEnumerable<Claim> claims)
    {
        return Guid.NewGuid().ToString("N");
    }

    public IEnumerable<Claim> GetClaimsByMember(Member member)
    {
        return new List<Claim>();
    }
}