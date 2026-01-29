using MediatR;
using ForjaDev.Domain.BackOffice.Commum.Abstract;

namespace ForjaDev.Application.Comment.Command.Request;

public record RemoveCommentRequest(Guid CommentId,Guid MemberId) : IRequest<Result>;