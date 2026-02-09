using MediatR;
using ForjaDev.Application.Post.UseCases.Command.Request;
using ForjaDev.Domain.BackOffice.Abstract;
using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Likes;
using ForjaDev.Domain.BackOffice.Repositories;
using ForjaDev.Domain.BackOffice.ValuesObject;

namespace ForjaDev.Application.Post.UseCases.Command.Handler;

internal sealed class RemoveLikeHandler : IRequestHandler<RemoveLikeRequest,Result>
{
    private readonly ILikeRepository _likeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveLikeHandler(IUnitOfWork unitOfWork, ILikeRepository likeRepository)
    {
        _unitOfWork = unitOfWork;
        _likeRepository = likeRepository;
    }

    public async Task<Result> Handle(RemoveLikeRequest request, CancellationToken cancellationToken)
    {
        var post = await _unitOfWork.PostRepository.GetByIdWithLike( request.PostId);
        if (post is null)
            return Error.PostNotFound();
        var resultRemoveLikeInPost = post.RemoveLike(request.MemberId);
        if (!resultRemoveLikeInPost.IsSuccess)
            return resultRemoveLikeInPost.Error;
        
        _likeRepository.Delete(resultRemoveLikeInPost.Value);
        _unitOfWork.PostRepository.Update(post);
        await _unitOfWork.CommitAsync();
        
        return Result.Success();
    }
}