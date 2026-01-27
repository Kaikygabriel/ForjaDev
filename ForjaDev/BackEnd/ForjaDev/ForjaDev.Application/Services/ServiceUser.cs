using ForjaDev.Domain.BackOffice.Commum.Abstract;
using ForjaDev.Domain.BackOffice.Entities;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Users;
using ForjaDev.Domain.BackOffice.Interfaces.Services;

namespace ForjaDev.Application.Services;

internal class ServiceUser : IServiceUser
{
    private readonly IUserRepository _userRepository;

    public ServiceUser(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Result CheckPassword(string password, User user)
    {
        if (!BCrypt.Net.BCrypt.Verify(password, user.Password.PasswordHash))
            return new Error("Password.Invalid", "invalid");
        return Result.Success();
    }

    public async Task<Result> EmailExists(string email)
    {
        if (await _userRepository.GetByPredicateAsync(x => x.Email.Address == email) is not null)
            return new Error("Email.Already", "Email exists");
        return Result.Success();
    }
}