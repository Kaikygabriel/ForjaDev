using ForjaDev.Application.Following.UseCases.Command.Request;
using ForjaDev.Domain.BackOffice.Abstract;
using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories;
using ForjaDev.Domain.BackOffice.Repositories;
using MediatR;

namespace ForjaDev.Application.Following.UseCases.Command.Handler;

internal sealed class RemoveFollowingHandler:IRequestHandler<RemoveFollowingRequest,Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveFollowingHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result> Handle(RemoveFollowingRequest request, CancellationToken cancellationToken)
    {
        var follow = await _unitOfWork.FollowingRepository.GetByPredicateAsync(x =>
            x.MemberToFollowId == request.MemberToFollowId &&
            x.FollowingMemberId == request.MemberFollowingId);
        if (follow is null)
            return new Error("Follow.NotFound", "Not Found !");
        
        _unitOfWork.FollowingRepository.Delete(follow);
        await _unitOfWork.CommitAsync();

        return Result.Success();
    }
}