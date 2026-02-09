using ForjaDev.Domain.BackOffice.Abstract;
using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.ValuesObject;

namespace ForjaDev.Domain.BackOffice.Entities;

public class Member : Entity
{
    private Member()
    {
        
    }
    private Member(User user, string name, string slug,string bio)
    {
        Bio = bio;
        User = user;
        Name = name;
        Slug = slug;
        Id = Guid.NewGuid();
        CreateAt = DateTime.UtcNow;
    }

    #region Property
    
    public DateTime CreateAt { get; init; }
    public Guid UserId { get;init; }
    public User User { get; init; }
    public string Slug { get;private set; }
    public string Name { get;private set; }
    public string Bio { get;private set; }
    public Role Role { get;private set; }
    public List<Following> Followings { get; private set; } = new();
    public List<Post> Posts { get; private set; } = new();
    public List<Comment> Comments { get;private set; } = new();
    public List<Link> Links { get;private set; } = new();

    #endregion
    
    #region methods
    
    public void AddLink(Link link)
        => Links.Add(link);
    public void AddPost(Post post)
        => Posts.Add(post);
    public void AddComment(Comment comment)
        => Comments.Add(comment);
    
    public Result RemoveLink(string placeKink)
    {
        var link = Links.FirstOrDefault(x => x.PlaceOfOrigin == placeKink);
        if (link is null)
            return new Error("Link.NotFound", "Link not found!");
        Links.Remove(link);
        return Result.Success();
    }
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
    
    public Result AddFollowing(Following following)
    {
        if (following.MemberToFollow.Id == this.Id)
            return new Error("Following.SelfFollow", "You cannot follow yourself!");
        
        if (Followings.Contains(following))
            return new Error("Follower.Already","you already Follower this user ! ");
        
        Followings.Add(following);
        return Result.Success();
    }
    
    public Result RemoveFollowing(Following following)
    {
        if (!Followings.Contains(following))
            return new Error("Following.NoExists","Not Found!");
        
        Followings.Remove(following);
        return Result.Success();
    }
    #endregion
    
    public static class Factory
    {
        public static Result<Member> Create(User user, string name, string slug,string bio)
        {
            return Result<Member>.Success(new(user, name,slug,bio));
        }
    } 
}