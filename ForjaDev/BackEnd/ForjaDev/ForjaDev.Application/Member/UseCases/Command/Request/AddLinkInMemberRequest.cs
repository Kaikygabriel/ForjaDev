using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Commum.Abstract;
using ForjaDev.Domain.BackOffice.ValuesObject;
using MediatR;

namespace ForjaDev.Application.Member.UseCases.Command.Request;

public record AddLinkInMemberRequest(string Place, string Address,Guid MemberId) : IRequest<Result>
{
    public Result<Link> ToEntity()
        => Link.Factory.Create(Place, Address);
};