using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Entities;
using ForjaDev.Domain.BackOffice.Entities.Abstraction;

namespace ForjaDev.Domain.BackOffice.ValuesObject;

public class Like : Entity
{
    private Like()
    {
        
    }
    private Like(Member member,Post post)
    {
        Post = post;
        PostId = post.Id;
        Member = member;
        MemberId = member.Id;
    }

    public Guid PostId { get; init; }
    public Post Post { get; init; }
    public Guid MemberId  { get; init; }
    public Member Member{ get; init; }

    public static class Factory
    {
        public static Result<Like> Create(Member member,Post post)
            => Result<Like>.Success(new Like(member,post));
    }
}


//OwnsMany