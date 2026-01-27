using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Entities;
using ForjaDev.Domain.BackOffice.Entities.Abstraction;

namespace ForjaDev.Domain.BackOffice.ValuesObject;

public class Like : Entity
{
    private Like()
    {
        
    }
    private Like(Member member)
    {
        Member = member;
        MemberId = member.Id;
    }

    public Guid MemberId  { get; init; }
    public Member Member{ get; init; }

    public static class Factory
    {
        public static Result<Like> Create(Member member)
            => Result<Like>.Success(new Like(member));
    }
}


//OwnsMany