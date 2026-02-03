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

    public async Task<MemberDashBoardPublic?> GetDashBoardPublicBySlug(string memberSlug)
    {
        var idMember = await _context.Members.Where(x=>x.Slug == memberSlug).Select(x => x.Id).FirstOrDefaultAsync();
        var countMemberToFollows = await _context.Followings.Where(x => x.MemberToFollowId == idMember).CountAsync();
        var countMemberToFollowings = await _context.Followings.Where(x => x.FollowingMemberId == idMember).CountAsync();
        
        return await _context.Members
            .AsNoTracking()
            .Where(m => m.Slug == memberSlug)
            .Select(m => new MemberDashBoardPublic(
                m.CreateAt,
                m.Posts, 
                m.Name,
                m.User.Email.Address,
                m.Bio,
                countMemberToFollows, 
                countMemberToFollowings          
            ))
            .FirstOrDefaultAsync();
    }

    public async Task<MemberDashBoardPrivate?> GetDashBoardPrivateById(Guid memberId)
    {
        var countMemberToFollows = await _context.Followings.Where(x => x.MemberToFollowId == memberId).CountAsync();
        var countMemberToFollowings = await _context.Followings.Where(x => x.FollowingMemberId == memberId).CountAsync();

        return await _context.Members
            .AsNoTracking()
            .Where(m => m.Id == memberId)
            .Select(m => new MemberDashBoardPrivate(
                m.Id,
                m.CreateAt,
                m.Posts, 
                m.Name,
                m.User.Email.Address,
                m.Bio,
                m.Slug,
                countMemberToFollows, 
                countMemberToFollowings
                ))
            .FirstOrDefaultAsync();
    }
}