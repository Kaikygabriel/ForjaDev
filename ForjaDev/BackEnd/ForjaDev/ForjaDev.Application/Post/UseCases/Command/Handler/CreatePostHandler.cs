using ForjaDev.Application.Post.UseCases.Command.Request;
using ForjaDev.Domain.BackOffice.Abstract;
using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories;
using ForjaDev.Domain.BackOffice.Repositories;
using MediatR;

namespace ForjaDev.Application.Post.UseCases.Command.Handler;

internal  sealed class CreatePostHandler : IRequestHandler<CreatePostRequest,Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePostHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreatePostRequest request, CancellationToken cancellationToken)
    {
        var resultCreatePost = request.ToEntity();
        if (!resultCreatePost.IsSuccess)
            return resultCreatePost.Error;
        var post = resultCreatePost.Value;
        var member = await _unitOfWork.MemberRepository.GetByPredicateAsync(x => x.Id == request.MemberId);

        if (member is null)
            return Error.MemberNotFound();
        
        member.AddPost(post);
        _unitOfWork.MemberRepository.Update(member);
        await _unitOfWork.CommitAsync();
        
        return Result.Success();
    }
}