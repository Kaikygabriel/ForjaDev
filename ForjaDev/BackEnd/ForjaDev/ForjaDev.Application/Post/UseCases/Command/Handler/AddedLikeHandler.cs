using ForjaDev.Application.Post.UseCases.Command.Request;
using ForjaDev.Domain.BackOffice.Commum.Abstract;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories;
using ForjaDev.Domain.BackOffice.ValuesObject;
using MediatR;

namespace ForjaDev.Application.Post.UseCases.Command.Handler;

internal sealed class AddedLikeHandler : IRequestHandler<AddedLikeRequest,Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddedLikeHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(AddedLikeRequest request, CancellationToken cancellationToken)
    {
        var member = await _unitOfWork.MemberRepository.GetByPredicateAsync(x => x.Id == request.MemberId);
        if(member is null)
            return new Error("Member.NotFound","not found !") ;
        var post = await _unitOfWork.PostRepository.GetByPredicateAsync(x => x.Id == request.PostId);
        if(post is null || post.MemberId == request.MemberId)
            return new Error("post.NotFound","not found !") ;

        var resultCreatedLike = Like.Factory.Create(member, post);
        if (!resultCreatedLike.IsSuccess)
            return resultCreatedLike.Error;

        var like = resultCreatedLike.Value;
        
        post.AddLike(like);
        _unitOfWork.PostRepository.Update(post);
        await _unitOfWork.CommitAsync();

        return Result.Success();
    }
}