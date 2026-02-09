using ForjaDev.Domain.BackOffice.Entities;
using ForjaDev.Domain.BackOffice.Repositories;

namespace ForjaDev.Domain.BackOffice.Interfaces.Repositories.Posts;

public interface IPostRepository : IRepositoryBase<Post>
{
    Task<Post> GetByIdWithLike(Guid Id);
    Task<Post> GetByIdWithCommentAsync(Guid id);
    Task<Post> GetByIdWithMemberAsync(Guid id);

    Task<IEnumerable<Post>> GetAllByMemberIdAsync(Guid memberId);
    Task<IEnumerable<Post>> GetAllByTitleCategoryAsync(string categoryTitle, int skip, int take);
    Task<IEnumerable<Post>> GetAllByLikesAsync(int skip, int take);
}