using ForjaDev.Domain.BackOffice.Entities.Abstraction;
using ForjaDev.Domain.BackOffice.ValuesObject;

namespace ForjaDev.Domain.BackOffice.Entities;

public class Post : Entity
{
    public string Title { get;private set; }
    public string Body { get;private set; }
    public string Slug { get;private set; }

    public Guid MemberId { get; init; }
    public Member Member { get; init; }

    public IEnumerable<Like>Likes { get;private set; }= Enumerable.Empty<Like>();
    public IEnumerable<Comment> Comments { get; private set; } = Enumerable.Empty<Comment>();
    
    
}