using ForjaDev.Application.Following.UseCases.Command.Request;
using ForjaDev.Domain.BackOffice.Abstract;
using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories;
using ForjaDev.Domain.BackOffice.Repositories;
using MediatR;

namespace ForjaDev.Application.Following.UseCases.Command.Handler;

internal sealed class CreateFollowoingHandler : IRequestHandler<CreateFollowingRequest,Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateFollowoingHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateFollowingRequest request, CancellationToken cancellationToken)
    {
        var memberToFollow = await _unitOfWork.MemberRepository.GetByPredicateAsync(x => x.Id == request.MemberToFollow);
        if (memberToFollow is null )
            return new Error("MemberToFollow.NotFound", "Not Found ! ");
        
        var memberFollowing = await _unitOfWork.MemberRepository.GetByEmail(request.EmailMemberFollowing);
        if (memberFollowing is null || memberToFollow.Id == memberFollowing.Id)
            return new Error("memberFollowing.NotFound", "Not Found ! ");

        if (await _unitOfWork.FollowingRepository.GetByPredicateAsync(x =>
                x.MemberToFollowId == memberToFollow.Id &&
                x.FollowingMemberId == memberFollowing.Id) is not null)
            return new Error("Following.Exists", "Following Already exists");
        
        var following = CreateFollowing(memberToFollow, memberFollowing).Value;

        _unitOfWork.FollowingRepository.Create(following);
        
        await _unitOfWork.CommitAsync();
        
        return Result.Success();
    }

    private Result<Domain.BackOffice.Entities.Following> CreateFollowing
        (Domain.BackOffice.Entities.Member memberToFollow, Domain.BackOffice.Entities.Member memberFollowing)
             => Domain.BackOffice.Entities.Following.Factory.Create(memberToFollow, memberFollowing);
}