using ForjaDev.Domain.BackOffice.Abstract;
using MediatR;

namespace ForjaDev.Application.Comment.Command.Request;

public record RemoveCommentRequest(Guid CommentId,Guid MemberId) : IRequest<Result>;