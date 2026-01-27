using System.Linq.Expressions;
using ForjaDev.Domain.BackOffice.Entities.Abstraction;

namespace ForjaDev.Domain.BackOffice.Interfaces.Repositories;

public interface IRepositoryBase<T> where T : Entity
{
    Task<T?> GetByPredicateAsync(Expression<Func<T,bool>>predicate);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}