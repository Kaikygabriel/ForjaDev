using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Likes;
using ForjaDev.Domain.BackOffice.ValuesObject;
using ForjaDev.Infra.Data.Context;

namespace ForjaDev.Infra.Repositories.Likes;

public class LikeRepository : RepositoryBase<Like>, ILikeRepository
{
    public LikeRepository(AppDbContext context) : base(context)
    {
    }
}