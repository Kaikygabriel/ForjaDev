using ForjaDev.Domain.BackOffice.Abstract;
using MediatR;

namespace ForjaDev.Application.Post.UseCases.Command.Request;

public record AddedLikeRequest(Guid MemberId,Guid PostId) : IRequest<Result>;