using ForjaDev.Domain.BackOffice.Abstract;
using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.ValuesObject;

namespace ForjaDev.Domain.BackOffice.Entities;

public class Post : Entity
{
    private Post(string tag)
    {
        Tag = tag;
    }
    private Post(string title, string body, Guid memberId, string tag, Guid categoryId = default)
    {
        Title = title;
        Body = body;
        MemberId = memberId;
        Tag = tag;
        CategoryId = categoryId;
        CreateAt = DateTime.UtcNow;
    }

    public string Tag { get;private set; }
    public string Title { get;private set; }
    public string Body { get;private set; }
    public DateTime CreateAt { get; init; }
    
    public Guid? CategoryId { get;private set; }
    public Category? Category { get;private set; }
    
    public Guid MemberId { get; init; }
    public Member Member { get; init; }

    public int LikeCount { get;private set; }
    public List<Like>Likes { get;private set; }= new();
    public List<Comment> Comments { get; private set; } = new();
    
    public Result AddLike(Like like)
    {
        if (Likes.Exists(x => x.MemberId == like.MemberId))
            return new Error("Like.Already", "Like already this in post");

        Likes.Add(like);
        LikeCount+=1;
        return Result.Success();
    }
    public Result<Like> RemoveLike(Guid memberid)
    {
        var like = Likes.FirstOrDefault(x => x.MemberId == memberid);
        if (like is null )
            return new Error("Like.NotFound", "Like not found!");
        Likes.Remove(like);
        LikeCount--;
        return Result<Like>.Success(like);
    }

    public void AddComment(Comment comment)
        => Comments.Add(comment);
    
    public Result RemoveComment(Comment comment)
    {
        if (!Comments.Contains(comment))
            return new Error("Comment.NotFound", "Comment not found!");
        Comments.Remove(comment);
        return Result.Success();
    }
    
    public static class Factory
    {
        public static Result<Post> Create(string title, string body, Guid memberId,string tag, Guid categoryId= default)
        {
            if(!ParametersIsValid(title, body, memberId, tag))
                return new Error("Parameters.Invalid","Parameters invalids !");
            return Result<Post>.Success(new(title, body, memberId,tag,categoryId));
        }
    }

    private static bool ParametersIsValid(string title, string body, Guid memberId, string tag)
    {
        if (string.IsNullOrEmpty(title) || title.Length <= 1)
            return false;
        if (string.IsNullOrEmpty(body) || body.Length <= 1)
            return false;
        if (string.IsNullOrEmpty(tag) || tag.Length <= 1)
            return false;
        if (string.IsNullOrWhiteSpace(memberId.ToString()))
            return false;
        return true;
    }
}