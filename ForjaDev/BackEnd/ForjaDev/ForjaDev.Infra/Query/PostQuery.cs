using ForjaDev.Application.Query.Interfaces;
using ForjaDev.Domain.BackOffice.Entities;
using ForjaDev.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ForjaDev.Infra.Query;

internal sealed class PostQuery : IPostQuery
{
    private readonly AppDbContext _appDbContext;

    public PostQuery(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IEnumerable<Post>> GetByTitle(string title)
    {
        return await _appDbContext.Posts
            .AsNoTrackingWithIdentityResolution()
            .Where(x => x.Title.Contains(title))
            .ToListAsync();
    }
}