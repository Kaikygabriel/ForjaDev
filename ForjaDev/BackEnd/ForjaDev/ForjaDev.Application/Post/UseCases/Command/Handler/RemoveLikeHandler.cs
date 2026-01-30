using MediatR;
using ForjaDev.Application.Post.UseCases.Command.Request;
using ForjaDev.Domain.BackOffice.Commum.Abstract;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories;

namespace ForjaDev.Application.Post.UseCases.Command.Handler;

internal sealed class RemoveLikeHandler : IRequestHandler<RemoveLikeRequest,Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveLikeHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(RemoveLikeRequest request, CancellationToken cancellationToken)
    {
        var post = await _unitOfWork.PostRepository.GetByPredicateAsync(x => x.Id == request.PostId);
        if (post is null)
            return new Error("Post.NotFound", "Not found");
        var resultRemoveLikeInPost = post.RemoveLike(request.MemberId);
        if (!resultRemoveLikeInPost.IsSuccess)
            return resultRemoveLikeInPost.Error;
        
        
        _unitOfWork.PostRepository.Update(post);
        await _unitOfWork.CommitAsync();
        
        return Result.Success();
    }
}