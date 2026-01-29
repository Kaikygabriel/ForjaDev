using ForjaDev.Application.Comment.Command.Request;
using ForjaDev.Domain.BackOffice.Commum.Abstract;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories;
using MediatR;

namespace ForjaDev.Application.Comment.Command.Handler;

internal sealed class RemoveCommentHandler : IRequestHandler<RemoveCommentRequest,Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveCommentHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(RemoveCommentRequest request, CancellationToken cancellationToken)
    {
        var comment = await _unitOfWork.CommentRepository.GetByPredicateAsync(x => x.Id == request.CommentId);
        if (comment is null || comment.MemberId != request.MemberId)
            return new Error("Comment.NotFound", "Not Found");
        
        _unitOfWork.CommentRepository.Delete(comment);
        await _unitOfWork.CommitAsync();

        return Result.Success();
    }
}