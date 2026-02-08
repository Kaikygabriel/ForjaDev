using ForjaDev.Application.Member.UseCases.Command.Handler;
using ForjaDev.Application.Member.UseCases.Command.Request;
using ForjaDev.Test.Mock;

namespace ForjaDev.Test.Application.Member.UseCases.Command;

public class RegisterMemberHandlerTest
{
    private readonly RegisterMemberHandler _handler = new(new FakeUnitOfWork(), new FakeServiceUser(),
        new FakeTokenService());

    [Fact]
    public async Task Should_Return_True_If_Get_Register_Member()
    {
        var request = new RegisterMemberRequest("test@gmail.com", "testestre", "teste", "teste", "teste");
        var result = await _handler.Handle(request,CancellationToken.None);
        Assert.True(result.IsSuccess);
    }
    [Fact]
    public async Task Should_Return_False_If_Parameters_Invalids()
    {
        var request = new RegisterMemberRequest("test", "t", string.Empty,string.Empty,string.Empty);
        var result = await _handler.Handle(request,CancellationToken.None);
        Assert.False(result.IsSuccess);
    }
    [Fact]
    public async Task Should_Return_False_If_Member_Already_Exists()
    {
        var request = new RegisterMemberRequest("test@gmail.com", "testestre", "teste", "teste", "teste");
        var request2 = new RegisterMemberRequest("test@gmail.com", "testestre", "teste", "teste", "teste");

        await _handler.Handle(request,CancellationToken.None);
        
        var result =await _handler.Handle(request,CancellationToken.None);
        Assert.True(result.IsSuccess);
    }
}