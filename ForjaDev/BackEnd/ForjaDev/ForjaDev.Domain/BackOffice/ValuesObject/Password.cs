using ForjaDev.Domain.BackOffice.Commum;

namespace ForjaDev.Domain.BackOffice.ValuesObject;

public class Password
{
    private Password()
    {
        
    }
    protected Password(string passwordHash)
    {
        PasswordHash = CreateHashPassword(passwordHash);
    }

    public string PasswordHash { get;private set; }

    private static string CreateHashPassword(string password)
        => BCrypt.Net.BCrypt.HashPassword(password);
    
    public static class Factory
    {
        public static Result<Password> Create(string password)
        { 
            return Result<Password>.Success(new Password(password));
        } 
    }
}