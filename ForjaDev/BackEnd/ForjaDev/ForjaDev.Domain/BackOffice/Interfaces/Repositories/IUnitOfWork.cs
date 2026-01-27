using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Categories;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Comments;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Members;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Posts;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Users;

namespace ForjaDev.Domain.BackOffice.Interfaces.Repositories;

public interface IUnitOfWork
{
    public ICommentRepository CommentRepository { get; }
    public IMemberRepository MemberRepository { get; }
    public IPostRepository PostRepository { get; }
    public IUserRepository UserRepository { get; }
    public ICategoryRepository CategoryRepository { get; }

    Task CommitAsync();

    void RollBack();
}