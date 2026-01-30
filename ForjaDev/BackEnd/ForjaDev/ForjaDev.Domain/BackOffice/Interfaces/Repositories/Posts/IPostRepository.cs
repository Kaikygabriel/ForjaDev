using ForjaDev.Domain.BackOffice.Entities;

namespace ForjaDev.Domain.BackOffice.Interfaces.Repositories.Posts;

public interface IPostRepository : IRepositoryBase<Post>
{
    Task<IEnumerable<Post>> GetAllByMemberIdAsync(Guid memberId);
    Task<Post> GetByIdWithCommentAsync(Guid id);
    Task<Post> GetByIdWithMemberAsync(Guid id);

    Task<IEnumerable<Post>> GetAllByTitleCategoryAsync(string categoryTitle, int skip, int take);
    Task<IEnumerable<Post>> GetAllByLikesAsync(int skip, int take);
}