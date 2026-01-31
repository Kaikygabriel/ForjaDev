using ForjaDev.Application.Dtos.StoreFront.Member;
using ForjaDev.Application.Query.Interfaces;
using ForjaDev.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ForjaDev.Infra.Query;

internal class MemberQuery : IMemberQuery
{
    private readonly AppDbContext _context;

    public MemberQuery(AppDbContext context)
    {
        _context = context;
    }

    public async Task<MemberDashBoardPublic?> GetDashBoardPublicBySlug(string slugMember)
    {
        return await _context.Members
            .AsNoTracking()
            .Where(m => m.Slug == slugMember)
            .Select(m => new MemberDashBoardPublic(
                m.CreateAt,
                m.Posts, 
                m.Name,
                m.Followings.Count(f => f.MemberToFollowId == m.Id), 
                m.Followings.Count()          
            ))
            .FirstOrDefaultAsync();
    }
}