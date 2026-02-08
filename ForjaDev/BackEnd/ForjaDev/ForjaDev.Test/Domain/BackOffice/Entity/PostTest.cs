using ForjaDev.Domain.BackOffice.Entities;
using ForjaDev.Domain.BackOffice.ValuesObject;

namespace ForjaDev.Test.Domain.BackOffice.Entity;

public class PostTest
{
    
    private static readonly User User_Valid = User.Factory.Create
        (Email.Factory.Create("teste@gmail.com").Value, Password.Factory.Create("teste@").Value).Value;

    private const string Name_Valid = "teste";
    private const string Slug_Valid = "teste";
    private const string Bio_Valid = "teste";
    
    private readonly Member Member_Valid = Member.Factory.Create(User_Valid, Name_Valid, Slug_Valid, Bio_Valid).Value;

    [Fact]
    public void Should_Return_True_If_Parameters_Is_Valid()
    {
        var resultCreatePost = Post.Factory.Create("teste","teste",Guid.NewGuid(),"teste",Guid.NewGuid());
        Assert.True(resultCreatePost.IsSuccess);
     }
    
    [Fact]
    public void Should_Return_False_If_Parameters_Is_Invalid()
    {
        var resultCreatePost = Post.Factory.Create(string.Empty,string.Empty,Guid.NewGuid(),string.Empty,Guid.NewGuid());
        Assert.False(resultCreatePost.IsSuccess);
    }
    [Fact]
    public void Should_Added_Comment_In_Post()
    {
        var  post = Post.Factory.Create("teste","teste",Guid.NewGuid(),"teste",Guid.NewGuid()).Value;
        var comment = Comment.Factory.Create(Guid.NewGuid(), Guid.NewGuid(), "rteste").Value;
        post.AddComment(comment);
        var commentExist = post.Comments.Contains(comment);
        Assert.True(commentExist);
    }
    [Fact]
    public void Should_Remove_Comment_In_Post()
    {
        var  post = Post.Factory.Create("teste","teste",Guid.NewGuid(),"teste",Guid.NewGuid()).Value;
        var comment = Comment.Factory.Create(Guid.NewGuid(), Guid.NewGuid(), "rteste").Value;
        post.AddComment(comment);
        post.RemoveComment(comment);
        var commentExist = post.Comments.Contains(comment);
        Assert.False(commentExist);
    }
    [Fact]
    public void Should_Added_Like_In_Post()
    {
        var post = Post.Factory.Create("teste","teste",Guid.NewGuid(),"teste",Guid.NewGuid()).Value;
        var like = Like.Factory.Create(Member_Valid, post).Value;
        post.AddLike(like);
        var likeExist = post.Likes.Contains(like);
        Assert.True(likeExist);
    }
    [Fact]
    public void Should_Remove_Like_In_Post()
    {
        var post = Post.Factory.Create("teste","teste",Guid.NewGuid(),"teste",Guid.NewGuid()).Value;
        var like = Like.Factory.Create(Member_Valid, post).Value;
        post.AddLike(like);
        post.RemoveLike(Member_Valid.Id);
        var likeExist = post.Likes.Contains(like);
        Assert.False(likeExist);
    }
}