using ForjaDev.Application.Services;
using ForjaDev.Domain.BackOffice.Entities;
using ForjaDev.Domain.BackOffice.ValuesObject;
using ForjaDev.Test.Mock;

namespace ForjaDev.Test.Application.Services;

public class ServiceUserTest
{
    private readonly User User_Valid = User.Factory.Create(
        Email.Factory.Create("admin@forjadev.com").Value,
        Password.Factory.Create("123456").Value
    ).Value;
    private readonly ServiceUser _serviceUser = new(new FakeUserRepository());

    [Fact]
    public void Should_Return_False_If_RequestPassword_Is_Not_Equals_UserPassword()
    {
        var passwordRequest = "teste";
        var result = _serviceUser.CheckPassword(passwordRequest, User_Valid);
        Assert.False(result.IsSuccess);
    }
    
    [Fact]
    public void Should_Return_True_If_RequestPassword_Is_Equals_UserPassword()
    {
        var passwordRequest = "123456";
        var result = _serviceUser.CheckPassword(passwordRequest, User_Valid);
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task Should_Return_True_If_Email_No_Exists()
    {
        var emailNoExists = "teste@gmail";
        var result = await _serviceUser.EmailExists(emailNoExists);
        Assert.True(result.IsSuccess);
    }
    
    [Fact]
    public async Task Should_Return_False_If_Email_No_Exists()
    {
        var emailNoExists = "joao@forjadev.com";
        var result = await _serviceUser.EmailExists(emailNoExists);
        Assert.False(result.IsSuccess);
    }
}