using ForjaDev.Application.Member.UseCases.Command.Handler;
using ForjaDev.Application.Member.UseCases.Command.Request;
using ForjaDev.Test.Mock;

namespace ForjaDev.Test.Application.Member.UseCases.Command;

public class LoginMemberHandlerTest
{
    private const string Email_Invalid = "teste@gmail.com";
    private const string Email_Valid = "joao@forjadev.com";
    
    private const string Password_Invalid = "Teste";
    private const string Password_Valid = "123456";
    
    private readonly LoginMemberHandler _handler = new(new FakeServiceUser(),new FakeUnitOfWork(),new FakeTokenService());

    [Fact]
    public async Task Should_Return_False_If_Member_Not_Found()
    {
        var request = new LoginMemberRequest(Email_Invalid,Password_Invalid);
        var resultOfLogin = await _handler.Handle(request,CancellationToken.None);
        Assert.False(resultOfLogin.IsSuccess);
    }
    
    [Fact]
    public async Task Should_Return_False_If_Member_Password_is_Invalid()
    {
        var request = new LoginMemberRequest(Email_Valid,Password_Invalid);
        var resultOfLogin = await _handler.Handle(request,CancellationToken.None);
        Assert.False(resultOfLogin.IsSuccess);
    }
    
    [Fact]
    public async Task Should_Return_False_If_Member_Email_is_Invalid()
    {
        var request = new LoginMemberRequest(Email_Invalid,Password_Valid);
        var resultOfLogin = await _handler.Handle(request,CancellationToken.None);
        Assert.False(resultOfLogin.IsSuccess);
    }
    
    [Fact]
    public async Task Should_Return_True_If_Member_Email_And_Password_is_Valid()
    {
        var request = new LoginMemberRequest(Email_Valid,Password_Valid);
        var resultOfLogin = await _handler.Handle(request,CancellationToken.None);
        Assert.True(resultOfLogin.IsSuccess);
    }
}