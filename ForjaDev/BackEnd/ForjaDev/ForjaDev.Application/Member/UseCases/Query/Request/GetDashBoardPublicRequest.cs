using ForjaDev.Application.Dtos.StoreFront.Member;
using ForjaDev.Domain.BackOffice.Commum;
using MediatR;

namespace ForjaDev.Application.Member.UseCases.Query.Request;

public record GetDashBoardPublicRequest(string SlugMember) : IRequest<Result<MemberDashBoardPublic>>;