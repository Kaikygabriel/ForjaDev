using ForjaDev.Domain.BackOffice.Entities;
using ForjaDev.Domain.BackOffice.Repositories;

namespace ForjaDev.Domain.BackOffice.Interfaces.Repositories.Categories;

public interface ICategoryRepository : IRepositoryBase<Category>
{
    Task<IEnumerable<Category>> GetAllAsync();
}