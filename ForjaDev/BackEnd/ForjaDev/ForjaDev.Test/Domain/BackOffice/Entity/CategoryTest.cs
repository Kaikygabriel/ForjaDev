using ForjaDev.Domain.BackOffice.Entities;

namespace ForjaDev.Test.Domain.BackOffice.Entity;

public class CategoryTest
{
    [Fact]
    public void Should_Return_True_If_Creation_Of_Category_Is_Success()
    {
        var resultCreateCategory = Category.Factory.Create("Test");
        Assert.True(resultCreateCategory.IsSuccess);
    }
    
    [Fact]
    public void Should_Return_False_If_Creation_Of_Category_Is_Failure()
    {
        var resultCreateCategory = Category.Factory.Create(String.Empty);
        Assert.False(resultCreateCategory.IsSuccess);
    }
}