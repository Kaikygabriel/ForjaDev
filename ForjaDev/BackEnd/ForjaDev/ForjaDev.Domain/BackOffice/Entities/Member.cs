using ForjaDev.Domain.BackOffice.Entities.Abstraction;

namespace ForjaDev.Domain.BackOffice.Entities;

public class Member : Entity
{
    public User User { get; init; }
    public IEnumerable<Post> Posts { get; private set; } = Enumerable.Empty<Post>();
    public string Name { get;private set; }
    public string Slug { get;private set; }
    public IEnumerable<Comment> Comments { get;private set; } = Enumerable.Empty<Comment>();
}