using ForjaDev.Domain.BackOffice.Entities;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Followings;
using ForjaDev.Infra.Data.Context;

namespace ForjaDev.Infra.Repositories.Followings;

public class FollowingRepository : RepositoryBase<Following>,IFollowingRepository
{
    public FollowingRepository(AppDbContext context) : base(context)
    {
    }
}