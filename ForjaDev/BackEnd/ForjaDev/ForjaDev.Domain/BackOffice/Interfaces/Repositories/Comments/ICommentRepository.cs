using ForjaDev.Domain.BackOffice.Entities;

namespace ForjaDev.Domain.BackOffice.Interfaces.Repositories.Comments;

public interface ICommentRepository :IRepositoryBase<Comment>
{
    Task<IEnumerable<Comment>> GetAllByPostId(Guid postId);
}