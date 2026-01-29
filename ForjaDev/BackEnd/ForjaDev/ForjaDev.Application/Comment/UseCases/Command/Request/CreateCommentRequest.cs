using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Commum.Abstract;
using MediatR;

namespace ForjaDev.Application.Comment.UseCases.Command.Request;

public record CreateCommentRequest(Guid MemberId, Guid PostId, string Message)
    : IRequest<Result>
{
    public Result<Domain.BackOffice.Entities.Comment> ToEntity()
        => Domain.BackOffice.Entities.Comment.Factory.Create(MemberId, PostId, Message);
}