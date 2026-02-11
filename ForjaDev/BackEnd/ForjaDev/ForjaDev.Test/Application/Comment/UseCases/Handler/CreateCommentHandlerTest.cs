using ForjaDev.Application.Comment.UseCases.Command.Handler;
using ForjaDev.Application.Comment.UseCases.Command.Request;
using ForjaDev.Domain.BackOffice.Repositories;
using ForjaDev.Test.Mock;

namespace ForjaDev.Test.Application.Comment.UseCases.Handler;

public class CreateCommentHandlerTest
{
    private static IUnitOfWork _unitOfWork = new FakeUnitOfWork();
    private readonly CreateCommentHandler _handler = new(_unitOfWork);

    [Fact]
    public async Task Should_Return_False_If_Comment_Is_Invalid()
    {
        var request = new CreateCommentRequest(Guid.Empty,Guid.Empty,"");
        var result = await _handler.Handle(request, default);
        Assert.False(result.IsSuccess);
    }
    [Fact]
    public async Task Should_Return_False_If_Member_Is_Null()
    {
        var request = new CreateCommentRequest(Guid.NewGuid(),Guid.NewGuid(),"teste");
        var result = await _handler.Handle(request, default);
        Assert.False(result.IsSuccess);
    }
    [Fact]
    public async Task Should_Return_False_If_Post_Is_Null()
    {
        var request = new CreateCommentRequest(Guid.NewGuid(),Guid.NewGuid(),"teste");
        var result = await _handler.Handle(request, default);
        Assert.False(result.IsSuccess);
    }
    
    [Fact]
    public async Task Should_Return_True_If_Create_Comment()
    {
        var member = await _unitOfWork.MemberRepository.GetByEmail("joao@forjadev.com");
        var post = await _unitOfWork.PostRepository.GetByPredicateAsync(x => x.Tag == "clean");
        var request = new CreateCommentRequest(member!.Id,post!.Id,"teste");
        var result = await _handler.Handle(request, CancellationToken.None);
        Assert.True(result.IsSuccess);
    }
}