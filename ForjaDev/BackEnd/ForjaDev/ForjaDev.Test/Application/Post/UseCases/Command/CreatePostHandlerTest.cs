using ForjaDev.Application.Post.UseCases.Command.Handler;
using ForjaDev.Application.Post.UseCases.Command.Request;
using ForjaDev.Domain.BackOffice.Repositories;
using ForjaDev.Test.Mock;

namespace ForjaDev.Test.Application.Post.UseCases.Command;

public class CreatePostHandlerTest
{
    private static IUnitOfWork _ofWork = new FakeUnitOfWork();
    private readonly CreatePostHandler _handler = new(_ofWork);

    [Fact]
    public async Task Should_Return_False_If_Member_Is_Not_Found()
    {
        var memberId = Guid.NewGuid();
        var request = new CreatePostRequest(memberId, "teste", "teste", "teset");

        var result = await _handler.Handle(request,CancellationToken.None);
        
        Assert.False(result.IsSuccess);
    }
    
    [Fact]
    public async Task Should_Return_False_If_Post_Is_Invalid()
    {
        var memberId = Guid.NewGuid();
        var request = new CreatePostRequest(memberId, string.Empty,string.Empty,string.Empty);

        var result = await _handler.Handle(request,CancellationToken.None);
        
        Assert.False(result.IsSuccess);
    }
    
    [Fact]
    public async Task Should_Return_true_If_Created_Post()
    {
        var member = await _ofWork.MemberRepository.GetByEmail("joao@forjadev.com");
        var request = new CreatePostRequest(member.Id, "teste","teste2","Teste3");

        var result = await _handler.Handle(request,CancellationToken.None);
        
        Assert.True(result.IsSuccess);
    }
}