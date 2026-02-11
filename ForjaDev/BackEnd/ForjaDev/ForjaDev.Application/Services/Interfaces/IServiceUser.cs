using ForjaDev.Domain.BackOffice.Abstract;
using ForjaDev.Domain.BackOffice.Entities;

namespace ForjaDev.Application.Services.Interfaces;

public interface IServiceUser
{
    Result CheckPassword(string password, User user);
    Task<Result> EmailExists(string email);
}