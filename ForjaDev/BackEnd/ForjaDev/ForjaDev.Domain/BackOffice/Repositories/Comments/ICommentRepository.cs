using ForjaDev.Domain.BackOffice.Entities;
using ForjaDev.Domain.BackOffice.Repositories;

namespace ForjaDev.Domain.BackOffice.Interfaces.Repositories.Comments;

public interface ICommentRepository :IRepositoryBase<Comment>
{
    Task<IEnumerable<Comment>> GetAllByPostId(Guid postId);
}