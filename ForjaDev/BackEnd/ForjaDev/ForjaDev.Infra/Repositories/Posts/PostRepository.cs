using ForjaDev.Domain.BackOffice.Entities;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Posts;
using ForjaDev.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ForjaDev.Infra.Repositories.Posts;

public class PostRepository : RepositoryBase<Post>,IPostRepository
{
    public PostRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Post>> GetAllByMemberIdAsync(Guid memberId)
    {
        return await _context.Posts.AsNoTracking()
            .Where(x => x.MemberId == memberId)
            .OrderByDescending(x => x.CreateAt)
            .ToListAsync();
    }

    public async Task<Post?> GetByIdWithCommentAsync(Guid id)
    {
        return await _context.Posts.AsNoTrackingWithIdentityResolution()
            .Include(x => x.Comments)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Post?> GetByIdWithMemberAsync(Guid id)
    {
        return await _context.Posts.AsNoTracking()
            .Include(x => x.Member)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Post>> GetAllByTitleCategoryAsync(string categoryTitle, int skip, int take)
    {
        return await _context.Posts.AsNoTrackingWithIdentityResolution()
            .Where(x => (x.Category.Title) == categoryTitle)
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }

    public async Task<IEnumerable<Post>> GetAllByLikesAsync(int skip, int take)
    {
        return await _context.Posts.AsNoTrackingWithIdentityResolution()
            .Skip(skip)
            .Take(take)
            .OrderByDescending(x=>x.Likes.Count)
            .ToListAsync();
    }
}