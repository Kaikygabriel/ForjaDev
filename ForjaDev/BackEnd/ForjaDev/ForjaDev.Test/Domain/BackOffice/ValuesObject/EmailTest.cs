using ForjaDev.Domain.BackOffice.ValuesObject;

namespace ForjaDev.Test.Domain.BackOffice.ValuesObject;

public class EmailTest
{
    [Fact]
    public void Should_Return_True_If_Address_In_Email_Is_Valid()
    {
        var emailValid = "teste@gmail.com";
        var resultCreateEmail = Email.Factory.Create(emailValid);
        Assert.True(resultCreateEmail.IsSuccess);
    }
    
    [Fact]
    public void Should_Return_False_If_Email_No_Constains_Arroba()
    {
        var emailInvalid = "testegmail.com";
        var resultCreateEmail = Email.Factory.Create(emailInvalid);
        Assert.False(resultCreateEmail.IsSuccess);
    }
    
    [Fact]
    public void Should_Return_False_If_Email_Is_Small_That_Four()
    {
        var emailInvalid = "tes";
        var resultCreateEmail = Email.Factory.Create(emailInvalid);
        Assert.False(resultCreateEmail.IsSuccess);
    }
    [Fact]
    public void Should_Return_False_If_Email_Is_Null_Or_Empty()
    {
        var emailInvalid = string.Empty;
        var resultCreateEmail = Email.Factory.Create(emailInvalid);
        Assert.False(resultCreateEmail.IsSuccess);
    }
}