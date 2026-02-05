using ForjaDev.Application.Post.UseCases.Command.Request;
using ForjaDev.Domain.BackOffice.Commum.Abstract;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Likes;
using ForjaDev.Domain.BackOffice.ValuesObject;
using MediatR;

namespace ForjaDev.Application.Post.UseCases.Command.Handler;

internal sealed class AddedLikeHandler : IRequestHandler<AddedLikeRequest,Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILikeRepository _likeRepository;
    
    public AddedLikeHandler(IUnitOfWork unitOfWork, ILikeRepository likeRepository)
    {
        _unitOfWork = unitOfWork;
        _likeRepository = likeRepository;
    }

    public async Task<Result> Handle(AddedLikeRequest request, CancellationToken cancellationToken)
    {
        var post = await _unitOfWork.PostRepository.GetByIdWithLike( request.PostId);
        if(post is null || post.MemberId == request.MemberId)
            return new Error("post.NotFound","not found !") ;
        
        var member = await _unitOfWork.MemberRepository.GetByPredicateAsync(x => x.Id == request.MemberId);
        if(member is null)
            return new Error("Member.NotFound","not found !") ;

        var resultCreatedLike = Like.Factory.Create(member, post);
        if (!resultCreatedLike.IsSuccess)
            return resultCreatedLike.Error;

        var like = resultCreatedLike.Value;
        
        var result= post.AddLike(like);
        if (!result.IsSuccess)
            return result.Error;
        
        _unitOfWork.PostRepository.Update(post);
        _likeRepository.Create(like);
        
        await _unitOfWork.CommitAsync();
       

        return Result.Success();
    }
}