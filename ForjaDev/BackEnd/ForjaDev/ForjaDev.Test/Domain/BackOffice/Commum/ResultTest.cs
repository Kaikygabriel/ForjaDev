using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Commum.Abstract;
using ForjaDev.Domain.BackOffice.Entities;

namespace ForjaDev.Test.Domain.BackOffice.Commum;

public class ResultTest
{
    [Fact]
    public void Should_Return_True_When_Method_Success_Active()
    {
        var result = Result.Success();
        Assert.True(result.IsSuccess);
    }
    
    [Fact]
    public void Should_Return_False_When_Method_Failure_Active()
    {
        var result = Result.Failure(new("teste","teste"));
        Assert.False(result.IsSuccess);
    }
    
    
    [Fact]
    public void Should_Return_Object_When_Method_Success_Of_Object_Active()
    {
        var category = Category.Factory.Create("teste").Value;
        var result = Result<Category>.Success(category);
        Assert.Equal(category,result.Value);
    }
    
    [Fact]
    public void Should_Return_Error_When_Method_Failure_Active()
    {
        var error = new Error("teste","teste");
        var result = Result.Failure(error);
        Assert.Equal(error,result.Error);
    }

}