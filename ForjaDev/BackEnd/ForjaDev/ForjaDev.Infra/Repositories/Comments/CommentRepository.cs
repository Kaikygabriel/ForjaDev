using ForjaDev.Domain.BackOffice.Entities;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Comments;
using ForjaDev.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ForjaDev.Infra.Repositories.Comments;

public class CommentRepository : RepositoryBase<Comment>,ICommentRepository
{
    public CommentRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Comment>> GetAllByPostId(Guid postId)
    {
        return await _context.Comments.AsNoTrackingWithIdentityResolution()
            .Include(x => x.SubComments)
            .Where(x => x.PostId == postId)
            .ToListAsync();
    }
}