using System.Linq.Expressions;

namespace ForjaDev.Domain.BackOffice.Specification.Post;

public class PostByIdSpecification(Guid Id) : Specification<Entities.Post>
{
    public override Expression<Func<Entities.Post, bool>> ToExpression()
        => x => x.Id == Id;
}