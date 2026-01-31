using ForjaDev.Domain.BackOffice.Interfaces.Repositories;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Categories;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Comments;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Followings;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Members;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Posts;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Users;
using ForjaDev.Infra.Data.Context;
using ForjaDev.Infra.Repositories.Categories;
using ForjaDev.Infra.Repositories.Comments;
using ForjaDev.Infra.Repositories.Followings;
using ForjaDev.Infra.Repositories.Members;
using ForjaDev.Infra.Repositories.Posts;
using ForjaDev.Infra.Repositories.Users;

namespace ForjaDev.Infra.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private UserRepository _userRepository;
    private CommentRepository _commentRepository;
    private PostRepository _postRepository;
    private MemberRepository _memberRepository;
    private CategoryRepository _category ;
    private FollowingRepository _followingRepository;
    
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public ICommentRepository CommentRepository
    {
        get
        {
            return _commentRepository = _commentRepository ?? new(_context);
        }
    }

    public IMemberRepository MemberRepository
    {
        get
        {
            return _memberRepository = _memberRepository ?? new(_context);
        }
    }

    public IPostRepository PostRepository
    {
        get
        {
            return _postRepository = _postRepository ?? new(_context);
        }
    }

    public IUserRepository UserRepository
    {
        get
        {
            return _userRepository = _userRepository ?? new(_context);
        }
    }

    public ICategoryRepository CategoryRepository
    {
        get
        {
            return _category = _category ?? new(_context);
        }
    }

    public IFollowingRepository FollowingRepository
    {
        get
        {
            return _followingRepository = _followingRepository ?? new(_context);
        }
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void RollBack()
    {
        
    }
}