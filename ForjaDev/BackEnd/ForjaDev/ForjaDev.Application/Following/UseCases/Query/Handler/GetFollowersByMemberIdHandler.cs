using ForjaDev.Application.Following.UseCases.Query.Request;
using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories;
using MediatR;

namespace ForjaDev.Application.Following.UseCases.Query.Handler;

internal sealed class GetFollowersByMemberIdHandler : IRequestHandler<GetFollowersByMemberIdRequest,Result<IEnumerable<Domain.BackOffice.Entities.Member>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetFollowersByMemberIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<IEnumerable<Domain.BackOffice.Entities.Member>>> Handle(GetFollowersByMemberIdRequest request, CancellationToken cancellationToken)
    {
        var membersFollowers = await _unitOfWork.FollowingRepository
            .GetFollowersByMemberId(request.MemberId);
        return Result<IEnumerable<Domain.BackOffice.Entities.Member>>.Success(membersFollowers);
    }
}