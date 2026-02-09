using ForjaDev.Domain.BackOffice.Abstract;
using MediatR;

namespace ForjaDev.Application.Following.UseCases.Command.Request;

public record CreateFollowingRequest(Guid MemberToFollow,string EmailMemberFollowing) : IRequest<Result>;