
using System.Linq.Expressions;
using ForjaDev.Domain.BackOffice.Entities.Abstraction;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories;
using ForjaDev.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ForjaDev.Infra.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
{
    protected readonly AppDbContext _context;

    public RepositoryBase(AppDbContext context)
    {
        _context = context;
    }

    public async Task<T?> GetByPredicateAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(predicate);
    }

    public void Create(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
}