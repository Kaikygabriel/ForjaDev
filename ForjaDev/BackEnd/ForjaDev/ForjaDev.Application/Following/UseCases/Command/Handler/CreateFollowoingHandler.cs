using ForjaDev.Application.Following.UseCases.Command.Request;
using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Commum.Abstract;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories;
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
        if (memberToFollow is null)
            return new Error("MemberToFollow.NotFound", "Not Found ! ");
        
        var memberFollowing = await _unitOfWork.MemberRepository.GetByEmail(request.EmailMemberFollowing);
        if (memberFollowing is null)
            return new Error("memberFollowing.NotFound", "Not Found ! ");

        var following = CreateFollowing(memberToFollow, memberFollowing).Value;

        memberFollowing.AddFollowing(following);
        _unitOfWork.MemberRepository.Update(memberToFollow);
        _unitOfWork.FollowingRepository.Create(following);
        
        await _unitOfWork.CommitAsync();
        
        return Result.Success();
    }

    private Result<Domain.BackOffice.Entities.Following> CreateFollowing
        (Domain.BackOffice.Entities.Member memberToFollow, Domain.BackOffice.Entities.Member memberFollowing)
             => Domain.BackOffice.Entities.Following.Factory.Create(memberToFollow, memberFollowing);
}