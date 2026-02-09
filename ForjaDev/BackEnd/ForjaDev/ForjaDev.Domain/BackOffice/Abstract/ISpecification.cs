using System.Linq.Expressions;

namespace ForjaDev.Domain.BackOffice.Abstract;

public interface ISpecification<T> where T : Entity
{
    Expression<Func<T, bool>> ToExpression();
    bool IsSatisfiedBy(T entity);
}