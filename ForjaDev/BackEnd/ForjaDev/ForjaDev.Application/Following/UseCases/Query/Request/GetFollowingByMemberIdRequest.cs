using ForjaDev.Domain.BackOffice.Commum;
using MediatR;

namespace ForjaDev.Application.Following.UseCases.Query.Request;

public record GetFollowingByMemberIdRequest(Guid MemberId) :
    IRequest<Result<IEnumerable<Domain.BackOffice.Entities.Member>>>;