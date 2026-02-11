using ForjaDev.Domain.BackOffice.Abstract;
using ForjaDev.Domain.BackOffice.Commum;

namespace ForjaDev.Domain.BackOffice.ValuesObject;

public class Password
{
    private Password()
    {
        
    }
    private Password(string passwordHash)
    {
        PasswordHash = CreateHashPassword(passwordHash);
    }

    public string PasswordHash { get;private set; }

    private string CreateHashPassword(string password)
        => BCrypt.Net.BCrypt.HashPassword(password);


    public Result UpdatePassword(string password)
    {
        if (PasswordIsInvalid(password))
            return new Error("Password.Invalid", "password is invalid !");
        PasswordHash = CreateHashPassword(password);
        return Result.Success();
    }
    public static class Factory
    {
        public static Result<Password> Create(string password)
        {
            if (PasswordIsInvalid(password))
                return new Error("Password.Invalid", "password is invalid !");
            
            return Result<Password>.Success(new Password(password));
        } 
    }

    private static bool PasswordIsInvalid(string password)
        => string.IsNullOrWhiteSpace(password) || password.Length <= 3;
}