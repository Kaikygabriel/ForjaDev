using ForjaDev.Application.Post.UseCases.Command.Handler;
using ForjaDev.Application.Post.UseCases.Command.Request;
using ForjaDev.Domain.BackOffice.Entities;
using ForjaDev.Domain.BackOffice.Repositories;
using ForjaDev.Domain.BackOffice.ValuesObject;
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
        var user1 = User.Factory.Create(
            Email.Factory.Create("teste@forjadev.com").Value,
            Password.Factory.Create("testestes").Value
        ).Value;
        var member3 = ForjaDev.Domain.BackOffice.Entities.Member.Factory.Create(
            user1,
            "teste",
            "teste",
            "test do sistema"
        ).Value;
        _ofWork.MemberRepository.Create(member3);
        var request = new CreatePostRequest(member3.Id, string.Empty,string.Empty,string.Empty);

        var result = await _handler.Handle(request,CancellationToken.None);
        
        Assert.True(result.IsSuccess);
    }
}