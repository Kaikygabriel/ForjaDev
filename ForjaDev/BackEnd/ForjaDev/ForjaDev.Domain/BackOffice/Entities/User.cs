using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Entities.Abstraction;
using ForjaDev.Domain.BackOffice.ValuesObject;

namespace ForjaDev.Domain.BackOffice.Entities;

public class User : Entity
{
    private User()
    {
        
    }
    private User(Password password, Email email)
    {
        Password = password;
        Email = email;
    }

    public Password Password { get;private set; }
    public Email Email{ get; init; }

    public static class Factory
    {
        public static Result<User> Create(Email email, Password password)
            => Result<User>.Success(new(password,email));
    }
}