using System.Linq.Expressions;
using ForjaDev.Domain.BackOffice.Entities;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Members;
using ForjaDev.Domain.BackOffice.ValuesObject;

namespace ForjaDev.Test.Mock;

public class FakeMemberRepository : IMemberRepository
{
    private readonly List<Member> _data = new();

    public FakeMemberRepository()
    {
        Seed();
    }

    private void Seed()
    {
        // ===== USERS (ajuste conforme seu domínio real) =====
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

        // ===== MEMBERS =====
        var member1 = Member.Factory.Create(
            user1,
            "João Silva",
            "joao-silva",
            "Backend Developer"
        ).Value;

        var member2 = Member.Factory.Create(
            user2,
            "Maria Souza",
            "maria-souza",
            "Frontend Developer"
        ).Value;

        var member3 = Member.Factory.Create(
            user3,
            "Admin",
            "admin",
            "Administrador do sistema"
        ).Value;

        _data.AddRange(new[] { member1, member2, member3 });
    }

    public Task<Member?> GetByPredicateAsync(Expression<Func<Member, bool>> predicate)
    {
        return Task.FromResult(_data.AsQueryable().FirstOrDefault(predicate));
    }

    public void Create(Member entity)
    {
        _data.Add(entity);
    }

    public void Update(Member entity)
    {
        _data.RemoveAll(x=>x.Id ==entity.Id);
        _data.Add(entity);
    }

    public void Delete(Member entity)
    {
        _data.Remove(entity);
    }

    public Task<Member?> GetByEmail(string addressEmail)
    {
        return Task.FromResult(
                _data.FirstOrDefault(x =>
                    x.User.Email.Address.Equals(addressEmail)
                )
            );
    }
}
