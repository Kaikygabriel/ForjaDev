using ForjaDev.Domain.BackOffice.Entities;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Members;
using ForjaDev.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ForjaDev.Infra.Repositories.Members;

public class MemberRepository : RepositoryBase<Member>,IMemberRepository
{
    public MemberRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Member?> GetByEmail(string addressEmail)
    {
        return await _context.Members.Include(x => x.User)
            .FirstOrDefaultAsync(x => x.User.Email.Address == addressEmail);
    }
}