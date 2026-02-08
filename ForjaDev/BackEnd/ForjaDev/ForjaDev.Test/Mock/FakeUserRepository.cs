using System.Linq.Expressions;
using ForjaDev.Domain.BackOffice.Entities;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Users;
using ForjaDev.Domain.BackOffice.ValuesObject;

namespace ForjaDev.Test.Mock;

public class FakeUserRepository : IUserRepository
{
    private readonly List<User> _data = new();

    public FakeUserRepository()
    {
        Seed();
    }

    private void Seed()
    {
        var user1 = User.Factory.Create(
            Email.Factory.Create("joao@forjadev.com").Value,
            Password.Factory.Create("123456").Value
        ).Value;

        var user2 = User.Factory.Create(
            Email.Factory.Create("maria@forjadev.com").Value,
            Password.Factory.Create("123456").Value
        ).Value;

        var user3 = User.Factory.Create(
            Email.Factory.Create("admin@forjadev.com").Value,
            Password.Factory.Create("123456").Value
        ).Value;

        _data.AddRange(new[] { user1, user2, user3 });
    }
    public Task<User?> GetByPredicateAsync(Expression<Func<User, bool>> predicate)
    {
        return Task.FromResult(_data.AsQueryable().FirstOrDefault(predicate));
    }

    public void Create(User entity)
    {
        _data.Add(entity);
    }

    public void Update(User entity)
    {
        _data.RemoveAll(x => x.Id == entity.Id);
        _data.Add(entity);
    }

    public void Delete(User entity)
    {
        _data.Remove(entity);
    }
}