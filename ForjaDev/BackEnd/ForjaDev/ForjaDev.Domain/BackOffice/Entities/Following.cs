using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Entities.Abstraction;

namespace ForjaDev.Domain.BackOffice.Entities;

public class Following : Entity
{
    private Following()
    {
        
    }
    private Following(Member memberToFollow, Member followingMember)
    {
        MemberToFollow = memberToFollow;
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