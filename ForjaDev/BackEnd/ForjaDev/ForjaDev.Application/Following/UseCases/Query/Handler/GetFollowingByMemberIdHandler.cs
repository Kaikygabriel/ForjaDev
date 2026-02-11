using ForjaDev.Application.Following.UseCases.Query.Request;
using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories;
using ForjaDev.Domain.BackOffice.Repositories;
using MediatR;

namespace ForjaDev.Application.Following.UseCases.Query.Handler;

internal sealed class GetFollowingByMemberIdHandler : 
    IRequestHandler<GetFollowingByMemberIdRequest,Result<IEnumerable<Domain.BackOffice.Entities.Member>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetFollowingByMemberIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<IEnumerable<Domain.BackOffice.Entities.Member>>> Handle(GetFollowingByMemberIdRequest request, CancellationToken cancellationToken)
    {
        var memberFollowing = await _unitOfWork.FollowingRepository
            .GetFollowingByMemberId(request.MemberId);
        // if (memberFollowing is null || !memberFollowing.Any())
        //     return new Error("MembersFollowings.NotFound", "not found followings");
        return Result<IEnumerable<Domain.BackOffice.Entities.Member>>.Success(memberFollowing);
    }
}