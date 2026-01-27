using ForjaDev.Application.Member.UseCases.Command.Response;
using ForjaDev.Domain.BackOffice.Commum;
using MediatR;

namespace ForjaDev.Application.Member.UseCases.Command.Request;

public record LoginMemberRequest(string Email,string Password) : IRequest<Result<AuthMemberResponse>>;