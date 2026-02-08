using ForjaDev.Domain.BackOffice.Commum.Abstract;
using ForjaDev.Domain.BackOffice.Entities;
using ForjaDev.Domain.BackOffice.Interfaces.Services;

namespace ForjaDev.Test.Mock;

public class FakeServiceUser : IServiceUser
{
    public Result CheckPassword(string password, User user)
    {
        if (BCrypt.Net.BCrypt.Verify(password, user.Password.PasswordHash))
            return Result.Success();
        return Result.Failure(new("teste", "treste"));
    }

    public Task<Result> EmailExists(string email)
    {
        return Task.FromResult(Result.Success());
    }
}