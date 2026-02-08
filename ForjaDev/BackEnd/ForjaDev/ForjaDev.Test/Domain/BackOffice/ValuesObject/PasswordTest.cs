using ForjaDev.Domain.BackOffice.ValuesObject;

namespace ForjaDev.Test.Domain.BackOffice.ValuesObject;

public class PasswordTest
{
    [Fact]
    public void Should_Return_True_If_Parameters_In_Constructor_IsValid()
    {
        var passwordValid = "fdklajfldjalçsdf";

        var resultCreatePassword = Password.Factory.Create(passwordValid);

        Assert.True(resultCreatePassword.IsSuccess);
    }
    [Fact]
    public void Should_Return_False_If_Password_Is_Small_That_Four()
    {
        var passwordInvalid = "sa3";

        var resultCreatePassword = Password.Factory.Create(passwordInvalid);

        Assert.False(resultCreatePassword.IsSuccess);
    }
    
    [Fact]
    public void Should_Return_False_If_Password_Is_Null_Or_Empty()
    {
        var passwordInvalid = string.Empty;

        var resultCreatePassword = Password.Factory.Create(passwordInvalid);

        Assert.False(resultCreatePassword.IsSuccess);
    }
}