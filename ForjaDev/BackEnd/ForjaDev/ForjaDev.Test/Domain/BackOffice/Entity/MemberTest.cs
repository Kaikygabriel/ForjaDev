using ForjaDev.Domain.BackOffice.Entities;
using ForjaDev.Domain.BackOffice.ValuesObject;

namespace ForjaDev.Test.Domain.BackOffice.Entity;

public class MemberTest
{
    private static readonly User User_Valid = User.Factory.Create
        (Email.Factory.Create("teste@gmail.com").Value, Password.Factory.Create("teste@").Value).Value;

    private const string Name_Valid = "teste";
    private const string Slug_Valid = "teste";
    private const string Bio_Valid = "teste";
    
     private readonly Member Member_Valid = Member.Factory.Create(User_Valid, Name_Valid, Slug_Valid, Bio_Valid).Value;
    
    [Fact]
    public void Should_Return_True_If_Parameters_In_Creation_Are_Valid()
    {
        var resultCreateMember = Member.Factory.Create(User_Valid, Name_Valid, Slug_Valid, Bio_Valid);
        Assert.True(resultCreateMember.IsSuccess);
    }

    [Fact]
    public void Should_added_Post_In_Member()
    {
        var post = Post.Factory.Create("teste", "teste", Member_Valid.Id, "teste").Value;
        Member_Valid.AddPost(post);
        var postExists = Member_Valid.Posts.Contains(post);
        Assert.True(postExists);
    }
    
    
    [Fact]
    public void Should_Remove_Post_In_Member()
    {
        var post = Post.Factory.Create("teste2", "teste2", Member_Valid.Id, "teste2").Value;
        Member_Valid.AddPost(post);
        Member_Valid.RemovePost(post);
        var postExists = Member_Valid.Posts.Contains(post);
        Assert.False(postExists);
    }
    
    [Fact]
    public void Should_added_Comment_In_Member()
    {
        var comment = Comment.Factory.Create(Guid.NewGuid(), Guid.NewGuid(), "rteste").Value;
        Member_Valid.AddComment(comment);
        var commentExistInMember = Member_Valid.Comments.Contains(comment);
        Assert.True(commentExistInMember);
    }
    
    
    [Fact]
    public void Should_Remove_Comment_In_Member()
    {
        var comment = Comment.Factory.Create(Guid.NewGuid(), Guid.NewGuid(), "teste").Value;
        Member_Valid.AddComment(comment);
        Member_Valid.RemoveComment(comment);
        var commentExistInMember = Member_Valid.Comments.Contains(comment);
        Assert.False(commentExistInMember);
    }
}