using ForjaDev.Domain.BackOffice.Commum.Abstract;
using MediatR;

namespace ForjaDev.Application.Post.UseCases.Command.Request;

public record RemovePostRequest(Guid PostId,Guid MemberId) : IRequest<Result>;