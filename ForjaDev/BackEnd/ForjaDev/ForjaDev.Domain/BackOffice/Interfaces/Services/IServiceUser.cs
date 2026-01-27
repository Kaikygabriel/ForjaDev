using ForjaDev.Domain.BackOffice.Commum.Abstract;
using ForjaDev.Domain.BackOffice.Entities;

namespace ForjaDev.Domain.BackOffice.Interfaces.Services;

public interface IServiceUser
{
    Result CheckPassword(string password, User user);
    Task<Result> EmailExists(string email);
}