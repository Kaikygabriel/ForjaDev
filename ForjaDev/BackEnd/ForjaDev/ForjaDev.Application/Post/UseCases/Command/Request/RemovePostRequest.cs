using ForjaDev.Domain.BackOffice.Abstract;
using MediatR;

namespace ForjaDev.Application.Post.UseCases.Command.Request;

public record RemovePostRequest(Guid PostId,Guid MemberId) : IRequest<Result>;