using System.Linq.Expressions;
using ForjaDev.Domain.BackOffice.Abstract;
using ForjaDev.Domain.BackOffice.Entities;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Comments;

namespace ForjaDev.Test.Mock;

public class FakeCommentRepository : ICommentRepository
{
    private readonly List<Comment> _storage;

    public FakeCommentRepository(IEnumerable<Comment>? seed = null)
    {
        _storage = Create();
    }

    public Task<Comment?> GetBySpecificationAsync(ISpecification<Comment> specification)
    {
        return Task.FromResult(_storage.FirstOrDefault());
    }

    public Task<Comment?> GetByPredicateAsync(Expression<Func<Comment, bool>> predicate)
    {
        var result = _storage.AsQueryable().FirstOrDefault(predicate);
        return Task.FromResult(result);
    }

    public void Create(Comment entity)
    {
        _storage.Add(entity);
    }

    public void Update(Comment entity)
    {
        _storage.RemoveAll(x=>x.Id == entity.Id);
        _storage.Add(entity);
    }

    public void Delete(Comment entity)
    {
        _storage.RemoveAll(x => x.Id == entity.Id);
    }

    public Task<IEnumerable<Comment>> GetAllByPostId(Guid postId)
    {
        var result = _storage.Where(c => c.PostId == postId).ToList();
        return Task.FromResult<IEnumerable<Comment>>(result);
    }
    public static List<Comment> Create()
    {
        var postId = Guid.NewGuid();

        var member1 = Guid.NewGuid();
        var member2 = Guid.NewGuid();
        var member3 = Guid.NewGuid();

        // Comentário principal 1
        var comment1 = Comment.Factory
            .Create(member1, postId, "Primeiro comentário do post")
            .Value;

        // Resposta ao comentário 1
        var subComment1 = Comment.Factory
            .Create(member2, postId, "Resposta ao primeiro comentário")
            .Value;

        subComment1.AddParentComment(comment1.Id);
        comment1.AddComment(subComment1);

        // Outra resposta ao comentário 1
        var subComment2 = Comment.Factory
            .Create(member3, postId, "Outra resposta ao primeiro comentário")
            .Value;

        subComment2.AddParentComment(comment1.Id);
        comment1.AddComment(subComment2);

        // Comentário principal 2
        var comment2 = Comment.Factory
            .Create(member2, postId, "Segundo comentário do post")
            .Value;

        // Resposta ao comentário 2
        var subComment3 = Comment.Factory
            .Create(member1, postId, "Resposta ao segundo comentário")
            .Value;

        subComment3.AddParentComment(comment2.Id);
        comment2.AddComment(subComment3);

        return new List<Comment>
        {
            comment1,
            subComment1,
            subComment2,
            comment2,
            subComment3
        };
    }
}
