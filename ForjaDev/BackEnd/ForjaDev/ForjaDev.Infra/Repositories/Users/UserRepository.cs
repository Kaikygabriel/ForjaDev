using ForjaDev.Domain.BackOffice.Entities;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Users;
using ForjaDev.Infra.Data.Context;

namespace ForjaDev.Infra.Repositories.Users;

public class UserRepository : RepositoryBase<User>,IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
}