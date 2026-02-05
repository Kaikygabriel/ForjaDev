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
}