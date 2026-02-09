using ForjaDev.Domain.BackOffice.Abstract;
using ForjaDev.Domain.BackOffice.Commum;

namespace ForjaDev.Domain.BackOffice.Entities;

public class Following : Entity
{
    private Following()
    {
        
    }
    private Following(Member memberToFollow, Member followingMember)
    {
        MemberToFollowId = memberToFollow.Id;
        MemberToFollow = memberToFollow;

        FollowingMemberId = followingMember.Id;
        FollowingMember = followingMember;
    }

    public Guid MemberToFollowId { get; init; }
    public Member MemberToFollow { get; init; }

    public Guid FollowingMemberId { get; init; }
    public Member FollowingMember { get; init; }
    
    public static class Factory
    {
        public static Result<Following> Create(Member member, Member followingMember)
            => Result<Following>.Success(new(member, followingMember));
    }
}