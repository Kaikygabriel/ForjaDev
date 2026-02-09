using ForjaDev.Domain.BackOffice.Interfaces.Repositories;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Categories;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Comments;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Followings;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Members;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Posts;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Users;
using ForjaDev.Domain.BackOffice.Repositories;

namespace ForjaDev.Test.Mock;

public class FakeUnitOfWork : IUnitOfWork
{
    public ICommentRepository CommentRepository { get; }
    public IMemberRepository MemberRepository { get;} = new FakeMemberRepository();
    public IPostRepository PostRepository { get; } = new FakePostRepository();
    public IUserRepository UserRepository { get; } = new FakeUserRepository();
    public ICategoryRepository CategoryRepository { get; }
    public IFollowingRepository FollowingRepository { get; }
    public async Task CommitAsync()
    {
        await Task.Delay(0);
    }

    public void RollBack()
    {
        
    }
}