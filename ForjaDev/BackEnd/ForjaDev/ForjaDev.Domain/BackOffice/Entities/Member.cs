using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Commum.Abstract;
using ForjaDev.Domain.BackOffice.Entities.Abstraction;
using ForjaDev.Domain.BackOffice.ValuesObject;

namespace ForjaDev.Domain.BackOffice.Entities;

public class Member : Entity
{
    private Member()
    {
        
    }
    private Member(User user, string name, string slug)
    {
        User = user;
        Name = name;
        Slug = slug;
        Id = Guid.NewGuid();
        CreateAt = DateTime.UtcNow;
    }
    public DateTime CreateAt { get; init; }
    public Guid UserId { get;init; }
    public User User { get; init; }
    public List<Post> Posts { get; private set; } = new();
    public string Slug { get;private set; }
    public string Name { get;private set; }
    public List<Comment> Comments { get;private set; } = new();
    public Role Role { get;private set; }
    public void AddPost(Post post)
        => Posts.Add(post);
    public void AddComment(Comment comment)
        => Comments.Add(comment);
    
    public Result RemovePost(Post post)
    {
        if (!Posts.Contains(post))
            return new Error("Post.NotFound", "Post not found!");
        Posts.Remove(post);
        return Result.Success();
    }
    public Result RemoveComment(Comment comment)
    {
        if (!Comments.Contains(comment))
            return new Error("Comment.NotFound", "Comment not found!");
        Comments.Remove(comment);
        return Result.Success();
    }

    public static class Factory
    {
        public static Result<Member> Create(User user, string name, string slug)
        {
            return Result<Member>.Success(new(user, name,slug));
        }
    } 
}