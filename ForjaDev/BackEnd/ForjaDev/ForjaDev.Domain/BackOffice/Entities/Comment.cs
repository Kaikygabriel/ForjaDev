using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Entities.Abstraction;

namespace ForjaDev.Domain.BackOffice.Entities;

public class Comment : Entity
{
    private Comment()
    {
        
    }
    private Comment(Guid memberId, Guid postId, string message)
    {
        MemberId = memberId;
        PostId = postId;
        Message = message;
        CreateAt = DateTime.UtcNow;
    }

    public Guid MemberId { get; init; }
    public Member Member { get; init; }
    
    public Guid PostId { get; init; }
    public Post Post { get; init; }

    public string Message { get;private set; }
    public DateTime CreateAt { get; init; }


    public List<Comment> SubComments { get; private set; } = new();
    
    public Guid? ParentCommentId { get;private set; }
    public Comment? ParentComment { get;private set; }

    public void AddComment(Comment comment)
        => SubComments.Add(comment);

    public void AddParentComment(Guid parentCommentId)
        => ParentCommentId = parentCommentId;
    
    public static class Factory 
    {
        public static Result<Comment> Create(Guid memberId, Guid postId, string message)
            => Result<Comment>.Success(new(memberId, postId, message));
    }
}