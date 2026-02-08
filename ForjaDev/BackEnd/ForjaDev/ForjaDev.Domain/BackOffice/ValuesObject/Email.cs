using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Commum.Abstract;

namespace ForjaDev.Domain.BackOffice.ValuesObject;

public class Email
{
    private Email()
    {
        
    }
    private Email(string address)
    {
        Address = address;
    }

    public string Address { get;private set; }

    public static class Factory
    {
        public static Result<Email> Create(string address)
        {
            if (EmailIsInvalid(address))
                return new Error("Email.Invalid", "Email is invalid");
            return Result<Email>.Success(new(address));
        } 
    }

    private static bool EmailIsInvalid(string email)
        => string.IsNullOrWhiteSpace(email) || email.Length <= 3 || !email.Contains('@');
}