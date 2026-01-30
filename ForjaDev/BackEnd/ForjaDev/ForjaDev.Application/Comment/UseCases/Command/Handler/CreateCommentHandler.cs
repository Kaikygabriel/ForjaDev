using ForjaDev.Application.Comment.UseCases.Command.Request;
using ForjaDev.Domain.BackOffice.Commum.Abstract;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories;
using MediatR;

namespace ForjaDev.Application.Comment.UseCases.Command.Handler;

internal sealed class CreateCommentHandler : IRequestHandler<CreateCommentRequest,Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCommentHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateCommentRequest request, CancellationToken cancellationToken)
    {
        var resultCreateComment = request.ToEntity();
        if (!resultCreateComment.IsSuccess)
            return resultCreateComment.Error;
        var comment = resultCreateComment.Value;
        var member = await _unitOfWork.MemberRepository.GetByPredicateAsync(x => x.Id == request.MemberId);
        if (member is null)
            return new Error("Member.NotFound", "Not Found !");
        var post = await _unitOfWork.PostRepository.GetByPredicateAsync(x => x.Id == request.PostId);
        if (post is null)
            return new Error("post.NotFound", "Not Found !");
        
        post.AddComment(comment);
        member.AddComment(comment);
        _unitOfWork.CommentRepository.Create(comment);
        await _unitOfWork.CommitAsync();

        return Result.Success();
    }
}