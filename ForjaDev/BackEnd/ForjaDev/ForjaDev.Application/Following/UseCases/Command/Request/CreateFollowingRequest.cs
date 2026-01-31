using ForjaDev.Domain.BackOffice.Commum.Abstract;
using MediatR;

namespace ForjaDev.Application.Following.UseCases.Command.Request;

public record CreateFollowingRequest(Guid MemberToFollow,string EmailMemberFollowing) : IRequest<Result>;