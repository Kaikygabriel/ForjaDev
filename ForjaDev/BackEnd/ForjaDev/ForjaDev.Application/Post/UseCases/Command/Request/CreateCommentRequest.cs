using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Commum.Abstract;
using ForjaDev.Domain.BackOffice.Entities;
using MediatR;

namespace ForjaDev.Application.Post.UseCases.Command.Request;

public record CreateCommentRequest(Guid MemberId, Guid PostId, string Message)
    : IRequest<Result>
{
    public Result<Comment> ToEntity()
        => Comment.Factory.Create(MemberId, PostId, Message);
}