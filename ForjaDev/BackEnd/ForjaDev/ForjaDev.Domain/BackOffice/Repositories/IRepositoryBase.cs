using System.Linq.Expressions;
using ForjaDev.Domain.BackOffice.Abstract;

namespace ForjaDev.Domain.BackOffice.Repositories;

public interface IRepositoryBase<T> where T : Entity
{
    Task<T?> GetBySpecificationAsync(ISpecification<T>specification);

    Task<T?> GetByPredicateAsync(Expression<Func<T,bool>>predicate);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}