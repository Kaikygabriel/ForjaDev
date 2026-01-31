using ForjaDev.Application.Dtos.StoreFront.Member;
using ForjaDev.Application.Member.UseCases.Query.Request;
using ForjaDev.Application.Query.Interfaces;
using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Commum.Abstract;
using MediatR;

namespace ForjaDev.Application.Member.UseCases.Query.Handler;

internal sealed class GetDashBoardPublicHandler: IRequestHandler<GetDashBoardPublicRequest,Result<MemberDashBoardPublic>>
{
    private readonly IMemberQuery _memberQuery;

    public GetDashBoardPublicHandler(IMemberQuery memberQuery)
    {
        _memberQuery = memberQuery;
    }

    public async Task<Result<MemberDashBoardPublic>> Handle(GetDashBoardPublicRequest request, CancellationToken cancellationToken)
    {
        var memberDashBoardPublic =await _memberQuery.GetDashBoardPublicBySlug(request.SlugMember);
        if (memberDashBoardPublic is null)
            return new Error("member.notfound","not found");
        return Result<MemberDashBoardPublic>.Success(memberDashBoardPublic);
    }
}