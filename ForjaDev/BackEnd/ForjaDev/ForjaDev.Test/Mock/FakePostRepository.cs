using System.Linq.Expressions;
using ForjaDev.Domain.BackOffice.Abstract;
using ForjaDev.Domain.BackOffice.Entities;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Posts;

namespace ForjaDev.Test.Mock;

public sealed class FakePostRepository : IPostRepository
{

    public FakePostRepository(IEnumerable<Post>? seed = null)
    {
        _posts = Seed();
    }
    
    private List<Post> _posts;

    public List<Post> Seed()
    {
        var memberA = Guid.NewGuid();
        var memberB = Guid.NewGuid();

        var categoryA = Guid.NewGuid();
        var categoryB = Guid.NewGuid();

        var p1 = Post.Factory.Create(
            title: "Introdução ao .NET",
            body: "Conteúdo sobre .NET",
            memberId: memberA,
            tag: "dotnet",
            categoryId: categoryA
        ).Value;

        var p2 = Post.Factory.Create(
            title: "Clean Architecture",
            body: "Separando camadas certinho",
            memberId: memberA,
            tag: "clean",
            categoryId: categoryB
        ).Value;

        var p3 = Post.Factory.Create(
            title: "LINQ na prática",
            body: "Where, Select, FirstOrDefault e armadilhas",
            memberId: memberB,
            tag: "linq",
            categoryId: categoryA
        ).Value;

        return new List<Post> { p1, p2, p3 };
    }

    public Task<Post?> GetBySpecificationAsync(ISpecification<Post> specification)
    {
        return Task.FromResult(_posts.FirstOrDefault(x=>specification.IsSatisfiedBy(x)));
    }

    public Task<Post?> GetByPredicateAsync(Expression<Func<Post, bool>> predicate)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));

        var compiled = predicate.Compile();
        return Task.FromResult(_posts.FirstOrDefault(compiled));
    }

    public void Create(Post entity)
    {
        _posts.Add(entity);
    }

    public void Update(Post entity)
    {
        _posts.RemoveAll(x => x.Id == entity.Id);
        _posts.Add(entity);
    }

    public void Delete(Post entity)
    {
        _posts.RemoveAll(p => p.Id == entity.Id);
    }

    public Task<Post> GetByIdWithLike(Guid Id)
        => GetRequiredById(Id);

    public Task<Post> GetByIdWithCommentAsync(Guid id)
        => GetRequiredById(id);

    public Task<Post> GetByIdWithMemberAsync(Guid id)
        => GetRequiredById(id);

    public Task<IEnumerable<Post>> GetAllByMemberIdAsync(Guid memberId)
    {
        var result = _posts
            .Where(p => p.MemberId == memberId)
            .OrderByDescending(p => p.CreateAt)
            .AsEnumerable();

        return Task.FromResult(result);
    }

    public Task<IEnumerable<Post>> GetAllByTitleCategoryAsync(string categoryTitle, int skip, int take)
    {
        var query = _posts.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(categoryTitle))
        {
            query = query.Where(p =>
                p.Category is not null &&
                string.Equals(p.Category.Title, categoryTitle, StringComparison.OrdinalIgnoreCase));
        }

        var result = query
            .OrderByDescending(p => p.CreateAt)
            .Skip(Math.Max(0, skip))
            .Take(take <= 0 ? int.MaxValue : take);

        return Task.FromResult(result);
    }

    public Task<IEnumerable<Post>> GetAllByLikesAsync(int skip, int take)
    {
        var result = _posts
            .OrderByDescending(p => p.LikeCount)
            .ThenByDescending(p => p.CreateAt)
            .Skip(Math.Max(0, skip))
            .Take(take <= 0 ? int.MaxValue : take)
            .AsEnumerable();

        return Task.FromResult(result);
    }

    private Task<Post> GetRequiredById(Guid id)
    {
        var post = _posts.FirstOrDefault(p => p.Id == id);

        return Task.FromResult(post);
    }
}
