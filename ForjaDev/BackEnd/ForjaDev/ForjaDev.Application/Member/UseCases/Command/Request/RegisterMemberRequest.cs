using ForjaDev.Application.Member.UseCases.Command.Response;
using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Entities;
using MediatR;

namespace ForjaDev.Application.Member.UseCases.Command.Request;

public record RegisterMemberRequest(string Email, string Password, string Name) : IRequest<Result<AuthMemberResponse>>
{
    public Result<Domain.BackOffice.Entities.Member> ToEntity()
    {
        var email = Domain.BackOffice.ValuesObject.Email.Factory.Create(Email);
        if (email.IsSuccess)
            return email.Error;
        var password = Domain.BackOffice.ValuesObject.Password.Factory.Create(Password);
        if (password.IsSuccess)
            return password.Error;
        
        var user = User.Factory.Create(email.Value, password.Value).Value;

        return Domain.BackOffice.Entities.Member.Factory.Create(user,Name);
    }
};