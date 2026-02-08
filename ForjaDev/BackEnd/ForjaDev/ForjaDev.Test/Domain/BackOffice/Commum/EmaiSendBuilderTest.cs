using ForjaDev.Domain.BackOffice.Commum;

namespace ForjaDev.Test.Domain.BackOffice.Commum;

public class EmaiSendBuilderTest
{
    [Fact]
    public void Should_Return_Name_When_Added()
    {
        var name = "teste";
        var emailBuilder = EmailSendBuilder.Configure().WithName(name);
        Assert.Equal(name,emailBuilder.Name);
    }
    
    [Fact]
    public void Should_Return_Address_When_Added()
    {
        var address = "teste";
        var emailBuilder = EmailSendBuilder.Configure().To(address);
        Assert.Equal(address,emailBuilder.ToAddress);
    }
    
    [Fact]
    public void Should_Return_Title_When_Added()
    {
        var title = "teste";
        var emailBuilder = EmailSendBuilder.Configure().WithTitle(title);
        Assert.Equal(title,emailBuilder.Title);
    }
    
    [Fact]
    public void Should_Return_Body_When_Added()
    {
        var body = "teste";
        var emailBuilder = EmailSendBuilder.Configure().WithBody(body);
        Assert.Equal(body,emailBuilder.Body);
    }
}