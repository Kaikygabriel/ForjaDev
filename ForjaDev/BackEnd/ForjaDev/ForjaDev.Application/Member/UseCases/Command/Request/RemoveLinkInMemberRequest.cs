using ForjaDev.Domain.BackOffice.Abstract;
using MediatR;

namespace ForjaDev.Application.Member.UseCases.Command.Request;

public record RemoveLinkInMemberRequest(Guid MemberId,string PlaceLink) : IRequest<Result>;