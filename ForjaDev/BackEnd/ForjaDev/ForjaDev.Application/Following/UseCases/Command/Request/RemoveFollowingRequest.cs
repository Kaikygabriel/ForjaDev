using ForjaDev.Domain.BackOffice.Abstract;
using MediatR;

namespace ForjaDev.Application.Following.UseCases.Command.Request;

public record RemoveFollowingRequest(Guid MemberToFollowId,Guid MemberFollowingId)  : IRequest<Result>;