using ForjaDev.Domain.BackOffice.Entities;

namespace ForjaDev.Test.Domain.BackOffice.Entity;

public class CommentTest
{
    [Fact]
    public void Should_Return_true_Parameters_In_Creation_Are_Valid()
    {
        var resultCreateComment = Comment.Factory.Create(Guid.NewGuid(), Guid.NewGuid(), "teste");
        Assert.True(resultCreateComment.IsSuccess);
    }
    
    [Fact]
    public void Should_Added_Other_Comment_In_Comment()
    {
        var comment = Comment.Factory.Create(Guid.NewGuid(), Guid.NewGuid(), "teste").Value;
        var commentOther = Comment.Factory.Create(Guid.NewGuid(), Guid.NewGuid(), "teste2").Value;
        
        comment.AddComment(commentOther);
        var existsOtherComment = comment.SubComments.Any();
        Assert.True(existsOtherComment);
    }
    
}