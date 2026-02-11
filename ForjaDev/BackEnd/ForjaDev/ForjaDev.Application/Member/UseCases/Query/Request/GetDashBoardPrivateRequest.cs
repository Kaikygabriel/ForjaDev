using ForjaDev.Application.Dtos.StoreFront.Member;
using ForjaDev.Domain.BackOffice.Commum;
using MediatR;

namespace ForjaDev.Application.Member.UseCases.Query.Request;

public record GetDashBoardPrivateRequest(Guid MemberId) : IRequest<Result<MemberDashBoardPrivate>>;