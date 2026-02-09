using ForjaDev.Domain.BackOffice.Entities;
using ForjaDev.Domain.BackOffice.Repositories;

namespace ForjaDev.Domain.BackOffice.Interfaces.Repositories.Members;

public interface IMemberRepository : IRepositoryBase<Member>
{
    Task<Member?> GetByEmail(string addressEmail);
}