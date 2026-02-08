using ForjaDev.Domain.BackOffice.ValuesObject;

namespace ForjaDev.Test.Domain.BackOffice.ValuesObject;

public class LinkTest
{
    [Fact]
    public void Should_Return_True_If_Parameters_Of_Creation_Are_Valid()
    {
        var placeOfOrigin = "testet";
        var address = "teste.com";

        var resultCreateLink = Link.Factory.Create(placeOfOrigin, address);
        
        Assert.True(resultCreateLink.IsSuccess);
    }
    
    [Fact]
    public void Should_Return_False_If_Parameters_Of_Creation_Are_Invalid()
    {
        var placeOfOrigin = "te";
        var address = "te";

        var resultCreateLink = Link.Factory.Create(placeOfOrigin, address);
        
        Assert.False(resultCreateLink.IsSuccess);
    }
}