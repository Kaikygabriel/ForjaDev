using ForjaDev.Application.Comment.UseCases.Command.Request;
using ForjaDev.Domain.BackOffice.Abstract;
using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories;
using ForjaDev.Domain.BackOffice.Repositories;
using MediatR;

namespace ForjaDev.Application.Comment.UseCases.Command.Handler;

internal sealed class CreateSubCommentHandler : IRequestHandler<CreateSubCommentRequest,Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSubCommentHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateSubCommentRequest request, CancellationToken cancellationToken)
    {
        var resultCreateSubComment = request.ToEntity();
        if (!resultCreateSubComment.IsSuccess)
            return resultCreateSubComment.Error;
        
        var subComment = resultCreateSubComment.Value; 
        var commentFather = await _unitOfWork.CommentRepository.GetByPredicateAsync(x => x.Id == request.CommentId);
        if (commentFather is null)
            return Error.MemberNotFound();
        
        commentFather.AddComment(subComment);
        subComment.AddComment(commentFather);
        
        _unitOfWork.CommentRepository.Create(subComment);
        await _unitOfWork.CommitAsync();
        
        return Result.Success();
    }
}