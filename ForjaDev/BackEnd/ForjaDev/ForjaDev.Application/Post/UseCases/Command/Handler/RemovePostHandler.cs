using ForjaDev.Application.Post.UseCases.Command.Request;
using ForjaDev.Domain.BackOffice.Commum.Abstract;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories;
using MediatR;

namespace ForjaDev.Application.Post.UseCases.Command.Handler;

internal sealed class RemovePostHandler :  IRequestHandler<RemovePostRequest,Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemovePostHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(RemovePostRequest request, CancellationToken cancellationToken)
    {
        var post = await _unitOfWork.PostRepository.GetByIdWithMemberAsync(request.MemberId);
        if (post is null || post.MemberId != request.MemberId)
            return new Error("Post.NotFound", "not found");
        
        _unitOfWork.PostRepository.Delete(post);
        await _unitOfWork.CommitAsync();

        return Result.Success();
    }
}