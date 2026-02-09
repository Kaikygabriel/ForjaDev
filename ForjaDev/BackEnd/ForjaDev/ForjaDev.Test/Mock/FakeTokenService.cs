using System.Security.Claims;
using ForjaDev.Application.Services.Interfaces;
using ForjaDev.Domain.BackOffice.Entities;

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