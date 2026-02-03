using ForjaDev.Domain.BackOffice.Entities;

namespace ForjaDev.Domain.BackOffice.Interfaces.Repositories.Followings;

public interface IFollowingRepository : IRepositoryBase<Following>
{
    Task<IEnumerable<Member>> GetFollowersByMemberId(Guid id);
    Task<IEnumerable<Member>> GetFollowingByMemberId(Guid id);
}