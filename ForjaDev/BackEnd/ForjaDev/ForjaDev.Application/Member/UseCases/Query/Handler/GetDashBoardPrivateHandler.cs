using ForjaDev.Application.Dtos.StoreFront.Member;
using ForjaDev.Application.Member.UseCases.Query.Request;
using ForjaDev.Application.Query.Interfaces;
using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Commum.Abstract;
using MediatR;

namespace ForjaDev.Application.Member.UseCases.Query.Handler;

internal sealed class GetDashBoardPrivateHandler :
    IRequestHandler<GetDashBoardPrivateRequest,Result<MemberDashBoardPrivate>>
{
    private readonly IMemberQuery _memberQuery;

    public GetDashBoardPrivateHandler(IMemberQuery memberQuery)
    {
        _memberQuery = memberQuery;
    }

    public async Task<Result<MemberDashBoardPrivate>> Handle
        (GetDashBoardPrivateRequest request, CancellationToken cancellationToken)
    {
        var dashBoard = await _memberQuery.GetDashBoardPrivateById(request.MemberId);
        if (dashBoard is null)
            return new Error("Member.NotFound", "Not Found !");
        return Result<MemberDashBoardPrivate>.Success(dashBoard);
    }
}