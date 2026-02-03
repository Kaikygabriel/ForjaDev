using ForjaDev.Domain.BackOffice.Entities;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Followings;
using ForjaDev.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ForjaDev.Infra.Repositories.Followings;

public class FollowingRepository : RepositoryBase<Following>,IFollowingRepository
{
    public FollowingRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Member>> GetFollowersByMemberId(Guid id)
    {
        return await _context.Followings
            .Where(x => x.FollowingMemberId == id)
            .Include(x=>x.MemberToFollow)
            .Select(x=>x.MemberToFollow)
            .ToListAsync();
    }

    public async Task<IEnumerable<Member>> GetFollowingByMemberId(Guid id)
    {
        return await _context.Followings
            .Where(x => x.MemberToFollowId == id)
            .Include(x=>x.FollowingMember)
            .Select(x=>x.FollowingMember)
            .ToListAsync();
    }
}