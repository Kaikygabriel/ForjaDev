using ForjaDev.Domain.BackOffice.Entities;
using ForjaDev.Domain.BackOffice.ValuesObject;

namespace ForjaDev.Test.Domain.BackOffice.Entity;

public class FollowingTest
{
    private static readonly User User_Valid = User.Factory.Create
        (Email.Factory.Create("teste@gmail.com").Value, Password.Factory.Create("teste@").Value).Value;

    private const string Name_Valid = "teste";
    private const string Slug_Valid = "teste";
    private const string Bio_Valid = "teste";
    
    private readonly Member Member_Valid = Member.Factory.Create(User_Valid, Name_Valid, Slug_Valid, Bio_Valid).Value;
    private readonly Member Member_Valid2 = Member.Factory.Create(User_Valid, Name_Valid, Slug_Valid, Bio_Valid).Value;

    [Fact]
    public void Should_Return_true_If_Creation_Parameters_Are_Valid()
    {
        var resultCreateFollowing = Following.Factory.Create(Member_Valid, Member_Valid2);
        Assert.True(resultCreateFollowing.IsSuccess);
    }
    
}